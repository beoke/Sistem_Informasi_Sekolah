
CREATE TABLE Jurusan (
    id INT IDENTITY(1,1),
    NamaJurusan VARCHAR(50) NOT NULL DEFAULT ('')
);


INSERT INTO Jurusan (NamaJurusan) VALUES ('Rekayasa Perangkat Lunak');
INSERT INTO Jurusan (NamaJurusan) VALUES ('Teknik Komputer Jaringan');
INSERT INTO Jurusan (NamaJurusan) VALUES ('Desain Komunikasi Visual');
INSERT INTO Jurusan (NamaJurusan) VALUES ('Akutansi');
INSERT INTO Jurusan (NamaJurusan) VALUES ('Manajemen Perkantoran');
INSERT INTO Jurusan (NamaJurusan) VALUES ('Bisnis Retail');
INSERT INTO Jurusan (NamaJurusan) VALUES ('Bisnis Digital');
INSERT INTO Jurusan (NamaJurusan) VALUES ('Perbankan');