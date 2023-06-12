namespace CarrosAPI.Models
{
    public class Carros
    {
        public Guid id { get; set; }
        public string modelo { get; set; }
        public string marca { get; set; }
        public string Gasolina { get; set; }
        public int millaje { get; set; }    
    }
}
