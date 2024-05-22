namespace spiel
{
    public class Enemy_Spectre : Entity
    {
        //Spectres tar halverad skada, de är gjorda av ektoplasma, därav är vapen mindre effektiva p.g.a fysik och kemiska anledningar, det är canon oki

        public override int TakeDamage(int damage)
        {
            hp -= damage/2;
            return damage/2; 
        }
        public Enemy_Spectre() : base(15, 3, 5, "Spectre")
        {}
    }
}