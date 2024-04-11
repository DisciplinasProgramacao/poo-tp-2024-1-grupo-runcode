﻿using System;

public class Requisicao
{

    private Cliente cliente;
    private DateTime dataRequisicao;
    private DateTime horaEntrada;
    private DateTime horaSaida;
    private int quantidadrClientes;
    private Mesa mesa;

    public void requisicao(Cliente cliente, int quantidadeCliente)
    {
        this.cliente = cliente;
        this.dataRequisicao = new DateTime();
        this.horaEntrada = null;
        this.horaSaida = null;
        this.quantidadeClientes = quantidadeCliente;
        this.mesa = null;
    }

    public void encerrarRequisicao()
    {
        this.horaSaida = new DateTime();
    }

}
