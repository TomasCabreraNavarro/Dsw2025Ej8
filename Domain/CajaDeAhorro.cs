using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    public class CajaDeAhorro : CuentaBancaria
    {
        public decimal TasaDeInteres {  get; set; }

        public CajaDeAhorro(string numero, decimal saldo, string[] titulares) : base(numero, saldo, titulares)
        {
        }

        public override void Depositar(decimal monto)
        {
            if (Estado == Estado.Activa)
            {
                if (monto <= 0) throw new MontoNoValidoException();
                else { Saldo += monto; }
            }
            else
            {
                throw new CuentaNoActivaException(Estado);
            }
        }

        public override void Retirar(decimal monto)
        {
            if (Estado == Estado.Activa)
            {
                if (Saldo < monto)
                {
                    throw new SaldoInsuficienteException();
                    Estado = Estado.Suspendida;
                }
                else 
                { 
                    Saldo -= monto; 
                }
                
            }else { throw new CuentaNoActivaException(Estado); }
        }

        public override void AplicarInteres()
        {
            if (Estado == Estado.Activa)
            {
                Saldo += Saldo * TasaDeInteres;
            }
            else
            {
                throw new CuentaNoActivaException(Estado);
            }

        }
    }
}
