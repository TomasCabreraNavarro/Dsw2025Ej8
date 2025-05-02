namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{
    public TipoCuenta Tipo { get; }
    public string Numero { get; }
    public decimal Saldo { get; protected set; }
    public Estado Estado { get; set; }
    public decimal TasaDeInteres { get; init; }
    public decimal LimiteDeDescubierto { get; init; }
    public decimal Comision { get; set; }
    public string[] Titulares { get; }

    public CuentaBancaria(string numero, decimal saldo, string[] titulares)
    {
        Numero = numero;
        Saldo = saldo;
        Estado = Estado.Activa;
        Titulares = titulares;
    }

    public abstract void Depositar(decimal monto);
    public abstract void Retirar(decimal monto);
    public abstract void AplicarInteres();


}