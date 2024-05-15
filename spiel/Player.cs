namespace spiel
{
    public class Player : Entity 
    {
        private int mana;
        public int Mana{get{return mana;} set{mana -= value;}}
        public Player(int mana) : base(20, 5, 0, "Player")
        {
            this.mana = mana;
        }
    }
}