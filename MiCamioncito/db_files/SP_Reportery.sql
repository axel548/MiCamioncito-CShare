USE [MiCamioncito]
GO


/****** StoredProcedure [dbo].[Reportery_list_vehicle] ******/
create procedure [dbo].[Reportery_list_vehicle]
(
    @StartDate DATETIME,
    @EndDate DATETIME
)
as
begin
	SELECT * FROM Vehicles
	WHERE AvailabilityStartDate BETWEEN @StartDate AND @EndDate
	AND AvailabilityEndDate BETWEEN @StartDate AND @EndDate
end
GO

/****** StoredProcedure [dbo].[Reportery_list_pilot] ******/
create procedure [dbo].[Reportery_list_pilot]
(
    @StartDate DATETIME,
    @EndDate DATETIME
)
as
begin
	SELECT * FROM Pilots
	WHERE AvailabilityStartDate BETWEEN @StartDate AND @EndDate
	AND AvailabilityEndDate BETWEEN @StartDate AND @EndDate
end
GO


