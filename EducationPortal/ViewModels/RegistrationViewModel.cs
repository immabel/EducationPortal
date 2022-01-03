using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.ViewModels
{
    public class RegistrationViewModel
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string PlaceStudy { get; set; }

        public string PlaceWork { get; set; }
    }
}