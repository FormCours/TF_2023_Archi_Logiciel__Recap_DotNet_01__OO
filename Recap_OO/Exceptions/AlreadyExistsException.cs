using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recap_OO.Exceptions
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException() { }
        public AlreadyExistsException(string? message) : base(message) { }
    }


    public class SpecializationAlreadyExistsException : AlreadyExistsException
    {
        public SpecializationAlreadyExistsException() { }
        public SpecializationAlreadyExistsException(string? message) : base(message) { }
    }

    public class CourseAlreadyExistsException : AlreadyExistsException
    {
        public CourseAlreadyExistsException() { }
        public CourseAlreadyExistsException(string? message) : base(message) { }
    }
}
