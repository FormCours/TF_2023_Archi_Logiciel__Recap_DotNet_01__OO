using Recap_OO.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recap_OO.Models
{
    public class Teacher : Person
    {
        // L'option "readonly" interdit la ré-affectation (Ne protege pas des modif: Add, Remove, ...)
        // Possibilité de l'initialiser : Directement (à coté de la déclaration) ou via le constructeur
        private readonly List<string> _Specialization = new List<string>();


        public IEnumerable<string> Specialization
        {
            // Envoi une copie de la liste en lecteur seul
			get { return _Specialization.AsReadOnly(); }
		}

		public string? Company { get; set; }


        private void InitializeTeacher(string? company)
        {
            this.Company = company;
        }

        public Teacher(string firstname, string lastname, DateTime birthDate, GenreEnum genre, string? company)
            : base(firstname, lastname, birthDate, genre)
        {
            InitializeTeacher(company);
        }

        public Teacher(string firstname, string lastname, DateTime birthDate, string? company)
          : base(firstname, lastname, birthDate)
        {
            InitializeTeacher(company);
        }


        public void AddSpecialization(string specialization)
        {
            if(_Specialization.Contains(specialization.ToLower()))
            {
                throw new SpecializationAlreadyExistsException();
            }

            _Specialization.Add(specialization.ToLower());
        }

        public void AddSpecialization(params string[] specializations)
        {
            foreach(string specialization in specializations)
            {
                AddSpecialization(specialization);
            }
        }

        public void RemoveSpecialization(string specialization)
        {
            _Specialization.Remove(specialization.ToLower());
        }
    }
}
