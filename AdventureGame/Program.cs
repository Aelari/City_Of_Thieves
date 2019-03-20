using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

// Program: Adventure Game
// Author: Gage Hunter
// Version: 0.4
// Date: 07/03/2019
// Description: An adventure game created as a testing field for C# based on the 'City of Thieves' choose your own adventure novel by Ian Livingstone.

namespace AdventureGame
{
    // Game class contains methods relating to Game functions
    public static class Game
    {
        // Default values for variables
        public static string CharacterName = "Bartholomew Black";
        public static int skill = 0;
        public static int stam = 0;
        public static int luck = 0;
        public static int lScore = 0;
        public static bool lucky = true;
        public static int monStam = 0;
        public static int monSkill = 0;

        // Head method writes game title
        public static void Head()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            // Declare game title in strings
            string title1 = "______________________________________________________________________________________________________";
            string title2 = "│                                                                                                    │";
            string title3 = "│ ▄█▄    ▄█    ▄▄▄▄▀ ▀▄    ▄     ████▄ ▄████         ▄▄▄▄▀ ▄  █ ▄█ ▄███▄      ▄   ▄███▄     ▄▄▄▄▄    │";
            string title4 = "│ █▀ ▀▄  ██ ▀▀▀ █      █  █      █   █ █▀   ▀     ▀▀▀ █   █   █ ██ █▀   ▀      █  █▀   ▀   █     ▀▄  │";
            string title5 = "│ █   ▀  ██     █       ▀█       █   █ █▀▀            █   ██▀▀█ ██ ██▄▄   █     █ ██▄▄   ▄  ▀▀▀▀▄    │";
            string title6 = "│ █▄  ▄▀ ▐█    █        █        ▀████ █             █    █   █ ▐█ █▄   ▄▀ █    █ █▄   ▄▀ ▀▄▄▄▄▀     │";
            string title7 = "│ ▀███▀   ▐   ▀       ▄▀                █           ▀        █   ▐ ▀███▀    █  █  ▀███▀              │";
            string title8 = "│                                        ▀                  ▀                █▐                      │";
            string title9 = "│                                                                            ▐                       │";
            string title0 = "|____________________________________________________________________________________________________|";
            // Write game title strings in centre of the console window
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (title1.Length / 2)) + "}", title1));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (title2.Length / 2)) + "}", title2));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (title3.Length / 2)) + "}", title3));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (title4.Length / 2)) + "}", title4));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (title5.Length / 2)) + "}", title5));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (title6.Length / 2)) + "}", title6));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (title7.Length / 2)) + "}", title7));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (title8.Length / 2)) + "}", title8));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (title9.Length / 2)) + "}", title9));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (title0.Length / 2)) + "}", title0));
            Console.WriteLine(" ");
            Console.ResetColor();
        }

        //keep track of the end width right here (part of WordWrap method)
        static int endWidth = 0;

        // Wrapping funtion to keep lines of text intact. Advice provided by a stack exchange user Kyle Olson.
        public static void WordWrap(string paragraph, int tabSize = 8)
        {
            //were only doing one bit at a time
            string process = paragraph;
            List<String> wrapped = new List<string>();

            //if were going to pass the end
            while (process.Length + endWidth > Console.WindowWidth)
            {
                //reduce the wrapping in the first line by the ending with
                int wrapAt = process.LastIndexOf(' ', Math.Min(Console.WindowWidth - 1 - endWidth, process.Length));

                //if there's no space
                if (wrapAt == -1)
                {
                    //if the next bit won't take up the whole next line
                    if (process.Length < Console.WindowWidth - 1)
                    {
                        //this will give us a new line
                        wrapped.Add("");
                        //reset the width
                        endWidth = 0;
                        //stop looping
                        break;
                    }
                    else
                    {
                        //otherwise just wrap the max possible
                        wrapAt = Console.WindowWidth - 1 - endWidth;
                    }
                }

                //add the next string as normal
                wrapped.Add(process.Substring(0, wrapAt));

                //shorten the process string
                process = process.Remove(0, wrapAt + 1);

                //now reset that to zero for any other line in this group
                endWidth = 0;
            }

            //write a line for each wrapped line
            foreach (string wrap in wrapped)
            {
                foreach (char c in wrap)
                {
                    Console.Write(c);
                    Thread.Sleep(50);
                }

            }

            //don't write line, just write. You can add a new line later if you need it, 
            //but if you do, reset endWidth to zero
            foreach (char c in process)
            {
                Console.Write(c);
                Thread.Sleep(50);
            }

                //endWidth will now be the lenght of the last line.
                //if this didn't go to another line, you need to add the old endWidth
                endWidth = process.Length + endWidth;
        }

        //use this to end a paragraph
        public static void EndParagraph()
        {
            Console.ResetColor();
            Console.WriteLine("\n");
            endWidth = 0;
        }

        // Beginning of game introduction, character naming and rolling of stats
        public static void StartGame()
        {
            Head();
            Thread.Sleep(100);
            WordWrap("The prosperous town of Silverton is being held to ransom by Zanbar Bone and his bloodthirsty Moon Dogs. YOU are an adventurer, and the merchants of Silverton turn to you in their hour of need. Your mission takes you along dark, twisting streets, where thieves, vagabonds and creatures of the night lie in wait to trap the unwary traveller. And beyond lies the most fearsome adventure of them all - the tower stronghold of the infamous Zanbar Bone!");
            Game.EndParagraph();
            Console.WriteLine("\nPress Enter to continue");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
            Head();
            NameCharacter();
            ChooseCharacter();
            Console.WriteLine("\nGood luck " + CharacterName + "!");
            Console.ResetColor();
            Console.ReadKey();
        }

        // Name character method
        static void NameCharacter()
        {
            Head();
            Console.WriteLine("What would you like to be called?");
            CharacterName = Console.ReadLine();
            Console.WriteLine("\nFantastic! Your name is now " + CharacterName + ".");
        }

        // Roll stats method
        static void ChooseCharacter()
        {
            Random rnd = new Random();
            int dice1 = rnd.Next(1, 7);
            int dice2 = rnd.Next(1, 7);
            int dice3 = rnd.Next(1, 7);
            int dice4 = rnd.Next(1, 7);

            skill = dice1 + 6;
            Console.WriteLine("\nYour Skill is: " + skill);

            stam = dice2 + dice3 + 12;
            Console.WriteLine("Your Stamina is: " + stam);

            luck = dice4 + 6;
            Console.WriteLine("Your Luck is: " + luck);
        }

        // Method to test the Characters luck
        public static void testLuck()
        {
            Game.lScore = RandomNumber(1, 7) + RandomNumber(1, 7);

            if (lScore <= luck)
            {
                lucky = true;
            }
            else
            {
                lucky = false;
            }
        }

        // Function to get a random number 
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }

        // Combat function
        public static void Combat()
        {
            int monAS = 10;
            int plAS = 10;
            bool live = true;

            // While loop to continue combat until either player on monster(s) are dead
            while (live == true)
            {
                // Attack scores for MONster and PLayer
                monAS = RandomNumber(1, 7) + RandomNumber(1, 7) + Game.monSkill;
                plAS = RandomNumber(1, 7) + RandomNumber(1, 7) + Game.skill;

                // Print Attack scores
                Console.WriteLine("Your Attack is: " + plAS + "\n");
                Console.WriteLine("Their Attack is: " + monAS + "\n");

                // IF statement to determine who is hit, checks if scores are tied first resulting in neither taking damage
                if (monAS == plAS)
                {
                    Console.WriteLine("Your weapons glance off each other.");
                }
                // If AS is not equal, continue checking values
                else
                {
                    // IF statement checks if player AS is higher
                    if (plAS > monAS)
                    {
                        // Results if player hits
                        Console.WriteLine("You have struck the enemy, would you like to try your luck and inflict a serious wound?");
                        // Player can spend luck to deal extra damage
                        string luck = Console.ReadLine();
                        if (luck == "yes")
                        {
                            // Call method to test players luck
                            testLuck();
                            if (Game.lucky)
                            {
                                Console.WriteLine("You have dealt a serious blow!");
                                Game.monStam = Game.monStam - 4;
                            }
                            else
                            {
                                Console.WriteLine("You have failed to deal extra damage.");
                                Game.monStam = Game.monStam - 2;
                            }
                            // Reduce players luck score by 1 after testing
                            Game.luck--;
                        }
                        // If player does not want to spend luck
                        else
                        {
                            Console.WriteLine("You have landed a hit!");
                            Game.monStam = Game.monStam - 2;
                        }
                    }
                    // If enemy AS is higher
                    else
                    {
                        // Results when enemy hits
                        Console.WriteLine("The enemy is about to hit you, would you like to try your luck and avoid some of the damage?");
                        // Player can reduce damage by spending luck
                        string luck = Console.ReadLine();
                        if (luck == "yes")
                        {
                            testLuck();
                            if (Game.lucky)
                            {
                                Console.WriteLine("You have avoided some of the damage!");
                                Game.stam = Game.stam - 1;
                            }
                            else
                            {
                                Console.WriteLine("You have failed to dodge in time.");
                                Game.stam = Game.stam - 2;
                            }
                            Game.luck--;
                        }
                        else
                        {
                            Console.WriteLine("You have taken a hit!");
                            Game.stam = Game.stam - 2;
                        }
                    }
                }
                // IF statement checks to see if player Stamina hits ZERO
                if (Game.stam <= 0)
                {
                    // Player death when Stamina hits ZERO
                    Console.WriteLine("You have died.");
                    live = false;
                    StartGame();
                }
                // IF statement checks to see if enemy Stamina hits ZERO
                else if (Game.monStam <= 0)
                {
                    // Player wins combat
                    Console.WriteLine("You have slain the monster!");
                    live = false;
                    Game.monSkill = 0;
                    Game.monStam = 0;
                    return;
                }
                // Prints player Stamina, Luck and AS, and monster Stamina and AS
                Console.WriteLine("\nYour Stamina is: " + Game.stam + "\n" + "Your Luck is: " + Game.luck + "\n" + "Your Attack is: " + plAS + "\n" + "The monsters Stamina is: " + Game.monStam + "\n" + "The monsters Attack is: " + monAS);
                Console.ReadLine();
            }
        }

        // Incorrect input
        static void BadInput()
        {
            Console.WriteLine("You must enter a valid option.");
        }

        // All story options listed p1 --> p400. Each option clears the screen and reprints the head.
        public static void p1()
        {
            Game.Head();
            string input = "";
            WordWrap("The walk to Port Blacksand takes you west some fifty miles across plains and over hills; fortunately without any harmful encounters. Eventually you reach the coast and see the high city wall surrounding Port Blacksand and the cluster of buildings projecting into the sea like an ugly black mark. Ships lie anchored in the harbour and smoke rises gently from chimneys. It looks peaceful enough and it is only when the wind changes that you smell the decay in the breeze to remind you of the evil nature of this notorious place. Following the dusty road north along the coast to the city gates, you begin to notice fearful warnings - skulls on wooden spikes, starving men in iron cages suspended from the city wall and black flags everywhere. As you approach the main gate a chill runs down your spine and you instinctively grip the hilt of your broadsword for reassurance. At the gate you are confronted by a tall guard wearing a black chainmail coat and iron helmet. He steps forward, barring the way with his pike, saying, ");
            Game.WordWrap("\"Who would enter Port Blacksand uninvited? State the nature of your business or go back the way you came.\"");
            EndParagraph();
            Console.WriteLine("Will you");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[1] Tell him you wish to be taken to Nicodemus?");
            EndParagraph();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[2] Tell him you wish to sell some stolen booty?");
            EndParagraph();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[3] Attack him quickly with your sword?");
            EndParagraph();

            input = Console.ReadLine();
            if (input == "1")
            {
                p202();
            }
            else if (input == "2")
            {
                p33();
            }
            else if (input == "3")
            {
                p49();
            }
            else
            {
                BadInput();
                p1();
            }
        }

        public static void p2()
        {
            Game.Head();
            string input = "";
            Game.WordWrap("You remove the bracelet from your wrist and toss it at the oncoming monster. It lands on its armour-like shell and sticks to it like glue. You then watch as the bracelet starts to burn its way through the shell into the body of the ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Game.WordWrap("Giant Centipede");
            Console.ResetColor();
            Game.WordWrap(". Smoke rises from the neat round hole and as the bracelet burns deeper you can see from the frantic movements of the ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Game.WordWrap("Centipede ");
            Console.ResetColor();
            Game.WordWrap("that it is in its death throes. Finally it is still and you manage to squeeze yourself between its body and the roof of the tunnel. You walk further down the tunnel, which ends at an iron grill through which the sewerage runs.");
            EndParagraph();
            Console.WriteLine("Do you wish to");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[1] Remove the grill?");
            EndParagraph();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[2] Walk back to the entrance hole?");
            EndParagraph();

            input = Console.ReadLine();
            if (input == "1")
            {
                p377();
            }
            else if (input == "2")
            {
                p174();
            }
            else
            {
                BadInput();
                p2();
            }
        }

        public static void p3()
        {
            Game.Head();
            string input = "";
            WordWrap("The man stops playing and tells you that he can bring you good fortune. For the sum of 3 Gold Pieces he will sing you a song that will bring you luck.");
            EndParagraph();
            Console.WriteLine("Do you wish to");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[1] Pay the musician?");
            EndParagraph();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[2] Walk to the next stall?");
            EndParagraph();

            input = Console.ReadLine();
            if (input == "1")
            {
                p37();
            }
            else if (input == "2")
            {
                p398();
            }
            else
            {
                BadInput();
                p3();
            }
        }

        public static void p4()
        {
            Game.Head();
            string input = "";
            WordWrap("You hear a bell ring on the other side of the door and a few minutes later the door is opened by a thin, pale-skinned man with dark, hollow eyes, who is wearing a servant's uniform. In a cold, hissing voice he says, \"Yes?\"");
            EndParagraph();
            Console.WriteLine("Do you wish to");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[1] Tell him you are a lost traveller?");
            EndParagraph();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[2] Attack him with your sword?");
            EndParagraph();

            input = Console.ReadLine();
            if (input == "1")
            {
                p339();
            }
            else if (input == "2")
            {
                p35();
            }
            else
            {
                BadInput();
                p4();
            }
        }

        public static void p5()
        {
            Game.Head();

            WordWrap("Drawing your sword you leap over the counter to attack the ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            WordWrap("Man-Orc");
            Console.ResetColor();
            WordWrap(", who swiftly grabs his hand-axe. You soon realise that the ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            WordWrap("Man-Orc");
            Console.ResetColor();
            WordWrap(" has used his weapon before.");
            EndParagraph();

            Game.monStam = 5;
            Game.monSkill = 8;
            Game.Combat();
            Console.ReadLine();
            p371();
        }

        public static void p6()
        {
            Game.Head();
            string input = "";
            WordWrap("Her tone becomes unpleasant and she tells you to get out of her house because there are certainly no rags in it, nor any other kind of jumble for that matter.");
            Console.WriteLine("Do you wish to");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[1] Leave the house and continue along Sable Street?");
            EndParagraph();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[2] Go through the curtains to see who is being so rude to you?");
            EndParagraph();

            input = Console.ReadLine();
            if (input == "1")
            {
                p333();
            }
            else if (input == "2")
            {
                p88();
            }
            else
            {
                BadInput();
                p6();
            }
        }

        public static void p7()
        {
            Game.Head();
            string input = "";
            WordWrap("You tiptoe quietly out of the room and close the door.");
            Console.WriteLine("Do you wish to");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[1] Pay the musician?");
            EndParagraph();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[2] Walk to the next stall?");
            EndParagraph();

            input = Console.ReadLine();
            if (input == "1")
            {
                p37();
            }
            else if (input == "2")
            {
                p398();
            }
            else
            {
                BadInput();
                p3();
            }
        }

        public static void p8()
        {
            Game.Head();
            string input = "";
            WordWrap("The man stops playing and tells you that he can bring you good fortune. For the sum of 3 Gold Pieces he will sing you a song that will bring you luck.");
            Console.WriteLine("Do you wish to");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[1] Pay the musician?");
            EndParagraph();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[2] Walk to the next stall?");
            EndParagraph();

            input = Console.ReadLine();
            if (input == "1")
            {
                p37();
            }
            else if (input == "2")
            {
                p398();
            }
            else
            {
                BadInput();
                p3();
            }
        }

        public static void p9()
        {
            Game.Head();
            string input = "";
            WordWrap("The man stops playing and tells you that he can bring you good fortune. For the sum of 3 Gold Pieces he will sing you a song that will bring you luck.");
            Console.WriteLine("Do you wish to");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[1] Pay the musician?");
            EndParagraph();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[2] Walk to the next stall?");
            EndParagraph();

            input = Console.ReadLine();
            if (input == "1")
            {
                p37();
            }
            else if (input == "2")
            {
                p398();
            }
            else
            {
                BadInput();
                p3();
            }
        }

        public static void p10()
        {
            Game.Head();
            string input = "";
            WordWrap("The man stops playing and tells you that he can bring you good fortune. For the sum of 3 Gold Pieces he will sing you a song that will bring you luck.");
            Console.WriteLine("Do you wish to");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[1] Pay the musician?");
            EndParagraph();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[2] Walk to the next stall?");
            EndParagraph();

            input = Console.ReadLine();
            if (input == "1")
            {
                p37();
            }
            else if (input == "2")
            {
                p398();
            }
            else
            {
                BadInput();
                p3();
            }
        }

        public static void p11()
        {
            Game.Head();
            string input = "";
            WordWrap("The man stops playing and tells you that he can bring you good fortune. For the sum of 3 Gold Pieces he will sing you a song that will bring you luck.");
            Console.WriteLine("Do you wish to");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[1] Pay the musician?");
            EndParagraph();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[2] Walk to the next stall?");
            EndParagraph();

            input = Console.ReadLine();
            if (input == "1")
            {
                p37();
            }
            else if (input == "2")
            {
                p398();
            }
            else
            {
                BadInput();
                p3();
            }
        }

        public static void p12()
        {
            Game.Head();
            string input = "";
            WordWrap("The man stops playing and tells you that he can bring you good fortune. For the sum of 3 Gold Pieces he will sing you a song that will bring you luck.");
            Console.WriteLine("Do you wish to");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[1] Pay the musician?");
            EndParagraph();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[2] Walk to the next stall?");
            EndParagraph();

            input = Console.ReadLine();
            if (input == "1")
            {
                p37();
            }
            else if (input == "2")
            {
                p398();
            }
            else
            {
                BadInput();
                p3();
            }
        }

        public static void p13()
        {
            Game.Head();
            string input = "";
            WordWrap("The man stops playing and tells you that he can bring you good fortune. For the sum of 3 Gold Pieces he will sing you a song that will bring you luck.");
            Console.WriteLine("Do you wish to");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[1] Pay the musician?");
            EndParagraph();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[2] Walk to the next stall?");
            EndParagraph();

            input = Console.ReadLine();
            if (input == "1")
            {
                p37();
            }
            else if (input == "2")
            {
                p398();
            }
            else
            {
                BadInput();
                p3();
            }
        }

        public static void p14()
        {
            Game.Head();
            string input = "";
            WordWrap("The man stops playing and tells you that he can bring you good fortune. For the sum of 3 Gold Pieces he will sing you a song that will bring you luck.");
            Console.WriteLine("Do you wish to");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[1] Pay the musician?");
            EndParagraph();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[2] Walk to the next stall?");
            EndParagraph();

            input = Console.ReadLine();
            if (input == "1")
            {
                p37();
            }
            else if (input == "2")
            {
                p398();
            }
            else
            {
                BadInput();
                p3();
            }
        }

        public static void p15()
        {
            Game.Head();
            string input = "";
            WordWrap("The man stops playing and tells you that he can bring you good fortune. For the sum of 3 Gold Pieces he will sing you a song that will bring you luck.");
            Console.WriteLine("Do you wish to");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[1] Pay the musician?");
            EndParagraph();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[2] Walk to the next stall?");
            EndParagraph();

            input = Console.ReadLine();
            if (input == "1")
            {
                p37();
            }
            else if (input == "2")
            {
                p398();
            }
            else
            {
                BadInput();
                p3();
            }
        }

        public static void p16()
        {
            Game.Head();
            string input = "";
            WordWrap("The man stops playing and tells you that he can bring you good fortune. For the sum of 3 Gold Pieces he will sing you a song that will bring you luck.");
            Console.WriteLine("Do you wish to");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[1] Pay the musician?");
            EndParagraph();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[2] Walk to the next stall?");
            EndParagraph();

            input = Console.ReadLine();
            if (input == "1")
            {
                p37();
            }
            else if (input == "2")
            {
                p398();
            }
            else
            {
                BadInput();
                p3();
            }
        }

        public static void p17()
        {
            Game.Head();
            string input = "";
            WordWrap("The man stops playing and tells you that he can bring you good fortune. For the sum of 3 Gold Pieces he will sing you a song that will bring you luck.");
            Console.WriteLine("Do you wish to");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[1] Pay the musician?");
            EndParagraph();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[2] Walk to the next stall?");
            EndParagraph();

            input = Console.ReadLine();
            if (input == "1")
            {
                p37();
            }
            else if (input == "2")
            {
                p398();
            }
            else
            {
                BadInput();
                p3();
            }
        }

        public static void p18()
        {
            Game.Head();
            string input = "";
            WordWrap("The man stops playing and tells you that he can bring you good fortune. For the sum of 3 Gold Pieces he will sing you a song that will bring you luck.");
            Console.WriteLine("Do you wish to");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[1] Pay the musician?");
            EndParagraph();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[2] Walk to the next stall?");
            EndParagraph();

            input = Console.ReadLine();
            if (input == "1")
            {
                p37();
            }
            else if (input == "2")
            {
                p398();
            }
            else
            {
                BadInput();
                p3();
            }
        }

        public static void p19()
        {
            Game.Head();
            string input = "";
            WordWrap("The man stops playing and tells you that he can bring you good fortune. For the sum of 3 Gold Pieces he will sing you a song that will bring you luck.");
            Console.WriteLine("Do you wish to");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[1] Pay the musician?");
            EndParagraph();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[2] Walk to the next stall?");
            EndParagraph();

            input = Console.ReadLine();
            if (input == "1")
            {
                p37();
            }
            else if (input == "2")
            {
                p398();
            }
            else
            {
                BadInput();
                p3();
            }
        }

        public static void p20()
        {
            Game.Head();
            string input = "";
            WordWrap("The man stops playing and tells you that he can bring you good fortune. For the sum of 3 Gold Pieces he will sing you a song that will bring you luck.");
            Console.WriteLine("Do you wish to");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[1] Pay the musician?");
            EndParagraph();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[2] Walk to the next stall?");
            EndParagraph();

            input = Console.ReadLine();
            if (input == "1")
            {
                p37();
            }
            else if (input == "2")
            {
                p398();
            }
            else
            {
                BadInput();
                p3();
            }
        }

        public static void p21()
        {
            Game.Head();
            string input = "";
            WordWrap("The man stops playing and tells you that he can bring you good fortune. For the sum of 3 Gold Pieces he will sing you a song that will bring you luck.");
            Console.WriteLine("Do you wish to");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[1] Pay the musician?");
            EndParagraph();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[2] Walk to the next stall?");
            EndParagraph();

            input = Console.ReadLine();
            if (input == "1")
            {
                p37();
            }
            else if (input == "2")
            {
                p398();
            }
            else
            {
                BadInput();
                p3();
            }
        }

        public static void p22()
        {
            Game.Head();
            string input = "";
            WordWrap("The man stops playing and tells you that he can bring you good fortune. For the sum of 3 Gold Pieces he will sing you a song that will bring you luck.");
            Console.WriteLine("Do you wish to");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[1] Pay the musician?");
            EndParagraph();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[2] Walk to the next stall?");
            EndParagraph();

            input = Console.ReadLine();
            if (input == "1")
            {
                p37();
            }
            else if (input == "2")
            {
                p398();
            }
            else
            {
                BadInput();
                p3();
            }
        }

        public static void p23()
        {
            Game.Head();
            string input = "";
            WordWrap("The man stops playing and tells you that he can bring you good fortune. For the sum of 3 Gold Pieces he will sing you a song that will bring you luck.");
            Console.WriteLine("Do you wish to");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[1] Pay the musician?");
            EndParagraph();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[2] Walk to the next stall?");
            EndParagraph();

            input = Console.ReadLine();
            if (input == "1")
            {
                p37();
            }
            else if (input == "2")
            {
                p398();
            }
            else
            {
                BadInput();
                p3();
            }
        }

        public static void p24()
        {
            Game.Head();
            string input = "";
            WordWrap("The man stops playing and tells you that he can bring you good fortune. For the sum of 3 Gold Pieces he will sing you a song that will bring you luck.");
            Console.WriteLine("Do you wish to");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[1] Pay the musician?");
            EndParagraph();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[2] Walk to the next stall?");
            EndParagraph();

            input = Console.ReadLine();
            if (input == "1")
            {
                p37();
            }
            else if (input == "2")
            {
                p398();
            }
            else
            {
                BadInput();
                p3();
            }
        }

        public static void p25()
        {
            Game.Head();
            string input = "";
            WordWrap("The man stops playing and tells you that he can bring you good fortune. For the sum of 3 Gold Pieces he will sing you a song that will bring you luck.");
            Console.WriteLine("Do you wish to");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[1] Pay the musician?");
            EndParagraph();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[2] Walk to the next stall?");
            EndParagraph();

            input = Console.ReadLine();
            if (input == "1")
            {
                p37();
            }
            else if (input == "2")
            {
                p398();
            }
            else
            {
                BadInput();
                p3();
            }
        }

        public static void p26()
        {

        }

        public static void p27()
        {

        }

        public static void p28()
        {

        }

        public static void p29()
        {

        }

        public static void p30()
        {

        }

        public static void p31()
        {

        }

        public static void p32()
        {

        }

        public static void p33()
        {

        }

        public static void p34()
        {

        }

        public static void p35()
        {

        }

        public static void p36()
        {

        }

        public static void p37()
        {

        }

        public static void p38()
        {

        }

        public static void p39()
        {

        }

        public static void p40()
        {

        }

        public static void p41()
        {

        }

        public static void p42()
        {

        }

        public static void p43()
        {

        }

        public static void p44()
        {

        }

        public static void p45()
        {

        }

        public static void p46()
        {

        }

        public static void p47()
        {

        }

        public static void p48()
        {

        }

        public static void p49()
        {

        }

        public static void p50()
        {
            
        }

        public static void p51()
        {
            
        }

        public static void p52()
        {

        }

        public static void p53()
        {

        }

        public static void p54()
        {

        }

        public static void p55()
        {

        }

        public static void p56()
        {

        }

        public static void p57()
        {

        }

        public static void p58()
        {

        }

        public static void p59()
        {

        }

        public static void p60()
        {

        }

        public static void p61()
        {

        }

        public static void p62()
        {

        }

        public static void p63()
        {

        }

        public static void p64()
        {

        }

        public static void p65()
        {

        }

        public static void p66()
        {

        }

        public static void p67()
        {

        }

        public static void p68()
        {

        }

        public static void p69()
        {

        }

        public static void p70()
        {

        }

        public static void p71()
        {

        }

        public static void p72()
        {

        }

        public static void p73()
        {

        }

        public static void p74()
        {

        }

        public static void p75()
        {

        }

        public static void p76()
        {

        }

        public static void p77()
        {

        }

        public static void p78()
        {

        }

        public static void p79()
        {

        }

        public static void p80()
        {

        }

        public static void p81()
        {

        }

        public static void p82()
        {

        }

        public static void p83()
        {

        }

        public static void p84()
        {

        }

        public static void p85()
        {

        }

        public static void p86()
        {

        }

        public static void p87()
        {

        }

        public static void p88()
        {

        }

        public static void p89()
        {

        }

        public static void p90()
        {

        }

        public static void p91()
        {

        }

        public static void p92()
        {

        }

        public static void p93()
        {

        }

        public static void p94()
        {

        }

        public static void p95()
        {

        }

        public static void p96()
        {

        }

        public static void p97()
        {

        }

        public static void p98()
        {

        }

        public static void p99()
        {

        }

        public static void p100()
        {

        }

        public static void p101()
        {
            
        }

        public static void p102()
        {

        }

        public static void p103()
        {

        }

        public static void p104()
        {

        }

        public static void p105()
        {

        }

        public static void p106()
        {

        }

        public static void p107()
        {

        }

        public static void p108()
        {

        }

        public static void p109()
        {

        }

        public static void p110()
        {

        }

        public static void p111()
        {

        }

        public static void p112()
        {

        }

        public static void p113()
        {

        }

        public static void p114()
        {

        }

        public static void p115()
        {

        }

        public static void p116()
        {

        }

        public static void p117()
        {

        }

        public static void p118()
        {

        }

        public static void p119()
        {

        }

        public static void p120()
        {

        }

        public static void p121()
        {

        }

        public static void p122()
        {

        }

        public static void p123()
        {

        }

        public static void p124()
        {

        }

        public static void p125()
        {

        }

        public static void p126()
        {

        }

        public static void p127()
        {

        }

        public static void p128()
        {

        }

        public static void p129()
        {

        }

        public static void p130()
        {

        }

        public static void p131()
        {

        }

        public static void p132()
        {

        }

        public static void p133()
        {

        }

        public static void p134()
        {

        }

        public static void p135()
        {

        }

        public static void p136()
        {

        }

        public static void p137()
        {

        }

        public static void p138()
        {

        }

        public static void p139()
        {

        }

        public static void p140()
        {

        }

        public static void p141()
        {

        }

        public static void p142()
        {

        }

        public static void p143()
        {

        }

        public static void p144()
        {

        }

        public static void p145()
        {

        }

        public static void p146()
        {

        }

        public static void p147()
        {

        }

        public static void p148()
        {

        }

        public static void p149()
        {

        }

        public static void p150()
        {

        }

        public static void p151()
        {
            
        }

        public static void p152()
        {

        }

        public static void p153()
        {

        }

        public static void p154()
        {

        }

        public static void p155()
        {

        }

        public static void p156()
        {

        }

        public static void p157()
        {

        }

        public static void p158()
        {

        }

        public static void p159()
        {

        }

        public static void p160()
        {

        }

        public static void p161()
        {

        }

        public static void p162()
        {

        }

        public static void p163()
        {

        }

        public static void p164()
        {

        }

        public static void p165()
        {

        }

        public static void p166()
        {

        }

        public static void p167()
        {

        }

        public static void p168()
        {

        }

        public static void p169()
        {

        }

        public static void p170()
        {

        }

        public static void p171()
        {

        }

        public static void p172()
        {

        }

        public static void p173()
        {

        }

        public static void p174()
        {

        }

        public static void p175()
        {

        }

        public static void p176()
        {

        }

        public static void p177()
        {

        }

        public static void p178()
        {

        }

        public static void p179()
        {

        }

        public static void p180()
        {

        }

        public static void p181()
        {

        }

        public static void p182()
        {

        }

        public static void p183()
        {

        }

        public static void p184()
        {

        }

        public static void p185()
        {

        }

        public static void p186()
        {

        }

        public static void p187()
        {

        }

        public static void p188()
        {

        }

        public static void p189()
        {

        }

        public static void p190()
        {

        }

        public static void p191()
        {

        }

        public static void p192()
        {

        }

        public static void p193()
        {

        }

        public static void p194()
        {

        }

        public static void p195()
        {

        }

        public static void p196()
        {

        }

        public static void p197()
        {

        }

        public static void p198()
        {

        }

        public static void p199()
        {

        }

        public static void p200()
        {

        }

        public static void p201()
        {
            
        }

        public static void p202()
        {
            Game.Head();
            string input = "";
            Game.WordWrap("The guard replies that he will send for an escort to take you to ");
            Console.ForegroundColor = ConsoleColor.Green;
            Game.WordWrap("Nicodemus");
            Console.ResetColor();
            Game.WordWrap(". He reaches up to a small bell on the wall of the guardhouse and rings it three times. Almost immediately two other guards come running out of the house, and you are surprised when they each grab hold of one of your arms. The guard with the pike looks up at the sky and laughs, saying, ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Game.WordWrap("\"So you want to see Nicodemus, do you? How would you like to see the inside of a dungeon cell instead? Guards, take this fool away to be shackled, and throw away the key.\"");
            EndParagraph();
            Console.WriteLine("Will you");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[1] Allow yourself to be taken away?");
            EndParagraph();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[2] Attempt to fight the guards?");
            EndParagraph();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Game.WordWrap("[3] Try to bribe the guards?");
            EndParagraph();

            input = Console.ReadLine();
            if (input == "1")
            {
                p151();
            }
            else if (input == "2")
            {
                p69();
            }
            else if (input == "3")
            {
                p276();
            }
            else
            {
                BadInput();
                p202();
            }
        }

        public static void p203()
        {

        }

        public static void p204()
        {

        }

        public static void p205()
        {

        }

        public static void p206()
        {

        }

        public static void p207()
        {

        }

        public static void p208()
        {

        }

        public static void p209()
        {

        }

        public static void p210()
        {

        }

        public static void p211()
        {

        }

        public static void p212()
        {

        }

        public static void p213()
        {

        }

        public static void p214()
        {

        }

        public static void p215()
        {

        }

        public static void p216()
        {

        }

        public static void p217()
        {

        }

        public static void p218()
        {

        }

        public static void p219()
        {

        }

        public static void p220()
        {

        }

        public static void p221()
        {

        }

        public static void p222()
        {

        }

        public static void p223()
        {

        }

        public static void p224()
        {

        }

        public static void p225()
        {

        }

        public static void p226()
        {

        }

        public static void p227()
        {

        }

        public static void p228()
        {

        }

        public static void p229()
        {

        }

        public static void p230()
        {

        }

        public static void p231()
        {

        }

        public static void p232()
        {

        }

        public static void p233()
        {

        }

        public static void p234()
        {

        }

        public static void p235()
        {

        }

        public static void p236()
        {

        }

        public static void p237()
        {

        }

        public static void p238()
        {

        }

        public static void p239()
        {

        }

        public static void p240()
        {

        }

        public static void p241()
        {

        }

        public static void p242()
        {

        }

        public static void p243()
        {

        }

        public static void p244()
        {

        }

        public static void p245()
        {

        }

        public static void p246()
        {

        }

        public static void p247()
        {

        }

        public static void p248()
        {

        }

        public static void p249()
        {

        }

        public static void p250()
        {

        }

        public static void p251()
        {
            
        }

        public static void p252()
        {

        }

        public static void p253()
        {

        }

        public static void p254()
        {

        }

        public static void p255()
        {

        }

        public static void p256()
        {

        }

        public static void p257()
        {

        }

        public static void p258()
        {

        }

        public static void p259()
        {

        }

        public static void p260()
        {

        }

        public static void p261()
        {

        }

        public static void p262()
        {

        }

        public static void p263()
        {

        }

        public static void p264()
        {

        }

        public static void p265()
        {

        }

        public static void p266()
        {

        }

        public static void p267()
        {

        }

        public static void p268()
        {

        }

        public static void p269()
        {

        }

        public static void p270()
        {

        }

        public static void p271()
        {

        }

        public static void p272()
        {

        }

        public static void p273()
        {

        }

        public static void p274()
        {

        }

        public static void p275()
        {

        }

        public static void p276()
        {

        }

        public static void p277()
        {

        }

        public static void p278()
        {

        }

        public static void p279()
        {

        }

        public static void p280()
        {

        }

        public static void p281()
        {

        }

        public static void p282()
        {

        }

        public static void p283()
        {

        }

        public static void p284()
        {

        }

        public static void p285()
        {

        }

        public static void p286()
        {

        }

        public static void p287()
        {

        }

        public static void p288()
        {

        }

        public static void p289()
        {

        }

        public static void p290()
        {

        }

        public static void p291()
        {

        }

        public static void p292()
        {

        }

        public static void p293()
        {

        }

        public static void p294()
        {

        }

        public static void p295()
        {

        }

        public static void p296()
        {

        }

        public static void p297()
        {

        }

        public static void p298()
        {

        }

        public static void p299()
        {

        }

        public static void p300()
        {

        }

        public static void p301()
        {
            
        }

        public static void p302()
        {

        }

        public static void p303()
        {

        }

        public static void p304()
        {

        }

        public static void p305()
        {

        }

        public static void p306()
        {

        }

        public static void p307()
        {

        }

        public static void p308()
        {

        }

        public static void p309()
        {

        }

        public static void p310()
        {

        }

        public static void p311()
        {

        }

        public static void p312()
        {

        }

        public static void p313()
        {

        }

        public static void p314()
        {

        }

        public static void p315()
        {

        }

        public static void p316()
        {

        }

        public static void p317()
        {

        }

        public static void p318()
        {

        }

        public static void p319()
        {

        }

        public static void p320()
        {

        }

        public static void p321()
        {

        }

        public static void p322()
        {

        }

        public static void p323()
        {

        }

        public static void p324()
        {

        }

        public static void p325()
        {

        }

        public static void p326()
        {

        }

        public static void p327()
        {

        }

        public static void p328()
        {

        }

        public static void p329()
        {

        }

        public static void p330()
        {

        }

        public static void p331()
        {

        }

        public static void p332()
        {

        }

        public static void p333()
        {

        }

        public static void p334()
        {

        }

        public static void p335()
        {

        }

        public static void p336()
        {

        }

        public static void p337()
        {

        }

        public static void p338()
        {

        }

        public static void p339()
        {

        }

        public static void p340()
        {

        }

        public static void p341()
        {

        }

        public static void p342()
        {

        }

        public static void p343()
        {

        }

        public static void p344()
        {

        }

        public static void p345()
        {

        }

        public static void p346()
        {

        }

        public static void p347()
        {

        }

        public static void p348()
        {

        }

        public static void p349()
        {

        }

        public static void p350()
        {

        }

        public static void p351()
        {
            
        }

        public static void p352()
        {

        }

        public static void p353()
        {

        }

        public static void p354()
        {

        }

        public static void p355()
        {

        }

        public static void p356()
        {

        }

        public static void p357()
        {

        }

        public static void p358()
        {

        }

        public static void p359()
        {

        }

        public static void p360()
        {

        }

        public static void p361()
        {

        }

        public static void p362()
        {

        }

        public static void p363()
        {

        }

        public static void p364()
        {

        }

        public static void p365()
        {

        }

        public static void p366()
        {

        }

        public static void p367()
        {

        }

        public static void p368()
        {

        }

        public static void p369()
        {

        }

        public static void p370()
        {

        }

        public static void p371()
        {

        }

        public static void p372()
        {

        }

        public static void p373()
        {

        }

        public static void p374()
        {

        }

        public static void p375()
        {

        }

        public static void p376()
        {

        }

        public static void p377()
        {

        }

        public static void p378()
        {

        }

        public static void p379()
        {

        }

        public static void p380()
        {

        }

        public static void p381()
        {

        }

        public static void p382()
        {

        }

        public static void p383()
        {

        }

        public static void p384()
        {

        }

        public static void p385()
        {

        }

        public static void p386()
        {

        }

        public static void p387()
        {

        }

        public static void p388()
        {

        }

        public static void p389()
        {

        }

        public static void p390()
        {

        }

        public static void p391()
        {

        }

        public static void p392()
        {

        }

        public static void p393()
        {

        }

        public static void p394()
        {

        }

        public static void p395()
        {

        }

        public static void p396()
        {

        }

        public static void p397()
        {

        }

        public static void p398()
        {

        }

        public static void p399()
        {

        }

        public static void p400()
        {

        }
    }

    // Item class stores what items are collected in game
    class Item
    {

    }

    // Program class initiates game, continues introduction and sets window size and other initial values.
    class Program
    {
        // Window size to full screen (Unsure of specifics as code is not mine originally).
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;

        // Main method is the game code itself, also includes one part of the code to set window size and title
        static void Main()
        {
            // Window settings (title and size)
            Console.Title = "City of Thieves - A Fighting Fantasy adventure!";
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);

            // Game start
            Game.StartGame();
            Game.Head();
            Game.WordWrap("You are an adventurer in a world full of monsters and magic, living by quickness of wit and skill of sword. You earn gold as a hired warrior, usually in the employ of rich nobles and barons on missions too dangerous or difficult for their own men. Slaying monsters and fearsome beasts in pursuit of some fabled treasure comes as second nature to you. Being an experienced and highly trained swordsman, you allow nothing to stand in your way on your quests. Your success on a mission is always assured and your reputation has spread throughout the lands. Whenever you enter a village or town, the news of your arrival spreads through the citizens like wildfire, as few of them have ever met a dragon-slayer before.");
            Game.EndParagraph();
            // Each paragraph is printed with a pause between
            Thread.Sleep(1000);

            Game.WordWrap("One evening, after a long walk through the outlands, you arrive at Silverton, which lies at the crossroads of the main trading routes in these parts. Great wooden wagons hauled by teams of oxen are often seen rumbling slowly through the town laden with herbs, spices, silks, metalware and exotic foods from far off lands.");
            Game.EndParagraph();
            Thread.Sleep(1000);

            Game.WordWrap("Over the years Silverton has prospered as a result of the rich merchants and traders stopping there en route to distant markets. Its wealth is quite apparent, with ornate buildings and richly dressed people aplenty. But as you enter the town gates, something strikes you as being not quite right. The people look nervous and on edge. Then you notice that all the windows on the buildings have great iron grills bolted over them and the doors have been strengthened too. Although you prefer your own company to that of others, you decide to stay in Silverton for the night to find out who or what is troubling the people.");
            Game.EndParagraph();
            // To improve readability, paragraphs are not printed all at once. To continue to the next page Enter must be pressed.
            Console.WriteLine("\nPress Enter to continue");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }

            Game.Head();
            Game.WordWrap("As you walk down the main street, a single note from a bell rings out from a tall tower ahead. Then a man shouts, almost deperately. ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Game.WordWrap("\"Nightfall! Nightfall! Everyone indoors!\"");
            Console.ResetColor();
            Game.WordWrap("You see people scurrying around with anxious faces, and looking surprised when they see you. Across the street you see a tavern with the words \'The Old Toad\' painted on its signboard. As you enter the tavern, a whisper runs through the locals as they recognize you - some put down their mugs and stare. You are somewhat surprised that none come over to you to hear tales of adventure. Walking over to the counter you ask the old innkeeper for a room and a hot tub, but he ignores you and shuffles over to the great oak door, pushing six large iron bolts into place. Only then does he turn to you and say quietly, ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Game.WordWrap("\"That will be 5 copper pieces for the room and one more for the tub, in advance if you please.\"");
            Console.ResetColor();
            Game.WordWrap("You reach into a leather pouch on your belt and toss the coins on the counter. He hands you an iron key, but at that very moment there is a loud knocking at the door followed by a voice shouting, ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Game.WordWrap("\"Open up! Open up! This is Owen Carralif.\"");
            Console.ResetColor();
            Game.WordWrap("The old innkeeper shuffles over to the oak door again and slides open the bolts. Then a fat and balding man dressed in rich scarlet robes bursts into the tavern, looking around frantically. He sees you and walks quickly in your direction, huffing and puffing. He is a man certainly not used to haste - you notice great beads of sweat on his forehead in the pale candlelight of the room. As he nears you, he calls out urgently, ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Game.WordWrap("\"");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Game.WordWrap(Game.CharacterName);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Game.WordWrap(", I must speak with you. Please sit down. It is important that I speak with you.\"");
            Game.EndParagraph();
            Thread.Sleep(1000);

            Game.WordWrap("When he turns to the innkeeper to snap his fingers for food and drink, you can see that he is obviously of some standing in the town, but his face is full of anguish and sorrow. Being curious, you decide to hear what the man has to say. He pulls out a chair for you at the table, bidding you to sit down and the innkeeper bustles in with a tray laden with hot broth, roast geese and mead. The man in the scarlet robes sits opposite in silence, watching you as you feast as though examining you for some purpose of his own. Finally as you push your plate away, the man leans forward and says, in a low but anxious voice, ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Game.WordWrap("\"");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Game.WordWrap(Game.CharacterName);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Game.WordWrap(", I know of you and seek your aid. My name is Owen Carralif and I am the mayor of Silverton. We are in great trouble and danger. We are living under a curse and it is I who must rid us of it. Ten days ago two messengers of evil rode into town on huge black stallions. Stallions with fiery red eyes! It was impossible to see the faces of the riders for they wore long black cloaks with hoods pulled over their faces. Their voices were cold and each word spoken ended with an unnerving hiss. They asked for me by name and when I came to greet them, they wanted to take my beloved daughter Mirelle to stay with their master, ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Game.WordWrap("Zanbar Bone");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Game.WordWrap("! No doubt you know that he is the Night Prince. Of course I refused their demand and without another word they turned and rode slowly out of the town, heads down and shoulders hunched. I knew then that beneath the cloaks were hidden the skeletal and soulless bodies of Spirit Stalkers. ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Game.WordWrap("Zanbar Bone");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Game.WordWrap(" always uses them as messengers as they will complete their mission or die in the attempt - and they do not die easily. Only a silver arrow through the heart will release those evil beings from their eternal twilight existence. Who knows what it would take to kill ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Game.WordWrap("Zanbar Bone");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Game.WordWrap("! Anyway, that same night after the Spirit Stalkers left, our troubles began. The Night Prince was angry and determined to harm us. Six Moon Dogs came, each stronger than four men, each with razor-sharp fangs. They stalked through the town, entering homes through open windows, and killing the poor people inside.\"");
            Game.EndParagraph();
            Console.WriteLine("\nPress Enter to continue");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }

            Game.Head();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Game.WordWrap("\"In the morning we counted twenty-three dead. So we barred our windows and bolted our doors, yet each night the Moon Dogs return and we are unable to sleep for fear that they might find a way into our homes. Some people are now talking of sending Mirelle to ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Game.WordWrap("Zanbar Bone");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Game.WordWrap(". Those whimpering traitors, I should have them flogged! But what good would that do? There is but one hope and that rests with you, ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Game.WordWrap(Game.CharacterName);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Game.WordWrap(". There is a man called ");
            Console.ForegroundColor = ConsoleColor.Green;
            Game.WordWrap("Nicodemus ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Game.WordWrap("who, for reasons I\'ll never understand, lives in ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Game.WordWrap("Port Blacksand");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Game.WordWrap(". The place is commonly called the City of Thieves as it is the home of every pirate, brigand, assassin, thief and evil-doer for hundreds of miles around. I think he lives there just to get some peace from the likes of us. He is a wise old wizard and is unlikely to come to much harm even in ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Game.WordWrap("Port Blacksand");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Game.WordWrap(", for his magical powers are great. He alone is capable of defeating ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Game.WordWrap("Zanbar Bone");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Game.WordWrap(". He used to be a friend of mine many years ago. We need him and I beg you to bring him to us - none here dares enter ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Game.WordWrap("Port Blacksand");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Game.WordWrap(". You will be well rewarded if you help us, ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Game.WordWrap(Game.CharacterName);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Game.WordWrap(". Take these 30 Gold Pieces for your journey, and take this sword to use and keep.\"");
            Game.EndParagraph();
            Thread.Sleep(1000);

            Game.WordWrap("As Owen Carralif rises, he pulles back his scarlet robe, revealing the finest broadsword you have ever seen. He hands it to you and, touching the edge of the blade, you are surprised to see a droplet of blood fall from your finger. You then examine the marvelously ornate gilded serpents twining round the hilt. You have never wanted anything so badly in your life before. You stand up and hold out your right arm to Owen. He shakes it eagerly, saying, ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Game.WordWrap("\"You must set off at the first light of dawn - the Moon Dogs will be gone by then. I shall be forced to stay the night here also, so let\'s drink to our destiny and may the gods be with us.\"");
            Game.EndParagraph();
            Thread.Sleep(1000);

            Game.WordWrap("For the next hour Owen talks about your upcoming journey, explaining in detail how to reach ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Game.WordWrap("Port Blacksand");
            Console.ResetColor();
            Game.WordWrap(". Later you gather up your backpack and furs and climb the wooden steps to your room. You sleep uneasily despite the security afforded by your new broadsword as you are more than once woken by the sniffing, scratching and howling of the Moon Dogs outside. By dawn, you are already awake and dressed, and determined to reach ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Game.WordWrap("Port Blacksand");
            Console.ResetColor();
            Game.WordWrap(" quickly to find this man ");
            Console.ForegroundColor = ConsoleColor.Green;
            Game.WordWrap("Nicodemus");
            Console.ResetColor();
            Game.WordWrap(". As you leave the tavern, a black cat scurries past your feet and you almost trip; a bad omen perhaps?");
            Game.EndParagraph();
            Console.WriteLine("\nPress Enter to continue");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }

            // Beginning of player interaction with the story.
            Game.p1();
        }
    }
}
