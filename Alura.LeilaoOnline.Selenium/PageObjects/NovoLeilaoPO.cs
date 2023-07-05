using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    internal class NovoLeilaoPO
    {
        private IWebDriver driver;

        private By ByInputTitulo;
        private By ByInputDescricao;
        private By ByInputCategoria;
        private By ByInputValorInicial;
        private By ByInputImagem;
        private By ByInputInicioPregao;
        private By ByInputTerminoPregao;
        private By ByBotaoSalvar;

        public IEnumerable<string> Categorias
        {
            get
            {
                var elementoCategoria = new SelectElement(driver.FindElement(By.Id("Categoria")));
                return elementoCategoria.Options
                    .Where(opt => opt.Enabled)
                    .Select(opt => opt.Text);
            }
        }

        public NovoLeilaoPO(IWebDriver driver)
        {
            this.driver = driver;
            ByInputTitulo = By.Id("Titulo");
            ByInputDescricao = By.Id("Descricao");
            ByInputCategoria = By.CssSelector(".select-dropdown:nth-child(1)");
            ByInputValorInicial = By.Id("ValorInicial");
            ByInputImagem = By.Id("ArquivoImagem");
            ByInputInicioPregao = By.Id("InicioPregao");
            ByInputTerminoPregao = By.Id("TerminoPregao");
            ByBotaoSalvar = By.CssSelector("button[type=submit]");
        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Leiloes/Novo");
        }

        public void PreencherFormulario(string titulo, string descricao, double valor, string imagem, DateTime inicio, DateTime termino)
        {
            driver.FindElement(ByInputTitulo).SendKeys(titulo);
            driver.FindElement(ByInputDescricao).SendKeys(descricao);
            var selectCategoria = driver.FindElement(ByInputCategoria);
            driver.FindElement(ByInputValorInicial).SendKeys(valor.ToString());
            driver.FindElement(ByInputImagem).SendKeys(imagem);
            driver.FindElement(ByInputInicioPregao).SendKeys(inicio.ToString("dd/MM/yyy"));
            driver.FindElement(ByInputTerminoPregao).SendKeys(termino.ToString("dd/MM/yyy"));
        }

        public void SubmetFormulario()
        {
            driver.FindElement(ByBotaoSalvar).Click();
        }
    }
}