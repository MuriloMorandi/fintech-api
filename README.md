## Comandos

### 📚  Gerenciamento do Banco de Dados

Este guia fornece os principais comandos do **Entity Framework Core (EF Core)** para criar, atualizar e gerenciar seu banco de dados através de migrations.

---

#### 🚀 Comandos para Migrations e Banco de Dados

##### 1️⃣ **Adicionar uma Migration**
Para criar uma nova migration que representa mudanças no modelo de dados:

```bash
  dotnet ef migrations add ${nomeMigration} --project src/Aplicacao.Infra --startup-project src/Aplicacao.API
```

```bash
  dotnet ef database update --project src/Aplicacao.Infra --startup-project src/Aplicacao.API
```


