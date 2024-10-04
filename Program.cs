

int opc;
int NroPedido = 0;

AccesoADatos accesoDatos;
Cadeteria MiCadeteria;

string tipoArchivo = getExtensionArchivo();
if (tipoArchivo == ".csv")
{
    accesoDatos = new AccesoCsv();
    MiCadeteria = accesoDatos.ConvertirCadeteria(Path.GetFullPath(@$"../tl2-tp1-2024-Balaturdar/Csv/Cadeteria{tipoArchivo}"));
}
else
{
    accesoDatos = new AccesoJson();
    MiCadeteria = accesoDatos.ConvertirCadeteria(Path.GetFullPath(@$"../tl2-tp1-2024-Balaturdar/Json/Cadeteria{tipoArchivo}"));
}


do
{
    opc = MenuInterfaz.Menu();

    switch (opc)
    {
        case 1://altaPedido
            //crear cliente
            System.Console.WriteLine("ingrese el nombre del cliente");
            var NombreCliente = Console.ReadLine();

            int TelefonoCliente = MenuInterfaz.Validar("ingrese el telefono del cliente", "Debe ingresar un numero");

            System.Console.WriteLine("ingrese la direccion del cliente");
            var DireccionCliente = Console.ReadLine();
            System.Console.WriteLine("ingrese la referencia de cliente");
            var RefDireccionCliente = Console.ReadLine();

            System.Console.WriteLine("Ingrese las observaciones del pediodo");
            var obsPedido = Console.ReadLine();
            MiCadeteria.AgregarPedido(new Pedido(NroPedido, obsPedido, new Cliente(NombreCliente, DireccionCliente, TelefonoCliente, RefDireccionCliente)));
            break;

        case 2://asignarpedidoCadete
            int NroPedidoAsignar = MenuInterfaz.Validar("Ingrese el numero del pedido que quiere asignar", "Debe ingresar un numero");
            int IdCadeteAsignar = MenuInterfaz.Validar("Ingrese el ID del cadete", "Debe ingresar un numero");
            MiCadeteria.AsignarPedido(IdCadeteAsignar, NroPedidoAsignar);
            break;

        case 3://cambiar estado pedido
            NroPedido = MenuInterfaz.Validar("ingrese el Nro del pedido", "Debe ingresar un numero");
            Pedido PedidoEstado = MiCadeteria.BuscarPedidoId(NroPedido);
            if (PedidoEstado == null)
            {
                System.Console.WriteLine("no e encontro ningun pedido con ese nro de pedido");
                break;
            }
            PedidoEstado.Entregar();
            break;

        case 4://reasignarPedido
            int idCadete1;
            idCadete1 = MenuInterfaz.Validar("ingrese el ID del cadete al que va a asignar el pedido", "Debe ingresar un numero");
            NroPedido = MenuInterfaz.Validar("ingrese el nro de pedido", "Debe ingresar un numero");
            MiCadeteria.ReasignarPedido(NroPedido, idCadete1);
            break;

        case 5://listarpedidoCadete
            int idCadete = MenuInterfaz.Validar("ingrese el id del cadete", "Debe ingresar un numero");
            Cadete cadete = MiCadeteria.BuscarCadeteId(idCadete);
            if (cadete == null)
            {
                System.Console.WriteLine("no se encontro ningun cadete con ese ID"); ;
                break;
            }

            MiCadeteria.ListarPedidosCadete(idCadete);
            break;
        case 6://ListarCadetes
            MiCadeteria.ListarCadetes();
            break;
        case 7://salir
            break;
    }

} while (opc != 7);


MiCadeteria.promedio();


string getExtensionArchivo()
{
    int opcionArchivo;
            string extension;

            Console.WriteLine(@"
            *************************************************
            **Seleccione con qué tipo de archivos trabajará**
            **1. JSON                                      **
            **2. CSV                                       **
            *************************************************
            ");
            

            while (!int.TryParse(Console.ReadLine(), out opcionArchivo) || (opcionArchivo != 1 && opcionArchivo != 2))
            {
                Console.WriteLine("Por favor, introduce un número válido.\n");
            }

            if (opcionArchivo == 1)
            {
                extension = ".json";
            }
            else
            {
                extension = ".csv";
            }

            return extension;
}