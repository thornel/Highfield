namespace Highfield.Core.Models
{
    public class FavouriteColourStatistics
    {
        public FavouriteColourStatistics(IEnumerable<string> allUsersFavouriteColours)
        {
            TotalUsers = allUsersFavouriteColours.Count();

            var distinctFavouriteColours = allUsersFavouriteColours.Distinct();
            TotalFavouriteColours = distinctFavouriteColours.Count();

            ColourFrequencies = new List<ColourFrequency>();
            foreach(var colour in distinctFavouriteColours)
            {
                ColourFrequencies.Add(new ColourFrequency()
                {
                    ColourName = colour,
                    Frequency = allUsersFavouriteColours.Count(x => x == colour)
                });
            }
        }

        public int TotalUsers { get; }

        public int TotalFavouriteColours { get; }

        public List<ColourFrequency> ColourFrequencies { get; }

        public class ColourFrequency
        {
            public string ColourName { get; set; }

            public int Frequency { get; set; }
        }
    }
}