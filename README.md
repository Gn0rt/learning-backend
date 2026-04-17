![.NET](https://img.shields.io/badge/.NET-6/7/8%2B-blue)
![MongoDB](https://img.shields.io/badge/Database-MongoDB-green)

# 🚀 Learning Backend API

**ASP.NET Core Web API + MongoDB + JWT Authentication**

📌 Backend project xây dựng theo hướng **clean, scalable, production-ready** sử dụng ASP.NET Core và MongoDB.

-----
## ✨ Overview**

Dự án này mô phỏng một hệ thống Backend hoàn chỉnh với các chức năng quản lý và xác thực người dùng, phù hợp để học tập và làm nền tảng cho các dự án thực tế.

-----
## 🔥 Features

**🧩 Core Modules**

- **Company Management** – CRUD Company
- **User Management** – CRUD User + Authentication
- **Device Management** – Quản lý thiết bị

**🔐 Security**

- Xác thực bằng **JWT Bearer Token**
- Bảo vệ API với [Authorize]
- Phân quyền truy cập tài nguyên

**🏗 Architecture**

- Áp dụng **Service Pattern**
- Tách biệt rõ:
  - Controller (API Layer)
  - Service (Business Logic)
  - DTO (Data Transfer)

**🗄 Database**

- Sử dụng **MongoDB (NoSQL)**
- Tối ưu với MongoDB.Driver

**📄 API Documentation**

- Tích hợp **Swagger UI**
- Test API tại /swagger
-----
## 🛠 Tech Stack

|**Category**|**Technology**|
| :- | :- |
|Language|C# (.NET 6/7/8)|
|Framework|ASP.NET Core Web API|
|Database|MongoDB|
|Authentication|JWT Bearer|
|Libraries|MongoDB.Driver, Microsoft.AspNetCore.Authentication.JwtBearer|

-----
## 📁 Project Structure

LearningBE/

│

├── Controllers/       # Xử lý HTTP request

├── Services/          # Business logic

├── Models/

│   ├── Entities/      # Mapping với MongoDB

│   └── DTOs/          # Data transfer objects

├── Configurations/    # Config MongoDB, JWT

└── Program.cs

-----
## ⚙️ Getting Started

**1️⃣ Requirements**

- .NET SDK (6/7/8)
- MongoDB (Local hoặc MongoDB Atlas)

**2️⃣ Configuration**

Cập nhật appsettings.json:
```
"MongoDbSettings": {
  "ConnectionString": "mongodb://localhost:27017",
  "DatabaseName": "LearningBEDB"
}
```

**3️⃣ Run Project**

cd LearningBE

dotnet restore

dotnet run

📍 API chạy tại:

https://localhost:7182 (tùy theo từng máy)

📄 Swagger UI:

https://localhost:7182/swagger

-----
## 🔐 Authentication Guide**

**🔑 Step 1: Login**

Gọi API login để lấy JWT Token

**📦 Step 2: Gửi Token**

Thêm vào Header:

Authorization: Bearer <your\_token>

-----
**👨‍💻 Author**

**Bui Trong**\
Web Developer (ASP.NET Core)

-----
**⭐️ Show your support**

Nếu bạn thấy project hữu ích, hãy ⭐ repo để ủng hộ nhé!

