SELECT part.druhe_slovo, part.points, part.amount, part.points * 1.0/part.amount * 1.0 as coefficient 
FROM (
	SELECT druhe_slovo, SUM(vzdialenost) as points, COUNT(druhe_slovo) as amount 
	FROM zbieranie_ohodnoteni WHERE prve_slovo LIKE 'diskutabilný' GROUP BY druhe_slovo
	) as part 
ORDER BY coefficient DESC, amount ASC