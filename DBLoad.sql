USE master;

CREATE DATABASE DBFilm;
GO;

USE DBFilm;


CREATE TABLE Film (
	Id INT PRIMARY KEY IDENTITY,
	Titre VARCHAR(100) NOT NULL,
	Annee INT,
	Genre VARCHAR(30),
	Realisateur VARCHAR(100),
	Synopsis VARCHAR(250),
)



CREATE TABLE Acteur (
	Id INT PRIMARY KEY IDENTITY,
	Nom VARCHAR(50),
	Prenom VARCHAR(50)
)

CREATE TABLE FilmActeur (
	FilmId INT, 
	ActeurId INT, 
	CONSTRAINT FK_Film FOREIGN KEY (FilmId) REFERENCES Film(Id)
		ON DELETE SET NULL ON UPDATE CASCADE,
	CONSTRAINT FK_Acteur FOREIGN KEY (ActeurId) REFERENCES Acteur(Id)
		ON DELETE SET NULL ON UPDATE CASCADE
)


INSERT INTO Film VALUES 
('Star Wars - New Hope', 1977, 'Sci-fi', 'Georges Lucas', 'Chewbacca et ses potes traversent la galaxie pour se faire Leia'),
('Indiana Jones', 1979, 'Aventure', 'Georges Lucas - Steven Spielberg', 'Un dingue avec un chapeau qui évite des gros caillou'),
('Terminator', 1987, 'Sci-fi', 'James Cameron', 'Un robot psychopathe du futur essaye de se faire une blonde alcolique'),
('Le seigneur des anneaux', 2001, 'Heroic-Fantasy', 'Peter Jackson', 'Une bande de pote traverse le monde pour se friter avec le gros méchant')


INSERT INTO Acteur VALUES
('Ford', 'Harisson'),
('Mark', 'Hammil'),
('Arnold', 'President'),
('Carrie', 'Fisher'),
('Andy', 'Serkis'),
('Elijah', 'Wood')

INSERT INTO FilmActeur VALUES
(1, 1),
(1, 2),
(1, 4),
(2, 1),
(3, 3),
(4, 5),
(4, 6)


/*SELECT *
FROM Acteur as a 
JOIN FilmActeur as fa 
ON fa.ActeurId = a.Id 
WHERE fa.FilmId = 1

SELECT * FROM Film
*/