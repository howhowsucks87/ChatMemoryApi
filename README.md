# Chat Memory API

A RESTful backend API built with ASP.NET Core for user authentication, chat message management, and long-term memory management.

This project focuses on core backend development concepts, including JWT authentication, user-level data isolation, Entity Framework Core, PostgreSQL, DTOs, pagination, centralized exception handling, and API documentation with Swagger.

## 專案簡介

Chat Memory API 是一個使用 ASP.NET Core 開發的 RESTful 後端 API，主要提供使用者註冊與登入、聊天訊息管理，以及長期記憶管理等功能。

本專案主要實作後端開發的核心概念，包括 JWT 身份驗證、使用者資料隔離、Entity Framework Core、PostgreSQL、DTO、分頁、集中式例外處理，以及使用 Swagger 建立 API 文件。

## Features

### Authentication

* User Registration
* User Login
* JWT Authentication
* JWT Claims
* Password Hashing with BCrypt
* Access Token Expiration

### Chat API

* Send Chat Messages
* Store Chat History
* Get User's Chat History
* Pagination
* Get a Specific Message
* Delete a Message
* User-Level Data Isolation

### Memory API

* Create Memory
* Get Memories
* Pagination
* Get a Specific Memory
* Delete a Memory
* User-Level Data Isolation

### API Quality & Infrastructure

* DTO-based Request/Response Models
* Unified API Response Format
* Global Exception Middleware
* Swagger JWT Authentication
* PostgreSQL Database
* Entity Framework Core

## 功能

### 使用者驗證

* 使用者註冊
* 使用者登入
* JWT 身份驗證
* JWT Claims
* 使用 BCrypt 進行密碼雜湊
* Access Token 過期機制

### Chat API

* 發送聊天訊息
* 儲存聊天記錄
* 取得使用者的聊天記錄
* 分頁功能
* 取得指定訊息
* 刪除訊息
* 使用者資料隔離

### Memory API

* 建立記憶
* 取得記憶列表
* 分頁功能
* 取得指定記憶
* 刪除記憶
* 使用者資料隔離

### API 品質與基礎架構

* 使用 DTO 建立 Request/Response Model
* 統一 API 回應格式
* Global Exception Middleware
* Swagger JWT 身份驗證
* PostgreSQL 資料庫
* Entity Framework Core

## Tech Stack

| Category                | Technology                                  |
| ----------------------- | ------------------------------------------- |
| Backend                 | ASP.NET Core                                |
| Language                | C#                                          |
| ORM                     | Entity Framework Core                       |
| Database                | PostgreSQL                                  |
| Authentication          | JWT Bearer Authentication                   |
| Password Hashing        | BCrypt                                      |
| API Documentation       | Swagger / OpenAPI                           |
| API Style               | RESTful API                                 |
| Configuration & Secrets | ASP.NET Core Configuration / Secret Manager |

## 技術棧

| 類別       | 技術                                          |
| -------- | ------------------------------------------- |
| 後端框架     | ASP.NET Core                                |
| 程式語言     | C#                                          |
| ORM      | Entity Framework Core                       |
| 資料庫      | PostgreSQL                                  |
| 身份驗證     | JWT Bearer Authentication                   |
| 密碼雜湊     | BCrypt                                      |
| API 文件   | Swagger / OpenAPI                           |
| API 架構風格 | RESTful API                                 |
| 設定與機密管理  | ASP.NET Core Configuration / Secret Manager |

## Architecture

```text
Client
   │
   │ HTTP / JSON
   ▼
ASP.NET Core Web API
   │
   ├── Middleware
   │     └── Global Exception Handling
   │
   ├── Authentication
   │     └── JWT Bearer Authentication
   │
   ├── Controllers
   │     ├── AuthController
   │     ├── UsersController
   │     ├── ChatController
   │     └── MemoriesController
   │
   ├── DTOs
   │     └── Request / Response Models
   │
   └── Entity Framework Core
         │
         ▼
      PostgreSQL
```

## Project Structure

```text
ChatMemoryApi/
│
├── Controllers/        # API endpoints and request handling
│   ├── AuthController.cs
│   ├── ChatController.cs
│   ├── MemoriesController.cs
│   └── UsersController.cs
│
├── data/               # Entity Framework Core database context
│   └── AppDbContext.cs
│
├── DTOs/               # Request and response data models
│   ├── ApiResponse.cs
│   ├── ChatMessageDto.cs
│   ├── CreateMemoryDto.cs
│   ├── CreateMessageDto.cs
│   ├── ErrorResponse.cs
│   ├── LoginDto.cs
│   ├── MemoryDto.cs
│   ├── PagedResult.cs
│   ├── RegisterDto.cs
│   └── UserMeDto.cs
│
├── Extensions/         # Custom extension methods
│   ├── ClaimsPrincipalExtensions.cs
│   └── MiddlewareExtensions.cs
│
├── Middlewares/        # Global exception handling
│   └── GlobalExceptionMiddleware.cs
│
├── Migrations/         # Entity Framework Core database migrations
│   └── EF Core Migrations
│
├── Models/             # Database entity models
│   ├── ChatMessage.cs
│   ├── Memory.cs
│   └── User.cs
│
├── Options/            # JWT configuration options
│   └── JwtOptions.cs
│
├── appsettings.json    # Application configuration
└── Program.cs          # Application configuration and service registration
```

## API Endpoints

### Authentication

| Method | Endpoint             | Description                  | Auth |
| ------ | -------------------- | ---------------------------- | ---- |
| POST   | `/api/auth/register` | Register a new user          | ❌    |
| POST   | `/api/auth/login`    | Login and receive a JWT access token  | ❌    |

### Users

| Method | Endpoint        | Description                    | Auth |
| ------ | --------------- | ------------------------------ | ---- |
| GET    | `/api/users/me` | Get current user's information | ✅    |

### Chat

| Method | Endpoint                                             | Description                             | Auth |
| ------ | ---------------------------------------------------- | --------------------------------------- | ---- |
| POST   | `/api/chat/messages`                                 | Send a chat message                     | ✅    |
| GET    | `/api/chat/messages?page={page}&pageSize={pageSize}` | Get user's chat history with pagination | ✅    |
| GET    | `/api/chat/messages/{id}`                            | Get a specific message                  | ✅    |
| DELETE | `/api/chat/messages/{id}`                            | Delete a message                        | ✅    |

### Memory

| Method | Endpoint                                        | Description                         | Auth |
| ------ | ----------------------------------------------- | ----------------------------------- | ---- |
| POST   | `/api/memories`                                 | Create a memory                     | ✅    |
| GET    | `/api/memories?page={page}&pageSize={pageSize}` | Get user's memories with pagination | ✅    |
| GET    | `/api/memories/{id}`                            | Get a specific memory               | ✅    |
| DELETE | `/api/memories/{id}`                            | Delete a memory                     | ✅    |

![image](https://github.com/howhowsucks87/ChatMemoryApi/blob/main/docs/images/swagger-overview.png)
![image](https://github.com/howhowsucks87/ChatMemoryApi/blob/main/docs/images/swagger-login.png)

### Pagination

The Chat and Memory list endpoints support pagination through query parameters.

Example:

```http
GET /api/chat/messages?page=1&pageSize=10
GET /api/memories?page=1&pageSize=10
```

* `page`: Page number
* `pageSize`: Number of items per page

![image](https://github.com/howhowsucks87/ChatMemoryApi/blob/main/docs/images/pagination.png)

## API 端點

### Authentication｜身份驗證

| Method | Endpoint             | Description     | Auth |
| ------ | -------------------- | --------------- | ---- |
| POST   | `/api/auth/register` | 註冊新使用者          | ❌    |
| POST   | `/api/auth/login`    | 登入並取得 JWT Access Token  | ❌    |

### Users｜使用者

| Method | Endpoint        | Description | Auth |
| ------ | --------------- | ----------- | ---- |
| GET    | `/api/users/me` | 取得目前使用者資訊   | ✅    |

### Chat｜聊天

| Method | Endpoint                                             | Description  | Auth |
| ------ | ---------------------------------------------------- | ------------ | ---- |
| POST   | `/api/chat/messages`                                 | 發送聊天訊息       | ✅    |
| GET    | `/api/chat/messages?page={page}&pageSize={pageSize}` | 分頁取得使用者的聊天記錄 | ✅    |
| GET    | `/api/chat/messages/{id}`                            | 取得指定訊息       | ✅    |
| DELETE | `/api/chat/messages/{id}`                            | 刪除訊息         | ✅    |

### Memory｜長期記憶

| Method | Endpoint                                        | Description | Auth |
| ------ | ----------------------------------------------- | ----------- | ---- |
| POST   | `/api/memories`                                 | 建立記憶        | ✅    |
| GET    | `/api/memories?page={page}&pageSize={pageSize}` | 分頁取得使用者的記憶  | ✅    |
| GET    | `/api/memories/{id}`                            | 取得指定記憶      | ✅    |
| DELETE | `/api/memories/{id}`                            | 刪除記憶        | ✅    |

### 分頁

Chat 和 Memory 的列表 API 支援透過 Query Parameters 進行分頁。

範例：

```http
GET /api/chat/messages?page=1&pageSize=10
GET /api/memories?page=1&pageSize=10
```

* `page`：頁碼
* `pageSize`：每頁資料筆數

## Authentication Flow

1. User registers with an email and password.
2. The password is hashed using BCrypt before being stored.
3. User logs in with their email and password.
4. The server verifies the password and generates a JWT access token.
5. The client sends the token using the `Authorization: Bearer <token>` header.
6. ASP.NET Core JWT middleware validates the token's signature, issuer, audience, and expiration.
7. `[Authorize]` protects authenticated endpoints.
8. The user ID is extracted from the authenticated JWT claims.

### Registration Flow

```text
Register
   │
   ▼
Email + Password
   │
   ▼
BCrypt Hash
   │
   ▼
PostgreSQL
```

### Login & Authorization Flow

```text
Login
   │
   ▼
Verify Password
   │
   ▼
Generate JWT Access Token
   │
   ▼
Client
   │
   │ Authorization: Bearer <token>
   ▼
JWT Validation
   │
   ▼
[Authorize]
   │
   ▼
Authorized API
```

## 身份驗證流程

1. 使用者使用電子郵件和密碼註冊帳號。
2. 密碼在儲存至資料庫前，使用 BCrypt 進行雜湊處理。
3. 使用者使用電子郵件和密碼登入。
4. 伺服器驗證密碼後，產生 JWT Access Token。
5. 用戶端透過 `Authorization: Bearer <token>` Header 傳送 Token。
6. ASP.NET Core JWT Middleware 驗證 Token 的簽章、Issuer、Audience 與有效期限。
7. 使用 `[Authorize]` 保護需要身份驗證的 API 端點。
8. 從已驗證的 JWT Claims 中取得使用者 ID。

## Data Isolation

Authenticated resources are always filtered by the authenticated user's ID extracted from the JWT claims.

For example:

```csharp
.Where(x => x.UserId == userId)
```

This ensures that users can only access their own chat messages and memories.

## 資料隔離

需要身份驗證的資源，都會使用從 JWT Claims 中取得的使用者 ID 進行資料篩選。

例如：

```csharp
.Where(x => x.UserId == userId)
```

這可以確保使用者只能存取屬於自己的聊天訊息與記憶資料。

## Database Design

### Users

* `Id`
* `Email`
* `PasswordHash`
* `CreatedAt`

### ChatMessages

* `Id`
* `UserId`
* `Content`
* `CreatedAt`

### Memories

* `Id`
* `UserId`
* `Summary`
* `CreatedAt`

### Relationships

```text
User
 │
 ├── 1 : N ── ChatMessages
 │
 └── 1 : N ── Memories
```

### Database Constraints

* User email is unique.
* Email comparison is case-insensitive using PostgreSQL `citext`.
* Chat messages reference their owning user through the `UserId` foreign key.
* Memories reference their owning user through the `UserId` foreign key.

## 資料庫設計

### Users｜使用者

* `Id`
* `Email`
* `PasswordHash`
* `CreatedAt`

### ChatMessages｜聊天訊息

* `Id`
* `UserId`
* `Content`
* `CreatedAt`

### Memories｜長期記憶

* `Id`
* `UserId`
* `Summary`
* `CreatedAt`

### 資料表關係

```text
User
 │
 ├── 1 : N ── ChatMessages
 │
 └── 1 : N ── Memories
```

### 資料庫限制

* 使用者 Email 必須是唯一的。
* 使用 PostgreSQL `citext` 實現 Email 不區分大小寫的比較。
* ChatMessages 透過 `UserId` 關聯所屬使用者。
* Memories 透過 `UserId` 關聯所屬使用者。

## Key Engineering Decisions

### User-Level Data Isolation

User-owned resources are always queried using the authenticated user's ID from JWT claims instead of accepting the `UserId` from client requests. This prevents users from accessing or modifying another user's data.

### DTOs

DTOs are used to separate API request/response models from database entities. This prevents database entities from being exposed directly through the API and provides better control over the data returned to clients.

### BCrypt Password Hashing

Passwords are hashed using BCrypt before being stored in the database. Plain-text passwords are never stored.

### Global Exception Handling

A global exception middleware was chosen to centralize unhandled exception handling and provide consistent API error responses.

## 主要工程設計決策

### 使用者資料隔離

使用者所屬的資源一律使用從 JWT Claims 取得的使用者 ID 進行查詢，而不是接受 Client 提供的 `UserId`。這可以避免使用者存取或修改其他使用者的資料。

### DTO

使用 DTO 將 API 的 Request/Response Model 與資料庫 Entity 分離，避免直接暴露資料庫 Entity，並能更好地控制回傳給 Client 的資料。

### BCrypt 密碼雜湊

使用 BCrypt 對密碼進行雜湊後再儲存至資料庫，不儲存明文密碼。

### Global Exception Handling

使用 Global Exception Middleware 集中處理未處理的例外，並提供一致的 API 錯誤回應格式。

## Error Handling

The API uses a global exception middleware to handle unhandled exceptions consistently.

The middleware:

- Catches unhandled exceptions across the application.
- Logs exception details on the server.
- Returns HTTP `500 Internal Server Error`.
- Returns a consistent JSON error response.
- Prevents internal exception details from being exposed to clients.

Example response:

```json
{
  "success": false,
  "message": "Internal Server Error"
}
```

```text
Request
   │
   ▼
ASP.NET Core Pipeline
   │
   ▼
Global Exception Middleware
   │
   ▼
Controller / Application Logic
   │
   ├── Success ──────────────► Normal Response
   │
   └── Exception
          │
          ▼
     Log Exception
          │
          ▼
     HTTP 500 Response
          │
          ▼
        Client
```

## 錯誤處理

本 API 使用 Global Exception Middleware 統一處理應用程式中未處理的例外。

Middleware 負責：

- 捕捉應用程式中的未處理例外。
- 在 Server 端記錄例外詳細資訊。
- 回傳 HTTP `500 Internal Server Error`。
- 回傳統一格式的 JSON 錯誤回應。
- 避免將內部例外詳細資訊暴露給 Client。

範例回應：

```json
{
  "success": false,
  "message": "Internal Server Error"
}
```

## Testing

The API was manually tested using Swagger UI. The following scenarios were verified.

### Authentication

- ✅ User Registration
- ✅ Duplicate Registration
- ✅ User Login
- ✅ Wrong Password

### JWT Authentication

- ✅ Swagger Authorize
- ✅ Unauthorized requests return `401 Unauthorized`

### Users

- ✅ Get Current User

### Chat

- ✅ Create Message
- ✅ Get Message List
- ✅ Get Message by ID
- ✅ Delete Message

### Memory

- ✅ Create Memory
- ✅ Get Memory List
- ✅ Get Memory by ID
- ✅ Delete Memory

### Security & Data Isolation

- ✅ Cannot view another user's messages
- ✅ Cannot delete another user's messages
- ✅ Cannot view another user's memories
- ✅ Cannot delete another user's memories

### Pagination

- ✅ `page`
- ✅ `pageSize`

## 測試

本 API 使用 Swagger UI 進行手動測試，並確認以下情境皆能正常運作。

### 身份驗證

- ✅ 使用者註冊
- ✅ 重複註冊
- ✅ 使用者登入
- ✅ 錯誤密碼

### JWT 身份驗證

- ✅ Swagger Authorize
- ✅ 未授權請求回傳 `401 Unauthorized`

### 使用者

- ✅ 取得目前使用者資訊

### Chat

- ✅ 建立訊息
- ✅ 取得訊息列表
- ✅ 取得指定訊息
- ✅ 刪除訊息

### Memory

- ✅ 建立記憶
- ✅ 取得記憶列表
- ✅ 取得指定記憶
- ✅ 刪除記憶

### 安全性與資料隔離

- ✅ 無法查看其他使用者的 Message
- ✅ 無法刪除其他使用者的 Message
- ✅ 無法查看其他使用者的 Memory
- ✅ 無法刪除其他使用者的 Memory

### 分頁

- ✅ `page`
- ✅ `pageSize`

## Swagger

The project includes Swagger/OpenAPI documentation and JWT authentication support.

To test authenticated endpoints:

1. Call `POST /api/auth/register` to create an account.
2. Call `POST /api/auth/login` to log in.
3. Copy the returned JWT access token.
4. Click the `Authorize` button in Swagger UI.
5. Enter the token using the `Bearer` scheme:

```text
Bearer <your-token>
```
![image](https://github.com/howhowsucks87/ChatMemoryApi/blob/main/docs/images/swagger-jwt.png)

6. Click `Authorize`.
7. You can now test protected endpoints that require authentication.

## Swagger

本專案使用 Swagger/OpenAPI 建立 API 文件，並支援 JWT 身份驗證。

要測試需要身份驗證的 API：

1. 呼叫 `POST /api/auth/register` 註冊帳號。
2. 呼叫 `POST /api/auth/login` 登入。
3. 複製回傳的 JWT Access Token。
4. 在 Swagger UI 點擊 `Authorize`。
5. 使用 `Bearer` 方式輸入 Token：

```text
Bearer <your-token>
```

6. 點擊 `Authorize`。
7. 完成驗證後，即可測試需要身份驗證的 API。

## Getting Started

### Prerequisites

- .NET 8 SDK
- PostgreSQL
- Entity Framework Core CLI (`dotnet-ef`)
- Visual Studio 2022 or VS Code

### 1. Clone the repository

```bash
git clone https://github.com/howhowsucks87/ChatMemoryApi.git
cd ChatMemoryApi
```
### 2. Configure the database

Configure the PostgreSQL connection string using .NET User Secrets or environment variables.

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=ChatMemoryDb;Username=your-username;Password=your-password"
  }
}
```

### 3. Configure JWT

Configure the following JWT settings:

- Key
- Issuer
- Audience
- ExpireMinutes

The JWT secret key should be stored using .NET User Secrets or environment variables.

Example:

```json
{
  "Jwt": {
    "Key": "your-secret-key",
    "Issuer": "ChatMemoryApi",
    "Audience": "ChatMemoryClient",
    "ExpireMinutes": 15
  }
}
```
The example above is for demonstration only. Do not use a real secret key in `appsettings.json`.

### 4. Apply migrations

```bash
dotnet ef database update
```
### 5. Run the application

```bash
dotnet run
```
### 6. Open Swagger

Open the Swagger UI URL shown in the console after starting the application.

See the [Swagger](#swagger) section for authentication and API testing instructions.

## 開始使用

### 前置需求

- .NET 8 SDK
- PostgreSQL
- Entity Framework Core CLI (`dotnet-ef`)
- Visual Studio 2022 或 VS Code

### 1. 複製 Repository

```bash
git clone https://github.com/howhowsucks87/ChatMemoryApi.git
cd ChatMemoryApi
```
### 2. 設定資料庫

使用 .NET User Secrets 或環境變數設定 PostgreSQL Connection String。

範例：

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=ChatMemoryDb;Username=your-username;Password=your-password"
  }
}
```

### 3. 設定 JWT

需要設定以下 JWT 設定：

- Key
- Issuer
- Audience
- ExpireMinutes

JWT Secret Key 應使用 .NET User Secrets 或環境變數儲存。

範例：

```json
{
  "Jwt": {
    "Key": "your-secret-key",
    "Issuer": "ChatMemoryApi",
    "Audience": "ChatMemoryClient",
    "ExpireMinutes": 15
  }
}
```
上述範例僅供示範，請勿將真正的 Secret Key 放入 `appsettings.json`。

### 4. 套用 Database Migration

```bash
dotnet ef database update
```
### 5. 執行應用程式

```bash
dotnet run
```
### 6. 開啟 Swagger

啟動應用程式後，開啟 Console 顯示的 Swagger UI URL。

JWT 身份驗證與 API 測試方式請參考上方的 Swagger 章節。

## Project Goal

This project was built to demonstrate practical backend development skills with ASP.NET Core, including authentication, authorization, database design, API design, user-level data isolation, error handling, and data access with Entity Framework Core.

The project is designed as a foundation for a future AI-powered Chat Memory / RAG backend system.

## 專案目標

本專案旨在展示使用 ASP.NET Core 進行實際後端開發的能力，包括身份驗證、授權、資料庫設計、API 設計、使用者資料隔離、錯誤處理，以及使用 Entity Framework Core 進行資料存取。

本專案也作為未來開發 AI-powered Chat Memory / RAG 後端系統的基礎。

## Future Improvements

- Refresh token support and rotation
- Password reset and email verification
- Role-based authorization
- Rate limiting
- Automated unit and integration tests
- Docker containerization and CI/CD
- Redis caching
- AI-powered memory extraction and semantic search

## 未來改進

- 支援 Refresh Token 與 Token Rotation
- 密碼重設與 Email 驗證
- Role-based Authorization（角色型授權）
- Rate Limiting（請求速率限制）
- 自動化 Unit Test 與 Integration Test
- Docker 容器化與 CI/CD
- Redis 快取
- AI 輔助的記憶擷取與語意搜尋
