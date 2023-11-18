namespace GeekLifeAPI.Dtos
{
    public class UpdateProdutoDtoSupport
    {
        public bool Atividade { get; set; }

        public string Status
        {
            get { return Atividade ? "ativa" : "inativa"; }
        }

        public DateTime HoraDaModificacao { get; set; } = DateTime.Now;
    }
}
