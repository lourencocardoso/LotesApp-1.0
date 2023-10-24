namespace appLotes.models

{
    //Modelagem dos dados vindo da planilha(venda.csv), me faz lembrar modelagem do banco de dados 
    public class PersonModels
    {
        public int? Id { get; set; }
        public string? Date { get; set; }
        public string? Product { get; set; }
        public int? Quantity { get; set; }
        public double? UnitPrice { get; set; }
    }
}