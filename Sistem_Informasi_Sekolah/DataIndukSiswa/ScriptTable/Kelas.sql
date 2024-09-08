
CREATE TABLE Kelas (
    KelasId INT IDENTITY(1,1),
    KelasNama VARCHAR(50) NOT NULL DEFAULT (''),
    KelasTingkat INT NOT NULL DEFAULT (''),
    JurusanNama VARCHAR (50) NOT NULL DEFAULT ('')
);
