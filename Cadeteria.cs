
public class Cadeteria{
    private string nombre;
    private int telefono;
    private List<Cadete> listaDeCadetes;
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
        ListaDeCadetes = listaDeCadetes;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListaDeCadetes { get => listaDeCadetes; set => listaDeCadetes = value; }
    public List<Pedido> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }

    public void AgregarCadete(Cadete cadete){
        ListaDeCadetes.Add(cadete);
    }

    public void ListarCadetes(){
        foreach (var cadete in listaDeCadetes)
        {
            Console.WriteLine(cadete.InfoCadete());
        }
    }

    public void AsignarPedido(int IdCadete, Pedido pedido){
        Cadete cadete = BuscarCadeteId(IdCadete);
        if (cadete == null)
        {
            System.Console.WriteLine("No se encontro el Cadete");
            return;
        }
        cadete.AgregarPedido(pedido);

    }

    public void AsignarPedido(int IdCadete, int idPedido){
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

    public void ReasignarPedido(int idPedido, int idCadete1, int idCadete2){
        
        Cadete cadete1=BuscarCadeteId(idCadete1);
        if(cadete1==null){
            Console.WriteLine($"no se encontro el cadete con id {idCadete1}");
            return;
        }

        Cadete cadete2=BuscarCadeteId(idCadete2);
        if(cadete2==null){
            Console.WriteLine($"no se encontro el cadete con id {idCadete2}");
            return;
        }

        Pedido pedido=BuscarPedidoId(idPedido);
        
        if(pedido == null){
            Console.WriteLine("El Cadete no tiene el pedido buscado");
            return;
        }
        
        pedido.AsignarCadete(cadete2);

    }

    public Cadete BuscarCadeteId(int id){
        foreach (var cadete in listaDeCadetes)
        {
            if(cadete.Id == id){
                return cadete;
            }
        }
        return null;
    }
    
    public Pedido BuscarPedidoId(int nroPedido){

        foreach (var pedido in ListaPedidos)
        {
            if (pedido.NroPedido == nroPedido)
            {
                return pedido;
            }
        }

        return null;
    }

    public Pedido BuscarPedidoNombre(string nombreCliente){
        Pedido pedidoBuscado = null;
        foreach (var cadete in listaDeCadetes)
        {
            pedidoBuscado = cadete.BuscarPedidoNombre(nombreCliente);
        }
        return pedidoBuscado;
    }

    public void AgregarPedido(Pedido pedido){
        ListaPedidos.Add(pedido);
    }

    public float JornalACobrar(int idCadete){
        return (float)ListaPedidos.Where(pedido => pedido.Cadete.Id == idCadete).Count() * 500;
    }

}