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
    public class AoNavegarParaFormNovoLeilao
    {
        private IWebDriver driver;

        public AoNavegarParaFormNovoLeilao(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginAdmDeveMostrarTresCategorias()
        {
            var loginPo = new LoginPO(driver);
            loginPo.Visitar();
            loginPo.PreencheFormulario("admin@example.org", "123");
            loginPo.SubmeteFormulario();
            var novoLeilaoPo = new NovoLeilaoPO(driver);

            novoLeilaoPo.Visitar();

            Assert.Equal(3, novoLeilaoPo.Categorias.Count());
        }

    }
}
