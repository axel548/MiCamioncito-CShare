--CREATE DATABASE MiCamioncito;
go
--use MiCamioncito;
go
-- Create Vehiculos table
CREATE TABLE Vehicles (
    IDVehicle INT PRIMARY KEY identity(1,1),
    CapacityCubicMeters DECIMAL(10, 2),
    FuelConsumptionPerKm DECIMAL(10, 2),
    AvailableDistanceKm DECIMAL(10, 2),
    AvailabilityStartDate DATETIME,
    AvailabilityEndDate DATETIME,
    DepreciationCostPerKm DECIMAL(10, 2),
    CargoType NVARCHAR(100)
);

-- Create Pilotos table
CREATE TABLE Pilots (
    IDPilot INT PRIMARY KEY identity(1,1),
    Name NVARCHAR(100),
    AvailableTime INT,
    AvailabilityStartDate DATETIME,
    AvailabilityEndDate DATETIME,
    PerDiem DECIMAL(10, 2),
    AdditionalExpenses DECIMAL(10, 2)
);

-- Create Clients table
CREATE TABLE Clients (
    IDClient INT PRIMARY KEY identity(1,1),
    Name NVARCHAR(100),
    Email NVARCHAR(100),
    CargoPercentage DECIMAL(5, 2),
    ReceptionAddress NVARCHAR(200),
    DeliveryAddress NVARCHAR(200),
    RequiredDocumentation NVARCHAR(MAX)
);

-- Create Services table
CREATE TABLE Services (
    IDService INT PRIMARY KEY identity(1,1),
    IDVehicle INT,
    IDPilot INT,
    IDClient INT,
    ServiceDate DATETIME,
    DeliveryDate DATETIME,
    TotalCost DECIMAL(10, 2),
    FOREIGN KEY (IDVehicle) REFERENCES Vehicles(IDVehicle),
    FOREIGN KEY (IDPilot) REFERENCES Pilots(IDPilot),
    FOREIGN KEY (IDClient) REFERENCES Clients(IDClient)
);


go






