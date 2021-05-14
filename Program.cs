using System;

namespace Sistema_Produtos
{
    class Program
    {
        static int tamanhoArrays = 2;
        static string[] nome = new string[tamanhoArrays];
        static float[] preco = new float[tamanhoArrays];
        static bool[] promocao = new bool[tamanhoArrays];
        static bool menuPrincipal = true;
        static int c = 0;
        static bool novoCadastro = true;
        static void Main(string[] args)
        {

            do
            {
                Menu();
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.WriteLine("Cadastre seus produtos; Máximo de 10 produtos");

                        novoCadastro = true;

                        Cadastrar();
                        break;
                    case "2":
                        Listar();
                        break;
                    case "3":
                    AumentarArray();
                        break;
                    default:
                        Console.WriteLine("Adeus");
                        menuPrincipal = false;
                        break;
                }

            } while (menuPrincipal);


        }
        static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Qual opção você quer realizar?");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(@"
            1 - Cadastrar Produto
            2 - Listar Produto
            3 - Aumentar Número de Cadastros
            
            Aperte Qualquer Botão Para Sair");
        }
        static void Cadastrar()
        {
            do
            {
                if (c < tamanhoArrays)
                {
                    Console.WriteLine("Digite o nome do produto");
                    nome[c] = Console.ReadLine();

                    Console.WriteLine("Digite o preço do produto");
                    preco[c] = float.Parse(Console.ReadLine());

                    Console.WriteLine("O produto está em promoção? S para sim e N para não");
                    string promocaoProduto = Console.ReadLine().ToUpper();

                    if (promocaoProduto == "S")
                    {
                        promocao[c] = true;
                    }
                    else
                    {
                        promocao[c] = false;
                    }

                    Console.WriteLine("Deseja cadastrar um novo produto; S para sim e N para não");
                    string novoProduto = Console.ReadLine().ToUpper();

                    if (novoProduto == "N")
                    {
                        novoCadastro = false;
                    }
                    else
                    {
                        Console.WriteLine("Ok,faremos um novo cadastro");
                    }
                    c++;
                }
                else
                {
                    Console.WriteLine("Máximo de cadastros alcançados");
                    novoCadastro = false;
                }
            } while (novoCadastro);
        }
        static void Listar()
        {
            for (var i = 0; i < c; i++)
            {
                Console.WriteLine($"{i + 1}° produto; {nome[i]} / R${preco[i]} / {(promocao[i] ? "Está em Promoção" : "Não Está em Promoção")} ");
            }
            Console.WriteLine();
        }

        static void AumentarArray()
        {
            Console.WriteLine("Deseja mudar para qual tamanho?");
            int novoTamanho = int.Parse(Console.ReadLine());
            tamanhoArrays = novoTamanho;
            Array.Resize(ref nome, tamanhoArrays);
            Array.Resize(ref preco, tamanhoArrays);
            Array.Resize(ref promocao, tamanhoArrays);
        }
    }
}
