using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class MenuLogadoPO
    {
        private IWebDriver  driver;
        private By byLogoutLink;
        private By byMeuPerfilLink;
        private By byTableValor;

        public MenuLogadoPO(IWebDriver driver)
        {
            this.driver = driver;
            byLogoutLink = By.Id("logout");
            byMeuPerfilLink = By.Id("meu-perfil");
            // XPath is used to find an element whose references are dynamic
            byTableValor = By.XPath("//div[@class='card minhas-ofertas']/*/table/tbody/tr[last()]");
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
