using System;
using Microsoft.Data.Sqlite;


//*********** calse dueño************
public class Dueno
{
    private int idDueño;
    private string nombre;
    private string dpi;
    private string nit;

    public int IdDueño
    {
        get
        {
            return idDueño;
        }
        set
        {
           idDueño= value;
        }
    }

    public string Nombre
    {
        get
        {
            return nombre;
        }
        set
        {
            if (!string.IsNullOrWhiteSpace(value) && value.Length >=3)
                nombre= value;
            else
            {
                Console.WriteLine("Nombre invalido (minimo 3 caracteres");
                Environment.Exit(0);
         
            }
        }
    }

    public string Dpi
    {
        get { return dpi; }
        set {
            if ( value.Length==13 && long.TryParse (value, out _))
            dpi = value;
            else
            {
                Console.WriteLine("No puede tener menos de 13 caracteres");
                Environment.Exit (0);
            }
        }
    }

    public string Nit
    {
        get { return nit; }
        set
        {
            if (value.Length == 9 && long.TryParse(value, out _))
                nit = value;
            else
            {
                Console.WriteLine("No puede tener menos de 9 caracteres");
                Environment.Exit(0);
            }
        }
    }

    public Dueno (string dpi,string nombre, string nit)
    {
        
        Nombre= nombre;
        Dpi= dpi;
        Nit= nit;
    }
    }


//******** clase vehiculo*******
public class Vehiculo
{
    private int idCarro;
    private string tipo;
    private string marca;
    private string linea; 
    private string noVin;
    private double costoInicial;
    private string fechaIngreso;
    private string estado;
    private int idDueño;

    public int IdCarro
    {
        get
        {
            return idCarro;
        }
        set { idCarro = value; }
            }

    public string Tipo
    {
        get
        {
            return tipo;
        }
        set
        {
            if (!string.IsNullOrWhiteSpace(value) && value.Length<3 )
            {
                tipo = value;
            }
            else
            {
                Console.WriteLine("Ingreso invalido(Minimo 3 caracteres)");
                Environment.Exit(0);
            
            }
        }
    }

    public string Marca
    {
        get
        {
            return marca;
        }
        set
        {
            if (!string.IsNullOrWhiteSpace(value) && value.Length < 3)
            {
                marca = value;
            }
            else
            {
                Console.WriteLine("Ingreso invalido(Minimo 3 caracteres)");
                Environment.Exit(0);

            }
        }
    }  
    public string Linea
    {
        get
        {
            return linea;
        }
        set
        {
            if (!string.IsNullOrWhiteSpace(value) && value.Length < 3)
            {
                linea = value;
            }
            else
            {
                Console.WriteLine("Ingreso invalido(Minimo 3 caracteres)");
                Environment.Exit(0);

            }
        }
    }
    public string NoVin
    {
        get { return noVin; }
        set
        {
            if (value.Length == 17 && long.TryParse(value, out _))
                noVin = value;
            else
            {
                Console.WriteLine("No puede tener menos de 17 caracteres");
                Environment.Exit(0);
            }
        }
    }

   public double CostoInicial
    {
        get
        { return costoInicial; }
        set
        {
            if (value >= 0)
            {
                costoInicial = value;
            }
            else
            {
                Console.WriteLine("El costo no puedser negativo");
                Environment.Exit(0);
            }
        }

    }
    public string FechaIngreso
    {
        get { return fechaIngreso; }
    
        set { fechaIngreso = value; }
    }
    public string Estado
    {
        get
        {
            if (string.IsNullOrWhiteSpace(estado))
            {
                return "No definido";

            }
            return estado;
        }

        set
        {
            if (value== "activo"|| value=="en reparacion"|| value=="finalizado" || value=="entregado")
            {
              estado = value;      
            }
        }

    }

    public int IdDueño
    {
        get
        { return idDueño; }
        set
        {
            idDueño = value;
        }
    }

    public Vehiculo(string tipo, string marca, string linea, string noVin, double costoInicial, string fechaIngreso, string estado, int idDueño)
    {
        Tipo=tipo;
        Marca=marca;
        NoVin=noVin;
        Linea=linea;
        CostoInicial=costoInicial;
        FechaIngreso=fechaIngreso;
        Estado=estado;
        IdDueño = idDueño;
    }
    }
// clase gasto**********
public class GastoFinanciero
{
    private int idGasto;
    private double monto;

    public int IdGasto
    {
        get { return idGasto; }
        set { idGasto = value; }
    }
    public double Monto
    {
        get { return monto; } 
        set
        {
            if (value >= 0)
            {
                monto = value;
            }
            else
            {
                Console.WriteLine("El monto no puedser negativo");
                Environment.Exit(0);
            }
        }
    }
    public GastoFinanciero(double monto)
    {
        monto = monto;
    }
}

// clase reparacion***************************
public class Reparacion:GastoFinanciero
{
    private string tipoReparacion;
    private string cantidadReparacion;
    private string cantidadpiezas;
    private int idCarro;

    public string TipoReparacion
    {
        get { if (string.IsNullOrWhiteSpace(tipoReparacion))
            {
                return "No especificada";
            }
            return tipoReparacion;
        }
        set
        {
            if (!string.IsNullOrWhiteSpace(value)&& value.Length<3)
            {
                tipoReparacion= value;
                
            }
            else
            {
                Console.WriteLine("Ingreso invalido(Minimo 3 caracteres)");
                Environment.Exit(0);

            }

        }
    }

    public string CantidadReparacion
    {
        get
        {
            if (string.IsNullOrWhiteSpace(cantidadReparacion))
            {
                return "0";
            }
            return cantidadReparacion;
        }
        set
        {
            if (int.TryParse(value, out int cantidad) && cantidad>=0)
            {
                cantidadReparacion = value;
            }
            else
            {
                Console.WriteLine("La cantidad no puede ser negativa");
                Environment.Exit(0);
            }
        }
    }

    public string CantidadPiezas
    {
        get
        {
            if (string.IsNullOrWhiteSpace(cantidadpiezas))
            {
                return "0";
            }
            return cantidadpiezas;
        }
        set
        {
            if (int.TryParse (value, out int cantidad) && cantidad>=0)
            {
                cantidadpiezas = value;
            }
        }
    }

    public int IdCarro
    {
        get
        {
            return idCarro;
        }
        set { idCarro = value; }
    }

    public Reparacion (string tipoReparacion, string cantidadReaparacion, 
        string cantidadPiezas, double costoReparacion, int idCarro): base (costoReparacion)
    {
        TipoReparacion=tipoReparacion;
        CantidadReparacion=cantidadReaparacion;
        CantidadPiezas=cantidadPiezas;
        IdCarro = idCarro;
    }

    }

//******* clase gastos adicionales*********
public class GastosAdicionales : GastoFinanciero
{
    private double viaticos;
    private double instancia;
    private double limpieza;
    private int idVenta;

    public double Viaticos
    {
        get
        {
            if (viaticos < 0)
                return 0;

            return viaticos;
        }
        set
        {
            if (value >= 0)
                viaticos = value;

        }
    }

    public double Instancia
    {
        get
        {
            if (instancia < 0)
                return 0;

            return instancia;
        }
        set
        {
            if (value >= 0)
                instancia = value;
            else
            {
                Console.WriteLine("Ingreso invalido(Minimo 3 caracteres)");
                Environment.Exit(0);

            }
        }
    }

    public double Limpieza
    {
        get
        {
            if (limpieza < 0)
                return 0;

            return limpieza;
        }
        set
        {
            if (value >= 0)
                limpieza = value;
            else
            {
                Console.WriteLine("Ingreso invalido(Minimo 3 caracteres)");
                Environment.Exit(0);

            }
        }
    }
    public int IdVenta
    {
        get { return idVenta; }
        set { idVenta = value; }
    }

    public GastosAdicionales(double viaticos, double instancia, double limpieza, int idVenta, double montoGasto)
        : base(montoGasto)
    {
        Viaticos = viaticos;
        Instancia = instancia;
        Limpieza = limpieza;
        IdVenta = idVenta;
    }
}









