namespace GeekLifeAPI.Dtos
{
    public class UpdateCategoriaDtoStatus
    {
        public bool Atividade { get; set; }

        public DateTime HoraDaModificacao { get; set; } = DateTime.Now;

        public string Status
        {
            get { return Atividade ? "ativa" : "inativa"; }
        }

       
    }
}
