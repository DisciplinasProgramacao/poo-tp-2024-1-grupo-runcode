using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante_POO
{
    internal public class Restaurante
    {
        private Queue<Cliente> filaEspera;
        private List<Mesa> mesas;

        public Restaurante()
        {
            filaEspera = new Queue<Cliente>();
            mesas = new List<Mesa>();

            // Criando mesa
            for (int i = 1; i <= 4; i++)
            {
                mesas.Add(new Mesa(i, 4));
            }

            for (int i = 1; i <= 4; i++)
            {
                mesas.Add(new Mesa(i, 6));
            }

            for (int i = 1; i <= 2; i++)
            {
                mesas.Add(new Mesa(i, 8));
            }
        }

        public Mesa LocalizarMesa()
        {
        }

        public void AtenderCliente(Cliente cliente)
        {
        }

        public void AdicionarFilaEspera(Cliente cliente)
        {
            filaEspera.Enqueue(cliente);
            Console.WriteLine($"Cliente {cliente.Nome} adicionado à fila de espera.");
        }

        public void AlocarParaMesa(Mesa mesa, Requisicao requisicao)
        {
            if (mesa.EstaDisponivel)
            {
                mesa.EstaDisponivel = false;
                requisicao.HoraEntrada = DateTime.Now;
                Console.WriteLine($"Mesa {mesa.IdMesa} alocada para o cliente {requisicao.Cliente.Nome}.");
            }
            else
            {
                Console.WriteLine($"Mesa {mesa.IdMesa} está ocupada.");
            }
        }

        public void FinalizarMesa(Mesa mesa)
        {
            mesa.EstaDisponivel = true;
            Console.WriteLine($"Mesa {mesa.IdMesa} está disponivel");
        }
    }
}
