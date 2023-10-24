using appLotes.models;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;


class UploadFile
{
  public void upload()
  {

    string caminhoArquivoCSV = "./files/vite.csv";

    using (var reader = new StreamReader(caminhoArquivoCSV))
    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
    {
      var registros = csv.GetRecords<PersonModels>().ToList();

      var produtoMaiorQuantidade = registros.OrderByDescending(p => p.Quantity).FirstOrDefault();

      ActividadesFiles actividadesFiles = new ActividadesFiles();


      // Fazendo Upload
      Console.WriteLine("Buscar dados ...");
      StringBuilder sb = new StringBuilder();
      Console.WriteLine("Montar Arquivo");
      sb.AppendLine("O produto com mais Destaque");
      sb.AppendLine($"Produto {produtoMaiorQuantidade.Product}     " + $"Quantidade {produtoMaiorQuantidade.Quantity}     " + $"Preço {produtoMaiorQuantidade.UnitPrice}     ");
      sb.AppendLine("");
     // sb.AppendLine("Ativades-Files");
     // sb.AppendLine($"{actividadesFiles.desvioPadrao}     " + $"{actividadesFiles.mediana}     " + $"{actividadesFiles.media}     ");
      var filePath = @"C:\Users\Rui\Desktop\appLotes 1.0\update\nweArquivo.csv";
      Console.WriteLine("Salvar Arquivo");
      File.WriteAllText(filePath, sb.ToString());
      Console.ReadKey();
    }
  }
}