LeadManagement
Setup do Sistema
Pré-requisitos
•	.NET 8.0 SDK
•	SQL Server (ou outro banco de dados compatível)
•	Visual Studio 2022 (ou outro IDE compatível)
Passos para Configuração
1.	Clone o repositório:
   git clone https://github.com/seu-usuario/LeadManagement.git
   cd LeadManagement
2.	Restaurar pacotes NuGet:
No diretório raiz do projeto, execute o comando:
   dotnet restore
3.	Configurar a string de conexão:
Abra o arquivo appsettings.json no projeto LeadManagement.API e configure a string de conexão para o seu banco de dados local:
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=LeadManagementDb;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
   }    
4.	Aplicar as migrações do banco de dados:
No diretório do projeto LeadManagement.API, execute os seguintes comandos para aplicar as migrações e criar o banco de dados:
    dotnet ef database update
5.	Executar o projeto:
No diretório raiz do projeto, execute o comando:
  dotnet run --project LeadManagement.API
O projeto estará disponível em https://localhost:5001 ou http://localhost:5000.

Criar Banco Local para Testes
1.	Configurar a string de conexão para testes:
Abra o arquivo appsettings.Development.json no projeto LeadManagement.API e configure a string de conexão para o seu banco de dados de testes:
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=LeadManagementTestDb;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
   }
2.	Aplicar as migrações do banco de dados de testes:
No diretório do projeto LeadManagement.API, execute os seguintes comandos para aplicar as migrações e criar o banco de dados de testes:   
   dotnet ef database update --context TestDbContext

Estrutura do Projeto
•	LeadManagement.API: Contém a API do projeto.
•	LeadManagement.Application: Contém a lógica de aplicação, incluindo handlers e validações.
•	LeadManagement.Domain: Contém as entidades de domínio e eventos.
•	LeadManagement.Infra: Contém a camada de infraestrutura, incluindo repositórios e mapeamentos.
•	LeadManagement.IoC: Contém a configuração de injeção de dependência.