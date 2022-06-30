using System.ComponentModel.DataAnnotations;

namespace ZavrsniTest.Models
{
    public class Band
    {
        public int Id { get; set; }

        [StringLength(200, ErrorMessage ="max length 200")]
        public string Name { get; set; }

        [Range(minimum: 1900, 2022, ErrorMessage = "value must be between 1900 and 2022")]
        public int YearCreate { get; set; }

    }
}
