using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runcode_poo.codigo
{ 

    class Requisicao
    {

        private Cliente cliente;
        private DateTime dataRequisicao;
        private DateTime? horaEntrada;
        private DateTime? horaSaida;
        private int quantidadeClientes;
       // private Mesa mesa;

        public Requisicao(Cliente cliente, int quantidadeCliente)
        {
            this.cliente = cliente;
            this.dataRequisicao = new DateTime();
            this.horaEntrada = null;
            this.horaSaida = null;
            this.quantidadeClientes = quantidadeCliente;
         //   this.mesa = null;
        }

        public void encerrarRequisicao()
        {
            this.horaSaida = new DateTime();
        }

        //public void addMesaRequisicao(Mesa mesa)
        //{
        //    this.mesa = mesa;
        //}


    }

}
