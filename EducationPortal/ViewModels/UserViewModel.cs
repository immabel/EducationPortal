namespace EducationPortal.ViewModels
{
    using System.Collections.Generic;

    public class UserViewModel
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public string PlaceStudy { get; set; }

        public string PlaceWork { get; set; }

        public List<string> Skills { get; set; }
    }
}