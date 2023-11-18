using GeekLifeAPI.Models;
using Microsoft.Extensions.Options;

namespace GeekLifeAPI.Services.ProdutoService
{
    public class VerificadorDeProdutos
    {
        private readonly Produto produto;
        private bool atividade;
        private  string descricao;
        private string nomeDoProduto;
        private float peso;
        private float altura;
        private float largura;
        private float valor;
        private float comprimento;
        private int QuantidadeEstoque;

        public VerificadorDeProdutos(Produto produto,float peso, float altura, float largura, float valor, float comprimento)
        {
            this.peso = peso;
            this.altura = altura;
            this.largura = largura;
            this.valor = valor;
        }

        public float VerificarFloat()
        {

            if (peso == 0)
            {
                peso = produto.Peso;
            }
            if (altura == 0)
            {
                altura = produto.Altura;
            }
            if (largura == 0)
            {
                largura = produto.Largura;
            }
            if (comprimento == 0)
            {
               comprimento = produto.Comprimento;
            }
            if (valor == 0)
            {
                valor = produto.Valor;
            }

            return produto.Peso + produto.Altura + produto.Valor + produto.Comprimento + produto.Valor + produto.Largura;
        }
    }
}






//_produtoRepository.NomeRepetido(produto);


//if (string.IsNullOrEmpty(produtoDto.NomeDoProduto))
//    produtoDto.NomeDoProduto = produto.NomeDoProduto;

//if (!string.IsNullOrEmpty(produto.NomeDoProduto))
//{

//    _produtoRepository.NomeRepetido(produto);
//    VerificarNome(produto.NomeDoProduto);

//}


//VerificarDescricao(produto.Descricao);
//if (string.IsNullOrEmpty(produtoDto.Descricao))
//    produtoDto.Descricao = produto.Descricao;
//if (produtoDto.Atividade != produtoDto.Atividade)
//{
//    produto.Atividade = produtoDto.Atividade;
//}
//if (produtoDto.Peso == 0)
//{
//    produtoDto.Peso = produto.Peso;
//}
//if (produtoDto.Altura == 0)
//{
//    produtoDto.Altura = produto.Altura;
//}
//if (produtoDto.Largura == 0)
//{
//    produtoDto.Largura = produto.Largura;
//}
//if (produtoDto.Comprimento == 0)
//{
//    produtoDto.Comprimento = produto.Comprimento;
//}
//if (produtoDto.Valor == 0)
//{
//    produtoDto.Valor = produto.Valor;
//}
//if (produtoDto.QuantidadeEstoque == 0)
//{
//    produtoDto.QuantidadeEstoque = produto.QuantidadeEstoque;
//}

