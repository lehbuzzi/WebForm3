CREATE PROC PessoaListarById
@IdPessoa int
AS
	BEGIN
	SELECT *
	FROM Pessoa
	WHERE IdPessoa = @IdPessoa
	END