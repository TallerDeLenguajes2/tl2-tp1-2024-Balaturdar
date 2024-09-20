public class Cadete{
    private int id;
    private string nombre;
    private string direccion;
    private int telefono;
    private List<Pedido> listaPedidos;

    public Cadete(int id, string nombre, string direccion, int telefono)
    {
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
    }

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public List<Pedido> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }

    public void JornalACobrar(){
        int cantEntregados = CantidadEntregados();
        float jornal = cantEntregados * 500;
        System.Console.WriteLine($"El jornal de el cadete {Nombre} es {jornal} y entrego {cantEntregados}");
    }

    public string InfoCadete(){
        return
            "Id: " + Id +
            "Nombre: " + Nombre +
            "Direccion: " + Direccion +
            "telefono: " + Telefono +
            "cantidad de Pedidos pendientes: " + ListaPedidos.Count() +
            "Cantidad de pedidos entregados: " + CantidadEntregados()
        ;
    }

    public void EntregarPedido(int id){
        foreach (var pedido in ListaPedidos)
        {
            if(pedido.NroPedido == id){
                pedido.Estado = "Entregado";
                break;
            }
        }
    }

    public int CantidadEntregados(){
        int i=0;
        foreach (var pedido in ListaPedidos)
        {
            if (pedido.Estado == "Entregado")
            {
                i++;
            }
        }
        return i;
    }

    public void EliminarPedido(int id){
        foreach (var pedido in ListaPedidos)
        {
            if(pedido.NroPedido == id){
                ListaPedidos.Remove(pedido);
                break;
            }
        }
    }

    public void AgregarPedido(Pedido pedido){
        ListaPedidos.Add(pedido);
    }

    public int CantPedidosPendientes(){
        int i=0;
        foreach (var pedido in ListaPedidos)
        {
            if (pedido.Estado == "Pendiente")
            {
                i++;
            }
        }
        return i;
    }

    public int CantPedidosTotal(){
        return ListaPedidos.Count();
    }

    public void ListarPedidos(){
        foreach (var pedido in ListaPedidos)
        {
            Console.WriteLine(pedido.InfoPedido());
        }
    }

    public Pedido BuscarPedidoId(int id){
        foreach (var pedido in listaPedidos)
        {
            if(pedido.NroPedido == id){
                return pedido;
            }
        }
        return null;
    }

    public Pedido BuscarPedidoNombre(string nombreCliente){
        foreach (var pedido in listaPedidos)
        {
            if(pedido.Cliente.Nombre == nombreCliente){
                return pedido;

            }
        }
        return null;
    }

}