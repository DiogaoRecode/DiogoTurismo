using System.ComponentModel.DataAnnotations;

namespace DiogoTurismo.Models
{
    public class Passagem
    {
        [Key]
        public int Id_passagem { get; set; }
        [Required]
        public string Numero_passaporte { get; set; } 
        public string Data_saida { get; set; }
        public string Data_chegada { get; set; }
        public string Horario_saida { get; set; }
        public string Horario_chegada { get; set; }
        public int CadastroId_cadastro { get; set; }
        public Cadastro Cadastro { get; set; }
        public int DestinoId_destino { get; set; }
        public Destino Destino { get; set; }
    }
}
