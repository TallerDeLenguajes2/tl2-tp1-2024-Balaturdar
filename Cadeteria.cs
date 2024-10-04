
public class Cadeteria
{
    private string nombre;
    private int telefono;
    private List<Cadete> listaCadetes;
    private List<Pedido> listaPedidos;

    public Cadeteria(string nombre, int telefono)
    {
        Nombre = nombre;
        Telefono = telefono;
    }
    public Cadeteria(string nombre, int telefono, List<Cadete> listaDeCadetes)
    {
        Nombre = nombre;
        Telefono = telefono;
        ListaCadetes = listaDeCadetes;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListaCadetes { get => listaCadetes; set => listaCadetes = value; }
    public List<Pedido> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }

    public void AgregarCadete(Cadete cadete)
    {
        ListaCadetes.Add(cadete);
    }

    public void ListarCadetes()
    {

        foreach (var cadete in listaCadetes)
        {
            Console.WriteLine(cadete.InfoCadete());
        }
    }

    public void AsignarPedido(int IdCadete, int idPedido)
    {
        Cadete cadete = BuscarCadeteId(IdCadete);
        if (cadete == null)
        {
            System.Console.WriteLine("no se encontro el cadete");
            return;
        }
        Pedido pedido = BuscarPedidoId(idPedido);
        if (pedido == null)
        {
            System.Console.WriteLine("no se encontro el pedido");
            return;
        }

        if (pedido.Cadete != null)
        {
            System.Console.WriteLine("este pedido ya esta asignado");
            return;
        }
        pedido.AsignarCadete(cadete);

    }

    public void ReasignarPedido(int idPedido, int idCadete1)
    {

        Cadete cadete1 = BuscarCadeteId(idCadete1);
        if (cadete1 == null)
        {
            Console.WriteLine($"no se encontro el cadete con id {idCadete1}");
            return;
        }

        Pedido pedido = BuscarPedidoId(idPedido);
        if (pedido == null)
        {
            Console.WriteLine("El Cadete no tiene el pedido buscado");
            return;
        }

        pedido.AsignarCadete(cadete1);
    }

    public Cadete BuscarCadeteId(int id)
    {
        return ListaCadetes.First(cadete => cadete.Id == id);
    }

    public Pedido BuscarPedidoId(int nroPedido)
    {
        return ListaPedidos.First(pedido => pedido.NroPedido == nroPedido);
    }

    public Pedido BuscarPedidoNombre(string nombreCliente)
    {
        return ListaPedidos.First(pedido => pedido.Cliente.Nombre == nombreCliente);
    }

    public void AgregarPedido(Pedido pedido)
    {
        ListaPedidos.Add(pedido);
    }

    public float JornalACobrar(int idCadete)
    {
        return (float)ListaPedidos.Where(pedido => pedido.Cadete.Id == idCadete).Count() * 500;
    }

    public void ListarPedidosCadete(int idCadete)
    {
        var pedidosCadete = ListaPedidos.Where(pedido => pedido.Cadete.Id == idCadete);
        foreach (var pedidos in pedidosCadete)
        {
            pedidos.InfoPedido();
        }
    }

    public void EliminarPedido(int idPedido)
    {
        ListaPedidos.Remove(ListaPedidos.First(pedido => pedido.NroPedido == idPedido));
    }

    public int CantEntregadosCadete(int idCadete)
    {
        return ListaPedidos.Where(pedido => pedido.Cadete.Id == idCadete && pedido.Estado == "Entregado").Count();
    }

    public int CantPedidosPendientesCadete(int idCadete)
    {
        return ListaPedidos.Where(pedido => pedido.Cadete.Id == idCadete && pedido.Estado == "Pendiente").Count();
    }

    public int CantPedidosTotalCadete(int idCadete)
    {
        return ListaPedidos.Where(pedido => pedido.Cadete.Id == idCadete).Count();
    }

    public void promedio()
    {
        float promedioEntregadosPorCadete;

        foreach (var cadete in ListaCadetes)
        {
            var idCadete = cadete.Id;
            var cobra = JornalACobrar(idCadete);
            promedioEntregadosPorCadete = CantEntregadosCadete(idCadete) / CantPedidosTotalCadete(idCadete);
            System.Console.WriteLine($"el promedio de envios entregados por este cadete es {promedioEntregadosPorCadete} y debe cobrar {cobra}");
        }
    }

}