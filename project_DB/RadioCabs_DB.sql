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





INSERT INTO Companies (
    CompanyName, CompanyID, Password, ContactPerson, Designation,
    Address, Mobile, Telephone, Fax, Email,
    MembershipType, PaymentType
)
VALUES 
('TechNova Solutions', 'TN001', 'Pass@1234', 'Alice Johnson', 'CEO',
 '123 Innovation Way, Silicon Valley, CA', '1234567890', '9876543210', '123-456-7891', 'alice@technova.com',
 'Premium', 'Monthly'),

('GreenEnergy Corp', 'GE002', 'Green#2024', 'Bob Smith', 'Operations Manager',
 '45 Solar Lane, Austin, TX', '2345678901', '8765432109', '234-567-8901', 'bob.smith@greenenergy.com',
 'Basic', 'Quarterly'),

('UrbanLogix Ltd.', 'UL003', 'Urban!Logix2024', 'Clara Benson', 'Logistics Head',
 '78 Transit Avenue, New York, NY', '3456789012', '7654321098', '345-678-9012', 'clara@urbanlogix.com',
 'Free', 'Monthly'),

('HealthBridge Inc.', 'HB004', 'HB#secure456', 'David Lee', 'CTO',
 '90 Wellness Street, Denver, CO', '4567890123', '6543210987', '456-789-0123', 'david.lee@healthbridge.com',
 'Premium', 'Quarterly'),

('AquaPure Systems', 'AP005', 'Aqua!2025', 'Eva Martins', 'Sales Director',
 '32 Riverbend Road, Portland, OR', '5678901234', '5432109876', '567-890-1234', 'eva@aquapure.com',
 'Basic', 'Monthly');
