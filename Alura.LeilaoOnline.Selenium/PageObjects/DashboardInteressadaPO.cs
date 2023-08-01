using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DashboardInteressadaPO
    {
        private IWebDriver driver;
        private By byLogoutLink;
        private By byMeuPerfilLink;
        private By bySelectCategorias;
        private By byInputTermo;
        private By byInputAndamento;
        private By byBotaoPesquisar;

        public DashboardInteressadaPO(IWebDriver driver)
        {
            this.driver = driver;
            byLogoutLink = By.Id("logout");
            byMeuPerfilLink = By.Id("meu-perfil");
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

            if(emAndamento)
            {
                driver.FindElement(byInputAndamento).Click();
            }

            driver.FindElement(byBotaoPesquisar).Click();

        }

        public void EfetuarLogout()
        {
            // To click on the hidden element, we must follow the steps to get to it.
            var linkMeuPerfil = driver.FindElement(byMeuPerfilLink);
            var linkLogout = driver.FindElement(byLogoutLink);
            driver.Manage().Window.Size = new Size(1024, 768);

            IAction acaoLogout = new Actions(driver)
                //mover para o elemento meu-perfil
                .MoveToElement(linkMeuPerfil)
                //mover para o link de logout
                .MoveToElement(linkLogout)
                //clicar no link de logout
                .Click()
                .Build();

            acaoLogout.Perform();

        }

    }
}
