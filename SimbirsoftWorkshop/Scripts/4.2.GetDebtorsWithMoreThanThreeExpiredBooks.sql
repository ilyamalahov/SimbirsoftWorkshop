SELECT 
	CONCAT_WS(' ', p.first_name, p.last_name) as user_name, 
	plc.books_count
FROM person p 
	INNER JOIN 
	(
		SELECT lc.person_id, COUNT(lc.book_id) AS books_count
		FROM library_card lc 
		WHERE datediff(current_date(), lc.book_taking_date) > 14
		GROUP BY lc.person_id
		HAVING COUNT(lc.book_id) > 3
	) plc ON plc.person_id = p.id