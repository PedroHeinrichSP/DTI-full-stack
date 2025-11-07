# DTI-full-stack
 Interface do usuário de gerenciamento de leads para uma empresa. Um aplicativo de página única (SPA) usando uma estrutura JS moderna (React), apoiada por .Net Core Web API e usando banco de dados SQL Server.

## Como executar

### Requisitos

| Ferramenta                                                         | Versão        |
| ------------------------------------------------------------------ | ------------- |
| [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) | 8.0           |
| [Node.js](https://nodejs.org/en/)                                  | 20.x          |
| npm                                                                | 10.x          |
| SQL Server                                                         | 2019+         |
| **Entity Framework Core Tools (`dotnet-ef`)**                      | 8.0+          |


### Clonar o repositório

```bash
git clone https://github.com/PedroHeinrichSP/DTI-full-stack.git
cd DTI-full-stack
```

### Windows
- Verifique se o SQL Server está rodando
- Confirme se o arquivo `backend/LeadManager.Api/appsettings.json` está com o seguinte String de conexão:
```json
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Database=LeadManagerDB;Trusted_Connection=True;TrustServerCertificate=True;"
    }
```
- Se estiver usando SQLExpress deve estar assim:

```json
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=LeadManagerDB;Trusted_Connection=True;TrustServerCertificate=True;"
    }
```

- Na pasta `backend` execute para criar o banco de dados e executar o backend:

```bash
cd backend
dotnet restore
dotnet tool install --global dotnet-ef --version 8.*
dotnet ef database update --project LeadManager.Infrastructure --startup-project LeadManager.Api
dotnet run --project LeadManager.Api
```
Swagger disponível em: [localhost:5197/swagger](localhost:5197/swagger)

- Num outro terminal para executar o frontend:

```bash
cd frontend/lead-manager-ui
npm install
npm run dev
```

Acesse pelo navegador em: [http://localhost:5173/](http://localhost:5173/)


#### Testes unitários
- Na pasta `backend`:

```bash
dotnet test
```

#### Emails falsos
- Os emails falsos são criados no arquivo `backend/LeadManager.Api/bin/Debug/net8.0/emails_sent.txt`