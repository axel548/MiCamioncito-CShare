use MiCamioncito
go

/****** StoredProcedure [dbo].[Pilots_Get] ******/
create procedure [dbo].[Pilots_Get]
as
begin
	SELECT * FROM Pilots;
end
GO


/****** StoredProcedure [dbo].[Pilot_Get_Id] ******/
create procedure [dbo].[Pilot_Get_Id]
(
	@idPilot int
)
as
begin
	SELECT * FROM Pilots
	WHERE IDPilot = @idPilot;
end
GO


/****** StoredProcedure [dbo].[Pilot_Insert_Id] ******/
create procedure [dbo].[Pilot_Insert]
(
	@Name NVARCHAR(100),
	@AvailableTime INT,
	@AvailabilityStartDate DATETIME,
	@AvailabilityEndDate DATETIME,
	@PerDiem DECIMAL(10, 2),
	@AdditionalExpenses DECIMAL(10, 2)
)
as
begin
	INSERT INTO Pilots(Name, AvailableTime, AvailabilityStartDate, AvailabilityEndDate, PerDiem, AdditionalExpenses) 
	VALUES (  
			@Name, 
			@AvailableTime,
			@AvailabilityStartDate,
			@AvailabilityEndDate,
			@PerDiem,
			@AdditionalExpenses
			);
end
GO


/****** @idPilotStoredProcedure [dbo].[Pilot_Update_Id] ******/
create procedure [dbo].[Pilot_Update_Id]
(
	@idPilot int,
	@Name NVARCHAR(100),
	@AvailableTime INT,
	@AvailabilityStartDate DATETIME,
	@AvailabilityEndDate DATETIME,
	@PerDiem DECIMAL(10, 2),
	@AdditionalExpenses DECIMAL(10, 2)
)
as
begin
	UPDATE Pilots SET  
			Name = @Name, 
			AvailableTime = @AvailableTime,
			AvailabilityStartDate = @AvailabilityStartDate,
			AvailabilityEndDate = @AvailabilityEndDate,
			PerDiem = @PerDiem,
			AdditionalExpenses = @AdditionalExpenses
	WHERE IDPilot = @idPilot;
end
GO


/****** StoredProcedure [dbo].[Pilot_Delete_Id] ******/
create procedure [dbo].[Pilot_Delete_Id]
(
	@idPilot int
)
as
begin
	DELETE FROM Pilots
	WHERE IDPilot = @idPilot
end
GO


