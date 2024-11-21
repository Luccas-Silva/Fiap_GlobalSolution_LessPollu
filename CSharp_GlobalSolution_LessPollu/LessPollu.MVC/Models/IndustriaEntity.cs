using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LessPollu.MVC.Models
{
    [Table("tabela_Industria")]
    public class IndustriaEntity
    {
        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "O Nome da Indústria é obrigatório.")]
        [DisplayName("Nome")]
        [StringLength(100, ErrorMessage = "O Nome da Indústria não pode exceder 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CEP da Indústria é obrigatório.")]
        [DisplayName("CEP")]
        [StringLength(8, ErrorMessage = "O CEP deve ter 8 dígitos.")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "O Tipo da Indústria é obrigatório.")]
        [DisplayName("Tipo")]
        [StringLength(50, ErrorMessage = "O Tipo da Indústria não pode exceder 50 caracteres.")]
        public string Tipo { get; set; }

    }
}
