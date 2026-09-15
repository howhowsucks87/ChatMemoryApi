using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using ChatMemoryApi.Extensions;
using ChatMemoryApi.Data;
using Microsoft.EntityFrameworkCore;
using ChatMemoryApi.DTOs;

namespace ChatMemoryApi.Controllers
{
    // =============================
    // UsersController
    // 功能：
    // - 提供與「目前登入使用者」相關的 API
    // - 透過 JWT 驗證身份
    // =============================
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _db;

        public UsersController(AppDbContext db)
        {
            _db = db;
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> Me()
        {
            var userId = User.GetUserId();

            // =============================
            // 取得 Email Claim
            // =============================
            var user = await _db.Users
             .AsNoTracking()
                .Where(u => u.Id == userId)
                .Select(u => new UserMeDto
                {
                    Id = u.Id,
                    Email = u.Email,
                    CreatedAt = u.CreatedAt
                })
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound(new ErrorResponse
                {
                    Success = false,
                    Message = "User not found"
                });

            }
            // =============================
            // 回傳目前登入者資訊
            // =============================
            return Ok(new ApiResponse<UserMeDto>
            {
                Success = true,
                Message = "User retrieved",
                Data = user
            });
        }
    }
}