using System.ComponentModel.DataAnnotations;

namespace DiogoTurismo.Models
{
    public class Cadastro
    {
        [Key]
        public int Id_cadastro { get; set; } 
        [Required]
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

    }
}
