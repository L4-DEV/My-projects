namespace GeekLifeAPI.Dtos.SubDtos
{
    public class UpdateSubDtoPatch
    {
        public string? NomeDaSub { get; set; }
        public bool? Atividade { get; set; }

        public string? Status => Atividade.HasValue ? (Atividade.Value ? "ativa" : "inativa") : null;
        public DateTime HoraDaModificacao { get; set; } = DateTime.Now;

    }
}
