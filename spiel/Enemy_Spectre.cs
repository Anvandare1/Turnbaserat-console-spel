namespace spiel
{
    public class Enemy_Spectre : Entity
    {

        public override int TakeDamage(int damage)
        {
            hp -= damage/2;
            return damage/2; 
        }
        public Enemy_Spectre() : base(15, 3, 5, "Spectre")
        {}
    }
}