using System.ComponentModel.DataAnnotations;


namespace GeekLifeAPI.Dtos.CCDDtos
{
    public class UpdateCDDto
    {

        [Required(ErrorMessage = "O campo NomeDoCd é obrigatório")]
        [RegularExpression(@"^[A-Za-zÀ-ÿ0-9\s]{1,128}$", ErrorMessage = "O nome da categoria deve conter apenas caracteres alfanuméricos.")]
        [StringLength(128, MinimumLength = 1, ErrorMessage = "E deve conter entre 1 e 128 caracteres")]
        public string NomeDoCD { get; set; }

        public int Numero { get; set; }

        [Required(ErrorMessage = "O campo Complemento é obrigatório")]
        [RegularExpression(@"^[A-Za-zÀ-ÿ0-9\s]{1,128}$", ErrorMessage = "O nome da categoria deve conter apenas caracteres alfanuméricos.")]
        [StringLength(128, MinimumLength = 1, ErrorMessage = "E deve conter entre 1 e 128 caracteres")]
        public string Complemento { get; set; }

        public string CEP { get; set; }

        public bool Atividade { get; set; } = true;
        public string Status
        {
            get { return Atividade ? "ativa" : "inativa"; }
        }

        public DateTime HoraDaModificacao { get; private set; } = DateTime.Now;
    }
}

