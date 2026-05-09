-- Crear la base de datos si no existe
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'arq_per_db')
BEGIN
    CREATE DATABASE arq_per_db;
END
GO

USE arq_per_db;
GO

-- -----------------------------------------------------
-- Table: persona
-- -----------------------------------------------------
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'persona')
BEGIN
    CREATE TABLE persona (
        cc       INT           NOT NULL,
        nombre   VARCHAR(45)   NOT NULL,
        apellido VARCHAR(45)   NOT NULL,
        genero   CHAR(1)       NOT NULL,
        edad     INT           NULL,

        CONSTRAINT PK_persona PRIMARY KEY (cc),
        CONSTRAINT CHK_persona_genero CHECK (genero IN ('M', 'F'))
    );
END
GO

-- -----------------------------------------------------
-- Table: profesion
-- -----------------------------------------------------
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'profesion')
BEGIN
    CREATE TABLE profesion (
        id  INT           NOT NULL,
        nom VARCHAR(90)   NOT NULL,
        des VARCHAR(MAX)  NULL,

        CONSTRAINT PK_profesion PRIMARY KEY (id)
    );
END
GO

-- -----------------------------------------------------
-- Table: estudios
-- -----------------------------------------------------
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'estudios')
BEGIN
    CREATE TABLE estudios (
        id_prof INT          NOT NULL,
        cc_per  INT          NOT NULL,
        fecha   DATE         NULL,
        univer  VARCHAR(50)  NULL,

        CONSTRAINT PK_estudios PRIMARY KEY (id_prof, cc_per),

        CONSTRAINT FK_estudios_persona
            FOREIGN KEY (cc_per)
            REFERENCES persona (cc),

        CONSTRAINT FK_estudios_profesion
            FOREIGN KEY (id_prof)
            REFERENCES profesion (id)
    );
END
GO

-- Índice para la FK de persona en estudios
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_estudios_cc_per')
BEGIN
    CREATE INDEX IX_estudios_cc_per ON estudios (cc_per);
END
GO

-- -----------------------------------------------------
-- Table: telefono
-- -----------------------------------------------------
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'telefono')
BEGIN
    CREATE TABLE telefono (
        num    VARCHAR(15)  NOT NULL,
        oper   VARCHAR(45)  NOT NULL,
        duenio INT          NOT NULL,

        CONSTRAINT PK_telefono PRIMARY KEY (num),

        CONSTRAINT FK_telefono_persona
            FOREIGN KEY (duenio)
            REFERENCES persona (cc)
    );
END
GO

-- Índice para la FK de persona en telefono
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_telefono_duenio')
BEGIN
    CREATE INDEX IX_telefono_duenio ON telefono (duenio);
END
GO
