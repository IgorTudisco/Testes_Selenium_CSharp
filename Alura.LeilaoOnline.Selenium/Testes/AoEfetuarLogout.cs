using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarLogout
    {
        private IWebDriver driver;

        public AoEfetuarLogout(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void TesteDadoLoginValidoDeveIrParaHomeLogada()
        {
            // Arrange
            new LoginPO(driver)
                .Visitar()
                .InformarEmail("fulano@example.org")
                .InformarSenha("123")
                .EfetuarLogin();

            var dashboardPO = new DashboardInteressadaPO(driver);

            // Act
            dashboardPO.Menu.EfetuarLogout();

            // Assert

            Assert.Contains("Próximos Leilões", driver.PageSource);

        }

    }
}
