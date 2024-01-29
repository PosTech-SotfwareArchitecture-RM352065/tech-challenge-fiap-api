USE [master]
GO

CREATE DATABASE dbo
GO

CREATE TABLE Clientes (
    Id      UNIQUEIDENTIFIER    NOT NULL
,   Tipo    INT                 NOT NULL
,   Cpf     VARCHAR(11)         NOT NULL
,   Nome    VARCHAR(50)         NOT NULL
,   Email   VARCHAR(50)         NOT NULL
,   CONSTRAINT Pk_Clientes PRIMARY KEY NONCLUSTERED (Id)
,   CONSTRAINT Uk1_Clientes UNIQUE CLUSTERED (Cpf)
)
GO

CREATE TABLE Produtos (
    Id          UNIQUEIDENTIFIER    NOT NULL
,   Categoria   INT                 NOT NULL
,   Nome        VARCHAR(50)         NOT NULL
,   Descricao   VARCHAR(100)        NOT NULL
,   Preco       DECIMAL(18, 2)      NOT NULL
,   Ativo       BIT                 NOT NULL DEFAULT (1)
,   CONSTRAINT Pk_Produtos PRIMARY KEY NONCLUSTERED (Id) 
,   CONSTRAINT Uk1_Produtos UNIQUE CLUSTERED (Descricao)
)
GO

CREATE TABLE Pedidos (
    Id          UNIQUEIDENTIFIER    NOT NULL
,   Numero      INT                 NOT NULL
,   ClienteId   UNIQUEIDENTIFIER        NULL
,   CriadoEm    DATETIME            NOT NULL DEFAULT (CURRENT_TIMESTAMP)
,   CONSTRAINT Pk_Pedidos PRIMARY KEY NONCLUSTERED (Id)
,   CONSTRAINT Fk1_Pedidos FOREIGN KEY (ClienteId) REFERENCES Clientes (Id)
)
GO

CREATE TABLE ItensPedido (
    Id          UNIQUEIDENTIFIER    NOT NULL
,   PedidoId    UNIQUEIDENTIFIER    NOT NULL
,   Codigo      INT                 NOT NULL
,   ProdutoId   UNIQUEIDENTIFIER    NOT NULL
,   Preco       DECIMAL(18, 2)      NOT NULL
,   CONSTRAINT Pk_ItensPedido PRIMARY KEY NONCLUSTERED (Id)
,   CONSTRAINT Fk1_ItensPedido FOREIGN KEY (PedidoId) REFERENCES Pedidos (Id)
,   CONSTRAINT Fk2_ItensPedido FOREIGN KEY (ProdutoId) REFERENCES Produtos (Id)
,   INDEX Ak1_ItensPedido CLUSTERED (PedidoId)
)
GO