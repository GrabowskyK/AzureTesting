using AzureTesting.Model;

namespace AzureTesting.DTO.Player
{
    public class PlayerBasicDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        

        public PlayerBasicDTO() { }
        public PlayerBasicDTO(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
}
