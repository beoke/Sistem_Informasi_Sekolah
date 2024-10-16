create table KelasSiswa(
 KelasId INT PRIMARY KEY IDENTITY (1,1),
 TahunAjaran VARCHAR(20) ,
 WaliKelasId INT

FOREIGN KEY (KelasId) REFERENCES Kelas(kelasId),

);