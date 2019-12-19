
CREATE TABLE Produto(
    id int PRIMARY KEY IDENTITY (1, 1),
    Nome VARCHAR (128) NOT NULL DEFAULT '',
    Qtd INT NOT NULL DEFAULT 0,
    Excluido BIT NOT NULL DEFAULT 0,
    Criado_em DATETIME NOT NULL DEFAULT GETDATE(),
    Alterado_em DATETIME NOT NULL DEFAULT GETDATE(),
)

INSERT INTO Produto (Nome) VALUES('Produto A')
INSERT INTO Produto (Nome) VALUES('Produto B')
INSERT INTO Produto (Nome) VALUES('Produto C')
INSERT INTO Produto (Nome) VALUES('Produto D')
INSERT INTO Produto (Nome) VALUES('Produto E')