using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAW_Lab1
{
    internal class Student
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public int Varsta { get; set; }
        public int NrMatricol { get; set; }
        public int AnInscriere { get; set; }
        public List<Materie> Materii { get; set; }
        public String NumePrenume
        {
            get { return Nume + " " + Prenume; }
            set { NumePrenume = Nume + " " + Prenume; }
        }


        public void NrMatr_An()
        {
            Console.WriteLine(NrMatricol.ToString() + "/" + AnInscriere.ToString());
        }
    }

    internal class Materie
    {
        public string titlu { get; set; }
        public string durata { get; set; }
    }
}
