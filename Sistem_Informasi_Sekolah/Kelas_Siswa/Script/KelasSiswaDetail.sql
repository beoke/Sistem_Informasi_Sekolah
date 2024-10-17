    CREATE TABLE KelasSiswaDetail (
        KelasId INT NOT NULL,
        SiswaId INT NOT NULL,
        PRIMARY KEY (KelasId, SiswaId),
        FOREIGN KEY (KelasId) REFERENCES Kelas(KelasId),
        FOREIGN KEY (SiswaId) REFERENCES Siswa(SiswaId)
    );