using Kontrola.Controllers;
using Kontrola.Context;
using Kontrola.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task RetornaNulQuandoIdNaoExiste()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new AppDbContext(dbContextOptions))
            {
                var controller = new ClientesController(context);

                // add cliente mock com ID 1
                context.Clientes.Add(new Cliente { ClienteId = 1, Nome = "Nome", Cnpj = "12121211", email = "email@teste.com", Telefone = "11111111" });
                context.SaveChanges();

                // Act
                var result = await controller.Details(2); // ID inexistente

                // Assert
                Assert.IsType<NotFoundResult>(result);
            }
        }

        [Fact]
        public async Task CriaClienteComSucesso()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new AppDbContext(dbContextOptions))
            {
                var controller = new ClientesController(context);
                var cliente = new Cliente { ClienteId = 1, Nome = "Nome", Cnpj = "12121211", email = "email@teste.com", Telefone = "11111111" };

                // Act
                var result = await controller.Create(cliente);

                // Assert
                var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
                Assert.Equal(nameof(ClientesController.Index), redirectToActionResult.ActionName);
            }
        }

        [Fact]
        public async Task CriaClienteComResultadoInvalido()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new AppDbContext(dbContextOptions))
            {
                var controller = new ClientesController(context);
                var cliente = new Cliente();

                // Act and Assert
                await Assert.ThrowsAsync<InvalidOperationException>(() => controller.Create(cliente));
            }
        }


        [Fact]
        public async Task DeletaClienteComSucesso()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new AppDbContext(dbContextOptions))
            {
                context.Clientes.Add(new Cliente { ClienteId = 1, Nome = "NomExemplo", Cnpj = "12121211", email = "email@teste.com", Telefone = "11111111" });
                context.SaveChanges();

                var controller = new ClientesController(context);

                // Act
                var result = await controller.Delete(1); 

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                Assert.IsType<ViewResult>(viewResult);
            }
        }

        [Fact]
        public async Task DeletaClienteFalha()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new AppDbContext(dbContextOptions))
            {
                var controller = new ClientesController(context);

                // Act
                var result = await controller.Delete(2); // ID inválido

                // Assert
                Assert.IsType<NotFoundResult>(result);
            }
        }
    }
}


