CREATE TABLE Team (
    id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY, 
    name VARCHAR(30) NOT NULL, 
    country VARCHAR(30) NOT NULL
);

CREATE TABLE Player ( 
    id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(30) NOT NULL, 
    age INT NOT NULL, 
    team_id INT UNSIGNED NOT NULL,
    FOREIGN KEY (team_id) REFERENCES Teams(id)
 );

INSERT INTO Team  (id, name, country) VALUES (1, 'Rome', 'Italy');
INSERT INTO Team (id, name, country) VALUES (2,'AZ Alkmaar', ' Netherlands');
INSERT INTO Player (name, age, team_id) VALUES ('Francesco Totti', 40, 1);
INSERT INTO Player (name, age, team_id) VALUES ('Vangelis Pavlidis', 25, 2);