using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();
        static void Main(string[] args)
        {
            string userOption = GetUserOpt();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListAll();
                        break;
                    case "2":
                        AddSerie();
                        break;
                    case "3":
                        UpdateSerie();
                        break;
                    case "4":
                        DeleteSerie();
                        break;
                    case "5":
                        ViewSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = GetUserOpt();
            }

            Console.WriteLine("Thank you so much to catch up with us!");
            Console.ReadLine();
        }

        private static void DeleteSerie()
        {
            Console.Write("Inform the Serie Id: ");
            int serieIndex = int.Parse(Console.ReadLine());

            repository.Delete(serieIndex);
        }

        private static void ViewSerie()
        {
            Console.Write("Inform the Serie Id: ");
            int serieIndex = int.Parse(Console.ReadLine());

            var serie = repository.ReturnById(serieIndex);

            Console.WriteLine(serie);
        }

        private static void UpdateSerie()
        {
            Console.Write("Inform the Serie Id: ");
            int serieIndex = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int genreEntry = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string titleEntry = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int yearEntry = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string descriptionEntry = Console.ReadLine();

            Serie updateSerie = new Serie(id: serieIndex,
                                        genre: (Genre)genreEntry,
                                        title: titleEntry,
                                        year: yearEntry,
                                        description: descriptionEntry);

            repository.Update(serieIndex, updateSerie);
        }
        private static void ListAll()
        {
            Console.WriteLine("Listing all series:");

            var fullList = repository.List();

            if (fullList.Count == 0)
            {
                Console.WriteLine("Sorry! No series found.");
                return;
            }

            foreach (var serie in fullList)
            {
                var excluded = serie.getExcluded();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.getId(), serie.getTitle(), (excluded ? "*Excluded*" : ""));
            }
        }

        private static void AddSerie()
        {
            Console.WriteLine("Inserir nova série");

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repository.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repository.Insere(novaSerie);
        }

        private static string GetUserOpt()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Series at your service!!!");
            Console.WriteLine("Please, select a option:");

            Console.WriteLine("1- List all series");
            Console.WriteLine("2- Add a new serie");
            Console.WriteLine("3- Update a serie");
            Console.WriteLine("4- Delete a serie");
            Console.WriteLine("5- View a serie");
            Console.WriteLine("C- Clean screen");
            Console.WriteLine("X- Exit");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
