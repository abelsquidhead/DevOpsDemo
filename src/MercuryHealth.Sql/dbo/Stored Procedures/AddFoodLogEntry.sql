CREATE PROCEDURE [dbo].[AddFoodLogEntry]
	@description nvarchar(max),
	@quantity real,
	@mealTime datetime,
	@tags nvarchar(max),
	@calories int,
	@protein decimal,
	@fat decimal,
	@carbs decimal,
	@sodium decimal
AS
	insert into FoodLogEntries (Description, Quantity, MealTime, Tags, Calories, ProteinInGrams, FatInGrams, CarbohydratesInGrams, SodiumInGrams)
	values (@description, @quantity, @mealTime, @tags, @calories, @protein, @fat, @carbs, @sodium)