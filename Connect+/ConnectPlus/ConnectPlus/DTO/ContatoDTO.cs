using System.ComponentModel.DataAnnotations;

namespace ConnectPlus.DTO;

public class ContatoDTO
{
    [Required(ErrorMessage = "O nome é obrigatorio!")]
    public string? Nome { get; set; }
    [Required(ErrorMessage = "A forma de Contato é obrigatório")]
    public string? FormaContato { get; set; }
    public IFormFile? Imagem { get; set; } = null;
    public Guid IdTipoContato { get; set; }
}
