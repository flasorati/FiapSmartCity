using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiapSmartCity.Models
{
    public class CadastroPessoaEF
    {
        [Key]
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Descrição obrigatória!")]
        [StringLength(50, ErrorMessage = "A descrição deve ter, no máximo, 50 caracteres")]
        [Display(Name = "Nome:")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Descrição obrigatória!")]
        [StringLength(50, ErrorMessage = "A descrição deve ter, no máximo, 50 caracteres")]
        [Display(Name = "Endereço:")]
        public string Endereco { get; set; }

    }
}
