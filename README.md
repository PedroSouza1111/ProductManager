# ProductManager

CP2 - Pedro Henrique de Souza

# ProductManager

API RESTful em .NET para gerenciamento de produtos, usando arquitetura em camadas, documentação Swagger e integração com banco de dados Oracle via Entity Framework Core.

---

## 🧱 Estrutura da Solução

- `ProductManager.Api` - Projeto principal da Web API.
- `ProductManager.Application` - Contém a lógica de negócio (serviços).
- `ProductManager.Domain` - Contém entidades e interfaces.
- `ProductManager.Infrastructure` - Responsável pelo acesso a dados e integração com o Oracle.

---

## 📦 Instalação

### Pré-requisitos:

- .NET 8 SDK instalado
- Banco Oracle acessível
- VS Code ou Visual Studio

### Passos:

1. Clone o repositório

2. Restaure os pacotes e crie a base de dados:

dotnet restore
dotnet ef migrations add InitialCreate -p ProductManager.Infrastructure -s ProductManager.Api
dotnet ef database update -p ProductManager.Infrastructure -s ProductManager.Api

3. Execute a aplicação:

dotnet run --project ProductManager.Api
