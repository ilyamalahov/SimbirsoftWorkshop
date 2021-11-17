SELECT 
	CONCAT_WS(' ', p.first_name, p.last_name) as user_name, 
	b.name AS book_name,
	DATEDIFF(current_date(), lc.book_taking_date) AS expire_days
FROM library_card lc 
	INNER JOIN person p ON p.id = lc.person_id
	INNER JOIN book b ON b.id = lc.book_id 
WHERE datediff(current_date(), lc.book_taking_date) > 14