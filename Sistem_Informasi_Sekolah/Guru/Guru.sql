﻿CREATE TABLE Guru(
	GuruId INT IDENTITY(1,1),
	GuruName VARCHAR(30) NOT NULL DEFAULT(''),
	TglLahir DATETIME NOT NULL DEFAULT('3000-01-01'),

	JurusanPendidikan VARCHAR(50) NOT NULL DEFAULT(''),
	TingkatPendidikan VARCHAR(10) NOT NULL DEFAULT(''),
	TahunLulus VARCHAR(4) NOT NULL DEFAULT(''),
	InstansiPendidikan VARCHAR(50) NOT NULL DEFAULT(''),
	KotaPendidikan VARCHAR(20) NOT NULL DEFAULT(''),

	CONSTRAINT PK_Guru PRIMARY KEY CLUSTERED(GuruId));