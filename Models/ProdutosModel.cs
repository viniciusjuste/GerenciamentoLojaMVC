using System.ComponentModel.DataAnnotations;

namespace GerenciamentoLojaMVC.Models
{
    public class ProdutosModel
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Digite o nome do produto")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Digite a descrição do produto")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "Digite a quantidade do produto")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Digite a categoria do produto")]
        public string Categoria { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
