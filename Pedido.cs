public class Pedido{
    private int nroPedido;
    private string obs;
    private Cliente cliente;
    private string estado;
    private Cadete cadete;

    public Pedido(int nroPedido, string obs, Cliente cliente)
    {
        NroPedido = nroPedido;
        Obs = obs;
        Cliente = cliente;
        Estado = "Pendiente";
        Cadete = null;
        
    }

    public Pedido(int nroPedido, string obs, Cliente cliente, string estado)
    {
        this.nroPedido = nroPedido;
        this.obs = obs;
        this.cliente = cliente;
        this.estado = estado;
        Cadete = null;
    }

    public Pedido(int nroPedido, string obs, Cliente cliente, Cadete cadete)
    {
        this.nroPedido = nroPedido;
        this.obs = obs;
        this.cliente = cliente;
        this.cadete = cadete;
    }

    public int NroPedido { get => nroPedido; set => nroPedido = value; }
    public string Obs { get => obs; set => obs = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    public string Estado { get => estado; set => estado = value; }
    public Cadete Cadete { get => cadete; set => cadete = value; }

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
    public void AsignarCadete (Cadete cadete){
        Cadete = cadete;
    }

}