namespace ChatMemoryApi.Options;

/// <summary>
/// JWT 設定類別
/// 
/// 用來對應 appsettings.json 內的 Jwt 區段設定。
/// 通常會透過 IOptions<JwtOptions> 注入使用。
/// 
/// 這個類別本身不做任何驗證，只是設定容器。
/// </summary>
public class JwtOptions
{
    /// <summary>
    /// JWT 簽章金鑰（Secret Key）
    /// </summary>
    public string Key { get; set; } = null!;

    /// <summary>
    /// JWT 發行者（Issuer）
    /// </summary>
    public string Issuer { get; set; } = null!;

    /// <summary>
    /// JWT 接收者（Audience）
    /// </summary>
    public string Audience { get; set; } = null!;

    /// <summary>
    /// Token 有效期限（分鐘）
    /// </summary>
    public int ExpireMinutes { get; set; }
}