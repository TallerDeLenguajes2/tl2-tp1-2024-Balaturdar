
int opc;
bool aux;
//List<Cadete> cadetes; leer csv

Cadeteria MiCadeteria = new Cadeteria("La Cadeteria",1234567890);

do
{
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

    do
    {
        System.Console.WriteLine("Ingrese una opcion:");;
        aux = int.TryParse(Console.ReadLine(), out opc);
        if (!aux)
        {
            System.Console.WriteLine("Debe ingresar un numero para seleccionar una opcion");
        }
    } while(!aux);
     



        
} while (opc != 7);

