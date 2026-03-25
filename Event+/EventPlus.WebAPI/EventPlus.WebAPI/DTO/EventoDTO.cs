using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class EventoDTO
{

    [Required(ErrorMessage = "O nome do evento é obrigatorio!")]
    public string? Nome { get; set; }
    [Required(ErrorMessage = "O Email do usuario é obrigatório")]
    public DateTime DataEvento { get; set; }
    public string? Descricao { get; set; }
    [Required(ErrorMessage = "A descricao do evento é obrigatório")]
    public Guid IdTipoEvento { get; set; }
    public Guid IdInstituicao { get; set; }

}
