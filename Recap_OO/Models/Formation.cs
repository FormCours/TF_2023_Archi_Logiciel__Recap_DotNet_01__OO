using Recap_OO.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Recap_OO.Models
{
    public class Formation
    {
        #region Field (Champs)
        private readonly List<string> _Courses = new List<string>();
        private readonly List<Student> _Participants = new List<Student>();
        private DateTime _StartDate;
        private DateTime? _EndDate;
        #endregion

        #region Indexeur
        public Student? this[string matricule]
        {
            get
            {
                // Teasing => Linq to Object
                return _Participants.FirstOrDefault(p => p.Matricule == matricule);
            }
        }
        // ↓ Génére une méthode que celle-ci
        // public Student? GetStudent(string matricule)
        // {
        //     return null;
        // }
        #endregion


        #region Props (Propriétés)
        public string Name { get; set; }
        public IEnumerable<string> Courses 
        {
            get { return _Courses.AsReadOnly(); }        
        }
        public DateTime StartDate
        { 
            get { return _StartDate; }
            set
            {
                if(EndDate != null && value > EndDate)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(StartDate),
                        "The Start date must be lower of the End Date !"
                    );
                }

                _StartDate = value;
            }
        }  
        public DateTime? EndDate
        { 
            get { return _EndDate; } 
            set
            {
                if(value != null && value < StartDate)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(EndDate), 
                        "The End date must be upper of the Start Date !"
                    );
                }
                   
                _EndDate = value;
            }
        }  
        public Teacher? MainTeacher { get; set; }
        public int NbMaxParticipants { get; init; } // init → Propiété initializé durant la création de l'objet
        public IEnumerable<Student> Participants
        {
            get { return _Participants.AsReadOnly(); }
        }
        #endregion

        #region Constructeur
        public Formation(string name, int nbMaxParticipants, DateTime startDate, DateTime? endDate = null)
        {
            this.Name = name;
            this.NbMaxParticipants = nbMaxParticipants;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }
        #endregion

        #region Méthodes
        public void AddCourse(params string[] courses)
        {
            foreach(var courseToAdd in courses) 
            {
                if(_Courses.Contains(courseToAdd))
                {
                    throw new CourseAlreadyExistsException(nameof(courses));
                }
                // _Courses.Add(courseToAdd);
            }

            _Courses.AddRange(courses);
        }

        public void RemoveCourse(string course)
        {
            _Courses.Remove(course);
        }

        public void AddParticipant(Student student)
        {
            if(_Participants.Count >= NbMaxParticipants)
            {
                throw new ArgumentException(nameof(student), "Too many students（︶^︶）");
            }

            _Participants.Add(student);
        }
        #endregion
    }
}
