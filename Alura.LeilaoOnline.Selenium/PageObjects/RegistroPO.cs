using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class RegistroPO
    {
        private IWebDriver driver;
        private By byFormRegistro;
        private By byInputName;
        private By byInputEmail;
        private By byInputSenha;
        private By byInputConfirmSenha;
        private By byBotaoRegistro;
        private By bySpanErrorNome;
        private By bySpanErrorEmail;

        public string NomeMensageErro => driver.FindElement(bySpanErrorNome).Text;
        public string EmailMensageErro => driver.FindElement(bySpanErrorEmail).Text;

        public RegistroPO(IWebDriver driver)
        {
            this.driver = driver;
            byFormRegistro = By.TagName("form");
            byInputName = By.Id("Nome");
            byInputEmail = By.Id("Email");
            byInputSenha = By.Id("Password");
            byInputConfirmSenha = By.Id("ConfirmPassword");
            byBotaoRegistro = By.Id("btnRegistro");
            bySpanErrorNome = By.CssSelector("span.msg-erro[data-valmsg-for=Nome]");
            bySpanErrorEmail = By.CssSelector("span.msg-erro[data-valmsg-for=Email]");
        }

        public void Navegar()
        {
            driver.Navigate().GoToUrl("http://localhost:5000");
        }

        public void SubmeteFomulario()
        {
            driver.FindElement(byBotaoRegistro).Click();
        }

        public void PreencherFormulario(string Nome, string Email, string Senha, string ConfirmSenha)
        {
            driver.FindElement(byInputName).SendKeys(Nome);
            driver.FindElement(byInputEmail).SendKeys(Email);
            driver.FindElement(byInputSenha).SendKeys(Senha);
            driver.FindElement(byInputConfirmSenha).SendKeys(ConfirmSenha);
        }
    }
}
