using System.ComponentModel.DataAnnotations;

namespace ConnectPlus.DTO;

public class TipoContatoDTO
{
    public Guid IdTipoContato { get; set; }
    [Required(ErrorMessage = "O titulo do tipo de contato eh obrigatorio")]
    public string? Titulo { get; set; }
}
