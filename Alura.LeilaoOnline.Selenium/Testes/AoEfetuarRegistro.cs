using Alura.LeilaoOnline.Selenium.Fixtures;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarRegistro
    {

        private IWebDriver driver;

        public AoEfetuarRegistro(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void TesteRegistro()
        {
            // Arrange
            driver.Navigate().GoToUrl("http://localhost:5000");

            // Get element
            var inputNome = driver.FindElement(By.Id("Nome"));
            var inputEmail = driver.FindElement(By.Id("Email"));
            var inputSenha = driver.FindElement(By.Id("Password"));
            var inputConfirmSenha = driver.FindElement(By.Id("ConfirmPassword"));
            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            inputNome.SendKeys("Igor");
            inputEmail.SendKeys("Igor@aluraestudos.com");
            inputSenha.SendKeys("123");
            inputConfirmSenha.SendKeys("123");

            // Act
            botaoRegistro.Click();

            // Assert
            Assert.Contains("Obrigado", driver.PageSource);

        }

        [Theory]
        [InlineData("Igor", "igor", "123", "123")]
        [InlineData("", "Igor@aluraestudos.com", "1234", "1234")]
        [InlineData("Igor", "Igor@aluraestudos.com", "", "1235")]
        [InlineData("Igor", "Igor@aluraestudos.com", "1235", "")]
        [InlineData("Igor", "Igor@aluraestudos.com", "1235", "125")]
        public void TesteRegistroDadosInvalidos(string nome, string email, string senha, string confirmSenha)
        {
            // Arrange
            driver.Navigate().GoToUrl("http://localhost:5000");

            // Get element
            var inputNome = driver.FindElement(By.Id("Nome"));
            var inputEmail = driver.FindElement(By.Id("Email"));
            var inputSenha = driver.FindElement(By.Id("Password"));
            var inputConfirmSenha = driver.FindElement(By.Id("ConfirmPassword"));
            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            inputNome.SendKeys(nome);
            inputEmail.SendKeys(email);
            inputSenha.SendKeys(senha);
            inputConfirmSenha.SendKeys(confirmSenha);

            // Act
            botaoRegistro.Click();

            // Assert
            Assert.Contains("section-registro", driver.PageSource);

        }
    }
}
