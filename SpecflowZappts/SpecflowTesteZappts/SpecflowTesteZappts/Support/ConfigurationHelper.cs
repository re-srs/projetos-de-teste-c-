using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SpecFlowSelenium.Support
{
    public static class ConfigurationHelper
    {
        //Aqui deve ser preenchido todos os dados base do SUT (System Under Test) que a automacao atuara
        public static string SiteUrl => "https://www.zappts.com.br/";
        public static string HomeUrl => "https://www.zappts.com.br/";
        public static string LoginUrl => "https://www.zappts.com.br/";
        //Os 3 links acima sao iguais por causa do exemplo, nao se prenda a esse detalhe

        //aqui deve ser inputado as credenciais para os testes
        //pela natureza do sistema testado, talvez seja preciso cadastrar o usuario antes de executar o exemplo
        public static string TestUserName => "quickstartselenium@mailinator.com";
        public static string TestPassword => "Teste123";

        //Essas sao as informacoes para impressao de tela e salvar arquivos pelas classes do "SeleniumHelper.cs"
        public static string FolderPath => Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
        public static string FolderPicture => string.Format("{0}{1}", FolderPath, "\\Screenshots\\");
    }
}
