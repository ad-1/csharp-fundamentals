namespace Server
{
    public class Square
    {

        public Team owner;
        public void AssignOwner(Team team)
        {
            owner = team;
        }

        public string Value
        {
            get
            {
                return owner switch
                {
                    Team.Unassigned => "-",
                    Team.Noughts => "O",
                    Team.Crosses => "X",
                    _ => "-",
                };
            }
        }

        public Square()
        {
            owner = Team.Unassigned;
        }

    }
}
