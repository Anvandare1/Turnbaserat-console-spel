// See https://aka.ms/new-console-template for more information
using spiel;

bool gameover = false;
bool introduction = true;
int kills = 0;
int rounds = 0;
int points = 0;
List<Entity> enemies = new List<Entity>();
List<int> roundpoints = new List<int>();
Player player;

while(true)
{
    Console.Clear();
    if(introduction)
    {
        introduction = false;
        Console.WriteLine("Enter any command to begin game");
        Console.ReadLine();
        Console.Clear();
    }
    StartGame();
    while(!gameover)
    {
        PlayerTurn();
        EnemyTurn();
    }
    GameOver();
}

//Skapar alla fiender samt spelaren
void StartGame()
{
    player = new Player(200);
    Random rng = new Random();
    int spawn = rng.Next(1, 5);

    for(int i = 0; i < spawn; i++)
    {
        int enemytype = rng.Next(0, 2);
        Entity newenemy;
        switch(enemytype)
        {
            case 0:
               newenemy = new Enemy_Skeleton();
            break;

            case 1:
               newenemy = new Enemy_Spectre();
            break;

            default:
               newenemy = new Enemy_Skeleton();
            break;
        }
        enemies.Add(newenemy);
    }
}

//Metoden vilken hanterar spelarens input och handlingar
void PlayerTurn()
{
    Console.Clear();
    DisplayEnemies();

    Console.WriteLine("Actions: ");
    Console.WriteLine("Attack (Attack a target)");
    Console.WriteLine("Stats (Display players current stats)");
    Console.WriteLine("Spells (Display avilable spells)");
    //Console.WriteLine("Quit (End the game)");
    Console.WriteLine("");

    string input = Console.ReadLine();
    if(input != "Stats" && input != "Attack" && input!= "Spells")
    {
        Console.Clear();
        Console.WriteLine("Error: Invalid Command");
        Console.ReadLine();
        PlayerTurn();
    }

    if(input == "Attack")
    {
        Console.Clear();
        DisplayEnemies();
        Console.Write("Enter Enemy Index: ");
        input = Console.ReadLine();
        try
        {
            int targetindex = int.Parse(input);
            int takendamage = player.Attack(enemies[targetindex]);
            Console.WriteLine("You Attacked " + enemies[targetindex].Name + " [" + targetindex + "] for " + takendamage + " Damage");
            if(enemies[targetindex].HP <= 0)
            {
                Console.WriteLine(enemies[targetindex].Name + " [" + input + "] died");
                points += enemies[targetindex].KillPoints;
                enemies.RemoveAt(targetindex);
                kills++;
            }
            if(enemies.Count == 0)
            {
                gameover = true;
            }
            Console.ReadLine();
        }

        catch
        {
            Console.WriteLine("Error performing Action");
            Console.ReadLine();
            PlayerTurn();
        }
    }

    if(input == "Stats")
    {
        Console.Clear();
        Console.WriteLine("Health: " + player.HP);
        Console.WriteLine("Attack Power: " + player.AttackPower);
        Console.WriteLine("Mana: " + player.Mana);
        Console.ReadLine();

        PlayerTurn();
    }

    if(input == "Spells")
    {
        Console.Clear();
        Console.WriteLine("Available spells: ");
        Console.WriteLine("Heal (Heals player for 10 hp) [Cost 5 Mana]");
        Console.WriteLine("Smite (Deals 30 damage to a selected enemy) [Cost: 10 Mana]");
        input = Console.ReadLine();

        if(input == "Heal" && player.Mana >= 5)
        {
            player.TakeDamage(-10);
            player.Mana = 5;
            Console.WriteLine("You healed for 5 hp");
            Console.WriteLine("5 Mana Removed");
            Console.ReadLine();
        }

        if(input == "Smite" && player.Mana >= 10)
        {
            Console.Clear();
            DisplayEnemies();
            Console.WriteLine("");
            Console.Write("Enter Enemy Index: ");
            input = Console.ReadLine();
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
                    gameover = true;
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
        if(!gameover)
        {
            PlayerTurn();
        }
    }
}

void DisplayEnemies()
{
    Console.WriteLine("Enemies: ");
    for(int i = 0; i < enemies.Count; i++)
    {
        Console.WriteLine(enemies[i].Name + " [" + i + "] HP: " + enemies[i].HP + " AP: " + enemies[i].AttackPower);
    }
    Console.WriteLine("");
}

void GameOver()
{
    //Console.Clear();
    Console.WriteLine("");
    if(player.HP <= 0)
    {
        string filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +@"\NotAVirus";
        roundpoints.Sort();
        roundpoints.Reverse();
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
        Console.ReadLine();
        Console.Clear();
        GameOver();
    }

    else if(enemies.Count == 0)
    {
        rounds++;
        roundpoints.Add(points);
        points = 0;
        Console.WriteLine("You stand victorious, but at what cost?");
        Console.WriteLine("Enter any command to continue");
        Console.ReadLine();
        gameover = false;
    }
}

//Fienders AI, styr alla fiender och deras handlingar
void EnemyTurn()
{
    Console.Clear();
    Console.WriteLine("Enemy Turn: ");
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

    if(player.HP <= 0)
    {
        gameover = true;
    }
    Console.ReadLine();
}