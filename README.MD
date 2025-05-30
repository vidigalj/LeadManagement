LeadManagement
Setup do Sistema
Pr�-requisitos
�	.NET 8.0 SDK
�	SQL Server (ou outro banco de dados compat�vel)
�	Visual Studio 2022 (ou outro IDE compat�vel)
Passos para Configura��o
1.	Clone o reposit�rio:
   git clone https://github.com/seu-usuario/LeadManagement.git
   cd LeadManagement
2.	Restaurar pacotes NuGet:
No diret�rio raiz do projeto, execute o comando:
   dotnet restore
3.	Configurar a string de conex�o:
Abra o arquivo appsettings.json no projeto LeadManagement.API e configure a string de conex�o para o seu banco de dados local:
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=LeadManagementDb;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
   }    
4.	Aplicar as migra��es do banco de dados:
No diret�rio do projeto LeadManagement.API, execute os seguintes comandos para aplicar as migra��es e criar o banco de dados:
    dotnet ef database update
5.	Executar o projeto:
No diret�rio raiz do projeto, execute o comando:
  dotnet run --project LeadManagement.API
O projeto estar� dispon�vel em https://localhost:5001 ou http://localhost:5000.

Criar Banco Local para Testes
1.	Configurar a string de conex�o para testes:
Abra o arquivo appsettings.Development.json no projeto LeadManagement.API e configure a string de conex�o para o seu banco de dados de testes:
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=LeadManagementTestDb;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
   }
2.	Aplicar as migra��es do banco de dados de testes:
No diret�rio do projeto LeadManagement.API, execute os seguintes comandos para aplicar as migra��es e criar o banco de dados de testes:   
   dotnet ef database update --context TestDbContext

Estrutura do Projeto
�	LeadManagement.API: Cont�m a API do projeto.
�	LeadManagement.Application: Cont�m a l�gica de aplica��o, incluindo handlers e valida��es.
�	LeadManagement.Domain: Cont�m as entidades de dom�nio e eventos.
�	LeadManagement.Infra: Cont�m a camada de infraestrutura, incluindo reposit�rios e mapeamentos.
�	LeadManagement.IoC: Cont�m a configura��o de inje��o de depend�ncia.