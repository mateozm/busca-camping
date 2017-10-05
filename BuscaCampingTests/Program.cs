using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuscaCamping.DataAccess.DataReaders;
using Newtonsoft.Json.Converters;

namespace BuscaCampingTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var gc = new GestorCliente();
            var clientes = gc.ObtenerTodos();

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(clientes));
            Console.ReadKey();
        }
    }
}
