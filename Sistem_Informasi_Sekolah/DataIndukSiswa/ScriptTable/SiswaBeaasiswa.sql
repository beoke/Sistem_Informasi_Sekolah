 CREATE TABLE SiswaBeasiswa(
    SiswaId INT NOT NULL DEFAULT(''), 
    NoUrut INT NOT NULL DEFAULT(''),
    Tahun VARCHAR (50)NOT NULL DEFAULT(''),
    Kelas VARCHAR(50)  NOT NULL DEFAULT(''),
    AsalBeasiswa VARCHAR(50) NOT NULL DEFAULT(''),
    )
 GO

CREATE CLUSTERED INDEX IX_SiswaBeasiswa_SiswaId
    ON SiswaBeasiswa (SiswaId, NoUrut)
GO