using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.Helpers
{
    public class SelectMaterialize
    {
        private IWebDriver driver;
        private IWebElement selectWrapper;
        private IEnumerable<IWebElement> opcoes;

        public SelectMaterialize(IWebDriver driver, By locatorSelectWrapper)
        {
            this.driver = driver;
            this.selectWrapper = driver.FindElement(locatorSelectWrapper);
            opcoes = selectWrapper.FindElements(By.CssSelector("li>span"));
        }

        public IEnumerable<IWebElement> Options => opcoes;

        public void OpenWrapper()
        {
            selectWrapper.Click();
        }

        public void LoseFocus()
        {
            selectWrapper.FindElement(By.TagName("li")).SendKeys(Keys.Tab);
        }

        public void DeselectAll()
        {
            OpenWrapper();
            // Deselect categories
            opcoes.ToList().ForEach(o => { o.Click(); });
        }

        public void SelectByText(string option)
        {
            OpenWrapper();
            opcoes
                .Where(o => o.Text.Contains(option))
                .ToList()
                .ForEach(o => { o.Click(); });
            LoseFocus();
        }
    }
}
