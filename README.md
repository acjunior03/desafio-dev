#PROJETO
Projeto desenvolvido com a finalidade de importar dados CNAB.txt, a fim de gravar 
estes dados em uma base de dados e exibí-los em tela para o usuario, informando o 
saldo atual de cada conta.

- WEBAPI/BACKOFFICE:
	Desenvolvido em ASP.Net Core (5.0) MVC, utilizando a arquitetura de desenvolvimento
	DDD (Domain Driven Design) e como base de dados utilizando o SQL Server. 
	E como documentação foi utilizada o Swagger (linguagem de descrição de interface 
	para descrever APIs RESTful expressas usando JSON)

- FRONT-END: 
	HTML + CSS
	JAVASCRIPT + JQUERY
	ASP.NET RAZOR PAGES

#REQUISITOS BÁSICOS
- Ter instalado e configurado SQL Server
- Ter instalado o IIS 7.5 ou superior (WINDOWS)
- Ter instalado o Apache (LINUX):
	- https://docs.microsoft.com/pt-br/aspnet/core/host-and-deploy/linux-apache?view=aspnetcore-5.0
- Caso o teste queira ser feito em modo de depuração, utilizar Visual Studio 2019 ou superior

#SETUP
- Através do SQL Server, executar o script do banco de dados localizado no diretório local:
	- /desafio-dev/DesafioDevWebAPI/Data/Scripts/
- Modificar string de conexão com o banco de dados no arquivo appsettings.json 
  localizado na pasta raiz do projeto DesafioDevWebAPI:
	- O parâmetro a ser modificado é "SqlConnection"
	
#UTILIZAÇÃO
- Devido a interface ser muito intuitiva e simples, não vi a necessidade de descrever um passo a passo para sua utilização