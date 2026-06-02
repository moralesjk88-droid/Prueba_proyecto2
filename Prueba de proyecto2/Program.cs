using System;
using System.Security.Cryptography;
using System.Transactions;
using Microsoft.Data.Sqlite;


//*********** calse dueño************
public class Dueno
{
    private int idDueno;
    private string nombre = "";
    private string dpi = "";
    private string nit = "";

    public int IdDueno
    {
        get
        {
            return idDueno;
        }
        set
        {
            if (value >= 0)
                idDueno = value;
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
    private int idDueno;
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

    public int IdDueno
    {
        get
        { return idDueno; }
        set
        {
            if (value > 0)
                idDueno = value;
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
        IdDueno = idDueno;
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
    private string cadenaConexion = "Data Source=YankorSistema.db";

    public void InicializarBaseDatos()
    {
        using (var conexion = new SqliteConnection(cadenaConexion))
        {
            conexion.Open();
            var activarFK = conexion.CreateCommand();
            activarFK.CommandText = "PRAGMA foreing_keys = ON;";
            activarFK.ExecuteNonQuery();

            var cmd = conexion.CreateCommand();
            cmd.CommandText = @"
            CREATE TABLE IF NOT EXISTS Dueno (
                IdDueno INTEGER PRIMARY KEY AUTOINCREMENT,
                Nombre TEXT NOT NULL,
                Dpi TEXT NOT NULL UNIQUE,
                Nit TEXT NOT NULL
            );

            CREATE TABLE IF NOT EXISTS Vehiculo(
                IdCarro INTEGER PRIMARY KEY AUTOINCREMENT,
                Tipo TEXT NOT NULL,
                Marca TEXT NOT NULL,
                Linea TEXT NOT NULL,
                NoVin TEXT NOT NULL,
                CostoInicial REAL NOT NULL,
                FechaIngreso TEXT NOT NULL,
                Estado TEXT NOT NULL,
                IdDueno INTEGER NOT NULL,
                FOREIGN KEY (IdDueno) REFERENCES Dueno(IdDueno)
            );

            CREATE TABLE IF NOT EXISTS Reparacion (
                IdGasto INTEGER PRIMARY KEY AUTOINCREMENT,
                Monto REAL NOT NULL,
                TipoReparacion TEXT NOT NULL,
                CantidadReparacion TEXT NOT NULL,
                CantidadPiezas TEXT NOT NULL,
                IdCarro INTEGER NOT NULL,
                FOREIGN KEY (IdCarro) REFERENCES Vehiculo(IdCarro)
            );

            CREATE TABLE IF NOT EXISTS VentaVehiculo (
                IdVenta INTEGER PRIMARY KEY AUTOINCREMENT,
                PrecioSubasta REAL NOT NULL,
                PrecioCostoReparacion REAL NOT NULL, 
                InstanciaMantenimiento REAL NOT NULL,
                PrecioFinal REAL NOT NULL,
                FechaVenta TEXT NOT NULL,
                IdCarro INTEGER NOT NULL,
                FOREIGN KEY (IdCarro) REFERENCES Vehiculo(IdCarro)
            );

            CREATE TABLE IF NOT EXISTS GastosAdicionales (
                IdGasto INTEGER PRIMARY KEY AUTOINCREMENT,
                Monto REAL NOT NULL,
                Viaticos REAL NOT NULL,
                Instancia REAL NOT NULL,
                Limpieza REAL NOT NULL,
                IdVenta INTEGER NOT NULL,
                FOREIGN KEY (IdVenta) REFERENCES VentaVehiculo(IdVenta)
            );";

            cmd.ExecuteNonQuery();
            Console.WriteLine("Base de datos inicializada correctamente de forma limpia.");
        }
    }


    // ==========================================
    // CRUD: DUENO
    // ==========================================
    public void InsertarDueno(Dueno d)
    {
        using (var con = new SqliteConnection(cadenaConexion))
        {
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Dueno(Nombre,Dpi,Nit) VALUES (@n,@d,@nit);";
            cmd.Parameters.AddWithValue("@n", d.Nombre);
            cmd.Parameters.AddWithValue("@d", d.Dpi);
            cmd.Parameters.AddWithValue("@nit", d.Nit);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Dueño agregado con éxito.");
        }
    }

    public void ModificarDueno(Dueno d)
    {
        using (var con = new SqliteConnection(cadenaConexion))
        {
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE Dueno SET Nombre=@n, Dpi=@d, Nit=@nit WHERE IdDueno=@id;";
            cmd.Parameters.AddWithValue("@n", d.Nombre);
            cmd.Parameters.AddWithValue("@d", d.Dpi);
            cmd.Parameters.AddWithValue("@nit", d.Nit);
            cmd.Parameters.AddWithValue("@id", d.IdDueno);
            cmd.ExecuteNonQuery();
            Console.WriteLine(" Dueño modificado con éxito.");
        }
    }

    public void EliminarDueno(int id)
    {
        using (var con = new SqliteConnection(cadenaConexion))
        {
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM Dueno WHERE IdDueno=@id;";
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) Console.WriteLine("Dueño eliminado.");
                else Console.WriteLine("ID no encontrado.");
            }
            catch { Console.WriteLine(" No se puede eliminar: el dueño tiene carros asignados."); }
        }
    }

    public void ListarDueno()
    {
        using (var con = new SqliteConnection(cadenaConexion))
        {
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = "SELECT IdDueno, Nombre, Dpi, Nit FROM Dueno;";
            using (var r = cmd.ExecuteReader())
            {
                Console.WriteLine("\n=============================================");
                Console.WriteLine("             LISTADO DE DUEÑOS               ");
                Console.WriteLine("=============================================");
                while (r.Read())
                {
                    Console.WriteLine($"ID: {r.GetInt32(0)} | Nombre: {r.GetString(1)} | DPI: {r.GetString(2)} | NIT: {r.GetString(3)}");
                }
                Console.WriteLine("---------------------------------------------");
            }
        }
    }

    // ==========================================
    // CRUD: VEHÍCULO
    // ==========================================
    public void InsertarVehiculo(Vehiculo v)
    {
        using (var con = new SqliteConnection(cadenaConexion))
        {
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Vehiculo (Tipo, Marca, Linea, NoVin, CostoInicial, FechaIngreso, Estado, IdDueno) VALUES (@t, @m, @l, @v, @c, @f, @e, @idD);";
            cmd.Parameters.AddWithValue("@t", v.Tipo);
            cmd.Parameters.AddWithValue("@m", v.Marca);
            cmd.Parameters.AddWithValue("@l", v.Linea);
            cmd.Parameters.AddWithValue("@v", v.NoVin);
            cmd.Parameters.AddWithValue("@c", v.CostoInicial);
            cmd.Parameters.AddWithValue("@f", v.FechaIngreso);
            cmd.Parameters.AddWithValue("@e", v.Estado);
            cmd.Parameters.AddWithValue("@idD", v.IdDueno);
            cmd.ExecuteNonQuery();
            Console.WriteLine(" Vehículo registrado con éxito.");
        }
    }

    public void ModificarVehiculo(Vehiculo v)
    {
        using (var con = new SqliteConnection(cadenaConexion))
        {
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE Vehiculo SET Tipo=@t, Marca=@m, Linea=@l, NoVin=@v, CostoInicial=@c, FechaIngreso=@f, Estado=@e WHERE IdCarro=@id;";
            cmd.Parameters.AddWithValue("@t", v.Tipo);
            cmd.Parameters.AddWithValue("@m", v.Marca);
            cmd.Parameters.AddWithValue("@l", v.Linea);
            cmd.Parameters.AddWithValue("@v", v.NoVin);
            cmd.Parameters.AddWithValue("@c", v.CostoInicial);
            cmd.Parameters.AddWithValue("@f", v.FechaIngreso);
            cmd.Parameters.AddWithValue("@e", v.Estado);
            cmd.Parameters.AddWithValue("@id", v.IdCarro);
            cmd.ExecuteNonQuery();
            Console.WriteLine(" Vehículo actualizado.");
        }
    }

    public void EliminarVehiculo(int id)
    {
        using (var con = new SqliteConnection(cadenaConexion))
        {
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM Vehiculo WHERE IdCarro=@id;";
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) Console.WriteLine("[ÉXITO] Vehículo eliminado de las tablas.");
                else Console.WriteLine(" ID no encontrado.");
            }
            catch { Console.WriteLine(" No se puede borrar: cuenta con bitácoras o ventas vigentes."); }
        }
    }

    public void ListarVehiculos()
    {
        using (var con = new SqliteConnection(cadenaConexion))
        {
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = "SELECT IdCarro, Marca, Linea, NoVin, CostoInicial, FechaIngreso, Estado, IdDueno FROM Vehiculo;";
            using (var r = cmd.ExecuteReader())
            {
                Console.WriteLine("\n=================================================================================");
                Console.WriteLine("                       INVENTARIO DE VEHÍCULOS COMPLETO                          ");
                Console.WriteLine("=================================================================================");
                while (r.Read())
                {
                    Console.WriteLine($" ID Carro: {r.GetInt32(0)} | {r.GetString(1)} {r.GetString(2)}");
                    Console.WriteLine($"   VIN: {r.GetString(3)} | Costo: Q.{r.GetDouble(4):N2} | Ingreso: {r.GetString(5)}");
                    Console.WriteLine($"   Estado: {r.GetString(6)} | ID Dueño: {r.GetInt32(7)}");
                    Console.WriteLine("---------------------------------------------------------------------------------");
                }
            }
        }
    }

    // ==========================================
    // CRUD: REPARACIÓN
    // ==========================================
    public void InsertarReparacion(Reparacion rep)
    {
        using (var con = new SqliteConnection(cadenaConexion))
        {
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Reparacion (Monto, TipoReparacion, CantidadReparacion, CantidadPiezas, IdCarro) VALUES (@m, @t, @cr, @cp, @idC);";
            cmd.Parameters.AddWithValue("@m", rep.Monto);
            cmd.Parameters.AddWithValue("@t", rep.TipoReparacion);
            cmd.Parameters.AddWithValue("@cr", rep.CantidadReparacion);
            cmd.Parameters.AddWithValue("@cp", rep.CantidadPiezas);
            cmd.Parameters.AddWithValue("@idC", rep.IdCarro);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Registro de taller guardado.");
        }
    }

    public void ModificarReparacion(Reparacion rep)
    {
        using (var con = new SqliteConnection(cadenaConexion))
        {
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE Reparacion SET Monto=@m, TipoReparacion=@t, CantidadReparacion=@cr, CantidadPiezas=@cp WHERE IdGasto=@id;";
            cmd.Parameters.AddWithValue("@m", rep.Monto);
            cmd.Parameters.AddWithValue("@t", rep.TipoReparacion);
            cmd.Parameters.AddWithValue("@cr", rep.CantidadReparacion);
            cmd.Parameters.AddWithValue("@cp", rep.CantidadPiezas);
            cmd.Parameters.AddWithValue("@id", rep.IdGasto);
            cmd.ExecuteNonQuery();
            Console.WriteLine(" Datos de reparación modificados.");
        }
    }

    public void EliminarReparacion(int id)
    {
        using (var con = new SqliteConnection(cadenaConexion))
        {
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM Reparacion WHERE IdGasto=@id;";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            Console.WriteLine(" Transacción eliminada de la bitácora.");
        }
    }

    public void ListarReparaciones()
    {
        using (var con = new SqliteConnection(cadenaConexion))
        {
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = "SELECT IdGasto, TipoReparacion, Monto, CantidadReparacion, CantidadPiezas, IdCarro FROM Reparacion;";
            using (var r = cmd.ExecuteReader())
            {
                Console.WriteLine("\n=================================================================================");
                Console.WriteLine("                          DETALLE DE GASTOS POR TALLER                           ");
                Console.WriteLine("=================================================================================");
                while (r.Read())
                {
                    Console.WriteLine($" ID Gasto: {r.GetInt32(0)} | Trabajo: {r.GetString(1)} | Costo: Q.{r.GetDouble(2):N2}");
                    Console.WriteLine($"   Reparaciones Realizadas: {r.GetString(3)} | Piezas Usadas: {r.GetString(4)} | Carro ID: {r.GetInt32(5)}");
                    Console.WriteLine("---------------------------------------------------------------------------------");
                }
            }
        }
    }

    // ==========================================
    // CRUD: VENTA VEHÍCULO
    // ==========================================
    public void InsertarVenta(VentaVehiculo v)
    {
        using (var con = new SqliteConnection(cadenaConexion))
        {
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = @"INSERT INTO VentaVehiculo 
                    (PrecioSubasta, PrecioCostoReparacion, InstanciaMantenimiento, PrecioFinal, FechaVenta, IdCarro) 
                    VALUES (@ps, @pcr, @im, @pf, @f, @idC);";
            cmd.Parameters.AddWithValue("@ps", v.PrecioSubasta);
            cmd.Parameters.AddWithValue("@pcr", v.PrecioCostoReparacion);
            cmd.Parameters.AddWithValue("@im", v.InstanciaMantenimiento);
            cmd.Parameters.AddWithValue("@pf", v.PrecioFinal);
            cmd.Parameters.AddWithValue("@f", v.FechaVenta);
            cmd.Parameters.AddWithValue("@idC", v.IdCarro);
            cmd.ExecuteNonQuery();
            Console.WriteLine(" Venta de vehículo registrada con éxito.");
        }
    }

    public void ModificarVenta(VentaVehiculo v)
    {
        using (var con = new SqliteConnection(cadenaConexion))
        {
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = @"UPDATE VentaVehiculo SET 
                    PrecioSubasta=@ps, PrecioCostoReparacion=@pcr, InstanciaMantenimiento=@im, 
                    PrecioFinal=@pf, FechaVenta=@f WHERE IdVenta=@id;";
            cmd.Parameters.AddWithValue("@ps", v.PrecioSubasta);
            cmd.Parameters.AddWithValue("@pcr", v.PrecioCostoReparacion);
            cmd.Parameters.AddWithValue("@im", v.InstanciaMantenimiento);
            cmd.Parameters.AddWithValue("@pf", v.PrecioFinal);
            cmd.Parameters.AddWithValue("@f", v.FechaVenta);
            cmd.Parameters.AddWithValue("@id", v.IdVenta);

            int filas = cmd.ExecuteNonQuery();
            if (filas > 0) Console.WriteLine(" Registro de venta actualizado.");
            else Console.WriteLine(" No se encontró el ID de la venta.");
        }
    }

    public void EliminarVenta(int idVenta)
    {
        using (var con = new SqliteConnection(cadenaConexion))
        {
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM VentaVehiculo WHERE IdVenta=@id;";
            cmd.Parameters.AddWithValue("@id", idVenta);
            try
            {
                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) Console.WriteLine("Venta eliminada correctamente.");
                else Console.WriteLine(" ID de venta no encontrado.");
            }
            catch
            {
                Console.WriteLine(" No se puede eliminar: Esta venta tiene Gastos Adicionales asociados.");
            }
        }
    }

    public void ListarVentas()
    {
        using (var con = new SqliteConnection(cadenaConexion))
        {
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = "SELECT IdVenta, PrecioSubasta, PrecioCostoReparacion, InstanciaMantenimiento, PrecioFinal, FechaVenta, IdCarro FROM VentaVehiculo;";
            using (var r = cmd.ExecuteReader())
            {
                Console.WriteLine("\n=================================================================================");
                Console.WriteLine("                             HISTORIAL DE VENTAS                                 ");
                Console.WriteLine("=================================================================================");
                while (r.Read())
                {
                    Console.WriteLine($" ID Venta: {r.GetInt32(0)} | Subasta: Q.{r.GetDouble(1):N2} | Taller Interno: Q.{r.GetDouble(2):N2} | Predio: Q.{r.GetDouble(3):N2}");
                    Console.WriteLine($"   PRECIO FINAL LIQUIDADO: Q.{r.GetDouble(4):N2} | Fecha Venta: {r.GetString(5)} | Carro ID: {r.GetInt32(6)}");
                    Console.WriteLine("---------------------------------------------------------------------------------");
                }
            }
        }
    }

    // ==========================================
    // CRUD: GASTOS ADICIONALES 
    // ==========================================
    public void InsertarGastoAdicional(GastosAdicionales ga)
    {
        using (var con = new SqliteConnection(cadenaConexion))
        {
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = @"INSERT INTO GastosAdicionales 
                    (Monto, Viaticos, Instancia, Limpieza, IdVenta) 
                    VALUES (@m, @v, @i, @l, @idV);";
            cmd.Parameters.AddWithValue("@m", ga.Monto);
            cmd.Parameters.AddWithValue("@v", ga.Viaticos);
            cmd.Parameters.AddWithValue("@i", ga.Instancia);
            cmd.Parameters.AddWithValue("@l", ga.Limpieza);
            cmd.Parameters.AddWithValue("@idV", ga.IdVenta);
            cmd.ExecuteNonQuery();
            Console.WriteLine(" Gastos adicionales de logística guardados.");
        }
    }

    public void ModificarGastoAdicional(GastosAdicionales ga)
    {
        using (var con = new SqliteConnection(cadenaConexion))
        {
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = @"UPDATE GastosAdicionales SET 
                    Monto=@m, Viaticos=@v, Instancia=@i, Limpieza=@l WHERE IdGasto=@id;";
            cmd.Parameters.AddWithValue("@m", ga.Monto);
            cmd.Parameters.AddWithValue("@v", ga.Viaticos);
            cmd.Parameters.AddWithValue("@i", ga.Instancia);
            cmd.Parameters.AddWithValue("@l", ga.Limpieza);
            cmd.Parameters.AddWithValue("@id", ga.IdGasto);

            int filas = cmd.ExecuteNonQuery();
            if (filas > 0) Console.WriteLine("[ÉXITO] Gastos adicionales actualizados.");
            else Console.WriteLine(" ID de gasto no encontrado.");
        }
    }

    public void EliminarGastoAdicional(int idGasto)
    {
        using (var con = new SqliteConnection(cadenaConexion))
        {
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM GastosAdicionales WHERE IdGasto=@id;";
            cmd.Parameters.AddWithValue("@id", idGasto);

            int filas = cmd.ExecuteNonQuery();
            if (filas > 0) Console.WriteLine(" Registro de gasto eliminado.");
            else Console.WriteLine("ID no encontrado.");
        }
    }

    public void ListarGastosAdicionales()
    {
        using (var con = new SqliteConnection(cadenaConexion))
        {
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = "SELECT IdGasto, Monto, Viaticos, Instancia, Limpieza, IdVenta FROM GastosAdicionales;";
            using (var r = cmd.ExecuteReader())
            {
                Console.WriteLine("\n=================================================================================");
                Console.WriteLine("                    BITÁCORA DETALLADA DE GASTOS ADICIONALES                     ");
                Console.WriteLine("=================================================================================");
                while (r.Read())
                {
                    int idGasto = r.GetInt32(0);
                    double montoTotal = r.GetDouble(1);
                    double viaticos = r.GetDouble(2);
                    double instancia = r.GetDouble(3);
                    double limpieza = r.GetDouble(4);
                    int idVenta = r.GetInt32(5);

                    Console.WriteLine($" Gasto ID: {idGasto} |  Asociado a Venta ID: {idVenta}");
                    Console.WriteLine($"   Limpieza (Car Wash): Q.{limpieza:N2}");
                    Console.WriteLine($"   Instancia (Predio):  Q.{instancia:N2}");
                    Console.WriteLine($"   Viáticos (Traslado): Q.{viaticos:N2}");
                    Console.WriteLine($"   MONTO TOTAL EXTRA: Q.{montoTotal:N2}");
                    Console.WriteLine("---------------------------------------------------------------------------------");
                }
            }
        }
    }
}















