--Extract all animals, who does not have an owner and are younger than 5 years (5 years from '01/01/2022'),
--except for the Birds.
--Select their name, year of birth and animal type.
--Order the result by animal's name.

SELECT
	 a.[Name]
	,YEAR(a.BirthDate) AS BirthYear
	,ant.AnimalType
		FROM Animals AS a
		JOIN AnimalTypes AS ant ON a.AnimalTypeId = ant.Id
	WHERE ant.AnimalType <> 'Birds' AND DATEDIFF(YEAR,a.BirthDate,'01/01/2022') < 5  AND a.OwnerId IS NULL
ORDER BY a.[Name]
