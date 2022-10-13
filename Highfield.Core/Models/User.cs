namespace Highfield.Core.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string FavouriteColour { get; set; }

        public int Age => CalculateAge();

        private DateTime NextBirthday => CalculateNextBirthday();

        private int CalculateAge()
        {
            var currentYear = DateTime.Now.Year;
            var yearsSinceBirthYear = currentYear - DateOfBirth.Year;
            var isBirthdayUpcomingThisYear = NextBirthday.Year == currentYear;
            return isBirthdayUpcomingThisYear ? yearsSinceBirthYear - 1 : yearsSinceBirthYear;
        }

        private DateTime CalculateNextBirthday()
        {
            var today = DateTime.Now.Date;
            var birthdayDateThisYear = new DateTime(today.Year, DateOfBirth.Month, DateOfBirth.Day);
            return today < birthdayDateThisYear ? birthdayDateThisYear.AddYears(1) : birthdayDateThisYear;
        }
    }
}
