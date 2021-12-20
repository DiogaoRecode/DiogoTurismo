using System.ComponentModel.DataAnnotations;

namespace DiogoTurismo.Models
{
    public class Destino
    {
        [Key]
        public int Id_destino { get; set; } 
        [Required]
        public string Cidade_destino { get; set; }  
        public string Cidade_origem { get; set; }
    }
}
