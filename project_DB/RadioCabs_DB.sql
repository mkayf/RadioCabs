create database RadioCabs_DB
use RadioCabs_DB


--Table for Users--

CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    Role NVARCHAR(50) CHECK (Role IN ('admin', 'company', 'driver', 'advertiser')) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);


--Table for Companies--

CREATE TABLE Companies (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CompanyName NVARCHAR(255) NOT NULL,
    CompanyID NVARCHAR(50) UNIQUE NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    ContactPerson NVARCHAR(100),
    Designation NVARCHAR(100),
    Address NVARCHAR(MAX),
    Mobile NVARCHAR(15),
    Telephone NVARCHAR(15),
    Fax NVARCHAR(20),
    Email NVARCHAR(100) UNIQUE NOT NULL,
    MembershipType NVARCHAR(50) CHECK (MembershipType IN ('Premium', 'Basic', 'Free')) NOT NULL,
    PaymentType NVARCHAR(50) CHECK (PaymentType IN ('Monthly', 'Quarterly')) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);


--Table for Drivers --

CREATE TABLE Drivers (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    DriverName NVARCHAR(100) NOT NULL,
    DriverID NVARCHAR(50) UNIQUE NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    ContactPerson NVARCHAR(100),
    Address NVARCHAR(MAX),
    City NVARCHAR(100),
    Mobile NVARCHAR(15),
    Telephone NVARCHAR(15),
    Email NVARCHAR(100) UNIQUE NOT NULL,
    Experience INT,
    Description NVARCHAR(MAX),
    PaymentType NVARCHAR(50) CHECK (PaymentType IN ('Monthly', 'Quarterly')) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);

--Table for Advertisements--

CREATE TABLE Advertisements (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CompanyName NVARCHAR(255) NOT NULL,
    Designation NVARCHAR(100),
    Address NVARCHAR(MAX),
    Mobile NVARCHAR(15),
    Telephone NVARCHAR(15),
    Fax NVARCHAR(20),
    Email NVARCHAR(100),
    Description NVARCHAR(MAX),
    PaymentType NVARCHAR(50) CHECK (PaymentType IN ('Monthly', 'Quarterly')) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);

--Table for payments--

CREATE TABLE Payments (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    PaymentFor NVARCHAR(50) CHECK (PaymentFor IN ('Registration', 'Driver', 'Advertisement')) NOT NULL,
    Amount DECIMAL(10,2) NOT NULL,
    PaymentType NVARCHAR(50) CHECK (PaymentType IN ('Monthly', 'Quarterly')) NOT NULL,
    PaymentDate DATETIME DEFAULT GETDATE(),
    Status NVARCHAR(50) CHECK (Status IN ('Pending', 'Completed')) DEFAULT 'Pending',
    FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE
);


--Table for feedback--

CREATE TABLE Feedback (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Mobile NVARCHAR(15),
    Email NVARCHAR(100),
    City NVARCHAR(100),
    Type NVARCHAR(50) CHECK (Type IN ('Complaint', 'Suggestion', 'Compliment')) NOT NULL,
    Description NVARCHAR(MAX),
    CreatedAt DATETIME DEFAULT GETDATE()
);

--Table for Services--


CREATE TABLE Services(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CompanyId INT NOT NULL,
    VehicleType NVARCHAR(120) NOT NULL,
    Description TEXT,
    AvailableCity NVARCHAR(150) NOT NULL,
    FarePerKm NVARCHAR(255) NOT NULL
)