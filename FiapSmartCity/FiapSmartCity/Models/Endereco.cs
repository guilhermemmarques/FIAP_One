using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiapSmartCity.Models
{
    [Table("ENDERECO")]
    public class Endereco
    {
        [Key]
        [Column("ID_ENDERECO")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id do Endereco")]
        public int IdEndereco { get; set; }

        [Required(ErrorMessage = "Descricao obrigatória!")]
        [StringLength(100, ErrorMessage = "A descricao deve ter no maximo 100 caracteres")]
        [Display(Name = "Descricao:")]
        [Column("DS_END")]
        //Navigation Property
        public string DescEnderecos { get; set; }

        [Column("UF")]
        public string UF { get; set; }
        [Column("CEP")]
        public int CEP { get; set; }

    }
}
