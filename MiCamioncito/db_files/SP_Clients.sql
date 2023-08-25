--use MiCamioncito
go

/****** StoredProcedure [dbo].[Client_Get] ******/
create procedure [dbo].[Client_Get]
as
begin
	SELECT * FROM Clients;
end
GO


/****** StoredProcedure [dbo].[Client_Get_Id] ******/
create procedure [dbo].[Client_Get_Id]
(
	@idClient int
)
as
begin
	SELECT * FROM Clients
	WHERE IDClient = @idClient;
end
GO



/****** StoredProcedure [dbo].[Client_Insert] ******/
create procedure [dbo].[Client_Insert]
(
    @Name NVARCHAR(100),
    @Email NVARCHAR(100),
    @CargoPercentage DECIMAL(5, 2),
    @ReceptionAddress NVARCHAR(200),
    @DeliveryAddress NVARCHAR(200),
    @RequiredDocumentation NVARCHAR(MAX)
)
as
begin
	INSERT INTO Clients(Name, Email, CargoPercentage, ReceptionAddress, DeliveryAddress, RequiredDocumentation) 
	VALUES (  
			@Name, 
			@Email,
			@CargoPercentage,
			@ReceptionAddress,
			@DeliveryAddress,
			@RequiredDocumentation
			);
end
GO


/****** StoredProcedure [dbo].[Client_Update_Id] ******/
create procedure [dbo].[Client_Update_Id]
(
	@IDClient INT,
    @Name NVARCHAR(100),
    @Email NVARCHAR(100),
    @CargoPercentage DECIMAL(5, 2),
    @ReceptionAddress NVARCHAR(200),
    @DeliveryAddress NVARCHAR(200),
    @RequiredDocumentation NVARCHAR(MAX)
)
as
begin
	UPDATE Clients SET  
			Name = @Name, 
			Email = @Email,
			CargoPercentage = @CargoPercentage,
			ReceptionAddress = @ReceptionAddress,
			DeliveryAddress = @DeliveryAddress,
			RequiredDocumentation = @RequiredDocumentation
	WHERE IDClient = @IDClient;
end
GO


/****** StoredProcedure [dbo].[Client_Delete_Id] ******/
create procedure [dbo].[Client_Delete_Id]
(
	@idClient int
)
as
begin
	DELETE FROM Clients
	WHERE IDClient = @idClient;
end
GO

