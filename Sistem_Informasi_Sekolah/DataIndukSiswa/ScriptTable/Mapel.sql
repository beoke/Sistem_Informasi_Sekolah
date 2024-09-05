CREATE TABLE Mapel(
  MapelId INT IDENTITY(1,1),
  NamaMapel VARCHAR (50) NOT NULL DEFAULT ('')
  );

iNSERT INTO Mapel (NamaMapel) VALUES ('Bahasa Idonesia');
INSERT INTO Mapel (NamaMapel) VALUES ('Matematika');
INSERT INTO Mapel (NamaMapel) VALUES ('Bahasa Inggris');
INSERT INTO Mapel (NamaMapel) VALUES ('Ilmu Pengetahuan Alam');
INSERT INTO Mapel (NamaMapel) VALUES ('Ilmu Pengetahuan Sosial');
INSERT INTO Mapel (NamaMapel) VALUES ('Biologi');
INSERT INTO Mapel (NamaMapel) VALUES ('Kimia');
INSERT INTO Mapel (NamaMapel) VALUES ('Sejarah');
INSERT INTO Mapel (NamaMapel) VALUES ('PPKN');
