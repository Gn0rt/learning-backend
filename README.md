#🚀 Learning Backend - ASP.NET Core Web API & MongoDB

Dự án này là kết quả của quá trình học tập và thực hành xây dựng hệ thống Backend chuyên nghiệp sử dụng ASP.NET Core Web API, kết nối cơ sở dữ liệu phi quan hệ MongoDB, và bảo mật bằng JWT (JSON Web Token)

📌 Các tính năng chính
- Quản lý Company, User, Device: Hệ thống cung cấp đầy đủ các API CRUD (Create, Read, Update, Delete) cho các thực thể chính
- Bảo mật JWT: Tích hợp xác thực bằng Token. Chỉ những User có Token hợp lệ mới có quyền truy cập vào các tài nguyên (như Company)
- Service Pattern: Code được tổ chức theo kiến trúc tách biệt giữa Controller và Service để dễ dàng bảo trì và mở rộng
- Tích hợp MongoDB: Sử dụng MongoDB.Driver để thao tác dữ liệu một cách tối ưu
- Tự động hóa tài liệu API: Tích hợp Swagger giúp việc test API trở nên trực quan và dễ dàng

🛠 Tech Stack
- Ngôn ngữ: C# (.NET 6/7/8)
- Database: MongoDB
- Xác thực: JWT Bearer Authentication
- Thư viện: MongoDB.Driver, Microsoft.AspNetCore.Authentication.JwtBearer

📂 Cấu trúc dự án
Dự án được tổ chức theo mô hình Clean Architecture (mini) để đảm bảo tính minh bạch và tách biệt trách nhiệm:
- Controllers/: Tiếp nhận các request HTTP và trả về kết quả
- Services/: Nơi xử lý toàn bộ logic nghiệp vụ (Business Logic)
- Models/:
-  Entities/: Các lớp ánh xạ trực tiếp với Database (Company, User, Device)
-  DTOs/: Chứa các object vận chuyển dữ liệu giữa các tầng
- Configurations/: Lưu trữ cấu hình hệ thống (MongoDB, JWT)

⚙️ Cấu hình và Cài đặt
1. Yêu cầu hệ thống
- NET SDK (phiên bản phù hợp với project).
- MongoDB đang chạy trên máy local hoặc Cloud (Atlas).
2. Cấu hình Connection String
Bro cần cấu hình thông tin kết nối trong file appsettings.json:
```
"MongoDbSettings": {
  "ConnectionString": "mongodb://localhost:27017",
  "DatabaseName": "LearningBEDB"
}
```
3. Cách chạy Project
**MacOS**
Dùng Terminal và thực hiện các lệnh sau:
# Di chuyển vào thư mục dự án
cd LearningBE

# Khôi phục các gói NuGet
dotnet restore

# Chạy ứng dụng
dotnet run

Sau khi chạy, API sẽ hoạt động tại các cổng mặc định (ví dụ: https://localhost:7182)
. Bro có thể truy cập /swagger để xem danh sách API

🔐 Hướng dẫn xác thực
- Gọi API Login để lấy chuỗi Token
- Trong các request tiếp theo, đính kèm Token vào Header theo định dạng: Authorization: Bearer <Your_Token>
