using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoCriarLeilao
    {
        private IWebDriver driver;

        public AoCriarLeilao(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginAdminEinfosValidasDeveCadastrarLeilao()
        {
            var loginPo = new LoginPO(driver);
            loginPo.Visitar();
            loginPo.PreencheFormulario("admin@example.org", "123");
            loginPo.SubmeteFormulario();

            var novoLeilaoPo = new NovoLeilaoPO(driver);
            novoLeilaoPo.Visitar();
            novoLeilaoPo.PreencherFormulario("Leilão de Coleção 1", "Lorem Ipsum when an unknown printer took a galley of type and scrambled it to make a type specimen book. ", 4000, "C:\\Users\\igort\\Pictures\\boaz.PNG", DateTime.Now.AddDays(10), DateTime.Now.AddDays(20));

            // Thread.Sleep(3000);

            novoLeilaoPo.SubmetFormulario();

            Assert.Contains("Leilões cadastrados no sistema", driver.PageSource);

        }

    }
}
