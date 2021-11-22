SET @personId = 2

SELECT 
	b.name,
	CONCAT_WS(' ', a.first_name, a.last_name) as author,
	bg.genres
FROM person p 
	INNER JOIN library_card lc ON lc.person_id = p.id
	INNER JOIN book b ON b.id = lc.book_id
	INNER JOIN author a ON a.id = b.author_id
	LEFT JOIN 
	(
		SELECT bg.book_id, GROUP_CONCAT(g.genre_name) as genres
		FROM genre g 
			INNER JOIN book_genre bg ON bg.genre_id = g.id
		GROUP BY bg.book_id 
	) bg ON bg.book_id = b.id  
WHERE p.id = @personId