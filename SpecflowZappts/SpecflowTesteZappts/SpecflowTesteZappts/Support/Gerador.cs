using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowSelenium.Support
{
    public class Gerador
    {
        //essas classes auxiliares podem ser usadas para gerar dados novos a cada teste se necessario
        public static String GerarCnpj()
        {
            int soma = 0, resto = 0;
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            Random rnd = new Random();
            string semente = rnd.Next(10000000, 99999999).ToString() + "0001";

            for (int i = 0; i < 12; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            return semente;
        }

        public static String GerarCpf()
        {
            int soma = 0, resto = 0;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            Random rnd = new Random();
            string semente = rnd.Next(100000000, 999999999).ToString();

            for (int i = 0; i < 9; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            return semente;
        }

        public static String GerarLoremIpsum(int minWords, int maxWords, int minSentences, int maxSentences, int numParagraphs)
            {

                var words = new[]{"lorem", "ipsum", "dolor", "sit", "amet", "consectetuer", "adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod", "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam", "erat"};

                var rand = new Random();
                int numSentences = rand.Next(maxSentences - minSentences) + minSentences + 1;
                int numWords = rand.Next(maxWords - minWords) + minWords + 1;

                StringBuilder result = new StringBuilder();

                for (int p = 0; p < numParagraphs; p++)
                    {
                        result.Append("<p>");
                        for (int s = 0; s < numSentences; s++)
                            {
                                for (int w = 0; w < numWords; w++)
                                    {
                                        if (w > 0) { result.Append(" "); }
                                result.Append(words[rand.Next(words.Length)]);
                                }
                                result.Append(". ");
                        }
                        result.Append("</p>");
                }

                return result.ToString();
        }
    }
}
