create table Absensi (
AbsensiId INT PRIMARY KEY IDENTITY (1,0),
Tanggal DATE,
KelasId INT,
MapelId INT,
GuruId INT,

FOREIGN KEY (KelasId) REFERENCES Kelas(KelasId),
FOREIGN KEY (MapelId) REFERENCES Mapel(MapelId),
FOREIGN KEY (GuruId) REFERENCES Guru(GuruId),
);