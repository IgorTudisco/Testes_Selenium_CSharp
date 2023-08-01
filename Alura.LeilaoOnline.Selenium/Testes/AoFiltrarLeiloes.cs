using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoFiltrarLeiloes
    {
        private IWebDriver driver;

        public AoFiltrarLeiloes(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginInteressadaDeveMostrarPainelResultado()
        {
            // Arrange
            new LoginPO(driver).EfetuarLoginComCredenciais("fulano@example.org", "123");
            var dashboardPO = new DashboardInteressadaPO(driver);

            // Act
            dashboardPO.Filtro.PesquisaLeiloes(
                new List<string> { "Arte", "Coleções" },
                "",
                true);

            // Assert
            Assert.Contains("Resultado da pesquisa", driver.PageSource);

        }

    }
}
