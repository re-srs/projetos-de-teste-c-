using SpecFlowSelenium.Support;
using SpecflowTesteZappts.Support;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecflowTesteZappts.Steps
{
    [Binding]
    public class ExemploDeFeatureSteps
    {

        public SeleniumHelper browser;
        public ExemploDeFeatureSteps(ScenarioContext scenarioContext)
        {
            browser = SeleniumHelper.Instance(scenarioContext);
        }


        [Given(@"que eu acesse o site da Zappts")]
        public void DadoQueEuAcesseOSiteDaZappts()
        {
            //Diz para o selenium abrir a pagina do SUT
            browser.NavegarParaUrl(ConfigurationHelper.SiteUrl);
            //Da 2 segundos de pausa para o sistema fazer qualquer tipo de processo e a thread nao se atrapalhar
            Thread.Sleep(2000);
        }

        [When(@"navega à página de carreiras")]
        public void QuandoNavegaAPaginaDeCarreiras()
        {
            browser.ClicarLinkPorTexto("CARREIRAS");
            Thread.Sleep(2000);
        }
        [Then(@"clico em oportunidades")]
        public void EntaoClicoEmOportunidades()
        {
            browser.ClicarLinkPorTexto("VER OPORTUNIDADES");
            Thread.Sleep(2000);
        }
    }
}
