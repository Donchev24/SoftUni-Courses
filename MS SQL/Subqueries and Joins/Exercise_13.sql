  SELECT c.CountryCode,
         Count(m.MountainRange) AS MountainRanges
    FROM Countries AS c
    JOIN MountainsCountries AS mc
      ON c.CountryCode = mc.CountryCode
    JOIN Mountains AS m
      ON m.Id = mc.MountainId
   WHERE c.CountryCode IN ('BG', 'RU', 'US')
GROUP BY c.CountryCode
          
