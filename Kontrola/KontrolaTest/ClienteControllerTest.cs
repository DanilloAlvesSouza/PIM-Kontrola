using System.Threading.Tasks;
using Kontrola.Controllers;
using Kontrola.Context;
using Kontrola.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Kontrola.Tests
{
    namespace Kontrola.Tests
    {
        public class ClientesControllerTests
        {
            [Fact]
            public async Task Details_ReturnsNotFound_WhenIdIsNull()
            {
                // Arrange
                var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                    .UseInMemoryDatabase(databaseName: "TestDatabase")
                    .Options;

                using (var context = new AppDbContext(dbContextOptions))
                {
                    var controller = new ClientesController(context);

                    // Act
                    var result = await controller.Details(null);

                    // Assert
                    Assert.IsType<NotFoundResult>(result);
                }
            }

            [Fact]
            public async Task Details_ReturnsNotFound_WhenClienteNotFound()
            {
                // Arrange
                var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                    .UseInMemoryDatabase(databaseName: "TestDatabase")
                    .Options;

                using (var context = new AppDbContext(dbContextOptions))
                {
                    // Adicione um cliente fictício com ID 1
                    context.Clientes.Add(new Cliente { ClienteId = 1 });
                    context.SaveChanges();

                    var controller = new ClientesController(context);

                    // Act
                    var result = await controller.Details(2); // ID inexistente

                    // Assert
                    Assert.IsType<NotFoundResult>(result);
                }
            }
        }
        // Você também pode adicionar mais testes para verificar o comportamento quando o cliente é encontrado.
    }
}

