using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Chrome;
using Xunit;
using Alura.LeilaoOnline.Selenium.Helpers;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium.Chromium;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    public class AoNavegarParaHomeMobile : IDisposable
    {
        private ChromeDriver driver;

        public AoNavegarParaHomeMobile()
        {
        }

        [Fact]
        public void DadaLargura992DeveMonstarMenuMobile()
        {
            // Arragen
            var deviceSettings = new ChromiumMobileEmulationDeviceSettings();
            deviceSettings.Width = 992;
            deviceSettings.Height = 800;
            deviceSettings.UserAgent = "Customizada";

            var options = new ChromeOptions();
            options.EnableMobileEmulation(deviceSettings);

            driver = new ChromeDriver(TestHelper.PastaDoExecutavel, options);

            var homePo = new HomeNaoLogadaPO(driver);

            // Act
            homePo.Visitar();

            // Assert
            Assert.True(homePo.Menu.MenuMobileVisivel);
        }

        [Fact]
        public void DadaLargura993NaoDeveMonstarMenuMobile()
        {
            // Arragen
            var deviceSettings = new ChromiumMobileEmulationDeviceSettings();
            deviceSettings.Width = 993;
            deviceSettings.Height = 800;
            deviceSettings.UserAgent = "Customizada";

            var options = new ChromeOptions();
            options.EnableMobileEmulation(deviceSettings);

            driver = new ChromeDriver(TestHelper.PastaDoExecutavel, options);

            var homePo = new HomeNaoLogadaPO(driver);

            // Act
            homePo.Visitar();

            // Assert
            Assert.False(homePo.Menu.MenuMobileVisivel);
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
