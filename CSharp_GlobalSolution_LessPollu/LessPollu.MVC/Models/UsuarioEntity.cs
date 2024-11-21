using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LessPollu.MVC.Models
{
    [Table("tabela_Usuario")]
    public class UsuarioEntity
    {
        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "O Nome do Usuário é obrigatório.")]
        [StringLength(100, ErrorMessage = "O Nome do Usuário não pode exceder 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Email do Usuário é obrigatório.")]
        [EmailAddress(ErrorMessage = "Por favor, insira um endereço de email válido.")]
        [StringLength(256, ErrorMessage = "O Email do Usuário não pode exceder 256 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha do Usuário é obrigatória.")]
        [StringLength(50, ErrorMessage = "A Senha do Usuário não pode exceder 50 caracteres.")]
        public string Senha { get; set; }
    }
}
