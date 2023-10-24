using appLotes.models;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
class ActividadesFiles
{
  public double media;

  public double mediana;

  public double desvioPadrao;
  public void message()
  {

    string filePath = "./files/vite.csv";

    using (var reader = new StreamReader(filePath))
    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
    {


      var registros = csv.GetRecords<MeuObjeto>().Select(record => (int)record.Quantity).ToList();

      // Organizar de forma crescente
      var numerosOrdenados = registros.OrderBy(n => n).ToList();

      //Pegar todos os numeros repitidos
      List<int> numerosUnicos = numerosOrdenados.Distinct().ToList();

      // Encontre os dois valores do meio
      int meio = numerosUnicos.Count / 2;
      int valorMeio1 = numerosUnicos[meio - 1];
      int valorMeio2 = numerosUnicos[meio];

      //Samando os valores do meio
      int somaValoresMeio = valorMeio1 + valorMeio2;

      //Achando a mediana 
      mediana = somaValoresMeio / 2;

      //Achando a Media
      media = numerosUnicos.Average();

      //Desvio Padrão 

      // soma dos quadrados das diferenças
      double somaDosQuadradosDasDiferencas = numerosUnicos.Sum(x => Math.Pow(x - media, 2));

      desvioPadrao = Math.Sqrt(somaDosQuadradosDasDiferencas / numerosUnicos.Count);

      //Retornando o Produto com maior quantidade
      product product = new product();

      product.ProductAct();


      Console.WriteLine($"Media: " + media);
      Console.WriteLine($"Mediana: " + mediana);
      Console.WriteLine($"DesvioPadrão: " + desvioPadrao);

    }


  }

}
