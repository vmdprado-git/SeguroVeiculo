1-DB utilizado SQL Server (Express)
	Criar DB: SeguroVeiculo
	Executar:	
		dotnet ef migrations add InitialCreate
		dotnet ef database update

2-Todos os serviços foram construídos
	dotnet watch run --project src/SeguroVeiculo.Api

3-O relatório foi construído e está disponível no projeto MVC2
	Em SeguroVeiculo.Mvc
	Executar:
		dotnet run

4-Dados do segurado estão disponíveis através do JSON Server
	json-server --watch db.json --port 3001

5-Testes automatizados
	Em SeguroVeiculo.Tests
	Executar:
		dotnet test

6-Hospedagem em qualquer uma das opções	