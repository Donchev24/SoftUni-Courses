   SELECT c.CountryCode,
          m.MountainRange,
   	      p.PeakName,
   	      p.Elevation
     FROM Countries AS c
     JOIN MountainsCountries AS mc
       ON c.CountryCode = mc.CountryCode
     JOIN Mountains as m
       ON mc.MountainId = m.Id
     JOIN Peaks as p
       ON m.Id = p.MountainId
    WHERE c.CountryCode = 'BG' 
          AND p.Elevation > 2835
 ORDER BY p.Elevation DESC
