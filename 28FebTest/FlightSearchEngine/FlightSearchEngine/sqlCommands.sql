CREATE DATABASE FlightSearchDb;
GO
USE FlightSearchDb;
GO

CREATE TABLE Flights(
    FlightId INT PRIMARY KEY IDENTITY(1,1),
    FlightName NVARCHAR(100) NOT NULL,
    FlightType NVARCHAR(50) NOT NULL,
    Source NVARCHAR(100) NOT NULL,
    Destination NVARCHAR(100) NOT NULL,
    PricePerSeat DECIMAL(18,2) NOT NULL
);
CREATE TABLE Hotels(
    HotelId INT PRIMARY KEY IDENTITY(1,1),
    HotelName NVARCHAR(100) NOT NULL,
    HotelType NVARCHAR(50) NOT NULL,
    Location NVARCHAR(100) NOT NULL,
    PricePerDay DECIMAL(18,2) NOT NULL
);
INSERT INTO Flights (FlightName, FlightType, Source, Destination, PricePerSeat)
VALUES
('Indigo 101','Domestic','Delhi','Mumbai',4000),
('Air India 202','Domestic','Delhi','Bangalore',5000),
('Etihad 303','International','Mumbai','Abu Dhabi',15000),
('Emirates 404','International','Bangalore','Dubai',4500);

INSERT INTO Hotels (HotelName, HotelType, Location, PricePerDay)
VALUES
('Taj Mumbai','5 Star','Mumbai',8000),
('Oberoi Bangalore','5 Star','Bangalore',7500),
('Dubai Grand','Luxury','Dubai',12000),
('Abu Dhabi','4 Star','Abu Dhabi',16000);
GO

CREATE PROCEDURE sp_GetSources
AS
BEGIN
    SELECT DISTINCT Source FROM Flights
END
go

CREATE PROCEDURE sp_GetDestinations
AS
BEGIN
    SELECT DISTINCT Destination FROM Flights
END
GO

CREATE PROCEDURE sp_SearchFlights
    @Source NVARCHAR(100),
    @Destination NVARCHAR(100),
    @Persons INT
AS
BEGIN
    SELECT 
        FlightId,
        FlightName,
        FlightType,
        Source,
        Destination,
        PricePerSeat * @Persons AS TotalCost
    FROM Flights
    WHERE Source = @Source AND Destination = @Destination
END
GO

CREATE PROCEDURE sp_SearchFlightsWithHotels
    @Source NVARCHAR(100),
    @Destination NVARCHAR(100),
    @Persons INT
AS
BEGIN
    SELECT 
        f.FlightId,
        f.FlightName,
        f.Source,
        f.Destination,
        h.HotelName,
        (f.PricePerSeat * @Persons) + h.PricePerDay AS TotalCost
    FROM Flights f
    INNER JOIN Hotels h ON f.Destination = h.Location
    WHERE f.Source = @Source AND f.Destination = @Destination
END
GO