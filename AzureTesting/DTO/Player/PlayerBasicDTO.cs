using AzureTesting.Model;

namespace AzureTesting.DTO.Player
{
    public class PlayerBasicDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int ShirtNumber { get; set; }
        

        public PlayerBasicDTO() { }
        public PlayerBasicDTO(int id, string name, string surname, int shirtNumber)
        {
            Id = id;
            Name = name;
            Surname = surname;
            ShirtNumber = shirtNumber;
        }
    }
}
