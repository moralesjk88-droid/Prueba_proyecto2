using System;
using System.Transactions;
using Microsoft.Data.Sqlite;


//*********** calse dueño************
public class Dueno
{
    private int idDueño;
    private string nombre = "";
    private string dpi = "";
    private string nit = "";

    public int IdDueño
    {
        get
        {
            return idDueño;
        }
        set
        {
            if (value >= 0)
                idDueño = value;
            else
            {
                Console.WriteLine("Error: El IdDueño no puede ser negativo para la base de datos.");
                
            }
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
                
         
            }
        }
    }

    public string Dpi
    {
        get { return dpi; }
        set {
            if ( !string.IsNullOrWhiteSpace(value)&&value.Length==13 && long.TryParse (value, out _))
            dpi = value;
            else
            {
                Console.WriteLine("El DPI debe tener exactamente 13 caracteres numéricos");
             
            }
        }
    }

    public string Nit
    {
        get { return nit; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value) && value.Length == 9) 
                nit = value;
            else
            {
                Console.WriteLine("El Nit debe tener exactamente 9 caracteres");
         
            }
        }
    }

    public Dueno(string nombre, string dpi, string nit)
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
    private string tipo = "";
    private string marca = "";
    private string linea = "";
    private string noVin = "";
    private double costoInicial;
    private string fechaIngreso = "";
    private string estado = "activo";
    private int idDueño;
    public int IdCarro
    {
        get
        {
            return idCarro;
        }
        set
        {
            if (value >= 0)
                idCarro = value;
            else
            {
                Console.WriteLine("Error: El IdCarro no puede ser negativo.");

            }
        }
    }
    public string Tipo
    {
        get
        {
            return tipo;
        }
        set
        {
            if (!string.IsNullOrWhiteSpace(value) && value.Length >= 3)
            {
                tipo = value;
            }
            else
            {
                Console.WriteLine("Ingreso invalido(Minimo 3 caracteres)");

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
            if (!string.IsNullOrWhiteSpace(value) && value.Length >= 3)
            {
                marca = value;
            }
            else
            {
                Console.WriteLine("Ingreso invalido(Minimo 3 caracteres)");


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
            if (!string.IsNullOrWhiteSpace(value) && value.Length >= 3)
            {
                linea = value;
            }
            else
            {
                Console.WriteLine("Ingreso invalido(Minimo 3 caracteres)");


            }
        }
    }
    public string NoVin
    {
        get { return noVin; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value) && value.Length == 17)
                noVin = value;
            else
            {
                Console.WriteLine("El VIN debe tener exactamente 17 caracteres");

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

            }
        }

    }
    public string FechaIngreso
    {
        get { return fechaIngreso; }

        set {
            if (!string.IsNullOrWhiteSpace(value))
                fechaIngreso = value;
            else
            {
                Console.WriteLine("La fecha de ingreso no puede estar vacía");

            }
        }
    }
    public string Estado
    {
        get
        {
             return string.IsNullOrWhiteSpace(estado) ? "activo" : estado;
               
        }

        set
        {
            string valorMin = value.ToLower();
            if (valorMin == "activo" || valorMin == "en reparacion" || valorMin == "finalizado" || valorMin == "entregado")
                estado = valorMin;
            else
            {
                Console.WriteLine("Estado inválido. Valores permitidos: activo, en reparacion, finalizado, entregado");
              
            }
        }

    }

    public int IdDueño
    {
        get
        { return idDueño; }
        set
        {
            if (value > 0)
                idDueño = value;
            else
            {
                Console.WriteLine("Error: El IdDueño asociado al vehículo debe ser un ID válido (mayor a 0).");
               
            }
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
        set {
            if(value >= 0)
                idGasto = value;
            else
            {
                Console.WriteLine("IdGasto inválido.");
            
            }
        }
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
                Console.WriteLine("El monto no puede ser negativo");
            
            }
        }
    }
    public GastoFinanciero(double monto)
    {
       this.Monto = monto;
    }
}

// clase reparacion***************************
public class Reparacion:GastoFinanciero
{
    private string tipoReparacion="";
    private string cantidadReparacion="0";
    private string cantidadpiezas="0";
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
            if (!string.IsNullOrWhiteSpace(value)&& value.Length>=3)
            {
                tipoReparacion= value;
                
            }
            else
            {
                Console.WriteLine("Ingreso invalido en TipoReparacion (Minimo 3 caracteres)");
             

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
                Console.WriteLine("La cantidad de reparación no puede ser negativa");
             
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
        set {
            if (value > 0)
                idCarro = value;
            else
            {
                Console.WriteLine("Error: Una reparación requiere un IdCarro válido.");
               
            }
        }
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
            else
            {
                Console.WriteLine("Los viáticos no pueden ser negativos");
              

            }
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
                Console.WriteLine("El costo de instancia no puede ser negativo");
              
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

                Console.WriteLine("El costo de limpieza no puede ser negativo");
           
            }
        }
    }
    public int IdVenta
    {
        get { return idVenta; }
        set {
            if (value > 0)
                idVenta = value;
            else
            {
                Console.WriteLine("Error: El IdVenta asignado a los gastos adicionales debe ser mayor a 0.");
               
            }
        }
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

//******************* calse venta***********************************
public class VentaVehiculo
{
    private int idVenta;
    private double precioSubasta;
    private double precioCostoReparacion;
    private double instaciaMantenimiento;
    private double precioFinal;
    private string fechaVenta="";
    private int idCarro;

    public int IdVenta
    {
        get { if (idVenta <= 0)
                return 0;

            return idVenta;
        } 
        
        set{
            if (value>0)
            {
                idVenta = value;
            }
            else
            {
                Console.WriteLine("Idventa inválido");
              
            }
        } }

    public double PrecioSubasta
    {
        get { return precioSubasta; }
        set
        {
            if (value>=0)
            {
                precioSubasta = value;
            }
            else
            {
                Console.WriteLine("El precio de subasta no puede ser negativo");
              
            }
        }
    }
    public double PrecioCostoReparacion
    {
        get { return precioCostoReparacion; }
        set
        {
            if (value >= 0)
            {
                precioCostoReparacion = value;
            }
            else
            {
                Console.WriteLine("El precio de reparacion no puede ser negativo");
              
            }
        }
    }
    public double InstanciaMantenimiento
    {
        get { return instaciaMantenimiento; }
        set
        {
            if (value >= 0)
            {
                instaciaMantenimiento = value;
            }
            else
            {
                Console.WriteLine("La instancia de mantenimiento no puede ser negativo");
              
            }
        }
    }
    public double PrecioFinal
    {
        get { return precioFinal; }
        set
        {
            if (value >= 0)
            {
                precioFinal= value;
            }
            else
            {
                Console.WriteLine("El precio no puede ser negativo");
            }
        }
    }
    public string FechaVenta
    {
        get { return fechaVenta; }

        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                fechaVenta = value;
            else
            {
                Console.WriteLine("La fecha de ingreso no puede estar vacía");
            }
        }
    }

    public int IdCarro
    {
        get { return idCarro; }
        set
        {
            if (value > 0)
                idCarro = value;
            else
            {
                Console.WriteLine("Error: El IdCarro asignado debe ser mayor a 0.");
            }
        }
    }
    public VentaVehiculo(double precioSubasta, double precioCostoReparacion, double instanciaMantenimiento, double precioFinal, string fechaVenta, int idCarro)
    {
        PrecioSubasta = precioSubasta;
        PrecioCostoReparacion = precioCostoReparacion;
        InstanciaMantenimiento = instanciaMantenimiento;
        PrecioFinal = precioFinal;
        FechaVenta = fechaVenta;
        IdCarro = idCarro;
    }
}


// ****************** creacion de base de datos*******************

public class BaseDatos
{
    private string cadenaConexion = "Data Sourse=YankorSistema.db";

    public void InicialiazarBaseDatos()
    {
        using (var conexion = new SqliteConnection(cadenaConexion))
        {
            conexion.Open();
            var activarFK = conexion.CreateCommand();
            activarFK.CommandText = "PRAGMA foreing_keys = ON;";
            activarFK.ExecuteNonQuery();

            var cmd = conexion.CreateCommand();
            cmd.CommandText = @"
CREATE TEABLE IF NOT EXIST  Dueno (
IdDueno INTEGER PRYMARY KEY AUTOINCREMENT,
Nombre TEXT NOT NULL,
Dpi TEXT NOT NULL UNIQUE,
Nit TEXT NOT NULL);

CREATE TABLE IF NOT EXIST Vehiculo(
IdCarro INTEGER PRYMARY KEY AUTOINCREMENT,
Tipo TEXT NOT NULL,
Marca TEXT NOT NULL,
Linea TEXT NOT NULL,
NoVin TEXT NOT NULL,
CostoInicial  REAL NOT NULL,
Fechaingreso TEXT NOT NUL,
Estado TEXT NOT NULL,
IdDueno INTEGER NOT NULL,
FOREIGN KEY (IdDueno) REFERENCE Dueno(IdDueno)
);

CREATE TABLE IF NOT EXIST Reparacion (
IdGasto INTENGER PRYMARY KEY AUTOINCREMENT,
Monto REAL NOT NULL,
TipoReparacion TEXT NOT NULL,
CantidadReparacion TEXT NOT NULL,
IdCarro INTENGER NOT NULL,
FOREING KEY (IdCarro) REFENCE Vehiculo(IdCarro)
);
 CREAT TABLE IF NOT EXIST VentaVehiculo (
IdVenta INTENGER PRYMARY KEY AUTOINCREMENT,
PrecioSubasta REAL NOT NULL,
PrecioCostoReparacion REAL NOT NULL, 
InstanciaMantenimiento REAL NOT NULL,
PrecioFinal REAL NOT NULL.
FechaVenta TEXT NOT NULL,
IdCarro INTENGER NOT NULL
FOREING KEY(IdCarro) REFERENCE Vehiculo(IdCarro)
);

CREATE TABLE NOT EXIST GastosAdicionales (
IdGasto INTENGER PRYMARY KEY AUTOINCREMENT,
Monto REAL NOT NULL,
Viaticos REAL NOT NULL
Instancia REAL NOT NULL,
Limpieza REAL NOT NULL,
IdVenta INTENGER NOT NULL,
FOREINNG KEY (IdVenta) REFERENCE VentaVehiculo(IdVenta)
);
";
            cmd.ExecuteNonQuery();
            Console.WriteLine("Base de datos inicializada correctamente");

        }
    }


    //************ Crud dueno*******
    public void InsertarDueno(Dueno d)
    {
        using (var con = new SqliteConnection(cadenaConexion))
        {
            con.Open();
            var cmd= con.CreateCommand();
            cmd.CommandText = "INSERT INTO Dueno(Nombre,Dpi,Nit) VALUES (@n,@d,@nit);";
            cmd.Parameters.AddWithValue("@n", d.Nombre);
            cmd.Parameters.AddWithValue("@d", d.Dpi);
            cmd.Parameters.AddWithValue("@nit", d.Nit);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Dueño agreado con exito");
        }
    }
}











