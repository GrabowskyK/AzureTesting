using System.ComponentModel.DataAnnotations;

namespace AzureTesting.Model
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [MaxLength(3)]
        public string ShortName { get; set; } 

        public Image Image { get; set; }
        public int ImageId { get; set; }

    }
}
