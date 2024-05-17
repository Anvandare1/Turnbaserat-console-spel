namespace spiel
{
    public class Player : Entity 
    {
        private int defense;
        private int mana;
        public int Mana{get{return mana;} set{mana -= value;}}
        public int Defense{get{return defense;}}

        public void MiscActions(int index)
        {
            switch(index)
            {
                case 0:
                defense += 5;
                break;
            }
        }
        //Konsturktor specialiserad för spelar-klassen, 
        public Player() : base(20, 5, 0, "Player")
        {
            this.mana = 10;
        }
        public override int TakeDamage(int damage)
        {
            //Bestämer hur skadan och försvaret ska hanteras 
            switch(defense)
            {
                case > 0:
                   int loggeddefense = defense;
                   defense -= damage;
                   if(defense < 0)
                   {
                       defense = 0;
                   }
                   damage -= loggeddefense;
                   if(damage < 0)
                   {
                      damage = 0;
                   }
                   return base.TakeDamage(damage);
                //break;

                case <= 0:
                   return base.TakeDamage(damage);
                //break;
            }
        }
    }
}