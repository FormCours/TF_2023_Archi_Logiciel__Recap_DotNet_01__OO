using Recap_OO.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recap_OO.Models
{
    // Mettre la classe en "abstract" permet d'interdir l'instanciation de celle-ci
    public abstract class Person
    {
        // Enumeration interne à la classe personne (Lien explicit avec Person)
        public enum GenreEnum
        {
            F, M, X
        }

        // Field (Champs)
        private DateTime _BirthDate;

        // Encapsulation des attributs de la classe
        // - Auto-props
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public GenreEnum? Genre { get; set; }

        // - Props Calculé
        public string Fullname
        {
            get { return $"{Firstname} {Lastname}"; }
        }

        // - Props full (-> Lié à une variable)
        public DateTime BirthDate 
        {
            get { return _BirthDate; }
            set 
            { 
                // Déclanchement d'un erreur si la date de naissance est dans le futur
                if(_BirthDate > DateTime.Today)
                {
                    throw new BirthDateException("No birthdate in futur (╯°□°）╯︵ ┻━┻");
                }
                
                _BirthDate = value; 
            }
        }

        #region Méthode générer par les propriétés
        /*
        // Une props (full/auto) créer 2 méthodes
        // - Getter (Accesseur)
        public DateTime GetBirthdate()
        {
            return _BirthDate;
        }
        // - Setter (Mutateur)
        public void SetBirthDate(DateTime value)
        {
            // Déclanchement d'un erreur si la date de naissance est dans le futur
            if (_BirthDate > DateTime.Today)
            {
                throw new BirthDateException("No birthdate in futur (╯°□°）╯︵ ┻━┻");
            }

            _BirthDate = value;
        }
        */
        #endregion

        public Person(string firstname, string lastname, DateTime birthDate)
        {
            // Le mot clef "this" dans se sénario est optionnel,
            // car la casse des variables et des propriété sont différentes
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.BirthDate = birthDate;
        }

        public Person(string firstname, string lastname, DateTime birthDate, GenreEnum genre) 
            : this(firstname, lastname, birthDate) // Appel au constructeur qui possede 3 parametres
        {
            this.Genre = genre;
        }
    }
}
