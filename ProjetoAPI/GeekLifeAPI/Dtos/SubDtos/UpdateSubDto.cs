using System.ComponentModel.DataAnnotations;



namespace GeekLifeAPI.Dtos.SubDtos
{
    public class UpdateSubDto
    {
        [Required]
        [RegularExpression(@"^[A-Za-zÀ-ÿ0-9\s]{1,128}$", ErrorMessage = "O nome da categoria deve conter apenas caracteres alfanuméricos!")]
        [StringLength(128, MinimumLength = 3, ErrorMessage = "E deve conter entre 3 e 128 caracteres")]
        public string NomeDaSub { get; set; }

        public bool Atividade { get; set; }

        public DateTime HoraDaModificacao { get; set; } = DateTime.Now;
        public string Status
        {
            get { return Atividade ? "ativa" : "inativa"; }
        }

    }
}

