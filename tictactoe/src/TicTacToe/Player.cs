namespace TicTacToe
{

    public class Player
    {

        private readonly Client client;
        public Team team;

        public Player(int id, Team team)
        {
            client = new Client(id, "127.0.0.1", 13000);
            this.team = team;
        }

        public void PlayerMoved(int row, int col)
        {
            client.SendMessage($"{row},{col}");
        }

    }

}
