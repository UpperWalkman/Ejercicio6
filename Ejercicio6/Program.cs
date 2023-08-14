using System;
using System.Collections.Generic;
using System.Linq;

namespace Ejercicio6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escriba el total de alumnos");
            string Alumnos = Console.ReadLine();
            int numeroAlumnos = int.Parse(Alumnos);
            double alumnosAprobados = 0;
            double alumnosReprobados = 0;
            double promedioGrupal = 0;
            string mayorCalificacion = string.Empty;
            string menorCalificacion = string.Empty;
            List<(string, double)> listAlumnos = new List<(string, double)>();

            int contador = 0;
            while (numeroAlumnos > contador)
            {
                contador += 1;
                Console.WriteLine("Alumno");
                string nombreAlumno = Console.ReadLine();

                Console.WriteLine("Promedio");
                string promedio = Console.ReadLine();
                if (double.Parse(promedio) <= 100)
                {
                    listAlumnos.Add((nombreAlumno, double.Parse(promedio)));
                }
                else
                {
                    while (true)
                    {
                        Console.WriteLine($"UPS, ERROR!, DIGITE DE NUEVO LA CALIFICACION DE: {nombreAlumno}");
                        promedio = Console.ReadLine();
                        if (double.Parse(promedio) <= 100)
                        {
                            listAlumnos.Add((nombreAlumno, double.Parse(promedio)));
                            break;
                        }
                    }
                }

            }


            //ordenado alfabeticamente
            List<(string, double)> listAlumnosOrdenado = new List<(string, double)>();
            listAlumnosOrdenado = listAlumnos.OrderBy(x => x).ToList();

            //promedio grupal, alumnos aprobados, reprobados
            double sumaPromedios = 0;
            double menorPromedio = 0;
            double mayorPromedio = 0;
            double menorPromedioReprobado = 60;
            for (int i = 0; i < listAlumnosOrdenado.Count; i++)
            {
                //promedio grupal
                sumaPromedios += listAlumnosOrdenado[i].Item2;
                //aprobados y mayor promedio
                if (listAlumnosOrdenado[i].Item2 >= 60)
                {
                    alumnosAprobados += 1;
                    if (listAlumnosOrdenado[i].Item2 > mayorPromedio)
                    {
                        //mayores promedios se agregan
                        mayorPromedio = listAlumnosOrdenado[i].Item2;
                        mayorCalificacion = $"{listAlumnosOrdenado[i].Item1} {listAlumnosOrdenado[i].Item2}";
                        if (menorPromedio == 0)
                        {
                            menorPromedio = listAlumnosOrdenado[i].Item2;
                            menorCalificacion = $"{listAlumnosOrdenado[i].Item1} {listAlumnosOrdenado[i].Item2}";
                        }
                    }
                    if (listAlumnosOrdenado[i].Item2 < menorPromedio)
                    {
                        //menores promedio se agregan
                        menorPromedio = listAlumnosOrdenado[i].Item2;
                        menorCalificacion = $"{listAlumnosOrdenado[i].Item1} {listAlumnosOrdenado[i].Item2}";
                    }
                }
                    
                //reprobados y menor calificacion
                if (listAlumnosOrdenado[i].Item2 < 60)
                {
                    alumnosReprobados += 1;
                    if(listAlumnosOrdenado[i].Item2 < menorPromedioReprobado)
                    {
                        //menores promedio se agregan
                        menorPromedio = listAlumnosOrdenado[i].Item2;
                        menorPromedioReprobado = listAlumnosOrdenado[i].Item2;
                        menorCalificacion = $"{listAlumnosOrdenado[i].Item1} {listAlumnosOrdenado[i].Item2}";
                    }
                }
            }

            promedioGrupal = sumaPromedios / numeroAlumnos;
            Console.WriteLine($"Promeio grupal: {promedioGrupal.ToString("F2")} Alumnos aprobados: {alumnosAprobados} Alumnos Reprobados: {alumnosReprobados} Mayor Calificacion: {mayorCalificacion} Menor Calificacion: {menorCalificacion}");
        }
    }
}
