CREATE TABLE AbsensiDetail (
    AbsensiId INT NOT NULL,
    NoUrut INT NOT NULL,
    SiswaId INT NOT NULL,
    StatusAbsen VARCHAR(10) NOT NULL DEFAULT(''),
    Keterangan VARCHAR(100) NOT NULL DEFAULT(''),
    
    FOREIGN KEY (AbsensiId) REFERENCES Absensi(AbsensiId)
);