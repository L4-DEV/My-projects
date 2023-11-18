

namespace GeekLifeAPI.Dtos.CDDtos;
public class UpdateCDDtoPatch
{
    public string? NomeDoCD { get; set; }

    public int Numero { get; set; }
    public string? Complemento { get; set; }

    public string? CEP { get; set; }


    public bool? Atividade { get; set; }

    public string? Status => Atividade.HasValue ? (Atividade.Value ? "ativa" : "inativa") : null;

    public DateTime HoraDaModificacao { get; private set; } = DateTime.Now;
}

