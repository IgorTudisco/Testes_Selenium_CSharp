using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoNavegarParaHome
    {
        private IWebDriver driver;

        //Setup
        public AoNavegarParaHome(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarLeiloesNoTitulo()
        {
            //arrange

            //act
            driver.Navigate().GoToUrl("http://localhost:5000");

            //assert
            Assert.Contains("Leil�es", driver.Title);
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarProximosLeiloesNaPagina()
        {
            //arrange

            //act
            driver.Navigate().GoToUrl("http://localhost:5000");

            //assert
            Assert.Contains("Pr�ximos Leil�es", driver.PageSource);
        }

        [Fact]
        public void DadoChromeAbertoNaoDeveMostrarMensagemDeErro()
        {
            //arrange

            //act
            driver.Navigate().GoToUrl("http://localhost:5000");
            var form = driver.FindElement(By.TagName("form"));
            var spans = form.FindElements(By.TagName("span"));

            //assert
            foreach (var span in spans)
            {
                Assert.True(string.IsNullOrEmpty(span.Text));
            }
        }
    }
}