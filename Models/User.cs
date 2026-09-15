namespace ChatMemoryApi.Models
{
    // ==========================================================
    // User
    // ----------------------------------------------------------
    // 功能：
    // 系統的使用者帳號資料
    // 作為認證（JWT）的主體
    // 與其他資料表建立關聯（ChatMessage / Memory）
    //
    // 在資料庫中對應：
    // Table: Users
    //
    // 關聯：
    // User (1) → (Many) ChatMessage
    // User (1) → (Many) Memory
    // ==========================================================
    public class User
    {
        // ----------------------------------------------------------
        // 主鍵（Primary Key）
        // ----------------------------------------------------------
        public int Id { get; set; }


        // ----------------------------------------------------------
        // Email（登入帳號）
        // ----------------------------------------------------------
        public string Email { get; set; } = null!;


        // ----------------------------------------------------------
        // PasswordHash（密碼雜湊）
        // ----------------------------------------------------------
        public string PasswordHash { get; set; } = null!;


        // ----------------------------------------------------------
        // 建立時間（UTC）
        // ----------------------------------------------------------
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // ==========================
        // Navigation Properties
        // ==========================

        // 一個 User 擁有多筆聊天紀錄
        public ICollection<ChatMessage> ChatMessages { get; set; } 
            = new List<ChatMessage>();

        // 一個 User 擁有多筆記憶資料
        public ICollection<Memory> Memories { get; set; } 
            = new List<Memory>();
    }
}