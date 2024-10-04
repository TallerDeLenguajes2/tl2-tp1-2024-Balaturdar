static public class MenuInterfaz
{
    static public int Menu()
    {
        int opc;
        bool aux;
        Console.WriteLine(@"
    *******************************************
    ** 1- dar de alta pedidos                **
    ** 2- asignarlos a cadetes               **
    ** 3- cambiarlos de estado               **
    ** 4- reasignar el pedido a otro cadete. **
    ** 5- listar pedidos de cadete           **
    ** 6- listar cadetes                     **
    ** 7- Salir                              **
    *******************************************
    ");
        return Validar("Elija una opcion","debe ingresar un numero para elegir una opcion");
    }

    static public int Validar(string texto1, string texto2)
    {
        bool aux;
        int opc;
        do
        {
            System.Console.WriteLine(texto1);
            aux = int.TryParse(Console.ReadLine(), out opc);
            if (!aux)
            {
                System.Console.WriteLine(texto2);
            }
        } while (!aux);
        return opc;
    }
}