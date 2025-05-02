using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    public class CuentaCorriente : CuentaBancaria
    {
        public CuentaCorriente(string numero, decimal saldo, string[] titulares) : base(numero, saldo, titulares)
        {
        }

        public override void Depositar(decimal monto)
        {
            if (Estado == Estado.Activa)
            {
                if (monto <= 0) throw new MontoNoValidoException();
                else
                {
                    monto -= monto * Comision;
                    Saldo += monto;
                }
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
                if (monto > 0)
                {
                    if (Saldo - monto >= -LimiteDeDescubierto)
                    {
                        Saldo -= monto;
                    }
                    if (Saldo < 0)
                    {
                        Estado = Estado.Suspendida;
                    }
                }
                else
                {
                    throw new SaldoInsuficienteException();
                    Estado = Estado.Suspendida;

                }
            }
            else
            {
                throw new CuentaNoActivaException(Estado);
            }
        }

        public override void AplicarInteres() 
        { 
            throw new NotSupportedException("Las cuentas corrientes no generan interés.");
        } 
    }
}
