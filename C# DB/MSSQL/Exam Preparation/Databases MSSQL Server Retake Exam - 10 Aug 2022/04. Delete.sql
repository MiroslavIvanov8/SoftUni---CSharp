DELETE FROM TouristsBonusPrizes
WHERE BonusPrizeId IN
(
	SELECT BonusPrizeId FROM BonusPrizes
	WHERE [Name] = 'Sleeping bag'
)

DELETE FROM BonusPrizes
WHERE [Name] = 'Sleeping bag'