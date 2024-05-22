namespace spiel
{
    //klass dedikerad till att skriva tutorial, mycket proffsigt skriven med endast massiva block av Console.WriteLine, 11/10 - IGN
    public class Tutorial
    {
        //Massiv metod för all skriva ut tutorial, uppdelat enligt berörd del av spelet. Ger ett även ett exempel på hur man spelar
        public void DisplayTutorial()
        {
            //tutorial för spelar input, berättar hur spelaren förväntas styra spelet
            Console.WriteLine("Input");
            Console.WriteLine("");
            Console.WriteLine("Unless otherwise indicated an input free of choice will progress through the menues");
            Console.WriteLine("If otherwise specified you will need to enter the input as directed by the game in order to progress");
            Console.ReadLine();
            Console.Clear();

            //Ger spelaren generell information angånde handlingsmenyns interface, samt hur slagfältet avläses
            Console.WriteLine("Combat Basics: Action Menu - Enemy List");
            Console.WriteLine("");
            Console.WriteLine("Enemies: ");
            Console.WriteLine("Skeleton: [0] HP: 5 AP: 1");
            Console.WriteLine("Skeleton: [1] HP: 2 AP: 1");
            Console.WriteLine("Spectre: [2] HP: 15 AP: 3");
            Console.WriteLine("");
            Console.WriteLine("Actions: ");
            Console.WriteLine("Attack (Attack a target)");
            Console.WriteLine("Stats (Display players current stats)");
            Console.WriteLine("Spells (Display avilable spells)");
            Console.WriteLine("");
            Console.WriteLine("This is the combat window, here you will peroform actions to progress the battle");
            Console.WriteLine("On the top of the menu a list of enemies will be displayed, these contain names, index, HP, and AP values");
            Console.WriteLine("The HP indicates how much health the enemy has left and the AP indicates how much damage the enemy deals when attacking");
            Console.WriteLine("The index will be used at a later stage");
            Console.WriteLine("");
            Console.WriteLine("Enter any Input to continue");
            Console.ReadLine();
            Console.Clear();
            
            //Ger spelaren information om handlingslistan (De handlingar som kan utföras) samt berättar hur denna används
            Console.WriteLine("Combat Basics: Action Menu - Actions List");
            Console.WriteLine("");
            Console.WriteLine("Enemies: ");
            Console.WriteLine("Skeleton: [0] HP: 5 AP: 1");
            Console.WriteLine("Skeleton: [1] HP: 2 AP: 1");
            Console.WriteLine("Spectre: [2] HP: 15 AP: 3");
            Console.WriteLine("");
            Console.WriteLine("Actions: ");
            Console.WriteLine("Attack (Attack a target)");
            Console.WriteLine("Stats (Display players current stats)");
            Console.WriteLine("Spells (Display avilable spells)");
            Console.WriteLine("Misc (Perform a misc action)");
            Console.WriteLine("Surrender (Surrender the battle)");
            Console.WriteLine("");
            Console.WriteLine("In order to perform any given action you enter the action as stated in the Actions list, without (text in here)");
            Console.WriteLine("Input is case sensitive and any invalid input at any point will display an error and return you here without progressing the timeline");
            Console.WriteLine("If you for instance wish to attack a target you will enter Attack as the input");
            Console.WriteLine("");
            Console.WriteLine("Enter any input to continue");
            Console.ReadLine();
            Console.Clear();
            
            //förklarar för spelaren hur anfallsmenyn fungerar, hur input ska anges för att korrekt anfalla
            Console.WriteLine("Combat Basics: Attacking - Targeting");
            Console.WriteLine("");
            Console.WriteLine("Enemies: ");
            Console.WriteLine("Skeleton: [0] HP: 5 AP: 1");
            Console.WriteLine("Skeleton: [1] HP: 2 AP: 1");
            Console.WriteLine("Spectre: [2] HP: 15 AP: 3");
            Console.WriteLine("");
            Console.WriteLine("Enter enemy index: ");
            Console.WriteLine("");
            Console.WriteLine("Entering the command correctly will bring you to this screen");
            Console.WriteLine("Here you will enter a enemy index as indicated in the square brackets for example [0], [1]");
            Console.WriteLine("The number entered will decide which enemy you wish to attack");
            Console.WriteLine("If you want to attack the second Skeleton, (who has the least HP remaining of the three) you would enter 1 as the input");
            Console.WriteLine("");
            Console.WriteLine("Enter any input to continue");
            Console.ReadLine();
            Console.Clear();

            //Berättar för spelaren hur utfallet av spelarens anfall avläses
            Console.WriteLine("Combat Basics: Attacking - Attack Outcome");
            Console.WriteLine("");
            Console.WriteLine("Enemies: ");
            Console.WriteLine("Skeleton: [0] HP: 5 AP: 1");
            Console.WriteLine("Skeleton: [1] HP: 2 AP: 1");
            Console.WriteLine("Spectre: [2] HP: 15 AP: 3");
            Console.WriteLine("");
            Console.WriteLine("Enter enemy index: 1");
            Console.WriteLine("You attacked Skeleton [1] for 5 damage");
            Console.WriteLine("Skeleton [1] died");
            Console.WriteLine("");
            Console.WriteLine("This is what a perforormed attack will look like");
            Console.WriteLine("The dmage number will indicate how much damage the attacked enemy suffered");
            Console.WriteLine("If the damage dealt is equal to or greater than their remaining health the Enemy [Index] died message will be displayed");
            Console.WriteLine("");
            Console.WriteLine("Enter any input to continue");
            Console.ReadLine();
            Console.Clear();

            //Informerar om hur combat-loggen (vad fiender gör på sitt drag) avläses 
            Console.WriteLine("Combat Basics: Combat Log");
            Console.WriteLine("");
            Console.WriteLine("Enemy Turn:");
            Console.WriteLine("Skeleton [0] Attacked you for 1 damage");
            Console.WriteLine("Spectre [1] Did not attack");
            Console.WriteLine("");
            Console.WriteLine("After an attack is performed by you it will be the enemies turn");
            Console.WriteLine("The log will only contain the actions of the enemies that are still alive");
            Console.WriteLine("Since Skeleton [1] was defeated earlier it will not be present and the Spectre will assume it's index");
            Console.WriteLine("if an enemy attacks on this turn the damage they deal to you will be displayed");
            Console.WriteLine("if they do not attack the log will display Did not attack");
            Console.WriteLine("");
            Console.WriteLine("Enter any input to contine");
            Console.ReadLine();
            Console.Clear();

            //Skriver ur information angående hur Stats-menyn avläses
            Console.WriteLine("Stats Menu");
            Console.WriteLine("");
            Console.WriteLine("Health: 20");
            Console.WriteLine("Attack Power: 5");
            Console.WriteLine("Mana: 10");
            Console.WriteLine("Defense: 0");
            Console.WriteLine("Turn Points: 5");
            Console.WriteLine("");
            Console.WriteLine("If you entered Stats as indicated in the Actions menu you will be brought to this screen");
            Console.WriteLine("Here you will se the stats of your player such as your remaning health, and mana");
            Console.WriteLine("This action does not progress the timeline");
            Console.WriteLine("");
            Console.WriteLine("Enter any input to continue");
            Console.ReadLine();
            Console.Clear();

            //Skriver ut information för hur Spell-menyn anläses och används
            Console.WriteLine("Advanced Actions: Spells");
            Console.WriteLine("");
            Console.WriteLine("Available spells:");
            Console.WriteLine("Heal (Heals player for 10 hp) [Cost 5 Mana]");
            Console.WriteLine("Smite (Deals 30 damage to a selected enemy) [Cost: 10 Mana]");
            Console.WriteLine("");
            Console.WriteLine("This is the spells menu, here you can perform powerful actions at the expense of Mana");
            Console.WriteLine("Mana is an finite resource that can not be gained so use it wisely");
            Console.WriteLine("The cost of a given spell is indicated in the square brackets");
            Console.WriteLine("A so long as you have enough mana selecting a spell will perform it, with the exception of targeted attack spells");
            Console.WriteLine("Performing a spell does not progress the timeline");
            Console.WriteLine("");
            Console.WriteLine("Enter any input to continue");
            Console.ReadLine();
            Console.Clear();

            //Skriver ut information hur misc menyn avläses och används
            Console.WriteLine("Advanced Actions: Misc");
            Console.WriteLine("");
            Console.WriteLine("Misc Actions: ");
            Console.WriteLine("Defend (Adds 5 defense to the player) [Cost: 3 Turn Points]");
            Console.WriteLine("");
            Console.WriteLine("In this menu you can perform misc actions at the cost of Turn Points");
            Console.WriteLine("These are a temporary resource that replenishes each turn");
            Console.WriteLine("Same as with the spells menu the cost of each action is indicated in the square brackets");
            Console.WriteLine("");
            Console.WriteLine("Enter any input to continue");
            Console.ReadLine();
            Console.Clear();

            //Skriver ut information om Surrender mekaniken
            Console.WriteLine("Surrendering");
            Console.WriteLine("");
            Console.WriteLine("Using the Surrender action in the Actions menu will end the ongoing game right away");
            Console.WriteLine("");
            Console.WriteLine("Enter any input to continue");
            Console.ReadLine();
            Console.Clear();

            //Beskriver hur spelet är uppbygt, hur spelomgångar, rundor or gameover stadier fungerar
            Console.WriteLine("Game pogression");
            Console.WriteLine("");
            Console.WriteLine("A game is made up of rounds, a round ends when one of three conditions are fulfilled: ");
            Console.WriteLine("All enemies are defeated, or the player dies (player health reaches 0 or below) or the player surrender");
            Console.WriteLine("If all enemies are defated a new round can begin, at the start of the round a new set of enemies will be spawned");
            Console.WriteLine("Aditionally all the players resources will be reset to their initial state");
            Console.WriteLine("If the round ends by the player being killed the game is over and a stat file will be created highlighting the player's performance of that game");
            Console.WriteLine("");
            Console.WriteLine("Enter any input to end the tutorial");
            Console.ReadLine();
            Console.Clear();
        }
    }

                                                                                                                                                                                                                                       //Alte Freunde, die Tage gezählt
                                                                                                                                                                                                                                       //Gesichter wie Berge, verwittert und zäh
                                                                                                                                                                                                                                       //Früher zusammen, die Zeit hat's getrennt
                                                                                                                                                                                                                                       //Nur noch Staub im Wind
                                                                                                                                                                                                                                       //Ich hab gesehen, wie es gestern war
                                                                                                                                                                                                                                       //Die Welt wird sich drehen, war schon vor uns da
                                                                                                                                                                                                                                       //Es ist egal, was du tust
                                                                                                                                                                                                                                       //Wir sind Segen und Fluch
                                                                                                                                                                                                                                       //
                                                                                                                                                                                                                                       //Heute endet es – ein letztes Gefecht
                                                                                                                                                                                                                                       //Wie weit kannst du gehen
                                                                                                                                                                                                                                       //Heute endet es - eine letzte Schlacht
                                                                                                                                                                                                                                       //Und dann kommt die Flut
                                                                                                                                                                                                                                       //
                                                                                                                                                                                                                                       //Schmerz ist in dir, faucht wie ein Tier
                                                                                                                                                                                                                                       //Im Käfig aus Gold, will er weg von dir
                                                                                                                                                                                                                                       //Fühlst du es nicht, wie das Eis zerbricht
                                                                                                                                                                                                                                       //Und das Licht verlischt
                                                                                                                                                                                                                                       //Hörst du die Stimmen, in dieser kalten Welt
                                                                                                                                                                                                                                       //Ein Chor der Sinne, das Lied der Ewigkeit
                                                                                                                                                                                                                                       //Bist du bereit, dein letzter Wille stark
                                                                                                                                                                                                                                       //Und der Tag vergeht
                                                                                                                                                                                                                                       //
                                                                                                                                                                                                                                       //Heute endet es – ein letztes Gefecht
                                                                                                                                                                                                                                       //Wie weit kannst du gehen
                                                                                                                                                                                                                                       //Heute endet es - eine letzte Schlacht
                                                                                                                                                                                                                                       //Und dann kommt die Flut
                                                                                                                                                                                                                                       //
                                                                                                                                                                                                                                       //Heute endet es – ein letztes Gefecht
                                                                                                                                                                                                                                       //Wie weit kannst du gehen
                                                                                                                                                                                                                                       //Heute endet es - eine letzte Schlacht
                                                                                                                                                                                                                                       //Und dann kommt die Flut
                                                                                                                                                                                                                                       //Und dann kommt die Flut

                                                                                                                                                                                                                                       //Text till Die Flut - Warkings 
}