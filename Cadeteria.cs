using System.Security.Cryptography.X509Certificates;

public class Cadeteria{
    private string nombre;
    private int telefono;
    private List<Cadete> listaDeCadetes;

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

    public void AgregarCadete(Cadete cadete){
        ListaDeCadetes.Add(cadete);
    }

    public void ListarCadetes(){
        foreach (var cadete in listaDeCadetes)
        {
            Console.WriteLine(cadete.infoCadete());
        }
    }

    public void AsignarPedido(int IdCadete, Pedido pedido){
        foreach (var cadete in ListaDeCadetes)
        {
            if (cadete.Id == IdCadete)
            {
                cadete.AgregarPedido(pedido);
                break;
            }
        }
    }

    public void ReasignarPedido(int idPedido, int idCadete1, int idCadete2){
        
        Cadete cadete1=BuscarCadete(idCadete1);
        if(cadete1==null){
            Console.WriteLine($"no se encontro el cadete con id {idCadete1}");
            return;
        }
        Cadete cadete2=BuscarCadete(idCadete2);
        if(cadete2==null){
            Console.WriteLine($"no se encontro el cadete con id {idCadete2}");
            return;
        }
        Pedido pedido=cadete1.BuscarPedido(idPedido);
        if(pedido == null){
            Console.WriteLine("El Cadete no tiene el pedido buscado");
            return;
        }
        
        cadete1.EliminarPedido(idPedido);
        cadete2.AgregarPedido(pedido);

    }

    public Cadete BuscarCadete(int id){
        foreach (var cadete in listaDeCadetes)
        {
            if(cadete.Id == id){
                return cadete;
            }
        }
        return null;
    }
    
}