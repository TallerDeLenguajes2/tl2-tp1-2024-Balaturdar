public class Pedido{
    private int nroPedido;
    private string obs;
    private Cliente cliente;
    private string estado;

    public Pedido(int nroPedido, string obs, Cliente cliente)
    {
        NroPedido = nroPedido;
        Obs = obs;
        Cliente = cliente;
        Estado = "Pendiente";
    }

    public int NroPedido { get => nroPedido; set => nroPedido = value; }
    public string Obs { get => obs; set => obs = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    public string Estado { get => estado; set => estado = value; }

    public string InfoPedido(){
        return
            "Nro Pedido: " + NroPedido +
            "Observacion: " + Obs +
            "Cliente: " + Cliente.Nombre +
            "direccion" + Cliente.Direccion +
            "Referecia Direccion: " + Cliente.RefDireccion +
            "Estado: " + Estado;
    }

    public void Entregar(){
        Estado = "Entregado";
    }

}