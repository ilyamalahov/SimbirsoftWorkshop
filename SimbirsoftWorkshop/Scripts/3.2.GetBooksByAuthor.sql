SET @authorId = 3

SELECT 
	CONCAT_WS(' ', a.first_name, a.last_name) as author_name,
	b.name AS book_name,
	bg.genres
FROM author a 
	INNER JOIN book b ON b.author_id = a.id
	LEFT JOIN 
	(
		SELECT bg.book_id, GROUP_CONCAT(g.genre_name) as genres
		FROM genre g 
			INNER JOIN book_genre bg ON bg.genre_id = g.id
		GROUP BY bg.book_id 
	) bg ON bg.book_id = b.id 
WHERE a.id = @authorId