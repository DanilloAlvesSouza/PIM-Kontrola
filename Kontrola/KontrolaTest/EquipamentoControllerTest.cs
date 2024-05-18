using Kontrola.Context;
using Kontrola.Controllers;
using Kontrola.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontrolaTest
{
    public class EquipamentoControllerTest
    {
        [Fact]
        public async Task Details_ReturnsNotFound_WhenEquipamentoNotFound()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new AppDbContext(dbContextOptions))
            {
                // Adicione um equipamento fictício com ID 1
                context.Equipamentos.Add(new Equipamento { EquipamentoId = 1, Marca = "MarcaX", Modelo = "ModeloY" });
                context.SaveChanges();

                var controller = new EquipamentosController(context);

                // Act
                var result = await controller.Details(2); // ID inexistente

                // Assert
                Assert.IsType<NotFoundResult>(result);
            }
        }
    }
}
