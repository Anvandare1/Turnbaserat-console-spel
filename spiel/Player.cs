namespace spiel
{
    public class Player : Entity 
    {
        private int mana;
        public int Mana{get{return mana;} set{mana -= value;}}
        
        //Konsturktor specialiserad för spelar-klassen, 
        public Player() : base(20, 5, 0, "Player")
        {
            this.mana = 10;
        }
    }
}