SELECT 
	CONCAT_WS(' ', p.first_name, p.last_name) as user_name, 
	plc.books_count,
	plc.expire_days
FROM person p 
	INNER JOIN 
	(
		SELECT 
			lc.person_id, 
			COUNT(lc.book_id) AS books_count, 
			SUM(datediff(current_date(), lc.book_taking_date)) AS expire_days 
		FROM library_card lc 
		WHERE datediff(current_date(), lc.book_taking_date) > 14 
		GROUP BY lc.person_id
	) plc ON plc.person_id = p.id