using Microsoft.EntityFrameworkCore;
using ChatMemoryApi.Models;

namespace ChatMemoryApi.Data
{
    // ==========================================================
    // AppDbContext
    // ----------------------------------------------------------
    // 功能：
    // 與資料庫溝通的核心類別
    // 管理所有 Entity（資料表）
    // 負責 LINQ 查詢 → 轉換成 SQL
    // 管理 Migration / Schema
    // ==========================================================
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // ==========================================================
        // DbSet<T>
        // ----------------------------------------------------------
        // 每個 DbSet 代表一張資料表
        //
        // EF Core 會根據 Entity 類別：
        // - 建立資料表
        // - 建立欄位
        // - 建立關聯
        //
        // 命名慣例：
        // 類別 User → 資料表 Users
        // ==========================================================

        // 使用者資料表
        public DbSet<User> Users => Set<User>();

        // 聊天訊息資料表
        public DbSet<ChatMessage> ChatMessages => Set<ChatMessage>();

        // 記憶資料表（例如 RAG / 長期記憶）
        public DbSet<Memory> Memories => Set<Memory>();


        // ==========================================================
        // OnModelCreating
        // ----------------------------------------------------------
        // 用來客製化資料表設定
        // - Index
        // - 關聯（Foreign Key）
        // - 欄位長度
        // - 預設值
        // - Constraint
        // ==========================================================
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ==========================================================
            // User 設定
            // ==========================================================
            modelBuilder.Entity<User>(entity =>
            {
                // Email 設定為 citext
                entity.Property(u => u.Email)
                    .HasColumnType("citext")
                    .HasMaxLength(255)
                    .IsRequired();

                // ----------------------------------------------------------
                // 建立唯一索引
                // ----------------------------------------------------------
                // 即使 Controller 有檢查 Email 是否存在
                // 還是必須在資料庫層做 Unique Constraint
                // 因為：
                // - 高併發情況下可能會同時註冊
                // - 只有 DB Constraint 才能 100% 保證唯一性
                entity.HasIndex(u => u.Email)
                      .IsUnique();

                entity.Property(u => u.PasswordHash)
                    .HasMaxLength(255)
                    .IsRequired();
            });

            // ==========================================================
            // ChatMessage 設定
            // ==========================================================

            modelBuilder.Entity<ChatMessage>()
                .Property(c => c.Content)
                .HasMaxLength(2000)
                .IsRequired();

            modelBuilder.Entity<ChatMessage>()
                .HasIndex(c => c.UserId);

            // ==========================================================
            // Memory 設定
            // ==========================================================

            modelBuilder.Entity<Memory>()
                .Property(m => m.Summary)
                .HasMaxLength(2000)
                .IsRequired();

            modelBuilder.Entity<Memory>()
                .HasIndex(m => m.UserId);

            // ==========================================================
            // 關聯設定
            // ==========================================================

            // ChatMessage ↔ User
            modelBuilder.Entity<ChatMessage>()
                .HasOne(c => c.User)
                .WithMany(u => u.ChatMessages)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Memory ↔ User
            modelBuilder.Entity<Memory>()
                .HasOne(m => m.User)
                .WithMany(u => u.Memories)
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}