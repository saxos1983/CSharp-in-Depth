namespace Chapter11_LINQ.Model
{
    public class User
    {
        public string Name { get; set; }
        public UserType UserType { get; set; }

        public User (string name, UserType userType)
        {
            this.Name = name;
            this.UserType = userType;
        }

        public override string ToString()
        {
            return string.Format("User: {0} ({1})", this.Name, this.UserType);
        }
    }
}
