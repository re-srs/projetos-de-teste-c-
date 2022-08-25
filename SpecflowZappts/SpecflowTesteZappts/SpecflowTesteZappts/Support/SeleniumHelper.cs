using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SpecFlowSelenium.Support;
using TechTalk.SpecFlow;

namespace SpecflowTesteZappts.Support
{


    //Essas classes sao uma forma refinada de chamar o selenium
    //Selenium tem varios comandos muito basicos que podem ser refinados para funcoes mais complexas
    //Voce pode sempre criar mais classes baseado nas que estao aqui presentes caso necessario
    //Essa sera sua biblioteca de comandos para manipular o selenium


    public class SeleniumHelper : IDisposable
    {
        public static IWebDriver CD;

        private static SeleniumHelper _instance;
        public WebDriverWait Wait;

        protected SeleniumHelper(ScenarioContext scenarioContext)
        {
            CD = scenarioContext["WEB_DRIVER"] as IWebDriver;
            Wait = new WebDriverWait(CD, TimeSpan.FromSeconds(30));
        }

        public static SeleniumHelper Instance(ScenarioContext scenarioContext)
        {

            _instance = new SeleniumHelper(scenarioContext);
            return _instance;
        }

        public string ObterUrl()
        {

            return CD.Url;
        }

        public void EsperarPorTexto(string texto)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(texto)));
        }

        public void EsperarPorId(string id)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));
        }

        public void EsperarPorCSS(string css)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(css)));
        }

        public bool ValidarConteudoUrl(string conteudo)
        {
            return Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains(conteudo));
        }

        public string NavegarParaUrl(string url)
        {
            CD.Navigate().GoToUrl(url);
            return CD.Url;
        }

        public void ClicarLinkPorTexto(string linkText)
        {
            var link = Wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(linkText)));
            link.Click();
        }

        internal void aceitarAlerta()
        {
            IAlert alert = Wait.Until(ExpectedConditions.AlertIsPresent());
            alert.Accept();
        }

        public void ClicarLinkPorXPath(string xpath)
        {
            var link = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            link.Click();
        }
        public void ClicarBotaoPorId(string botaoId)
        {
            var botao = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(botaoId)));
            botao.Click();
        }
        public void ClicarBotaoPorXPath(string xpath)
        {
            var botao = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            botao.Click();
        }
        public void ClicarBotaoPorCSS(string CSS)
        {
            var botao = Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(CSS)));
            botao.Click();
        }

        public void PreencherTextBoxPorId(string idCampo, string valorCampo)
        {
            var campo = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(idCampo)));
            campo.SendKeys(valorCampo);
        }
        public void PreencherTextBoxPorName(string nomeCampo, string valorCampo)
        {
            var campo = Wait.Until(ExpectedConditions.ElementIsVisible(By.Name(nomeCampo)));
            campo.SendKeys(valorCampo);
        }
        public void PreencherTextBoxPorXPath(string xpath, string valorCampo)
        {
            var campo = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            campo.SendKeys(valorCampo);
        }

        public void PreencherDropDownPorId(string idCampo, string valorCampo)
        {
            var campo = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(idCampo)));
            var selectElement = new SelectElement(campo);
            selectElement.SelectByValue(valorCampo);
        }
        public void PreencherDropDownPorName(string nomeCampo, string valorCampo)
        {
            var campo = Wait.Until(ExpectedConditions.ElementIsVisible(By.Name(nomeCampo)));
            var selectElement = new SelectElement(campo);
            selectElement.SelectByValue(valorCampo);
        }
        public string ObterTextoElementoPorClasse(string className)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(className))).Text;
        }

        public string ObterTextoElementoPorId(string id)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id))).Text;
        }

        public IEnumerable<IWebElement> ObterListaPorClasse(string className)
        {
            return Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.ClassName(className)));
        }

        public void ObterScreenShot(string nome)
        {
            var screenshot = ((ITakesScreenshot)CD).GetScreenshot();
            SalvarScreenShot(screenshot, string.Format("{0}_" + nome + ".png", DateTime.Now.ToFileTime()));
        }

        private void SalvarScreenShot(Screenshot screenshot, string fileName)
        {
            var path = ConfigurationHelper.FolderPicture;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            screenshot.SaveAsFile(string.Format("{0}{1}", ConfigurationHelper.FolderPicture, fileName),
                ScreenshotImageFormat.Png);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}