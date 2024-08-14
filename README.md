# contatos

docker compose -f .\deploy\docker-compose.yaml -p fase1 up -d --build

dotnet ef migrations add BaseInicial -p .\src\Fase1.Contatos.Infra.Data\Fase1.Contatos.Infra.Data.csproj -s .\src\Fase1.Contatos.Api\Fase1.Contatos.Api.csproj -c ContatoDbContext -o Migrations

dotnet ef database update -p .\src\Fase1.Contatos.Infra.Data\Fase1.Contatos.Infra.Data.csproj -s .\src\Fase1.Contatos.Api\Fase1.Contatos.Api.csproj -c ContatoDbContext