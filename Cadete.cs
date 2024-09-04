public class Cadete{
    private int id;
    private string nombre;
    private string direccion;
    private int telefono;
    private List<Pedido> listaPedidosPendientes;
    private List<Pedido> ListaPedidosEntregados;

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
    public List<Pedido> ListaPedidosPendientes { get => listaPedidosPendientes; set => listaPedidosPendientes = value; }
    public List<Pedido> ListaPedidosEntregados1 { get => ListaPedidosEntregados; set => ListaPedidosEntregados = value; }

    public void JornalACobrar(){
        float jornal = ListaPedidosEntregados.Count() * 500;
        System.Console.WriteLine($"El jornal de el cadete {Nombre} es {jornal} y entrego {ListaPedidosEntregados.Count()}");
    }
}