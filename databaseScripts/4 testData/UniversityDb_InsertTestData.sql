
--insert test data into dbo.Courses
insert into dbo.Courses(Name, Description)
values ('C# basics', 'This course is a great introduction to both fundamental programming concepts and the C# programming language.'),
('Java basics', 'This course is a great introduction to both fundamental programming concepts and the Java programming language.'),
('Python basics', 'This course is a great introduction to both fundamental programming concepts and the Python programming language.');

-- insert test data into dbo.Groups
insert into dbo.Groups (CourseId, Name)
values (1, 'SR-01'), (2, 'SR-02'), (3, 'SR-03'), (1, 'SR-04'), (2, 'SR-05'), (3, 'SR-06'), (1, 'SR-07'), (2, 'SR-08'), (3, 'SR-09') ;

--insert test data into dbo.Students
insert into dbo.Students (GroupId, FirstName, LastName)
values (1, 'John', 'Doe'), (1, 'Tim', 'Brook'), (1, 'Irwin', 'Klocko'), (1, 'Mike', 'Miller'), (1, 'Ann', 'White'),
(1, 'Jane', 'Doe'), (1, 'Nathan', 'Green'), (1, 'Madelyn', 'Schamberger'), (1, 'Providenci', 'Gaylord'), (1, 'Sibyl', 'Purdy'),
(1, 'Jaden', 'Farrell'), (1, 'Estefania', 'Gorczany'), (1, 'Daphney', 'Bosco'), (1, 'Oleta', 'Roob'), (1, 'Kristopher', 'Beatty'),

(4, 'John', 'Doe'), (4, 'Tim', 'Brook'), (4, 'Irwin', 'Klocko'), (4, 'Mike', 'Miller'), (4, 'Ann', 'White'),
(4, 'Jane', 'Doe'), (4, 'Nathan', 'Green'), (4, 'Madelyn', 'Schamberger'), (4, 'Providenci', 'Gaylord'), (4, 'Sibyl', 'Purdy'),
(4, 'Jaden', 'Farrell'), (4, 'Estefania', 'Gorczany'), (4, 'Daphney', 'Bosco'), (4, 'Oleta', 'Roob'), (4, 'Kristopher', 'Beatty'),

(2, 'Eliezer', 'Donnelly'), (2, 'Korey', 'Baumbach'), (2, 'Wilfred', 'Monahan'), (2, 'Caterina', 'Lehner'), (2, 'Sim', 'Deckow'),
(2, 'Violet', 'Schimmel'), (2, 'Davin', 'Lang'), (2, 'Antwan', 'Mayer'), (2, 'Werner', 'Bauch'), (2, 'Henriette', 'Sporer'),
(2, 'Kailey', 'Bauch'), (2, 'Isidro', 'OHara'),

(5, 'Eliezer', 'Donnelly'), (5, 'Korey', 'Baumbach'), (5, 'Wilfred', 'Monahan'), (5, 'Caterina', 'Lehner'), (5, 'Sim', 'Deckow'),
(5, 'Violet', 'Schimmel'), (5, 'Davin', 'Lang'), (5, 'Antwan', 'Mayer'), (5, 'Werner', 'Bauch'), (5, 'Henriette', 'Sporer'),
(5, 'Kailey', 'Bauch'), (5, 'Isidro', 'OHara'),

(3, 'Aurelia', 'Conn'), (3, 'Kavon', 'Shields'), (3, 'Kaven', 'Gleason'), (3, 'Celia', 'Rogahn'), (3, 'Stephania', 'Rolfson'),
(3, 'Vida', 'Keeling'), (3, 'Jairo', 'McGlynn'), (3, 'Lenore', 'VonRueden'), (3, 'Celia', 'Gleason'),

(6, 'Aurelia', 'Conn'), (6, 'Kavon', 'Shields'), (6, 'Kaven', 'Gleason'), (6, 'Celia', 'Rogahn'), (6, 'Stephania', 'Rolfson'),
(6, 'Vida', 'Keeling'), (6, 'Jairo', 'McGlynn'), (6, 'Lenore', 'VonRueden'), (6, 'Celia', 'Gleason');
