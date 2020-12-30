using System;
using System.IO;
using System.Text;

namespace Registros_de_datos
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = 0;
            do
            {
                option = Menu();

                if (option == 1)
                {
                    string aux = Data();
                    Space();

                    Console.Write("(g) = guardar y (s) = salir: ");
                    string save = Console.ReadLine();

                    if (save == "g")
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(args[0], true))
                        {
                            file.WriteLine(aux);
                        }
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
                    if (File.Exists(@"C:\Users\Ricardo D.Monkey\Desktop\Registros_de_datos" + @"\" + args[0]))
                    {
                        Console.Write("Digite la cedula del registro a buscar: ");
                        string finddni = Console.ReadLine();
                        string[] lines = File.ReadAllLines(@"C:\Users\Ricardo D.Monkey\Desktop\Registros_de_datos" + @"\" + args[0]);    
                        foreach (string line in lines)
                        {
                            if(line.Contains(finddni))
                            {
                                Space();
                                Console.WriteLine(line);
                            }
                        }
                    }
                }
                if (option == 3)
                {
                    if (File.Exists(@"C:\Users\Ricardo D.Monkey\Desktop\Registros_de_datos" + @"\" + args[0]))
                    {
                        int pos = 0;
                        Console.Write("Digite la cedula del registro a editar: ");
                        string finddni = Console.ReadLine();
                        string[] lines = File.ReadAllLines(@"C:\Users\Ricardo D.Monkey\Desktop\Registros_de_datos" + @"\" + args[0]);    
                        foreach (string line in lines)
                        {
                            
                            if(line.Contains(finddni))
                            {
                                Space();
                                Console.WriteLine(line);
                                Space();

                                string aux = Data();

                                using (StreamWriter file = new StreamWriter(args[0]))
                                {
                                    for (int actualLine = 1; actualLine <= lines.Length; actualLine++)
                                    {
                                        if (actualLine - 1 == pos)
                                        {
                                            file.WriteLine(aux);
                                        }
                                        else
                                        {
                                            file.WriteLine(lines[actualLine - 1]);
                                        }
                                    }
                                }
                            }
                            pos++;
                        }
                    }
                }
                if (option == 4)
                {
                    if (File.Exists(@"C:\Users\Ricardo D.Monkey\Desktop\Registros_de_datos" + @"\" + args[0]))
                    {
                        int pos = 0;

                        Console.Write("Digite la cedula del registro a eliminar:");
                        string finddni = Console.ReadLine();

                        string[] lines = File.ReadAllLines(@"C:\Users\Ricardo D.Monkey\Desktop\Registros_de_datos" + @"\" + args[0]);    
                        foreach (string line in lines)
                        {
                            
                            if(line.Contains(finddni))
                            {
                                Space();
                                Console.WriteLine(line);

                                using (StreamWriter file = new StreamWriter(args[0]))
                                {
                                    for (int actualLine = 1; actualLine <= lines.Length; actualLine++)
                                    {
                                        if (actualLine - 1 == pos)
                                        {

                                        }
                                        else
                                        {
                                            file.WriteLine(lines[actualLine - 1]);
                                        }
                                    }
                                }
                            }
                            pos++;
                        }
                    }
                }
                if (option == 5)
                {
                    if (File.Exists(@"C:\Users\Ricardo D.Monkey\Desktop\Registros_de_datos" + @"\" + args[0]))
                    {
                        string[] lines = File.ReadAllLines(@"C:\Users\Ricardo D.Monkey\Desktop\Registros_de_datos" + @"\" + args[0]);
                        foreach(string line in lines)
                        {
                            Console.WriteLine(line); 
                            Space();
                        }
                        Console.WriteLine("Todos los registros listados an sido listados.");
                    }
                }
            } while (option != 6);
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
        private static string Data()
        {
            Console.WriteLine("Cadula: ");
            string dni = DataDouble();
            Console.WriteLine();
            Console.WriteLine("Nombre: ");
            string name = DataString();
            Console.WriteLine();
            Console.WriteLine("Apellido: ");
            string lastname = DataString();
            Console.WriteLine();
            Console.WriteLine("Edad: ");
            string age = DataInt();
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
            string result = dni + "," + name + "," + lastname + "," + age + "," + money + "," + comfirmed;
            return result;
        }   
        private static string DataString()
        {
            string charater = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace)
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
        private static string DataInt()
        {
            string charater = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace)
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
            return charater;
        }
        private static string DataDouble()
        {
            string charater = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace)
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
                if (key.Key != ConsoleKey.Backspace)
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
