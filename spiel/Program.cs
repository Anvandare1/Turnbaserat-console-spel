// See https://aka.ms/new-console-template for more information - Nej, det tänker jag inte göra
using spiel;

//De globala variabler som används av spelet, t.ex antal rundon, totalt antal kills, poäng o.s.v
bool roundover = false;
bool gameover = false; 
bool introduction = true;
int kills = 0;
int rounds = 0;
int points = 0;
int turnpoints = 5;
List<Entity> enemies = new List<Entity>();
List<int> roundpoints = new List<int>();
Player player;

//Spelets huvud-loop, körs (nästan) alltid (tills den inte gör det mer, big IQ wrinkle-brain koncept ikr)
while(!gameover)
{
    //Att använda Clear-metoden motsvarar att anropa MS-DOS cls-kommandot i kommandotolksfönstret. När Clear-metoden anropas rullar markören automatiskt till det övre vänstra hörnet av fönstret och innehållet i skärmbufferten ställs in på tomrum med de aktuella bakgrundsfärgerna i förgrunden.
    Console.Clear();
    //kontrollerar om detta är fösta gången loopen körs (vilket innebär första rundan av spelomgången), ger möjlighet att spela en tutorial om så är fallet
    if(introduction)
    {
        introduction = false;
        Console.WriteLine("Enter any command to begin game");
        Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Play Tutorial?");
        Console.WriteLine("Yes");
        Console.WriteLine("No (any input apart form Yes)");
        string input = Console.ReadLine();
        //kontrollerar om spelaren vill köra tutorial eller ej, om så är fallet skapas en instans av en tutorial-klass (med anledningen av antalet writeline-kommandon är detta seperat klass) 
        if(input == "Yes")
        {
            Console.Clear();
            Tutorial tutorial = new Tutorial();
            tutorial.DisplayTutorial();
        }
        Console.Clear();
    }
    //Kallar funktioner vilken skapar alla klasser som ska användas under spelgången
    StartGame();
    //loopen som spelrundan körs i, upprepas tills rundan är över
    while(!roundover)
    {
        PlayerTurn();
        EnemyTurn();
    }
    //Kallar funktionen som hanterar slutet av spelomgången
    GameOver();
}

//Skapar alla fiender samt spelaren
void StartGame()
{
    //skapar spelaren
    player = new Player();
    Random rng = new Random();
    int spawn = rng.Next(1, 5);

    //skapar ett smupmässigt antal fiender där varje fiendes typ är slumpvald
    for(int i = 0; i < spawn; i++)
    {
        //tre är det magiska talet i datorspelsdesign, alla vet att om någonting ska fungera måste det ske 3 gånger, vill du klara din quest? Hitta 3 guldägg, vill du döda svampen? Hoppa på den 3 gånger, vill du dyrka ett lås? tryck ned alla 3 låspinnar (i rätt ordning)! Därav finns det tre fiendetyper för att allting ska jobba på "Peak" Efficiency!
        int enemytype = rng.Next(0, 3);
        Entity newenemy;
        switch(enemytype)
        {
            case 0:
               newenemy = new Enemy_Skeleton();
            break;

            case 1:
               newenemy = new Enemy_Spectre();
            break;

            case 2:
               newenemy = new Enemy_Berserker();
            break;

            default:
               newenemy = new Enemy_Skeleton();
            break;
        }
        enemies.Add(newenemy);
    }
}

//Metoden vilken hanterar alla spelarens input och handlingar
void PlayerTurn()
{
    Console.Clear();
    DisplayEnemies();

    //skriver ut handlingslistan i handlingsmenyn
    Console.WriteLine("Actions: ");
    Console.WriteLine("Attack (Attack a target)");
    Console.WriteLine("Stats (Display players current stats)");
    Console.WriteLine("Spells (Display avilable spells)");
    Console.WriteLine("Misc (Perform a misc action)");
    Console.WriteLine("Surrender (Surrender the battle)");
    Console.WriteLine("");

    string input = Console.ReadLine();
    //kontrollerar om splarens input är felaktigt och om så är fallet visas felmedelande och Playerturn metoden kallas igen. 
    //Varför i helvete gjorde jag detta istället för att abvända ett else-statement? Ingen vet, inte ens jag. 
    if(input != "Stats" && input != "Attack" && input!= "Spells" && input!= "Misc" && input!= "Surrender")
    {
        Console.Clear();
        Console.WriteLine("Error: Invalid Command");
        Console.ReadLine();
        PlayerTurn();
    }

    //sköter logiken för att anfalla en fiende
    if(input == "Attack")
    {
        Console.Clear();
        DisplayEnemies();
        Console.Write("Enter Enemy Index: ");
        input = Console.ReadLine();
        //försöker utföra anfall med givet input, om inpuit ej är giltigt (index out of range) eller input är bokstäver utförs catch istället
        try
        {
            int targetindex = int.Parse(input);
            int takendamage = player.Attack(enemies[targetindex]);
            Console.WriteLine("You Attacked " + enemies[targetindex].Name + " [" + targetindex + "] for " + takendamage + " Damage");
            if(enemies[targetindex].HP <= 0)
            {
                Console.WriteLine(enemies[targetindex].Name + " [" + input + "] died"); //användning av input här, men ej ovan, hur trött i hue va man när man skrev detta? Ba liksom, varför tho
                points += enemies[targetindex].KillPoints;
                enemies.RemoveAt(targetindex);
                kills++;
            }
            if(enemies.Count == 0)
            {
                roundover = true;
            }
            turnpoints = 5;
            Console.ReadLine();
        }

        //om input på något sätt är felaktigt kallas denna
        catch
        {
            Console.WriteLine("Error performing Action");
            Console.ReadLine();
            PlayerTurn();
        }
    }

    //Skriver ut spelarens stats i stat-menyn
    if(input == "Stats")
    {
        Console.Clear();
        Console.WriteLine("Health: " + player.HP);
        Console.WriteLine("Attack Power: " + player.AttackPower);
        Console.WriteLine("Mana: " + player.Mana);
        Console.WriteLine("Defense: " + player.Defense);
        Console.WriteLine("Bonus Damage: " + player.BonusDamage);
        Console.WriteLine("Turn Points: " + turnpoints);
        Console.ReadLine();

        PlayerTurn();
    }

    //logik för att utfföra magi, skriver ut samt hanterar input vid spells-menyn, förmodligen möjlig att skriva på något bättre sätt, med hjälp av spell-klass(er) eller liknande
    if(input == "Spells")
    {
        Console.Clear();
        Console.WriteLine("Available spells: ");
        Console.WriteLine("Heal (Heals player for 10 hp) [Cost 5 Mana]");
        Console.WriteLine("Smite (Deals 30 damage to a selected enemy) [Cost: 10 Mana]");
        input = Console.ReadLine();

        //Kontorllerar om "Heal" är giltig samt utför handlingen om så är fallet
        if(input == "Heal" && player.Mana >= 5)
        {
            player.TakeDamage(-10);
            player.Mana = 5;
            Console.WriteLine("You healed for 5 hp");
            Console.WriteLine("5 Mana Removed");
            Console.ReadLine();
        }

        //kontrollerar om "Smite" är giltig samt utför handlingen om så är fallet
        if(input == "Smite" && player.Mana >= 10)
        {
            //I princip kopia av Attack fast med små ändringar, kan kodas på ett bättre sätt
            Console.Clear();
            DisplayEnemies();
            Console.WriteLine("");
            Console.Write("Enter Enemy Index: ");
            input = Console.ReadLine();
            //försöker utföra anfall med givet input, om inpuit ej är giltigt (index out of range) eller input är bokstä ... https://www.youtube.com/watch?v=dv13gl0a-FA 
            try
            {
                int targetindex = int.Parse(input);
                int takendamage = enemies[targetindex].TakeDamage(30);
                Console.WriteLine("You Smited " + enemies[targetindex].Name + " [" + targetindex + "] for " + takendamage + " Damage");
                if(enemies[targetindex].HP <= 0)
                {
                    Console.WriteLine(enemies[targetindex].Name + " [" + input + "] died");
                    points += enemies[targetindex].KillPoints;
                    enemies.RemoveAt(targetindex);
                    kills++;
                }
                if(enemies.Count == 0)
                {
                    roundover = true;
                }
                player.Mana = 10;
                Console.ReadLine();
            }

            catch
            {
                Console.WriteLine("Error performing action");
                Console.WriteLine();
                PlayerTurn();
            }
        }
        //If-Statement förebygger softlock bugg om Smite dödar sista fienden, utan det fastnar spelet i Handlingsmenyn/Playerturn-Funktionen utan möjlighet att nå roundover state
        if(!roundover)
        {
            PlayerTurn();
        }
    }

    //Styr misc-handlingar, till skillnad från spells används en annan valuta samt kallar inte nödvändigtvis playerturn-metoden 
    if(input == "Misc")
    {
        Console.Clear();
        Console.WriteLine("Misc Actions: ");
        Console.WriteLine("Defend (Adds defense to the player) [Cost: 3 Turn Points]");
        Console.WriteLine("Sharpen Blade (Adds 5 damage to your next attack, progresses timeline) [Cost: 5 Turn Points]");        
        input = Console.ReadLine();

        if(input == "Defend" && turnpoints >= 3)
        {
            turnpoints -= 3;
            player.MiscActions(0);
            Console.WriteLine("Defense increased by 5");
            Console.ReadLine();
        }

        else if(input == "Sharpen Blade" && turnpoints >= 5)
        {
            turnpoints -= 5;
            player.MiscActions(1);
            Console.WriteLine("5 bonus damage for next attack");
            Console.ReadLine();
            turnpoints = 5;
        }

        //lösning som krävde genomsnittligt högre intelligensanvändning än metoden vilken detta if-statement är en del av, ibland kan det vara smart att bruka else, vem had kunnat ana!
        else
        {
            Console.Clear();
            Console.WriteLine("Error performing action");
            Console.ReadLine();
            PlayerTurn();
        }

        //fattig implimentering för att hantera skillnaden mellan att köra vidare timeline eller ej.
        if(input != "Sharpen Blade")
        {
            PlayerTurn();
        }
        //PlayerTurn(); Rouge bit av borttagen kod, otroligt nog ej lika vanligt förkommande i detta program/denna klass som vanligtvis... 
    }

    //Hur avslutar man en pågående spelrunda egentligen? Som man burkar säga: "When in doubt... Kalla skadefunktionen med ett stort tal och hoppas det löser problemet" - Sun Tzu
    if(input == "Surrender")
    {
        player.TakeDamage(800);
        gameover = true;
        roundover = true;
    }
}

//Ritar ut listan av fiender under spelet, i anfallsmenyns samt handlingsmenyn
void DisplayEnemies()
{
    Console.WriteLine("Enemies: ");
    for(int i = 0; i < enemies.Count; i++)
    {
        Console.WriteLine(enemies[i].Name + " [" + i + "] HP: " + enemies[i].HP + " AP: " + enemies[i].AttackPower);
    }
    Console.WriteLine("");
}

//kontrollerar logiken för spelets gameover stadie, bestämmer om en ny runda ska påbörjas eller om spelet är ordenligt slut
void GameOver()
{
    Console.WriteLine("");
    //Om spelaren är död avslutas spelet och en nu runda kan ej påbörjas, funktioner utför de sista handlingarna innan programmet avslutas
    if(player.HP <= 0)
    {
        string filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +@"\NotAVirus";
        //Sorterar en lista med poäng från spelade rundor envligt elements värde i stigande ordning och inverterar dess ordning sedan för att få högst poäng först
        roundpoints.Sort();
        roundpoints.Reverse();
        //Om directory MyDocuments/NotAVirus ej finns skapas det och med filen GameResults.txt vilken fylls med information angående sinaste spelomgången, om directory of fil finns skrivs dess innehåll över
        if(!Directory.Exists(filepath))
        {
            Directory.CreateDirectory(filepath);
        }
        StreamWriter streamwriter = new StreamWriter(filepath + @"\GameResults.txt");
        streamwriter.WriteLine("Rounds surived " + rounds);
        streamwriter.WriteLine("Total kills: " + kills);
        streamwriter.WriteLine("");
        streamwriter.WriteLine("Best Rounds: ");
        if(roundpoints.Count >= 3)
        {
            streamwriter.WriteLine("1st Round: " + roundpoints[0] + " Points");
            streamwriter.WriteLine("2nd Round: " + roundpoints[1] + " Points");
            streamwriter.WriteLine("3rd Round: " + roundpoints[2] + " Points");
        }
        else streamwriter.WriteLine("Not enough data was collected in the recent run, survive 3 or more rounds.");
        streamwriter.Close();
        Console.WriteLine("GAME OVER");
        Console.WriteLine("");
        Console.WriteLine("You have fallen in battle");
        Console.WriteLine("You have slain " + kills + " enemies");
        Console.WriteLine("You survied " + rounds + " battles");
        Console.WriteLine("Statistics from this run can be found at " + filepath + @"\GameResults.txt");
        gameover = true;
        Console.ReadLine();
        Console.Clear();
        //GameOver();
    }

    //Om alla fiender är döda avslutas spelet och en ny runda kan påbörjas, funktioner förbereder den nya rundan
    else if(enemies.Count == 0)
    {
        rounds++;
        roundpoints.Add(points);
        points = 0;
        Console.WriteLine("You stand victorious, but at what cost?");
        Console.WriteLine("Enter any command to continue");
        Console.ReadLine();
        roundover = false;
    }
}

//Fienders AI, styr alla fiender och deras handlingar
void EnemyTurn()
{
    Console.Clear();
    Console.WriteLine("Enemy Turn: ");
    //Loopar igenom listan enemies (där alla aktiva fiender är lagrade) och utför en chansbaserad handling (huruvida de anfaller eller ej) samt skriver ut combat-loggen
    for(int i = 0; i < enemies.Count; i++)
    {
        Random rng = new Random();
        int attackchance = rng.Next(0, 100);

        if(attackchance > 40)
        {
            int takendamage = enemies[i].Attack(player);
            Console.WriteLine(enemies[i].Name + " [" + i + "] Attacked you for " + takendamage + " Damage");
        }

        else {Console.WriteLine(enemies[i].Name +  " [" + i + "] Did not attack");}
    }
    //kontrollerar om spelaren är död efter fienders drag, om så är fallet sätts gameover till true och avslutar därmed spel-loopen
    if(player.HP <= 0)
    {
        roundover = true;
    }
    Console.ReadLine();
}