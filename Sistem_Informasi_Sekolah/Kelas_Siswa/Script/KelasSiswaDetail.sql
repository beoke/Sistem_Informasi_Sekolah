CREATE TABLE KelasSiswaDetail(
    KelasId INT NOT NULL CONSTRAINT DF_KelasSiswaDetail_KelasId DEFAULT(0),
    SiswaId INT NOT NULL CONSTRAINT DF_KelasSiswaDetail_SiswaId DEFAULT(0)
) 
GO

CREATE CLUSTERED INDEX CX_KelasSiswaDetail_KelasId
    ON KelasSiswaDetail(KelasId)
GO