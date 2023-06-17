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
    public class AoEfetuarLogin
    {
        private IWebDriver driver;
        private LoginPO loginPO;

        public AoEfetuarLogin(TestFixture fixture)
        {
            driver = fixture.Driver;
            loginPO = new LoginPO(driver);
        }

        [Fact]
        public void DadosCredenciaisValidasDeveIrParaDashboard()
        {
            // 
            loginPO.Navagar();
            loginPO.PreencheFormulario("fulano@example.org", "123");

            // Act
            loginPO.SubmeteFormulario();

            // Assert
            Assert.Contains("Dashboard", driver.Title);
        }

        [Fact]
        public void DadosCredenciaisInvalidasDeveContinuarNaPageLogin()
        {
            // 
            loginPO.Navagar();
            loginPO.PreencheFormulario("fulano@example.org", "1234");

            // Act
            loginPO.SubmeteFormulario();

            // Assert
            Assert.Contains("Login", driver.PageSource);
        }

    }
}
