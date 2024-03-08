using System.ComponentModel.DataAnnotations;

namespace GerenciamentoLojaMVC.Models
{
    public class FuncionariosModel
    {
            [Key]
            public int FuncionarioId { get; set; }

            [Required(ErrorMessage = "Digite o nome do funcionário")]
            public string NomeFuncionario { get; set; } = string.Empty;

            [Required(ErrorMessage = "Digite o cargo do funcionário")]
            public string CargoFuncionario { get; set; } = string.Empty;

            [Required(ErrorMessage = "Digite o salário do funcionário")]
            public decimal SalarioFuncionario { get; set; }

            [Required(ErrorMessage = "Digite o e-mail do funcionário")]
            public string Email { get; set; } = string.Empty;

            [Required(ErrorMessage = "Digite o telefone do funcionário")]
            public string Telefone { get; set; } = string.Empty;

    }
}
