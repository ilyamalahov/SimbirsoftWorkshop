ALTER TABLE library_card 
ADD COLUMN book_taking_date datetime NULL

SET @startDate = DATE_SUB(CURRENT_DATE() , INTERVAL 28 DAY)
SET @endDate = CURRENT_DATE() 

UPDATE library_card 
SET book_taking_date = FROM_UNIXTIME
(
    UNIX_TIMESTAMP(@startDate) + 
    FLOOR
    (
    	RAND() * 
    	(
    		UNIX_TIMESTAMP(@endDate) - 
    		UNIX_TIMESTAMP(@startDate) + 
    		1
		)
	)
)

ALTER TABLE library_card 
MODIFY COLUMN book_taking_date datetime NOT NULL