using System;
using appLotes.models;
using System.Text;
using CsvHelper;
using System.IO;
using System.Globalization;
using static System.Console;

namespace appLotes
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Seja Bem-vindo ao AppLotes");
            Console.ResetColor();

            Console.WriteLine("usa as setas do teclado ⬆ ⬇ para Navegar no Menu");

            ConsoleKeyInfo key;
            int option = 1;
            bool select = false;
            (int left, int top) = Console.GetCursorPosition();
            string color = "✅ \u001b[32m";

            while (!select)
            {
                Console.SetCursorPosition(left, top);

                Console.WriteLine($"{(option == 1 ? color : " ")}Option  Ler o arquivo\u001b[0m");
                Console.WriteLine($"{(option == 2 ? color : " ")}Option  Mostrar Atividades do arquivo\u001b[0m");
                Console.WriteLine($"{(option == 3 ? color : " ")}Option  Upload das Atividades no Arquivo\u001b[0m");

                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        option = (option == 3 ? 1 : option + 1);
                        break;

                    case ConsoleKey.UpArrow:
                        option = (option == 1 ? 3 : option - 1);
                        break;

                    case ConsoleKey.Enter:
                        select = true;
                        break;
                }
            }
            switch (option)
            {
                case 1:
                    Console.Clear();

                    var reader = new StreamReader("./files/vite.csv");

                    var csvConfig = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        PrepareHeaderForMatch = args => args.Header.Replace(" ", string.Empty)
                    };

                    var csv = new CsvReader(reader, csvConfig);


                    var employees = csv.GetRecords<PersonModels>();

                    foreach (var e in employees)
                    {
                        WriteLine($"Data_Venda: {e.Date} / Produto: {e.Product} / Quantidade: {e.Quantity} / Preco_Unitario: {e.Quantity}");
                    }
                    break;
                case 2:
                    Console.Clear();
                    ActividadesFiles actividadesFiles = new ActividadesFiles();
                    actividadesFiles.message();
                    break;
                case 3:
                    Console.Clear();
                    UploadFile uploadFile = new UploadFile();
                    uploadFile.upload();
                    break;

            }
        }

    }
}