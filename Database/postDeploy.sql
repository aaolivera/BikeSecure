INSERT INTO Lector (Nombre) VALUES ('Lector1');
INSERT INTO Lector (Nombre) VALUES ('Lector2');

INSERT INTO Bicicletero (Lector_Id) VALUES ((Select Id from Lector where Nombre = 'Lector1'));
INSERT INTO Bicicletero (Lector_Id) VALUES ((Select Id from Lector where Nombre = 'Lector2'));

INSERT INTO Estacionamiento (Direccion,LocalizacionX,LocalizacionY,Bicicletero_Id) VALUES ('Calle1 0123',1111,2222,(Select Bicicletero.Id from Bicicletero,Lector where  Bicicletero.Lector_Id = Lector.Id and Lector.Nombre = 'Lector1'));
INSERT INTO Estacionamiento (Direccion,LocalizacionX,LocalizacionY,Bicicletero_Id) VALUES ('Calle2 3456',3333,4444,(Select Bicicletero.Id from Bicicletero,Lector where  Bicicletero.Lector_Id = Lector.Id and Lector.Nombre = 'Lector2'));

INSERT INTO Zocalo (Bicicletero_Id) VALUES ((Select Bicicletero.Id from Bicicletero,Lector where  Bicicletero.Lector_Id = Lector.Id and Lector.Nombre = 'Lector1'));
INSERT INTO Zocalo (Bicicletero_Id) VALUES ((Select Bicicletero.Id from Bicicletero,Lector where  Bicicletero.Lector_Id = Lector.Id and Lector.Nombre = 'Lector1'));
INSERT INTO Zocalo (Bicicletero_Id) VALUES ((Select Bicicletero.Id from Bicicletero,Lector where  Bicicletero.Lector_Id = Lector.Id and Lector.Nombre = 'Lector1'));
INSERT INTO Zocalo (Bicicletero_Id) VALUES ((Select Bicicletero.Id from Bicicletero,Lector where  Bicicletero.Lector_Id = Lector.Id and Lector.Nombre = 'Lector1'));
INSERT INTO Zocalo (Bicicletero_Id) VALUES ((Select Bicicletero.Id from Bicicletero,Lector where  Bicicletero.Lector_Id = Lector.Id and Lector.Nombre = 'Lector1'));
INSERT INTO Zocalo (Bicicletero_Id) VALUES ((Select Bicicletero.Id from Bicicletero,Lector where  Bicicletero.Lector_Id = Lector.Id and Lector.Nombre = 'Lector1'));
INSERT INTO Zocalo (Bicicletero_Id) VALUES ((Select Bicicletero.Id from Bicicletero,Lector where  Bicicletero.Lector_Id = Lector.Id and Lector.Nombre = 'Lector1'));
INSERT INTO Zocalo (Bicicletero_Id) VALUES ((Select Bicicletero.Id from Bicicletero,Lector where  Bicicletero.Lector_Id = Lector.Id and Lector.Nombre = 'Lector1'));

INSERT INTO Zocalo (Bicicletero_Id) VALUES ((Select Bicicletero.Id from Bicicletero,Lector where  Bicicletero.Lector_Id = Lector.Id and Lector.Nombre = 'Lector2'));
INSERT INTO Zocalo (Bicicletero_Id) VALUES ((Select Bicicletero.Id from Bicicletero,Lector where  Bicicletero.Lector_Id = Lector.Id and Lector.Nombre = 'Lector2'));
INSERT INTO Zocalo (Bicicletero_Id) VALUES ((Select Bicicletero.Id from Bicicletero,Lector where  Bicicletero.Lector_Id = Lector.Id and Lector.Nombre = 'Lector2'));
INSERT INTO Zocalo (Bicicletero_Id) VALUES ((Select Bicicletero.Id from Bicicletero,Lector where  Bicicletero.Lector_Id = Lector.Id and Lector.Nombre = 'Lector2'));
INSERT INTO Zocalo (Bicicletero_Id) VALUES ((Select Bicicletero.Id from Bicicletero,Lector where  Bicicletero.Lector_Id = Lector.Id and Lector.Nombre = 'Lector2'));
INSERT INTO Zocalo (Bicicletero_Id) VALUES ((Select Bicicletero.Id from Bicicletero,Lector where  Bicicletero.Lector_Id = Lector.Id and Lector.Nombre = 'Lector2'));
INSERT INTO Zocalo (Bicicletero_Id) VALUES ((Select Bicicletero.Id from Bicicletero,Lector where  Bicicletero.Lector_Id = Lector.Id and Lector.Nombre = 'Lector2'));
INSERT INTO Zocalo (Bicicletero_Id) VALUES ((Select Bicicletero.Id from Bicicletero,Lector where  Bicicletero.Lector_Id = Lector.Id and Lector.Nombre = 'Lector2'));
