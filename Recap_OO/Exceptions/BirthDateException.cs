using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recap_OO.Exceptions
{
    /// <summary>
    /// Exception customizé pour représenter une erreur par rapport à la date de naissance d'une personne
    /// </summary>
    public class BirthDateException : Exception
    {
        // Le mot clef "base" permet d'appeler explicitement le constructeur de la classe parent
        public BirthDateException() : base() { }
        public BirthDateException(string message) : base(message) { }
    }
}
