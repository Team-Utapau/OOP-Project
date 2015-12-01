namespace Utrepalo.Game.GameObjects
{
    public class User
    {
        private string name;
        private string password;
        private PlayerCharacter character;

        public User(string name,string password, PlayerCharacter character)
        {
            this.Character = this.character;
            this.Name = this.name;
            this.Password = this.password;
        }
        public string Name { get; set; }
        public string Password { get; set; }
        public PlayerCharacter Character { get; set; }
    }
}
