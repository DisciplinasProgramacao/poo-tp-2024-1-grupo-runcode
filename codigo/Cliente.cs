using System;

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
