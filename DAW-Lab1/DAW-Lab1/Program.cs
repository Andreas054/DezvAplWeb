// See https://aka.ms/new-console-template for more information
using DAW_Lab1;

List<Student> lista_studenti = new List<Student>
{
    new Student { Nume = "Daniel", Prenume = "Mihai", Varsta = 19, NrMatricol = 225, AnInscriere = 2022},
    new Student { Nume = "Marian", Prenume = "Popescu", Varsta = 20, NrMatricol = 305, AnInscriere = 2021},
    new Student { Nume = "Alina", Prenume = "Dumitru", Varsta = 18, NrMatricol = 294, AnInscriere = 2023}
};

lista_studenti[0].Materii = new List<Materie>
{
    new Materie { titlu = "Algebra", durata = "2h"},
    new Materie { titlu = "Analiza", durata = "1h30m"}
};

lista_studenti[1].Materii = new List<Materie>
{
    new Materie { titlu = "Structuri de Date", durata = "2h"},
    new Materie { titlu = "Arhitectura Sistemelor de Calcul", durata = "3h"},
    new Materie { titlu = "Sisteme de Operare", durata = "2h"}
};

lista_studenti[2].Materii = new List<Materie>
{
    new Materie { titlu = "Limbaje Formale si Automate", durata = "1h"},
    new Materie { titlu = "Engleza", durata = "30m"},
    new Materie { titlu = "Baze de Date", durata = "2h30m"}
};

for (int i = 0; i < lista_studenti.Count; i++)
{
    Console.WriteLine("\n" + lista_studenti[i].NumePrenume);
    lista_studenti[i].NrMatr_An();
    for (int j = 0; j < lista_studenti[i].Materii.Count; j++)
    {
        Console.WriteLine(lista_studenti[i].Materii[j].titlu + " " + lista_studenti[i].Materii[j].durata);
    }
}