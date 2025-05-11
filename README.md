# 📚 Library System

A simple .NET-based backend application for managing a library's book collection, including features for tracking available books, removed books, and restoring previously deleted entries.

---

## 🚀 Features

- Get, Add, update, and delete books that represent basic functionalities for CRUD operations on book records
- Search, filter and pagination for books based on specific filters
- View and restore removed books in case they are lost or worn out (RemovedBook)
- Maintain user profiles (Profiles)
- Book Lending Managment Process: The system facilitates book lending through a borrowing process (BookRecord POST) and a return process (BookRecord PUT /{id}). When a user borrows a book, the system creates a record of the transaction. Upon returning the book, the record is updated rather than deleted.
- Built using ASP.NET Core MVC and Entity Framework

---

## 🖥️ System Requirements

- **.NET SDK**: 6.0 or later
- **IDE**: Visual Studio 2022
- **Database**: MySQL 
- **OS**: Windows, macOS, or Linux
- 
## 📖 Database
Connection String
The application uses the following default MSSQL connection string:
server=localhost;user=root;password=<your_password>;database=library_management
You might need to change it according to your environment

🛠️ Installation and Setup

 ### 1 Clone the Repository

git clone <repository-url>
cd LibrarySystem/LibrarySystem


### 2. Configure the Database Connection

server=localhost;user=root;password=<your_password>;database=library_management

### 3. Install Dependencies

dotnet restore

dotnet ef database update

dotnet run
