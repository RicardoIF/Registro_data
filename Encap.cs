using System;

namespace Registros_de_datos
{
    public sealed class Regist
    {
        private int data = 0;
        public string dni {get;}
        public string name {get;}
        public string lastname {get;}
        public string money {get;}
        public string password {get;}

        public Status status = 0;
        public Sex sex = 0;
        public Grade grade = 0;

        public int age = 0;

        internal static Regist From(in string line)
        {
            string[] val = line.Split(',');
            string dni = val[0];
            string name = val[1];
            string lastname = val[2];
            string money = val[3];
            string password = val[4];
            Int16 data = Convert.ToInt16(val[5]);
        
            Sex sex = (Sex) (data & 2);
            Status status = (Status) (data & 1);
            Grade grade = (Grade) (data & 12);
            int age = data >> 4;
            
            return new Regist(dni, name, lastname, money, password, status, sex, grade, age);
        }
        public Regist(in string Dni, in string Name, in string Lastname, in string Money, in string Password, in Status status, in Sex sex, in Grade grade, in int Age)
        {
            dni = Dni;
            name = Name;
            lastname = Lastname;
            money = Money;
            password = Password;
            data = (Age << 4) |   ((int)sex) | ((int)status) | ((int) grade); 
        }

    }
    public enum Status {Soltero = 0, Casado = 1}
    public enum Sex {Masculino = 0, Femenino = 2}
    public enum Grade {Inicial = 0, Media = 4, Grado = 8, Postgrado = 12}
}