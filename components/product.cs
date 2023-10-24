using appLotes.models;
using System;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;




  class product
  {
   
      public void ProductAct ()
      {
         string caminhoArquivoCSV = "./files/vite.csv";

        using (var reader = new StreamReader(caminhoArquivoCSV))
        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            var registros = csv.GetRecords<PersonModels>().ToList();

            var produtoMaiorQuantidade = registros.OrderByDescending(p => p.Quantity).FirstOrDefault();
            
            if (produtoMaiorQuantidade != null)
            {
                Console.WriteLine("Produto com a maior quantidade: {0}", produtoMaiorQuantidade.Product);
                Console.WriteLine("Quantidade: {0}", produtoMaiorQuantidade.Quantity);
                Console.WriteLine("Valor: {0}", produtoMaiorQuantidade.UnitPrice);
            }
            else
            {
                Console.WriteLine("Nenhum registro encontrado no arquivo CSV.");
            }
        }
      }
  }
