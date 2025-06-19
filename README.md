# System Management

A web application built with ASP.NET Core Razor Pages (.NET 6) for managing company-related data and user identities.

## Features

- User authentication and identity management
- Company data management
- Secure connection to SQL Server databases
- Email notifications via SMTP (Gmail supported)
- Configurable logging

## Technologies Used

- ASP.NET Core Razor Pages (.NET 6)
- Entity Framework Core
- SQL Server
- SMTP (for email notifications)

## Getting Started

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- Visual Studio 2022 or later

### Configuration

1. **Database Connections:**  
   Update the `ConnectionStrings` section in `appsettings.json` with your SQL Server details:
   - `CompanyConnection`
   - `IdentityConnection`

2. **Email Settings:**  
   Configure the `Email` section in `appsettings.json` with your SMTP provider details.

3. **Logging:**  
   Adjust logging levels in the `Logging` section as needed.

### Running the Application

1. Restore NuGet packages:
   dotnet restore
2. Apply database migrations (if applicable):
   dotnet ef database update
3. Run the application:
   dotnet run


### Usage

- Access the application in your browser at `https://localhost:5001` (or the port specified in launch settings).
- Use the provided features to manage company data and user accounts.

## Folder Structure

- `Pages/` - Razor Pages for UI
- `Data/` - Database context and models
- `wwwroot/` - Static files
- `appsettings.json` - Application configuration

## License

This project is licensed under the MIT License.

---

**Note:**  
Replace sensitive information in `appsettings.json` (such as email and passwords) before publishing to GitHub.
