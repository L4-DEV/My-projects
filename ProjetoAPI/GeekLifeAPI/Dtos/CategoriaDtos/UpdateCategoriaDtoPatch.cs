

namespace GeekLifeAPI.Dtos.CategoriaDtos
{
    public class UpdateCategoriaDtoPatch
    {
        public string? NomeDaCategoria { get; set; }

        public bool? Atividade { get; set; }

        public string? Status => Atividade.HasValue ? (Atividade.Value ? "ativa" : "inativa") : null;

        public DateTime HoraDaModificacao { get;  set; } = DateTime.Now;
    }
}
