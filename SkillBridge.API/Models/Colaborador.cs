using System.ComponentModel.DataAnnotations;

namespace SkillBridge.API.Models
{
    public class Colaborador
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CargoAtual { get; set; } = string.Empty;
        
        public virtual ICollection<PlanoDesenvolvimento> Planos { get; set; } = new List<PlanoDesenvolvimento>();
    }
}