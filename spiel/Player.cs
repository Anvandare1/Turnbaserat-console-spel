namespace spiel
{
    public class Player : Entity 
    {
        private int defense;
        private int bonusdamage;
        private int mana;
        public int Mana{get{return mana;} set{mana -= value;}}
        public int Defense{get{return defense;}}
        public int BonusDamage{get{return bonusdamage;}}

        public void MiscActions(int index)
        {
            switch(index)
            {
                case 0:
                defense += 5;
                break;

                case 1:
                bonusdamage += 5;
                break;
            }
        }

        //Override av anfallsmetoden, syfte att implimentera bonusskadehantering
        public override int Attack(Entity target)
        {
            if(bonusdamage > 0)
            {
                int takendamage = target.TakeDamage(attackpower + bonusdamage);
                bonusdamage = 0;
                return takendamage;    
            }
            return base.Attack(target);
        }
        //Konsturktor specialiserad för spelar-klassen, 
        public Player() : base(20, 5, 0, "Player")
        {
            this.mana = 10; //Rouge "this" nycekord/modifikator, monumentet för fenomenet restes 2024-05-22 och har lockar åskådare från land och rike runt sedan dess. Ja jag är för lat för att ta bort modifikatiorn men inte för lat för att skriva denna svinlånga komentar precis bredvid den istället för att trycka på backspace fem gånger, prioriteringarna är spikraka här sir!
            bonusdamage = 0;
        }
        public override int TakeDamage(int damage)
        {
            //Bestämer hur skadan och försvaret ska hanteras, använder den legendariska switch - case - return strukturen, vissa skulle påstå att switch - case - break är vanligare men i denna ekonomi har vi inte råd med sådant 
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