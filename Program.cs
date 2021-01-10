using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Registros_de_datos
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] document;
            int option = 0;
            TextWriter writer;
            StringBuilder output = new StringBuilder();
            List<Regist> person = new List<Regist>();

            if (!File.Exists(args[0]))
            {
                File.AppendAllText(args[0], output.ToString());
            }
            document = File.ReadAllLines(args[0]);
            foreach (var h in document)
            {
                person.Add(Regist.From(h));
            }
            do
            {
                option = Menu();
                if (option == 1)
                {
                    string aux = Data(person);
                    Space();

                    Console.Write("(g) = guardar y (s) = salir: ");
                    string save = Console.ReadLine();

                    if (save == "g")
                    {
                        person.Add(Regist.From(aux));
                        Space();
                        Console.WriteLine("Se ha guardado.");
                    }
                    else
                    {
                        Space();
                    }
                }
                if (option == 2)
                {
                    if (File.Exists(args[0]))
                    {
                        Console.Write("Digite la cedula del registro a buscar: ");
                        string finddni = Console.ReadLine();   
                        foreach (Regist p in person)
                        {
                            if(p.dni == finddni)
                            {
                                Space();
                                Console.WriteLine(p);
                            }
                        }
                    }
                }
                if (option == 3)
                {
                    if (File.Exists(args[0]))
                    {
                        int pos = 0;
                        Console.Write("Digite la cedula del registro a editar: ");
                        string finddni = Console.ReadLine(); 
                        foreach (Regist p in person)
                        {
                            
                            if(p.dni == finddni)
                            {
                                Space();
                                Console.WriteLine(p);
                                Space();

                                string aux = Data(person);
                                person.Add(Regist.From(aux));
                            }
                            pos++;
                        }
                    }
                }
                if (option == 4)
                {
                    if (File.Exists(args[0]))
                    {
                        int pos = 0;

                        Console.Write("Digite la cedula del registro a eliminar:");
                        string finddni = Console.ReadLine();    
                        foreach (Regist p in person)
                        {
                            
                            if(p.dni == finddni)
                            {
                                Space();
                                Console.WriteLine(p);
                                person.Remove(p);
                            }
                            pos++;
                        }
                    }
                }
                if (option == 5)
                {
                    if (File.Exists(args[0]))
                    {
                        string[] lines = File.ReadAllLines(args[0]);
                        foreach(Regist p in person)
                        {
                            Console.WriteLine(p);
                            Space();
                        }
                        Console.WriteLine("Todos los registros listados an sido listados.");
                    }
                }
            } while (option != 6);
            writer = new StreamWriter(args[0]);
            foreach (Regist p in person)
            {
                writer.WriteLine(Regist.setData(p));
            }
            writer.Close();
        }
        private static int Menu()
        {
            int result = 0;
            Space();
            Console.WriteLine("1) Nuevo registro.");
            Console.WriteLine("2) Buscar registro.");
            Console.WriteLine("3) Editar registro.");
            Console.WriteLine("4) Eliminar registro.");
            Console.WriteLine("5) Listar registros.");
            Console.WriteLine("6) Sarlir.");
            Space();
            Console.Write("Elija una opcion: ");
            result = Convert.ToInt16(Console.ReadLine());
            Space();
            return result;
        }
        private static string Data(List<Regist> person)
        {
            Int16 data = 0;
            Int16 aux= 0;
            bool exist;

            string dni;
            do
            {
                Console.WriteLine("Cadula: ");
                dni = DataDouble();
               
                exist =InData(dni, person);
                if (exist)
                {
                    Console.WriteLine();
                    Console.WriteLine("La cedula ya existe!");
                }
                
            } while (exist != false);
            Console.WriteLine();

            Console.WriteLine("Nombre: ");
            string name = DataString();
            Console.WriteLine();

            Console.WriteLine("Apellido: ");
            string lastname = DataString();
            Console.WriteLine();

            Console.WriteLine("Edad: ");
            aux = Convert.ToInt16(DataInt() << 4);
            data = Convert.ToInt16(data|aux);
            Console.WriteLine();

            Console.WriteLine("Casado(c), Soltero(s): ");
            data = Convert.ToInt16(data | Code(0));
            Console.WriteLine();

            Console.WriteLine("Femenino(f), Masculino(m): ");
            data = Convert.ToInt16(data | Code(1));
            Console.WriteLine();

            Console.WriteLine("Nivel academico, Inicial(i), Media(m), Greado(g), Postgrado(p): ");
            aux = Convert.ToInt16(Code(2) << 2);
            data = Convert.ToInt16(data | aux);
            Console.WriteLine();

            Console.WriteLine("Ahorro: ");
            string money = DataDouble();
            Console.WriteLine();

            Console.WriteLine("Contraseña: ");
            string password = DataPass();
            Console.WriteLine();

            Console.WriteLine("Confirme contraseña: ");
            string comfirmed = DataPass();
            Console.WriteLine();

            while (password != comfirmed)
            {
                Console.WriteLine("Las contraseñas no coinciden.");
                Console.WriteLine("Contraseña: ");
                password = DataPass();
                Console.WriteLine();
                Console.WriteLine("Confirme contraseña: ");
                comfirmed = DataPass();
                Console.WriteLine();
            }
            string result =  dni + "," + name + "," + lastname + "," + money + "," + comfirmed + "," + data;
            return result;
        }
        private static bool InData(string info, List<Regist> person)
        {
            foreach (Regist p in person)
            {
                if (p.dni == info)
                {
                    return true;
                }
            }
            return false;
        }  
        private static Int16 Code(Int16 condition = 0)
        {
            string charater = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    int aux = 0;
                    bool isdata= int.TryParse(key.KeyChar.ToString(), out aux);
                    if (isdata == false)
                    {
                        charater += key.KeyChar;
                        Console.Write(key.KeyChar); 
                    }
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && charater.Length > 0 )
                    {
                        charater = charater.Substring(0,(charater.Length-1));
                        Console.Write("\b \b"); 
                    }
                }
            } while (key.Key != ConsoleKey.Enter);
            Int16 result = 0;
            if (condition == 0)
            {
                if (charater == "c" | charater == "C")
                {
                    result = 1;
                }
            }
            if (condition == 1)
            {
                if (charater == "f" | charater == "F")
                {
                    result = 2;
                } 
            }
            if (condition == 2)
            {
                if (charater == "m" | charater == "M")
                {
                    result = 1;
                }
                if (charater == "g" | charater == "G")
                {
                    result = 2;
                }
                if (charater == "p" | charater == "P")
                {
                    result = 3;
                }
            } 
            return result;
        }
        private static string DataString()
        {
            string charater = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    int aux = 0;
                    bool isdata= int.TryParse(key.KeyChar.ToString(), out aux);
                    if (isdata == false)
                    {
                        charater += key.KeyChar;
                        Console.Write(key.KeyChar); 
                    }
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && charater.Length > 0 )
                    {
                        charater = charater.Substring(0,(charater.Length-1));
                        Console.Write("\b \b"); 
                    }
                }
            } while (key.Key != ConsoleKey.Enter);
            return charater;
        }
        private static Int16 DataInt()
        {
            string charater = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    int aux = 0;
                    bool isdata= int.TryParse(key.KeyChar.ToString(), out aux);
                    if (isdata)
                    {
                        charater += key.KeyChar;
                        Console.Write(key.KeyChar); 
                    }
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && charater.Length > 0 )
                    {
                        charater = charater.Substring(0,(charater.Length-1));
                        Console.Write("\b \b"); 
                    }
                }
            } while (key.Key != ConsoleKey.Enter);
            Int16 result = Convert.ToInt16(charater);
            return result;
        }
        private static string DataDouble()
        {
            string charater = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    double aux = 0;
                    bool isdata = double.TryParse(key.KeyChar.ToString(), out aux);
                    if (isdata)
                    {
                        charater += key.KeyChar;
                        Console.Write(key.KeyChar); 
                    }
                }
                if (key.KeyChar == '.' && !charater.Contains("."))
                {
                        charater += key.KeyChar;
                        Console.Write(key.KeyChar);
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && charater.Length > 0 )
                    {
                        charater = charater.Substring(0,(charater.Length-1));
                        Console.Write("\b \b"); 
                    }
                }
            } while (key.Key != ConsoleKey.Enter);
            return charater;
        }
        private static void Space()
        {
            Console.WriteLine("========================================================");
        }
        private static string DataPass()
        {
            string charater = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    charater += key.KeyChar;
                    Console.Write("*"); 
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && charater.Length > 0 )
                    {
                        charater = charater.Substring(0,(charater.Length-1));
                        Console.Write("\b \b"); 
                    }
                }
            } while (key.Key != ConsoleKey.Enter);
            return charater;
        }
    }
}