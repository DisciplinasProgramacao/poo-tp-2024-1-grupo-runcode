using System;
using System.Collections.Generic;

namespace runcode_poo.codigo
{
	class Cardapio
	{
        private List<Produto> Produtos;
        public Cardapio()
        {
            Produtos = new List<Produto>();
        }

        public void AdicionarProduto(Produto produto)
        {
            Produtos.Add(produto);
        }
    }
}


