SELECT 
	CONCAT_WS(' ', a.first_name, a.last_name) as author,
	g.genre_name,
	COUNT(b.id) AS books_count
FROM author a 
	LEFT JOIN book b ON b.author_id = a.id 
	INNER JOIN book_genre bg ON bg.book_id = b.id
	INNER JOIN genre g ON g.id = bg.genre_id 
GROUP BY 
	CONCAT_WS(' ', a.first_name, a.last_name),
	g.genre_name