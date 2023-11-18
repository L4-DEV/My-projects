using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace GeekLifeAPI.Models
{
    public class CD
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string NomeDoCD { get; set; }
        
        public string Logradouro { get; set; }
        
        public int Numero { get; set; }
        
        public string Complemento {get;set;}
       
        public string Bairro { get; set;}
        
        public string Cidade { get; set;}
        
        public string UF { get; set;} 

        public string CEP { get; set; }

        [JsonIgnore]
        public bool Atividade { get; set; } = true;

        public string Status { get; set; } = "ativa";

        public DateTime HoraDaCriacao { get; private set; }
        public DateTime HoraDaModificacao { get; private set; }

        public virtual ICollection <Produto> Produtos { get;  set; }

    }
}



