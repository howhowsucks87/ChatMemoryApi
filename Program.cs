// JWT 驗證核心
using Microsoft.AspNetCore.Authentication.JwtBearer;

// EF Core
using Microsoft.EntityFrameworkCore;

// JWT 驗證用的 Token 驗證參數
using Microsoft.IdentityModel.Tokens;

using System.Text;

// 自己的 DbContext
using ChatMemoryApi.Data;

// 自己的 Jwt 設定類別
using ChatMemoryApi.Options;

using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using ChatMemoryApi.Extensions;


// 建立 WebApplication Builder
var builder = WebApplication.CreateBuilder(args);

// 註冊 Controller
// 讓專案可以使用 [ApiController]
builder.Services.AddControllers();


// =======================
// 註冊 DbContext
// =======================

// 使用 PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// =======================
// JWT Authentication 設定
// =======================

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        // 讀取 appsettings.json 的 Jwt 區段
        var jwt = builder.Configuration
            .GetSection("Jwt")
            .Get<JwtOptions>()!;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            // 驗證發行者
            ValidateIssuer = true,

            // 驗證接收者
            ValidateAudience = true,

            // 驗證是否過期
            ValidateLifetime = true,

            // 驗證簽章
            ValidateIssuerSigningKey = true,

            // 必須符合設定的 Issuer
            ValidIssuer = jwt.Issuer,

            // 必須符合設定的 Audience
            ValidAudience = jwt.Audience,

            // 使用對稱金鑰驗證簽章
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwt.Key)
            ),

            // 指定 Name Claim 對應
            // 這樣 User.Identity.Name 會對應 Sub
            NameClaimType = JwtRegisteredClaimNames.Sub,

            // 角色 Claim 對應
            RoleClaimType = ClaimTypes.Role,

            // 關閉預設 5 分鐘誤差
            ClockSkew = TimeSpan.Zero
        };
    });


// =======================
// 驗證 JwtOptions 啟動時檢查
// =======================

builder.Services
    .AddOptions<JwtOptions>()
    .Bind(builder.Configuration.GetSection("Jwt"))

    // Key 不能為空
    .Validate(o => !string.IsNullOrWhiteSpace(o.Key),
        "Jwt Key is required")

    // Key 至少 32 bytes
    .Validate(
        o => Encoding.UTF8.GetByteCount(o.Key) >= 32,
        "Jwt Key must be at least 32 bytes (256 bits)"
    )

    .Validate(
        o => !string.IsNullOrWhiteSpace(o.Issuer),
        "Jwt Issuer is required"
    )

    .Validate(
        o => !string.IsNullOrWhiteSpace(o.Audience),
        "Jwt Audience is required"
    )

    // 過期時間必須 > 0
    .Validate(o => o.ExpireMinutes > 0,
        "ExpireMinutes must be greater than 0")

    // 啟動時就驗證
    .ValidateOnStart();


// =======================
// Swagger + JWT 支援
// =======================

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    // 定義 Bearer 認證方式
    options.AddSecurityDefinition("Bearer",
        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = Microsoft.OpenApi.Models.ParameterLocation.Header,
            Description = "輸入格式：Bearer {你的 JWT Token}"
        });

    // 全域要求使用 Bearer
    options.AddSecurityRequirement(
        new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
        {
            {
                new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Reference =
                        new Microsoft.OpenApi.Models.OpenApiReference
                        {
                            Type =
                                Microsoft.OpenApi.Models.ReferenceType
                                .SecurityScheme,
                            Id = "Bearer"
                        }
                },
                Array.Empty<string>()
            }
        });
});


// 建立 App
var app = builder.Build();


// =======================
// Middleware 區
// =======================

// 開發環境才啟用 Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// 強制 HTTPS
app.UseHttpsRedirection();

/*
JWT 一定要搭配 HTTPS
否則 Token 可被攔截。
*/

// 例外處理統一格式
app.UseGlobalException();


app.UseAuthentication();
app.UseAuthorization();


// 對應 Controller Route
app.MapControllers();


// 啟動應用程式
app.Run();