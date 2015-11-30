namespace Utrepalo.Core.GameObjects
{
    public class User
    {
        private string name;
        private string password;
        private Character character;

        public User(string name,string password, Character character)
        {
            this.Character = this.character;
            this.Name = this.name;
            this.Password = this.password;
        }
        public string Name { get; set; }
        public string Password { get; set; }
        public Character Character { get; set; }
    }
}
