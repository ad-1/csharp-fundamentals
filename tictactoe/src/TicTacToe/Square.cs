namespace TicTacToe
{
    public class Square
    {

        public Team owner;

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
            this.owner = Team.Unassigned;
        }

        public void AssignOwner(Team owner)
        {
            this.owner = owner;
        }

    }
}
