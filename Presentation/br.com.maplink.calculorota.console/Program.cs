using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using br.com.maplink.calculorota.console.CalculoRotaWcf;

namespace br.com.maplink.calculorota.console
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<DadosEntrada> d = new List<DadosEntrada>();

            Console.WriteLine("Calculo de Rota - v[1.0]\n\n");
            Console.WriteLine("Entre com os dados do Ponto de Partida: ");

            d.Add(LerDados());

            Console.WriteLine("\n\nEntre com os dados do Ponto Final: ");

            d.Add(LerDados());
            object r;

            try
            {
                var c = new CalculoRotaClient();
                r = c.CalcularRotaMaisRapida(d.ToArray());

            }
            catch (Exception e)
            {
                r = e;
            }

            Console.WriteLine("\n\nResultado: ");
            PrintResult(r);

            Console.ReadKey();
        }

        #region Métodos internos...
        private static void PrintResult(object resultadoCalculo)
        {
            var obj = resultadoCalculo.GetType();
            var prop = obj.GetProperties();

            foreach (var p in prop)
            {
                if (p.Name.Contains("Extension"))
                    continue;

                Console.WriteLine("{0}: {1}", p.Name, p.GetValue(resultadoCalculo, null));
            }

        }

        private static DadosEntrada LerDados()
        {
            DadosEntrada d1 = new DadosEntrada();

            Console.Write("Estado: ");
            d1.Estado = Console.ReadLine();

            Console.Write("Cidade: ");
            d1.Cidade = Console.ReadLine();

            Console.Write("Rua: ");
            d1.Rua = Console.ReadLine();

            Console.Write("Numero: ");
            d1.Numero = Console.ReadLine();

            Console.Write("Cep: ");
            d1.Cep = Console.ReadLine();

            return d1;

        }
        #endregion
    }
}
