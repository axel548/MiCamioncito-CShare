use MiCamioncito
go


/****** StoredProcedure [dbo].[Vehicles_Get] ******/
create procedure [dbo].[Vehicles_Get]
as
begin
	SELECT * FROM Vehicles;
end
GO


/****** StoredProcedure [dbo].[Vehicle_Get_Id] ******/
create procedure [dbo].[Vehicle_Get_Id]
(
	@idVehicle int
)
as
begin
	SELECT * FROM Vehicles
	WHERE IDVehicle = @idVehicle;
end
GO



/****** StoredProcedure [dbo].[Vehicle_Insert] ******/
create procedure [dbo].[Vehicle_Insert]
(
    @CapacityCubicMeters DECIMAL(10, 2),
    @FuelConsumptionPerKm DECIMAL(10, 2),
    @AvailableDistanceKm DECIMAL(10, 2),
    @AvailabilityStartDate DATETIME,
    @AvailabilityEndDate DATETIME,
    @DepreciationCostPerKm DECIMAL(10, 2),
    @CargoType NVARCHAR(100)
)
as
begin
	INSERT INTO [dbo].[Vehicles](CapacityCubicMeters, FuelConsumptionPerKm, AvailableDistanceKm, AvailabilityStartDate, AvailabilityEndDate, DepreciationCostPerKm, CargoType) 
	VALUES (  
			@CapacityCubicMeters, 
			@FuelConsumptionPerKm,
			@AvailableDistanceKm,
			@AvailabilityStartDate,
			@AvailabilityEndDate,
			@DepreciationCostPerKm,
			@CargoType
	);
end
GO


/****** StoredProcedure [dbo].[Vehicle_Update_Id] ******/
create procedure [dbo].[Vehicle_Update_Id]
(
	@idVehicle int,
    @CapacityCubicMeters DECIMAL(10, 2),
    @FuelConsumptionPerKm DECIMAL(10, 2),
    @AvailableDistanceKm DECIMAL(10, 2),
    @AvailabilityStartDate DATETIME,
    @AvailabilityEndDate DATETIME,
    @DepreciationCostPerKm DECIMAL(10, 2),
    @CargoType NVARCHAR(100)
)
as
begin
	UPDATE Vehicles SET  
			CapacityCubicMeters = @CapacityCubicMeters, 
			FuelConsumptionPerKm = @FuelConsumptionPerKm,
			AvailableDistanceKm = @AvailableDistanceKm,
			AvailabilityStartDate = @AvailabilityStartDate,
			AvailabilityEndDate = @AvailabilityEndDate,
			DepreciationCostPerKm = @DepreciationCostPerKm,
			CargoType = @CargoType
	WHERE IDVehicle = @idVehicle;
end
GO


/****** StoredProcedure [dbo].[Vehicle_Delete_Id] ******/
create procedure [dbo].[Vehicle_Delete_Id]
(
	@idVehicle int
)
as
begin
	DELETE FROM Vehicles
	WHERE IDVehicle = @idVehicle
end
GO