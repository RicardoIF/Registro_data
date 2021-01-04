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
                    if (File.Exists(args[0]))
                    {
                        //@"C:\Users\Ricardo D.Monkey\Desktop\Registros_de_datos" + @"\" + 
                        Console.Write("Digite la cedula del registro a buscar: ");
                        string finddni = Console.ReadLine();
                        string[] lines = File.ReadAllLines(args[0]);    
                        foreach (string line in lines)
                        {
                            if(line.Contains(finddni))
                            {
                                string temporary ="";
                                int limit = line.Length;
                                for (int i = 0; i < limit; i++)
                                {
                                   if (line[i] != ',')
                                   {
                                       temporary = temporary + line[i];
                                   } 
                                   else if (line[i] == ',')
                                   {
                                       limit = i;
                                   }
                                }
                                Space();
                                Console.WriteLine(line + Encode(temporary));
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
                            string temporary ="";
                            int limit = line.Length;
                            for (int i = 0; i < limit; i++)
                            {
                                if (line[i] != ',')
                                {
                                    temporary = temporary + line[i];
                                } 
                                else if (line[i] == ',')
                                {
                                    limit = i;
                                }
                            }
                            Console.WriteLine(line + Encode(temporary));
                            Space();
                        }
                        Console.WriteLine("Todos los registros listados an sido listados.");
                    }
                }
            } while (option != 6);
        }
        private static string Encode(string code)
        {
            string result = "";
            Int16 data = Convert.ToInt16(code);
            if(data == (data | 1))
            {
                result = result + ", Casado";
            }
            else
            {
                result = result + ", Soltero";
            }
            if(data == (data | 2))
            {
                result = result + ", Femenino";
            }
            else
            {
                result = result + ", Masculino";
            }
            if(data == (data | 4))
            {
                result = result + ", Media";
            }
            else if(data == (data | 8))
            {
                result = result + ", Grado";
            }
            else if(data == (data | 12))
            {
                result = result + ", Posgrado";
            }
            else
            {
                result = result + ", Inicial";
            }
            string age = Convert.ToString(data >> 4);
            result = result + ", " + age;
            return result;
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
            Int16 data = 0;
            Int16 aux= 0;
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
            string result = data + "," + dni + "," + name + "," + lastname + "," + money + "," + comfirmed;
            return result;
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