using Recap_OO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recap_OO.Models
{
    // Un "Student" est une "Person" => Celui-ci hérite de tout ses attributs et méthodes
    public class Student : Person
    {
        public string Matricule { get; set; }
        public string? SchoolDegree { get; set; }
        public TransportTypeEnum TransportType { get; set; }


        // Méthode pour éviter la répétition dans les constructeurs de "student"
        // Dans notre sénario, les constructeurs ne peuvent pas utiliser "this" car, il utilise déjà "base"
        private void InitializeStudent(string matricule, TransportTypeEnum transportType)
        {
            this.Matricule = matricule.ToUpper();
            this.TransportType = transportType;
            this.SchoolDegree = null;
        }

        public Student(string firstname, string lastname, DateTime birthDate, GenreEnum genre, string matricule, TransportTypeEnum transportType)
            : base(firstname, lastname, birthDate, genre)
        {
            InitializeStudent(matricule, transportType);
        }

        public Student(string firstname, string lastname, DateTime birthDate, string matricule, TransportTypeEnum transportType)
            : base(firstname, lastname, birthDate)
        {
            InitializeStudent(matricule, transportType);
        }
    }
}
