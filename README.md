
# RadioCabs Project Setup Instructions

## 1. Install Required Packages
To create a connection with **SQL Server**, ensure you have the following packages installed:

- **Microsoft.EntityFrameworkCore**
- **Microsoft.EntityFrameworkCore.Design**
- **Microsoft.EntityFrameworkCore.SqlServer**
- **Microsoft.EntityFrameworkCore.Tools**

You can install these packages via **NuGet Package Manager** or by running the following commands in the **Package Manager Console**:
```powershell
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.Design
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
```

---

## 2. Setup Database
- Open the **RadioCabs.sql** file located in the **project_DB** folder.
- Run the SQL script on **SQL Server**.
- Ensure you are using **Windows Authentication**.

---

## 3. Update Server Name
- Change the **server name** in both the **appsettings.json** and **appsettings.Development.json** files to match your actual server name.

Example:
```json
"ConnectionStrings": {
  "db": "Server=YOUR_SERVER_NAME;Database=RadioCabs_DB;Integrated Security=True;TrustServerCertificate=True;"
}
```

---

## 4. Program.cs File Configuration
Ensure the following lines are present in your **Program.cs** file:

```csharp
var provide = builder.Services.BuildServiceProvider();
var config = provide.GetService<IConfiguration>();
builder.Services.AddDbContext<RadioCabsDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("db")));
```

✅ **Important:**
- Make sure the **DbContext** reference is **`<RadioCabsDbContext>`**, NOT **`<RadioCabs_DBContext>`**.

---

## 5. Scaffold the Database
Run the following scaffold command to generate models and establish the connection:

```powershell
Scaffold-DbContext Name=db Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
```

- If a file named **RadioCabs_DBContext.cs** is created in the **Models** directory, **delete it**, but do **NOT** delete **RadioCabsDbContext.cs**.

---

## 6. Run Migration Command
To sync your code with the database, run the migration command:

```powershell
Update-Database
```

This will ensure that any model changes are applied to the database.
