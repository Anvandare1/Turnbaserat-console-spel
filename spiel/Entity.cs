namespace spiel
{
    public class Entity
    {
        protected int hp;
        protected int attackpower;
        protected string name;
        protected int killpoints;

        public int HP{get{return hp;}}
        public int AttackPower{get{return attackpower;}}
        public int KillPoints{get{return killpoints;}}
        public string Name{get{return name;}}
        /// <summary>
        /// Baskonstruktor för alla entities, skapar en ny entity med attributer angivna i subklasser
        /// </summary>
        /// <param name="hp"></param>
        /// <param name="attackpower"></param>
        public Entity(int hp, int attackpower, int killpoints, string name)
        {
            this.hp = hp;
            this.attackpower = attackpower;
            this.killpoints = killpoints;
            this.name = name;
        }

        /// <summary>
        /// Tar in en referens till en annan entity, d.v.s måltavlan för anfallet och kallar dess TakeDamage-Funktion
        /// </summary>
        /// <param name="target"></param>
        public virtual int Attack(Entity target)
        {
            int takendamage = target.TakeDamage(attackpower);
            return takendamage;
        }

        /// <summary>
        /// Metoden för att skada en entity, tar in en intager vilken motsvarar anfallarens attackskada
        /// </summary>
        /// <param name="damage"></param>

        public virtual int TakeDamage(int damage)
        {
            hp -= damage;
            return damage;
        }
    }
}