# PIM-Kontrola
Para rodar essa aplicação, você precisará atender aos seguintes requisitos básicos:

1. **.NET 6.0 SDK**: Certifique-se de ter o SDK do .NET 6.0 instalado em sua máquina. Você pode baixá-lo (https://dotnet.microsoft.com/download/dotnet/6.0).

2. **Visual Studio ou Visual Studio Code (VS Code)**: Você pode usar o Visual Studio ou o VS Code como seu ambiente de desenvolvimento. Ambos são compatíveis com projetos .NET.

3. **Banco de Dados (SQLite ou SQL Server)**: Sua aplicação parece usar o Entity Framework Core para acesso a dados. Certifique-se de ter um banco de dados configurado. Você pode escolher entre o SQLite ou o SQL Server. Se você deseja usar o SQLite, certifique-se de ter o pacote `Microsoft.EntityFrameworkCore.Sqlite` instalado. Se você deseja usar o SQL Server, certifique-se de ter o pacote `Microsoft.EntityFrameworkCore.SqlServer` instalado.

4. **Pacotes NuGet**:
                        Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="6.0.25"
                        Microsoft.EntityFrameworkCore.Design" Version="7.0.10"
                        Microsoft.EntityFrameworkCore.Sqlite" Version="6.0.29"
                        Microsoft.EntityFrameworkCore.SqlServer" Version="7.0.10"
                        Microsoft.EntityFrameworkCore.Tools" Version="7.0.10"
                        Microsoft.VisualStudio.Web.CodeGeneration.Design" Version="6.0.16"
                        ReflectionIT.Mvc.Paging" Version="6.0.1"

5. **Ferramentas de Geração de Código**: Se você planeja gerar código (por exemplo, scaffolding de controladores), certifique-se de ter o pacote `Microsoft.VisualStudio.Web.CodeGeneration.Design` instalado.

6. **Configuração do ambiente**: Verifique se você configurou corretamente as variáveis de ambiente necessárias, como a string de conexão do banco de dados e outras configurações específicas do seu aplicativo.

7. **sistema operacional**: No desenvolmimento do projeto foi utilizado na criação foi o Windows 11 Home, mas o ASP.NET Core 6.0 já oferece suporte ao ambiente Linux conforme documentação da microsoft - https://dotnet.microsoft.com/pt-br/download/dotnet/6.0 
🚀
