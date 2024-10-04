int opc;
bool aux;
int NroPedido = 0;
Cadeteria MiCadeteria = CsvHelper.ConvertirCadeteria(CsvHelper.LeerArchivo(Path.GetFullPath(@"../tl2-tp1-2024-Balaturdar/Csv/Cadeteria.csv")));

do
{
    opc = MenuInterfaz.Menu();

    switch (opc)
    {
        case 1://altaPedido
            //crear cliente
            System.Console.WriteLine("ingrese el nombre del cliente");
            var NombreCliente = Console.ReadLine();
            System.Console.WriteLine("ingrese el telefono del cliente");
            int TelefonoCliente;
            do
            {
                System.Console.WriteLine("Ingrese una opcion:");
                aux = int.TryParse(Console.ReadLine(), out TelefonoCliente);
                if (!aux)
                {
                    System.Console.WriteLine("Debe ingresar un numero");
                }
            } while (!aux);
            System.Console.WriteLine("ingrese la direccion del cliente");
            var DireccionCliente = Console.ReadLine();
            System.Console.WriteLine("ingrese la referencia de cliente");
            var RefDireccionCliente = Console.ReadLine();

            System.Console.WriteLine("Ingrese las observaciones del pediodo");
            var obsPedido = Console.ReadLine();
            MiCadeteria.AgregarPedido(new Pedido(NroPedido, obsPedido, new Cliente(NombreCliente, DireccionCliente, TelefonoCliente, RefDireccionCliente)));
            break;

        case 2://asignarpedidoCadete
            System.Console.WriteLine("Ingrese el numero del pedido que quiere asignar");
            int NroPedidoAsignar;
            do
            {
                System.Console.WriteLine("Ingrese el numero de pedido");
                aux = int.TryParse(Console.ReadLine(), out NroPedidoAsignar);
                if (!aux)
                {
                    System.Console.WriteLine("Debe ingresar un numero");
                }
            } while (!aux);

            System.Console.WriteLine("Ingrese el ID del cadete");
            int IdCadeteAsignar;
            do
            {
                System.Console.WriteLine("Ingrese una opcion:");
                aux = int.TryParse(Console.ReadLine(), out IdCadeteAsignar);
                if (!aux)
                {
                    System.Console.WriteLine("Debe ingresar un numero");
                }
            } while (!aux);
            MiCadeteria.AsignarPedido(IdCadeteAsignar, NroPedidoAsignar);
            break;

        case 3://cambiar estado pedido

            System.Console.WriteLine("ingrese el Nro del pedido");
            do
            {
                System.Console.WriteLine("Ingrese una opcion:");
                aux = int.TryParse(Console.ReadLine(), out NroPedido);
                if (!aux)
                {
                    System.Console.WriteLine("Debe ingresar un numero");
                }
            } while (!aux);
            Pedido PedidoEstado = MiCadeteria.BuscarPedidoId(NroPedido);
            if (PedidoEstado == null)
            {
                System.Console.WriteLine("no e encontro ningun pedido con ese nro de pedido");
                break;
            }
            PedidoEstado.Entregar();

            break;

        case 4://reasignarPedido
            int idCadete1, idCadete2;
            System.Console.WriteLine("ingrese el ID del cadete que tiene el pedido");
            do
            {
                System.Console.WriteLine("Ingrese una opcion:");
                aux = int.TryParse(Console.ReadLine(), out idCadete1);
                if (!aux)
                {
                    System.Console.WriteLine("Debe ingresar un numero");
                }
            } while (!aux);
            System.Console.WriteLine("ingrese el Id del cadete que al que va a asignar el pedido");
            do
            {
                System.Console.WriteLine("Ingrese una opcion:");
                aux = int.TryParse(Console.ReadLine(), out idCadete2);
                if (!aux)
                {
                    System.Console.WriteLine("Debe ingresar un numero");
                }
            } while (!aux);
            System.Console.WriteLine("ingrese el nro de pedido");
            do
            {
                System.Console.WriteLine("Ingrese una opcion:");
                aux = int.TryParse(Console.ReadLine(), out NroPedido);
                if (!aux)
                {
                    System.Console.WriteLine("Debe ingresar un numero");
                }
            } while (!aux);

            MiCadeteria.ReasignarPedido(NroPedido, idCadete1, idCadete2);
            break;

        case 5://listarpedidoCadete
            int idCadete;
            Cadete cadete;
            System.Console.WriteLine("ingrese el id del cadete");
            do
            {
                System.Console.WriteLine("Ingrese una opcion:");
                aux = int.TryParse(Console.ReadLine(), out idCadete);
                if (!aux)
                {
                    System.Console.WriteLine("Debe ingresar un numero");
                }
            } while (!aux);

            cadete = MiCadeteria.BuscarCadeteId(idCadete);
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
