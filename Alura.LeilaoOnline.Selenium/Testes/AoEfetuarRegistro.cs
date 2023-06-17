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
    public class AoEfetuarRegistro
    {

        private IWebDriver driver;
        private RegistroPO registroPO;

        public AoEfetuarRegistro(TestFixture fixture)
        {
            driver = fixture.Driver;
            registroPO = new RegistroPO(driver);
        }

        [Fact]
        public void TesteRegistro()
        {
            // Arrange
            registroPO.Navegar();

            // Get element
            registroPO.PreencherFormulario(
                Nome: "Igor",
                Email: "Igor@aluraestudos.com",
                Senha: "123",
                ConfirmSenha: "123"
            );

            // Act
            registroPO.SubmeteFomulario();

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
            registroPO.Navegar();

            // Get element
            registroPO.PreencherFormulario(
                Nome: nome,
                Email: email,
                Senha: senha,
                ConfirmSenha: confirmSenha
            );

            // Act
            registroPO.SubmeteFomulario();

            // Assert
            Assert.Contains("section-registro", driver.PageSource);

        }

        [Fact]
        public void TesteMostraMensagemErroNoNome()
        {
            // Arrange
            registroPO.Navegar();

            // Act
            registroPO.SubmeteFomulario();

            // Assert
            Assert.Equal("The Nome field is required.", registroPO.NomeMensageErro);
        }

        [Fact]
        public void TesteMostraMensagemErroNoEmail()
        {
            // Arrange
            registroPO.Navegar();

            registroPO.PreencherFormulario(
                Nome: "",
                Email: "Igor",
                Senha: "",
                ConfirmSenha: ""
            );
            
            // Act
            registroPO.SubmeteFomulario();

            // Assert
            Assert.Equal("Please enter a valid email address.", registroPO.EmailMensageErro);
        }
    }
}
