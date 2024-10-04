public class CsvHelper{

    public static List<string[]> LeerArchivo(string nombreArchivo)
    {
        List<string[]> archivoLeido = new();
        string linea;
        using (FileStream miArchivo = new FileStream(nombreArchivo, FileMode.Open))
        {
            using (StreamReader lector = new StreamReader(miArchivo))
            {
                while ((linea = lector.ReadLine()) != null)
                {
                    String[] fila = linea.Split(",");
                    archivoLeido.Add(fila);
                }
            }
        }
        return archivoLeido;
    }

    public static void AgregarLinea(string nombreArchivo, string linea)
    {
        using (FileStream miArchivo = new FileStream(nombreArchivo, FileMode.Append, FileAccess.Write))
        {
            using (StreamWriter escritor = new StreamWriter(miArchivo))
            {
                escritor.WriteLine(linea);
            }
        }
    }

    public static Cadeteria ConvertirCadeteria(List<string[]> Fila)
    {
        string nombre = null;
        int telefono = 0;
        foreach (string[] i in Fila)
        {
            nombre = i[0];
            telefono = int.Parse(i[1]);
        }
        
        return new Cadeteria(nombre, telefono, ConvertirCadete(LeerArchivo(Path.GetFullPath(@"../tl2-tp1-2024-Balaturdar/Csv/Cadetes.csv"))));
    }

    public static List<Cadete> ConvertirCadete(List<string[]> Filas)
    {
        List<Cadete> misCadetes = new List<Cadete>();
        foreach (string[] fila in Filas)
        {
            Cadete cad = new Cadete(int.Parse(fila[0]), fila[1], fila[2], int.Parse(fila[3]));
            misCadetes.Add(cad);
        }
        return misCadetes;
    }

    public static List<Pedido> ConvertirPedidos(List<string[]> Filas)
    {
        List<Pedido> misPedidos = new List<Pedido>();
        foreach (string[] fila in Filas)
        {
            Cliente cliente = new Cliente(fila[2],fila[3],int.Parse(fila[4]),fila[5]);
            Pedido ped = new Pedido(int.Parse(fila[0]),fila[1],cliente,fila[6]);
            misPedidos.Add(ped);
        }
        return misPedidos;
    }

    public static string CrearLineaDePedidos(Pedido pedido)
    {
        string linea = $"{pedido.NroPedido.ToString()},{pedido.Obs},{pedido.Cliente.Nombre},{pedido.Cliente.Direccion},{pedido.Cliente.Telefono.ToString()},{pedido.Cliente.RefDireccion},{pedido.Estado.ToString()}";
        return linea;
    }
    public static void ReescribirArchivoCsv(List<Pedido> pedidos, string nombreArchivo)
    {
        using (StreamWriter sw = new StreamWriter(nombreArchivo, false))
        {
            foreach (var pedido in pedidos)
            {
                string linea = CrearLineaDePedidos(pedido);
                sw.WriteLine(linea);
            }
        }
    }
    

}