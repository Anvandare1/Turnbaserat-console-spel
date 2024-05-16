namespace spiel
{
    public class Enemy_Berserker : Entity
    {
        private int rage;
        public Enemy_Berserker(): base(12, 2, 4, "Berserker")
        {

        }

        public override int TakeDamage(int damage)
        {
            rage += damage;
            if(rage > 5)
            {
                Console.WriteLine("Berserker attack power increased!");
                attackpower += rage;
                rage = 0;
            }
            return base.TakeDamage(damage);
        }
    }
}