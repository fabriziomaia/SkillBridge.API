using System.ComponentModel.DataAnnotations;

namespace SkillBridge.API.Models
{
    public class PlanoDesenvolvimento
    {
        [Key]
        public Guid Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Objetivo { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; }
        public DateTime DataTerminoPrevista { get; set; }
        
        public Guid ColaboradorId { get; set; }
        public virtual Colaborador? Colaborador { get; set; } 
    }
}