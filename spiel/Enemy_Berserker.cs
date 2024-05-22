namespace spiel
{
    public class Enemy_Berserker : Entity
    {
        //Intager, inom C# vanligtvis åtfunnen som variabler i klasser, de används för att hålla heltal, ett heltal är ett tal utan decimaler, ett tal med decimaler kalls decimaltal, Matte 101; (ja vi avslutar med ; det är meningen, ifrågasätt ej) ; ; ; ; ; ; ;
        private int rage;
        public Enemy_Berserker(): base(12, 2, 4, "Berserker")
        {

        }

        public override int TakeDamage(int damage)
        {
            //Berserker har rage, rage bra, rage ger attackpower, berserker gillar attackpower, det ger berserker något att leva för, berserker är glad att ha något att leva för. Appropå ämnet, varför mördar du berserkers?! De vill dig inget illa, de vill ednast mörda dig med sina yxor och sedan dricka mjöd
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