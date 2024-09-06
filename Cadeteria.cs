public class Cadeteria{
    private string nombre;
    private int telefono;
    private List<Cadete> listaDeCadetes;

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
            System.Console.WriteLine(cadete.infoCadete() + "\n");
        }
    }
}