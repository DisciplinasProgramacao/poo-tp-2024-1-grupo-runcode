using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runcode_poo.codigo
{
    class Cliente
    {
        private string nomeCliente;

        public Cliente(string nomeCliente)
        {
            this.nomeCliente = nomeCliente;
        }

        public string RetornarNome()
        {
            return nomeCliente;
        }
    }
}
