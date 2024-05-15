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
            if(rage > 10)
            {
                Console.WriteLine("Berserker healed for 5 points");
                hp += 5;
                rage = 0;
            }
            return base.TakeDamage(damage);
        }
    }
}