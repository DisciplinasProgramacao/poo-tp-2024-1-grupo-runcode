using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runcode_poo.codigo
{
    class Mesa
    {
        private int id;
        private int quantidadeLugares;
        private bool ocupada;

        public Mesa(int numero, int qtdLugares) 
        { 
            this.id = numero;
            this.quantidadeLugares = qtdLugares;
            this.ocupada = false;

        }

        public bool verifivarDisponibilidade()
        {
            return ocupada;
        }

        public void ocuparMesa()
        {
            this.ocupada = true;
        }

        public void liberarMesa()
        {
            this.ocupada = false;
        }

    }
}
