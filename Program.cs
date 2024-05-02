using System;

// Definición de la estructura Trabajador
struct Trabajador
{
    public string nombre;
    public int edad;
    public double sueldo;
}

class Program
{
    static void Main(string[] args)
    {
        bool continuar = true;

        while (continuar)
        {
            // Solicitar al usuario la cantidad de trabajadores
            int cantidadTrabajadores = SolicitarNumero("Ingrese la cantidad de trabajadores: ");

            // Declarar un arreglo de trabajadores
            Trabajador[] trabajadores = new Trabajador[cantidadTrabajadores];

            // Variables para contar la cantidad de empleados mayores de 50 años y el total de sueldos netos
            int mayoresDe50 = 0;
            double totalSueldosNetos = 0;

            // Solicitar los datos de cada trabajador
            for (int i = 0; i < cantidadTrabajadores; i++)
            {
                Console.WriteLine($"\nIngrese los datos del trabajador {i + 1}:");
                string nombre = SolicitarTexto("Nombre: ");
                int edad = SolicitarNumeroEntero("Edad: ");
                double sueldo = SolicitarNumeroDecimal("Sueldo: ");

                // Guardar los datos en el arreglo de trabajadores
                trabajadores[i].nombre = nombre;
                trabajadores[i].edad = edad;
                trabajadores[i].sueldo = sueldo;

                // Contar la cantidad de empleados mayores de 50 años
                if (edad > 50)
                {
                    mayoresDe50++;
                }

                // Calcular y mostrar el sueldo neto y las deducciones
                double sueldoNeto = CalcularSueldoNeto(sueldo);
                MostrarSueldoYDeducciones(nombre, sueldo, sueldoNeto);
                totalSueldosNetos += sueldoNeto;
            }

            // Mostrar la información total
            Console.WriteLine($"\nCantidad de empleados mayores de 50 años: {mayoresDe50}");
            Console.WriteLine($"Total de sueldos netos a pagar: {totalSueldosNetos:C}");

            // Preguntar al usuario si desea continuar o salir del sistema
            Console.WriteLine("\n¿Desea realizar otro cálculo? (Presione cualquier letra para sí, un número para salir)");
            char opcion = Console.ReadKey().KeyChar;
            if (char.IsDigit(opcion))
            {
                continuar = false;
            }

            Console.Clear(); // Limpiar la consola para el siguiente cálculo
        }
    }

    // Función para calcular el sueldo neto aplicando los descuentos en porcentaje
    static double CalcularSueldoNeto(double sueldo)
    {
        const double SeguroSocial = 0.05;
        const double AhorroHabitacional = 0.07;
        const double CajaAhorro = 0.1;

        double totalDescuentos = sueldo * (SeguroSocial + AhorroHabitacional + CajaAhorro);
        double sueldoNeto = sueldo - totalDescuentos;
        return sueldoNeto;
    }

    // Función para mostrar el sueldo neto y las deducciones por separado
    static void MostrarSueldoYDeducciones(string nombre, double sueldo, double sueldoNeto)
    {
        double seguroSocial = sueldo * 0.05;
        double ahorroHabitacional = sueldo * 0.07;
        double cajaAhorro = sueldo * 0.1;

        Console.WriteLine($"\nEmpleado: {nombre}");
        Console.WriteLine($"Sueldo: {sueldo:C}");
        Console.WriteLine($"Deducción Seguro Social (5%): {seguroSocial:C}");
        Console.WriteLine($"Deducción Ahorro Habitacional (7%): {ahorroHabitacional:C}");
        Console.WriteLine($"Deducción Caja de Ahorro (10%): {cajaAhorro:C}");
        Console.WriteLine($"Total sueldo a pagar: {sueldoNeto:C}");
    }

    // Función para solicitar un número entero al usuario con validación
    static int SolicitarNumeroEntero(string mensaje)
    {
        int numero;
        bool esNumero;
        do
        {
            Console.Write(mensaje);
            esNumero = int.TryParse(Console.ReadLine(), out numero);
            if (!esNumero)
            {
                Console.WriteLine("Por favor, ingrese un valor numérico entero.");
            }
        } while (!esNumero);
        return numero;
    }

    // Función para solicitar un número decimal al usuario con validación
    static double SolicitarNumeroDecimal(string mensaje)
    {
        double numero;
        bool esNumero;
        do
        {
            Console.Write(mensaje);
            esNumero = double.TryParse(Console.ReadLine(), out numero);
            if (!esNumero)
            {
                Console.WriteLine("Por favor, ingrese un valor numérico decimal.");
            }
        } while (!esNumero);
        return numero;
    }

    // Función para solicitar un texto al usuario con validación de texto
    static string SolicitarTexto(string mensaje)
    {
        string texto;
        do
        {
            Console.Write(mensaje);
            texto = Console.ReadLine();
            if (!EsTextoValido(texto))
            {
                Console.WriteLine("Por favor, ingrese un valor válido (solo texto).");
            }
        } while (!EsTextoValido(texto));
        return texto;
    }

    // Función para verificar si un texto contiene solo letras y espacios en blanco
    static bool EsTextoValido(string texto)
    {
        foreach (char c in texto)
        {
            if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
            {
                return false;
            }
        }
        return true;
    }

    // Función para solicitar un número al usuario con validación
    static int SolicitarNumero(string mensaje)
    {
        int numero;
        bool esNumero;
        do
        {
            Console.Write(mensaje);
            esNumero = int.TryParse(Console.ReadLine(), out numero);
            if (!esNumero || numero <= 0)
            {
                Console.WriteLine("Por favor, ingrese un valor numérico entero mayor que cero.");
            }
        } while (!esNumero || numero <= 0);
        return numero;
    }
}
