using System;

namespace runcode_poo.codigo
{
    class Produto
    {
        private string Nome;
        private string Descricao;
        private double Preco;
        private string Categoria;

        public Produto(string nome, string descricao, double preco, string categoria)
        {
            this.Nome = nome;
            this.Descricao = descricao;
            this.Preco = preco;
            this.Categoria = categoria;
        }
    }
}
