using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runcode_poo.codigo
{
    /// <summary>
    /// Classe que representa um cardápio de café, herdando a classe Cardapio.
    /// </summary>
    public class CardapioCafe : Cardapio
    {
        /// <summary>
        /// Preenche o cardápio de café com uma lista predefinida de produtos.
        /// </summary>
        public void PreencherCardapio()
        {
            this.Produtos.Add(new Produto(1, "Não de Queijo", 5.00));
            this.Produtos.Add(new Produto(2, "Bolinha de Cogumelo", 7.00));
            this.Produtos.Add(new Produto(3, "Rissole de Palmito", 7.00));
            this.Produtos.Add(new Produto(4, "Coxinha de Carne de Jaca", 8.00));
            this.Produtos.Add(new Produto(5, "Fatia de Queijo de Caju", 9.00));
            this.Produtos.Add(new Produto(6, "Biscoito Amanteigado", 3.00));
            this.Produtos.Add(new Produto(7, "Cheesecake de Frutas Vermelhas", 15.00));
            this.Produtos.Add(new Produto(8, "Água", 3.00));
            this.Produtos.Add(new Produto(9, "Copo de Suco", 7.00));
            this.Produtos.Add(new Produto(10, "Café Espresso Orgânico", 6.00));
        }
    }
}
