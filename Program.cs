using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var cuenta1 = new CajaDeAhorro("CA1", 2500m, ["Samuel"])
            {
                TasaDeInteres = 0.05m
            };

            var cuenta2 = new CajaDeAhorro("CA2", 3000m, ["Facundo"])
            {
                TasaDeInteres = 0.05m
            };

            var cuenta3 = new CuentaCorriente("CC1", 3200m, ["Tomas"])
            {
                Comision = 0.02m,
                LimiteDeDescubierto = 500
            };

            var cuenta4 = new CuentaCorriente("CC2", 2100m, ["Rocio"])
            {
                Comision = 0.02m,
                LimiteDeDescubierto = 500
            };


            Console.WriteLine("== OPERACIONES ==");
            try
            {
                cuenta1.Depositar(200);
                cuenta1.AplicarInteres();
                cuenta1.Retirar(300);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            cuenta2.Estado = Estado.Inactiva;
            try
            {
                cuenta2.Depositar(100);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            try
            {
                cuenta3.Depositar(100);
                cuenta3.Retirar(500);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            try
            {
                cuenta4.Retirar(120);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            try
            {
                cuenta4.Depositar(100);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            Console.WriteLine("\n== RESUMEN DE CUENTAS ==");


            void MostrarResumen(CuentaBancaria cuenta)
            {
                var resumen = new
                {
                    Numero = cuenta.Numero,
                    Tipo = cuenta.GetType().Name,
                    Saldo = cuenta.Saldo,
                    Estado = cuenta.Estado.ToString()
                };

                Console.WriteLine($"Cuenta {resumen.Numero} | Tipo: {resumen.Tipo} | Saldo: {resumen.Saldo} | Estado: {resumen.Estado}");
            }

            MostrarResumen(cuenta1);
            MostrarResumen(cuenta2);
            MostrarResumen(cuenta3);
            MostrarResumen(cuenta4);
        }
    }
}