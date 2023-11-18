using GeekLifeAPI.Dtos.ProdutoDtos;

namespace GeekLifeAPI.Dtos.CDDtos;

    public class ReadCDDto
    {
        public int Id { get; set; }

        public string NomeDoCD { get; set; }

        public string Logradouro { get; set; }

        public int Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string UF { get; set; }

        public string CEP { get; set; }

         public string Atividade { get; set; }

        public DateTime HoraDaCriacao { get; private set; }

        public DateTime HoraDaModificacao { get; private set; }

        public ICollection<ReadProdutoDtoEnd> Produto { get; set; }

    }

