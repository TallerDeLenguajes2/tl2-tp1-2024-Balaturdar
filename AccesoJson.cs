using System.Text.Json;

public class AccesoJson : AccesoADatos
{
    public override List<Cadete> ConvertirCadete(string rutaArchivo)
    {
        var jsonDocument = AbrirArchivoTexto(rutaArchivo);
        return JsonSerializer.Deserialize<List<Cadete>>(jsonDocument);
    }

    public override Cadeteria ConvertirCadeteria(string rutaArchivo)
    {
        var jsonDocument = AbrirArchivoTexto(rutaArchivo);
        Cadeteria cadeteria = JsonSerializer.Deserialize<Cadeteria>(jsonDocument);
        var listaCadetes = ConvertirCadete(Path.GetFullPath(@"../tl2-tp1-2024-Balaturdar/Json/Cadete.json"));
        foreach (var cadete in listaCadetes)
        {
            cadeteria.AgregarCadete(cadete);
        }
        return cadeteria;
    }

    public static string AbrirArchivoTexto(string nombreArchivo)
    {
        string documento;
        using (var archivoOpen = new FileStream(nombreArchivo, FileMode.Open))
        {
            using (var strReader = new StreamReader(archivoOpen))
            {
                documento = strReader.ReadToEnd();
                archivoOpen.Close();
            }
        }
        return documento;
    }
}