using System.ComponentModel.DataAnnotations;

namespace CharacterCreator.Models
{
    public class User
    {
        [Key]
        public string username;

        public string password;

    }
}
