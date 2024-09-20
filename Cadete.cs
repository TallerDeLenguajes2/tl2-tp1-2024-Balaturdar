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

    

    public string InfoCadete(){
        return
            "Id: " + Id +
            "Nombre: " + Nombre +
            "Direccion: " + Direccion +
            "telefono: " + Telefono ;
        ;
    }

}