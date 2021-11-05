using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = obterOpcaoUsuario();
            while(opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;

                    case "5":
                        VisualizarSerie();
                        break;
                    
                    case "c":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentException();
                }
                opcaoUsuario = obterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por usar nossos serviços");
            Console.ReadLine();
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(idSerie);
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(idSerie);
            Console.WriteLine(serie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero),i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Informe o titulo da serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Informe a descricao da série: ");
            string entradaDescricao = Console.ReadLine();

            Console.WriteLine("Informe o ano da serie: ");
            int entradaAnoSerie = int.Parse(Console.ReadLine());

            Serie atualizarSerie = new Serie(id: indiceSerie, genero: (Genero)entradaGenero, titulo: entradaTitulo,
                                        descricao: entradaDescricao, ano: entradaAnoSerie);
            
            repositorio.Atualiza(indiceSerie, atualizarSerie);  
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listando series: ");
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Não existem series..");
                return;
            }
            foreach(var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                if (!excluido)
                {
                    Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
                }
                
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série: ");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero),i));
            }
            Console.Write("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Informe o titulo da serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Informe a descricao da série: ");
            string entradaDescricao = Console.ReadLine();

            Console.WriteLine("Informe o ano da serie: ");
            int entradaAnoSerie = int.Parse(Console.ReadLine());

            Serie novaSerie = new Serie(id: repositorio.ProximoId(), genero: (Genero)entradaGenero, titulo: entradaTitulo,
                                        descricao: entradaDescricao, ano: entradaAnoSerie);

            repositorio.Insere(novaSerie);
        }

        private static string obterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Séries a seu dispor:");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1- Listar Série");
            Console.WriteLine("2- Inserir nova Série");
            Console.WriteLine("3- Atualizar Série");
            Console.WriteLine("4- Excluir Série");
            Console.WriteLine("5- Visualizar Série");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
