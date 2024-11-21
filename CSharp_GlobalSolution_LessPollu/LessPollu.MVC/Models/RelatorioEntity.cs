using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LessPollu.MVC.Models
{
    [Table("tabela_Relatorio")]
    public class RelatorioEntity
    {
        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "A Data de Geração do Relatório é obrigatória.")]
        [DisplayName("Data de Geração")]
        [DataType(DataType.Date)]
        public DateTime dataGeracao { get; set; }

        [Required(ErrorMessage = "O Período de Cobertura do Relatório é obrigatório.")]
        [DisplayName("Período de Cobertura")]
        [StringLength(100, ErrorMessage = "O Período de Cobertura não pode exceder 100 caracteres.")]
        public string periodoCobertura { get; set; }

        [Required(ErrorMessage = "As Métricas do Relatório são obrigatórias.")]
        [DisplayName("Métricas")]
        [StringLength(1000, ErrorMessage = "As Métricas não podem exceder 1000 caracteres.")]
        public string Metricas { get; set; }

        [Required(ErrorMessage = "As Observações do Relatório são obrigatórias.")]
        [DisplayName("Observações")]
        [StringLength(1000, ErrorMessage = "As Observações não podem exceder 1000 caracteres.")]
        public string Observacoes { get; set; }
    }
}
