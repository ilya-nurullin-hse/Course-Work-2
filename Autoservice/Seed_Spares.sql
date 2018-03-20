declare @i int
declare @cnt int
declare @modelsCount int
declare @spareCount int

--select @i = 0, @cnt = 860

--while @i < @cnt 
--begin
--	INSERT INTO Spares (SpareTypeId, Vendorcode) VALUES
--	((SELECT TOP 1 Id FROM SpareTypes ORDER BY NEWID()), 
--	SUBSTRING(CONVERT(varchar(255), REPLACE(NEWID(), '-', '')), 0, 6 + CONVERT(INT, (11-6+1)*RAND())))

--	select @i += 1
--end

select @i = 1, @modelsCount = (select Count(*) from AutoModels), @cnt = @modelsCount * 6, @spareCount = (select Count(*) from Spares)
while @i < @cnt 
begin
	INSERT INTO AutoModelSpare(AutoModels_Id, Spares_Vendorcode) VALUES
	((SELECT Id FROM AutoModels ORDER BY Id OFFSET @i % (@modelsCount + 1) ROWS FETCH NEXT 1 ROW ONLY), 
	(SELECT Vendorcode FROM Spares ORDER BY Vendorcode OFFSET @i % (@spareCount + 1) ROWS FETCH NEXT 1 ROW ONLY))

	select @i += 1
end


--select @i = 0, @cnt = 2000

--while @i < @cnt 
--begin
--	INSERT INTO Prices(Manufacturer_Id, Provider_Id, Spare_Vendorcode, Value) VALUES
--	(
--		(SELECT TOP 1 Id FROM Manufacturers ORDER BY NEWID()), 
--		(SELECT TOP 1 Id FROM Providers ORDER BY NEWID()), 
--		(SELECT TOP 1 Vendorcode FROM Spares ORDER BY NEWID()), 
--		501 + CONVERT(INT, (25000-501+1)*RAND())
--	)

--	select @i += 1
--end