using System.ComponentModel.DataAnnotations;

namespace ZavrsniTest.Models
{
    public class Album
    {
        public int Id { get; set; }


        [MaxLength(80, ErrorMessage = "maximum length is80")]
        [MinLength(3, ErrorMessage = "maximum length is80")]
        public string Name { get; set; }

        [Range(1950, 2022)]
        public int YearPublish { get; set; }

        [MaxLength(50, ErrorMessage = "maximum length is80")]
        [MinLength(3, ErrorMessage = "maximum length is80")]
        public string Genre { get; set; }

        [Range(0,100)]
        public int NumberOfSales { get; set; }

        public int BandId { get; set; }

        public Band Band { get; set; }
    }
}
