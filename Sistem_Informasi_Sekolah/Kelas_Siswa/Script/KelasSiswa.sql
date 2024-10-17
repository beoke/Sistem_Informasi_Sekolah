CREATE TABLE KelasSiswa (
    KelasId INT PRIMARY KEY IDENTITY(1,1),
    TahunAjaran VARCHAR(20),
    WaliKelasId INT,
    FOREIGN KEY (WaliKelasId) REFERENCES Guru(GuruId),
    KelasId_FK INT,
    FOREIGN KEY (KelasId_FK) REFERENCES Kelas(KelasId)
);