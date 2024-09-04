public class Cliente{
    private string nombre;
    private string direccion;
    private int telefono;
    private string refDireccion;

    public Cliente(string nombre, string direccion, int telefono, string refDireccion)
    {
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        RefDireccion = refDireccion;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public string RefDireccion { get => refDireccion; set => refDireccion = value; }

    public string InfoCliente(){
        return 
            "nombre: " + Nombre +
            "Direccion: " + Direccion +
            "Telefono: " + Telefono +
            "Referecia Direccion: " + RefDireccion;
    }
}