CREATE TABLE genre 
(
	id int NOT NULL AUTO_INCREMENT,
	genre_name varchar(64) NOT NULL,
	CONSTRAINT genre_pk PRIMARY KEY(id),
	CONSTRAINT genre_name_uk UNIQUE KEY(genre_name)
)

CREATE TABLE author
(
	id int NOT NULL AUTO_INCREMENT,
	first_name varchar(256) NOT NULL,
	last_name varchar(256) NOT NULL,
	middle_name varchar(256) NULL,
	CONSTRAINT author_pk PRIMARY KEY(id),
	CONSTRAINT author_names_uk UNIQUE KEY (first_name, last_name, middle_name)
)

CREATE TABLE person
(
	id int NOT NULL AUTO_INCREMENT,
	first_name varchar(256) NOT NULL,
	last_name varchar(256) NOT NULL,
	middle_name varchar(256) NULL,
	birth_date date NULL,
	CONSTRAINT person_pk PRIMARY KEY(id),
	CONSTRAINT person_names_uk UNIQUE KEY (first_name, last_name, middle_name)
)

CREATE TABLE book 
(
	id int NOT NULL AUTO_INCREMENT,
  	name varchar(512) NOT NULL,
  	author_id int NOT NULL,
  	CONSTRAINT book_pk PRIMARY KEY (id),
  	CONSTRAINT book_name_author_uk UNIQUE KEY (name,author_id),
  	CONSTRAINT book_author_fk FOREIGN KEY (author_id) REFERENCES author (id)
)

CREATE TABLE book_genre
(
	book_id int NOT NULL,
	genre_id int NOT NULL,
	CONSTRAINT book_genre_pk PRIMARY KEY (book_id, genre_id),
	CONSTRAINT book_genre_book_fk FOREIGN KEY (book_id) REFERENCES book (id),
	CONSTRAINT book_genre_genre_fk FOREIGN KEY (genre_id) REFERENCES genre (id)
)

CREATE TABLE library_card
(
	book_id int NOT NULL,
	person_id int NOT NULL,
	CONSTRAINT library_card_pk PRIMARY KEY (book_id, person_id),
	CONSTRAINT library_card_book_fk FOREIGN KEY (book_id) REFERENCES book (id),
	CONSTRAINT library_card_person_fk FOREIGN KEY (person_id) REFERENCES person (id)
)