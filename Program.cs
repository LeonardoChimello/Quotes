using DocumentFormat.OpenXml.Office.CustomUI;
using System;
using HtmlAgilityPack;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace MeuPrimeiroPrograma
{
    class Program
    {


        static void Main(string[] args)
        {
            string Moeda = "R$4,9653";
            int count = 0;
            int x = 0;
            int Caso = 0;
            Double d;
            Double Calculo;

                    //Conecta com o site para buscar a cotação

            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument dol = web.Load("https://www.melhorcambio.com/dolar-hoje");
                                     var eul = web.Load("https://www.melhorcambio.com/euro-hoje");
                                     var eth = web.Load("https://coinmarketcap.com/pt-br/currencies/ethereum/");
                                     var btc = web.Load("https://coinmarketcap.com/pt-br/currencies/bitcoin/");
            
            foreach (var Bitcoin in btc.DocumentNode.SelectNodes("/html/body/div/div/div[1]/div[2]/div/div[1]/div[2]/div[2]/div[1]/div"))
            foreach (var Ethereum in eth.DocumentNode.SelectNodes("/html/body/div/div/div[1]/div[2]/div/div[1]/div[2]/div[2]/div[1]/div"))
            foreach (var Euro in eul.DocumentNode.SelectNodes("/html/body/div[5]/div[4]/table/tbody/tr[3]/td[2]"))
            foreach (var Dolar in dol.DocumentNode.SelectNodes("/html/body/div[5]/div[4]/table/tbody/tr[3]/td[2]"))
           
            {
                    Console.WriteLine(" Digite '1' para Dolar \n Digite '2' para Euro \n Digite '3' para Ethereum \n Digite '4' para Bitcoin \n Digite '5' para sair da aplicação");
                    Caso = int.Parse(Console.ReadLine());

                        if (Caso > 5)
                                {
                                Caso = 5;
                                }
                        switch (Caso)
                        {
                            case 1:
                                Moeda = Dolar.InnerText;

                                break;
                            case 2:
                                Moeda = Euro.InnerText;

                                break;
                            case 3:
                                Console.WriteLine(" A Cotação Do Ethereum Hoje é:  ");
                                Console.Write($"{Ethereum.InnerText}\n");
                                Console.ReadLine();
                                Environment.Exit(0);
                                break;
                            case 4:
                                Console.WriteLine(" A Cotação Do Bitcoin Hoje é:  ");
                                Console.Write($"{Bitcoin.InnerText}\n");
                                Console.ReadLine();
                                Environment.Exit(0);
                                break;
                            case 5:
                                Console.WriteLine("\n Saindo..... \n");
                                Console.ReadLine();
                                Environment.Exit(0);
                                break;
                            }
                               
                                //Converte o string com caracteres para um int

                                string[] numbers = Moeda.Split(',', 'R', '$');

                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] != "")
                    {
                        count++;
                    }
                }
                string[] number = new String[count];
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] != "")
                    {
                        number[x] = numbers[i];
                        x++;
                    }
                }
                int[] num = new int[number.Length];
                for (int j = 0; j < number.Length; j++)
                {
                    num[j] = int.Parse(number[j]);
                }
                foreach (string n in number)
                {

                }

                        // comando para transformar int em String 

                string numeroString = number[0].ToString() + number[1].ToString();

                        //Comando para transformar String em Double 

                Calculo = Int32.Parse(numeroString);
                Calculo = Calculo / 10000;


                    
                                  

                switch (Caso)
                {
                    case 1:
                            Console.Write(" A Cotação Do Dolar Hoje é:  ");
                            Console.WriteLine(Dolar.InnerText);
                            Console.Write("Digite o valor que deseja converter para real: "); d = Double.Parse(Console.ReadLine());
                            d = Calculo * d;
                            Console.WriteLine($"R$:{d}");
                            break;
                    case 2:
                            Console.WriteLine(" A Cotação Do Euro Hoje é:  |");
                            Console.Write($"{Euro.InnerText}\n");
                            Console.Write("Digite o valor que deseja converter para real: "); d = Double.Parse(Console.ReadLine());
                            d = Calculo * d;
                            Console.WriteLine($"R$:{d}");
                            break;
                    }
                Console.ReadLine();
            }
        }
    }
}

//implementar Bitcoin etc....
