select * from Countries

insert into Countries(Name)
values
	('Ukraine'),
	('USA'),
	('France'),
	('Italy'),
	('Poland')


select * from Genres

insert into Genres(Name)
values
	('Rock'),
	('Hip-Hop'),
	('Classical'),
	('Rap'),
	('Jazz'),
	('Pop')


select * from Categories

insert into Categories(Name)
values
	('Rock'),
	('Hip-Hop'),
	('Classical'),
	('Rap'),
	('Jazz'),
	('Pop')


select * from Artists

insert into Artists(Surname, Name, CountryId)
values
    ('Waters', 'Roger', 1),
    ('Jackson', 'Michael', 2),
    ('Young', 'Angus', 2),
    ('Lennon', 'John', 4),
    ('Springsteen', 'Bruce', 2),
    ('Hill', 'Lauryn', 3),
    ('Swift', 'Taylor', 2),
    ('Rita', 'Dua', 5),
    ('Freddie', 'Mercury', 4),
    ('Cobain', 'Kurt', 1);

select * from Albums

insert into Albums(Name, ArtistId, Year, GenreId)
values
    ('The Dark Side of the Moon', 1, 1973, 1),
    ('Thriller', 2, 1982, 6),
    ('Back in Black', 3, 1980, 1),
    ('The Wall', 1, 1979, 1),
    ('Abbey Road', 4, 1969, 1),
    ('Born to Run', 5, 1975, 1),
    ('The Miseducation of Lauryn Hill', 6, 1998, 2),
    ('Lover', 7, 2019, 6),
    ('Reputation', 7, 2017, 6),
    ('Future Nostalgia', 8, 2020, 6);

select * from Tracks

insert into Tracks(Name, AlbumId, Duration)
values
    ('Speak to Me', 1, '1.30'),
    ('Billie Jean', 2, '4.54'),
    ('Hells Bells', 3, '4.30'),
    ('Comfortably Numb', 4, '6.22'),
    ('Come Together', 5, '4.20'),
    ('Thunder Road', 6, '4.49'),
    ('Doo Wop (That Thing)', 7, '5.20'),
    ('ME!', 8, '3.13'),
    ('Look What You Made Me Do', 9, '3.31'),
    ('Physical', 10, '3.12');

select * from Playlists
select * from PlaylistTrack