using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class FiltroLeiloesPO
    {
        private IWebDriver driver;
        private By bySelectCategorias;
        private By byInputTermo;
        private By byInputAndamento;
        private By byBotaoPesquisar;

        public FiltroLeiloesPO(IWebDriver driver)
        {
            this.driver = driver;
            bySelectCategorias = By.ClassName("select-wrapper");
            byInputTermo = By.Id("termo");
            byInputAndamento = By.ClassName("switch");
            byBotaoPesquisar = By.CssSelector("form>button.btn");
        }


        // As the element is invisible in CSS Materialize, we have to use this method to work around the problem and find the elements
        public void PesquisaLeiloes(List<string> categorias, string termo, bool emAndamento)
        {
            var select = new SelectMaterialize(driver, bySelectCategorias);
            select.DeselectAll();
            categorias.ForEach(categ =>
            {
                select.SelectByText(categ);

            });

            driver.FindElement(byInputTermo).SendKeys(termo);

            if (emAndamento)
            {
                driver.FindElement(byInputAndamento).Click();
            }

            driver.FindElement(byBotaoPesquisar).Click();

        }
    }
}
