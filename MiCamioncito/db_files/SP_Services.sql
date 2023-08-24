use MiCamioncito
go

/****** StoredProcedure [dbo].[Services_Get] ******/
create procedure [dbo].[Services_Get]
as
begin
	SELECT * FROM Services;
end
GO


/****** StoredProcedure [dbo].[Service_Get_Id] ******/
create procedure [dbo].[Service_Get_Id]
(
	@idService int
)
as
begin
	SELECT * FROM Services
	WHERE IDService = @idService;
end
GO


/****** StoredProcedure [dbo].[Service_Insert_Id] ******/
create procedure [dbo].[Service_Insert]
(
    @IDVehicle INT,
    @IDPilot INT,
    @IDClient INT,
    @ServiceDate DATETIME,
    @DeliveryDate DATETIME,
    @TotalCost DECIMAL(10, 2)
)
as
begin
	INSERT INTO Services(IDVehicle, IDPilot, IDClient, ServiceDate, DeliveryDate, TotalCost) 
	VALUES (  
			@IDVehicle, 
			@IDPilot,
			@IDClient,
			@ServiceDate,
			@DeliveryDate,
			@TotalCost
			);
end
GO


/****** StoredProcedure [dbo].[Service_Update_Id] ******/
create procedure [dbo].[Service_Update_Id]
(
	@IDService INT,
    @IDVehicle INT,
    @IDPilot INT,
    @IDClient INT,
    @ServiceDate DATETIME,
    @DeliveryDate DATETIME,
    @TotalCost DECIMAL(10, 2)
)
as
begin
	UPDATE Services SET  
			IDVehicle = @IDVehicle, 
			IDPilot = @IDPilot,
			IDClient = @IDClient,
			ServiceDate = @ServiceDate,
			DeliveryDate = @DeliveryDate,
			TotalCost = @TotalCost
	WHERE IDService = @IDService;
end
GO


/****** StoredProcedure [dbo].[Pilot_Delete_Id] ******/
create procedure [dbo].[Service_Delete_Id]
(
	@idService int
)
as
begin
	DELETE FROM Services
	WHERE IDService = @idService
end
GO