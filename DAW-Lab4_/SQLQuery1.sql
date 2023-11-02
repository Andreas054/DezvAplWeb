INSERT INTO [students] (Id, DateTime, LastModified, Name, Age)
VALUES (NEWID(), GETDATE(), GETDATE(), 'Florin', 22);

INSERT INTO [students] (Id, DateTime, LastModified, Name, Age)
VALUES (NEWID(), GETDATE(), GETDATE(), 'Marian', 23);

select * from Students