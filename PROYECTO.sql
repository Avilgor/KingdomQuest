DROP DATABASE IF EXISTS KingdomQuest;
CREATE DATABASE KingdomQuest;
DROP USER admin;
GRANT ALL PRIVILEGES ON KingdomQuest.* TO 'admin' IDENTIFIED BY '12345' WITH GRANT OPTION;
USE KingdomQuest;

CREATE TABLE Personajes (
	nombre VARCHAR(100) PRIMARY KEY,
    vida int
);

create table Historial(
	id INT NOT NULL AUTO_INCREMENT,
	nombre VARCHAR(100) NOT NULL,
	puntos double,
	##personaje VARCHAR(200),
    primary key (id)
);

CREATE TABLE Ranking (
	posicion double PRIMARY KEY,
	nombreJugador VARCHAR(100),
	puntuacion double
);

CREATE TABLE Sonidos(
	escena varchar(100) PRIMARY KEY,
	cancion varchar(100)
);

##ALTER TABLE Historial add constraint fk_personaje foreign key (personaje) references Personajes (nombre) on delete cascade;

INSERT INTO Sonidos Values("Menu","MusicaBackground");
INSERT INTO Sonidos Values("Controles","MusicaBackground");
INSERT INTO Sonidos Values("SelecPersonaje","MusicaBackground");
INSERT INTO Sonidos Values("Ranking","MusicaBackground");
INSERT INTO Sonidos Values("NombreJugador","MusicaBackground");
INSERT INTO Sonidos Values("scene1","MusicaBackground");
INSERT INTO Sonidos Values("Victory","VictorySound");
INSERT INTO Sonidos Values("GAME OVER","Game_Over sound");
INSERT INTO Sonidos Values("Nivel 1","Celtic Music - Medieval Battle");
INSERT INTO Sonidos Values("Nivel 2","Celtic Music - Medieval Battle");
INSERT INTO Sonidos Values("Nivel 3","Celtic Music - Medieval Battle");
INSERT INTO Sonidos Values("Nivel 4","Celtic Music - Medieval Battle");
INSERT INTO Sonidos Values("Nivel 5","Celtic Music - Medieval Battle");
INSERT INTO Sonidos Values("Nivel Boss","BossMusic");


INSERT INTO Ranking Values(1,"A","5");
INSERT INTO Ranking Values(2,"B","4");
INSERT INTO Ranking Values(3,"C","3");
INSERT INTO Ranking Values(4,"D","2");
INSERT INTO Ranking Values(5,"E","1");

INSERT INTO Personajes Values("Arturito",3);
INSERT INTO Personajes Values("Folagon",2);
INSERT INTO Personajes Values("Ubbe",4);
INSERT INTO Personajes Values("Firulais",3);

