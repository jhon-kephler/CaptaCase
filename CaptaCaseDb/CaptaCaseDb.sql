CREATE DATABASE CaptaCaseDb;
GO

USE CaptaCaseDb;
GO

CREATE TABLE CustomerType(
    Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    TYPE VARCHAR(100) NOT NULL
);
GO

CREATE TABLE CustomerSituation(
    Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Situation VARCHAR(100) NOT NULL
);
GO

CREATE TABLE Customer(
    CPF VARCHAR(11) NOT NULL PRIMARY KEY, 
    Name VARCHAR(100) NOT NULL,
    CustomerTypeId INT NOT NULL,
    Gender VARCHAR(15) NOT NULL,
    CustomerSituationId INT NOT NULL,
    FOREIGN KEY (CustomerTypeId) REFERENCES CustomerType(Id),
    FOREIGN KEY (CustomerSituationId) REFERENCES CustomerSituation(Id)
);
GO
