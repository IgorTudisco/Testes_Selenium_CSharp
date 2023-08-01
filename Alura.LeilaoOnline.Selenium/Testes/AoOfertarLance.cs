using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoOfertarLance
    {
        private IWebDriver driver;

        public AoOfertarLance(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginInteressadaDeveAtulaizarLanceAtual()
        {
            // Arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("fulano@example.org", "123");
            loginPO.SubmeteFormulario();
            var dashboardPO = new DashboardInteressadaPO(driver);

            var detalherPO = new DetalheLeilaoPO(driver);
            detalherPO.Visitar(2); // in progress

            // Act
            detalherPO.OfertarLance(300);

            // Assert

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            // This function waits until the conditional is true or the timeout is finished
            bool equalValor = wait.Until(drv => detalherPO.LanceAtual == 300);

            Assert.True(equalValor);
        }
    }
}
