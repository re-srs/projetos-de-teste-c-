using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SpecflowTesteZappts.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        [Binding]
        class Setup
        {
            //Before executa antes de todos os testes, iniciando o chromedriver
            [Before]
            public void CreateWebDriver(ScenarioContext context)
            {
                // Configuracao para usar o chrome como navegador do Selenium
                var options = new ChromeOptions();
                options.AddArgument("--start-maximized");
                options.AddArgument("--disable-notifications");

                //Starta o chromedriver
                IWebDriver webDriver = new ChromeDriver(options);
                context["WEB_DRIVER"] = webDriver;
            }


            //After executa depois de todos os testes, fechando o navegador
            [After]
            public void CloseWebDriver(ScenarioContext context)
            {
                var driver = context["WEB_DRIVER"] as IWebDriver;
                driver.Quit();
            }
        }
    }
}