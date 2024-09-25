using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Core.ValueObjetc;

public class GenderList
{
    public static List<string> Genders = new List<string>() {
        "Romance",
        "Ficção Científica",
        "Fantasia",
        "Terror",
        "Aventura",
        "Biografia",
        "História" ,
        "Autoajuda"
    };

    public void ValidationList(string gender)
    {
        if (!GenderList.Genders.Contains(gender))
        {
            Console.Write("Gênero inválido! O Gênero informado não corresponde aos Gêneros disponíveis existentes!");
        }
    }
}
