SELECT g.genre_name, COUNT(b.id) AS books_count
FROM genre g 
	LEFT JOIN book_genre bg ON bg.genre_id = g.id 
	LEFT JOIN book b ON b.id = bg.book_id 
GROUP BY g.genre_name
ORDER BY COUNT(b.id)
