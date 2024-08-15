using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TestadorDeSites
{
    internal class Program
    {
        const int numeroMonitoramentos = 2;
        const int delay = 5;

        static async Task Main(string[] args)
        {
            ExibeIntroducao();
            while (true)
            {
                ExibeMenu();
                int comando = LeComando();

                switch (comando)
                {
                    case 1:
                        await IniciarMonitoramento();
                        break;
                    case 2:
                        Console.WriteLine("Exibindo Logs...");
                        ImprimeLogs();
                        break;
                    case 3:
                        Console.WriteLine("Adicionando um novo site");
                        AdicionarNovoSite();
                        break;
                    case 0:
                        Console.WriteLine("Saindo do programa");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Não conheço este comando");
                        Environment.Exit(-1);
                        break;
                }
            }
        }
        static void ExibeIntroducao()
        {
            Console.Write("Digite seu nome: ");
            string nome = Console.ReadLine();
            string versao = "2.0";
            Console.WriteLine("Olá, Sr(a). " + nome + "!" + "Seja bem-vindo(a).");
            Console.WriteLine("Este programa está na versão " + versao);
        }
        static void ExibeMenu()
        {
            Console.WriteLine("1- Iniciar Monitoramento");
            Console.WriteLine("2- Exibir Logs");
            Console.WriteLine("3- Adicionar novo site");
            Console.WriteLine("0- Sair do Programa");
        }
        static int LeComando()
        {
            int comandoLido;
            int.TryParse(Console.ReadLine(), out comandoLido);
            Console.WriteLine("O comando escolhido foi " + comandoLido);
            Console.WriteLine("");
            return comandoLido;
        }

        static async Task IniciarMonitoramento()
        {
            Console.WriteLine("Monitorando...");

            List<string> sites = LeSitesDoArquivo();

            for(int i = 0; i < numeroMonitoramentos; i++)
            {
                foreach(var site in sites)
                {
                    Console.WriteLine("Testando site: " + site);
                    await TestaSite(site);
                }
                Thread.Sleep(delay * 1000);
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }

        static async Task TestaSite(string site)
        {
            using (HttpClient client = new HttpClient())

            try
            {
                HttpResponseMessage response = await client.GetAsync(site);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Site: " + site + " foi carregado com sucesso!");
                        RegistraLog(site, true);
                    }
                    else
                    {
                        Console.WriteLine("Site: " + site + " está com problemas. Status Code: " + response.StatusCode);
                        RegistraLog(site, false);
                    }
                }
            catch (Exception ex) 
            {
                    Console.WriteLine("Ocorreu o seguinte erro: " + ex.Message);

            }
        }

        static void AdicionarNovoSite()
        {
            Console.Write("Digite a URL do novo site (com http:// ou https://): ");
            string novoSite = Console.ReadLine().Trim();

            if (!novoSite.StartsWith("http://") && !novoSite.StartsWith("https://"))
            {
                Console.WriteLine("URL inválida. Certifique-se de incluir http:// ou https://");
                return;
            }

            try
            {
                // Lê todas as linhas existentes
                List<string> linhas = new List<string>();
                if (File.Exists("sites.txt"))
                {
                    linhas = File.ReadAllLines("sites.txt").ToList();
                }

                // Adiciona o novo site
                linhas.Add(novoSite);

                // Escreve todas as linhas de volta ao arquivo
                File.WriteAllLines("sites.txt", linhas);

                Console.WriteLine("Site adicionado com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao adicionar o site: " + e.Message);
            }
        }

        static List<string> LeSitesDoArquivo()
        {
            List<string> sites = new List<string>();

            try
            {
                using (StreamReader sr = new StreamReader("sites.txt"))
                {
                    string linha;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        sites.Add(linha.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu o seguinte erro: " + ex.Message);
            }

            return sites;
        }

        static void ImprimeLogs()
        {
            try
            {
                string[] logs = File.ReadAllLines("log.txt");
                foreach (string log in logs)
                {
                    Console.WriteLine(log);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu o seguinte erro: " + e.Message);
            }
        }

        static void RegistraLog(string site, bool status)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("log.txt", true))
                {
                    sw.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - " + site + " - online: " + status);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu o seguinte erro: " + e.Message);
            }
        }
    }
}