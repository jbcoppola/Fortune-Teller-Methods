using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week1project
{
	class Program
	{
		static void Main(string[] args)
		{
			string input = "";
			bool endQuit = false;

			string[] questionArray =
				{
					"Enter your first name.",
					"Enter your last name.",
					"Enter your age.",
					"Enter your birthmonth as a digit (1-12)",
					"Enter a ROYGBIV color, or two colors seperated by a space (type 'help' if you do not know what ROYGBIV is)",
					"Enter how many siblings you have."
				};

			while (input != "quit" && endQuit == false)
			{
			//for the "restart" goto
			Start:
				Console.WriteLine("Welcome to the Fortune Teller. Type \"quit\" to quit, or \"restart\" to restart.");

				string firstName = "";
				string lastName = "";
				int age = 0;
				int birthMonth = 0;
				int siblings = 0;
				string[] color = { "", "" };

				//since all the inputs are different data types we can't just put them in an array, leading to the ugly solution
				//of an if followed by a switch within the loop for each question

				//asks each question, then assigns it to the appropriate variable
				for (int i = 0; i < questionArray.Length; i++)
				{
					input = Program.Question(questionArray[i]);
					if (input.ToLower() == "quit")
					{
						//the only way to get out of the while loop without repeating a ton of code I could find
						goto Finish; //after the while loop
					}
					else if (input.ToLower() == "restart")
					{
						goto Start; //top of the while loop
					}
					else if (i == 4 && input.ToLower() == "help")
					{
						Console.WriteLine("ROYGBIV is the color spectrum. It consists of:\n\n" +
										"Red\nOrange\nYellow\nGreen\nBlue\nIndigo\nViolet\n\n" +
										"Type your favorite one or two of these colors.");

						input = Console.ReadLine();
					}

					switch (i)
					{
						case 0:
							firstName = input;
							break;
						case 1:
							lastName = input;
							Greeter(firstName, lastName);
							break;
						case 2:
							age = int.Parse(input);
							break;
						case 3:
							birthMonth = int.Parse(input);
							break;
						case 4:
							color = input.Split(' ');
							break;
						case 5:
							siblings = int.Parse(input);
							break;
						default:
							break;
					}
				}

				//these four methods could technically all be type void by writing to Console.Writeline instead of
				//returning a value, in which case they would simply be called in the writeline statement below.
				//however, this would severely reduce readability
				int retire = CalculateRetirement(age);
				double bankCash = CalclulateCash(birthMonth);
				string vacationHome = CalculateVacationHome(siblings);
				string favoriteVehicle = "";
				if (color[1] == "")
				{
					favoriteVehicle = CalculateVehicle(color[0]);
				}
				else
				{
					favoriteVehicle = CalculateVehicle(color[0], color[1]);
				}
				Console.WriteLine(firstName + ' ' + lastName + " will retire in " + retire + " years with $" + bankCash + " in the bank, " +
									"a vacation home in " + vacationHome + " and a " + favoriteVehicle + '.');
				FortuneJudger();
				endQuit = true;
			}
			//for the "quit" goto
			Finish:

			if (input.ToLower() == "quit")
			{
				Console.WriteLine("Nobody likes a quitter...");
			}
		}

		//the method for asking a question and returning a string answer
		static string Question(string question)
		{
			Console.WriteLine(question);
			string value = Console.ReadLine();
			return value;
		}

		static string Greeter(string firstName, string lastName)
		{
			string text = "Greetings, " + firstName + ' ' + lastName + ". I will tell you your fortune!";
			return text;
		}

		static int CalculateRetirement(int age)
		{
			int retire;
			if (age % 2 == 0)
			{
				retire = 40;
			}
			else
			{
				retire = 30;
			}
			return retire;
		}

		static string CalculateVacationHome(int siblings)
		{
			string vacationHome;
			if (siblings == 0)
			{
				vacationHome = "Las Vegas";
			}
			else if (siblings == 1)
			{
				vacationHome = "Cancun";
			}
			else if (siblings == 2)
			{
				vacationHome = "Australia";
			}
			else if (siblings == 3)
			{
				vacationHome = "France";
			}
			else if (siblings > 3)
			{
				vacationHome = "Jamaica";
			}
			else
			{
				vacationHome = "Antarctica";
			}
			return vacationHome;
		}

		static double CalclulateCash(int birthMonth)
		{
			double bankCash;
			if (birthMonth > 0 && birthMonth < 13)
			{
				if (birthMonth > 8)
				{
					bankCash = 100000.00;
				}
				else if (birthMonth > 4)
				{
					bankCash = 80000.00;
				}
				else
				{
					bankCash = 60000.00;
				}
			}
			else
			{
				bankCash = 0.00;
			}
			return bankCash;
		}

		//prints one of 6 random fortunes
		static void FortuneJudger()
		{
			Random rand = new Random();
			int check = rand.Next(6);
			string text = "";
			switch (check)
			{
				case 0:
					text = "How odd, it didn't mention your nosejob even once. You haven't had one? Oops...";
					break;
				case 1:
					text = "Oh dear. I'd stock up on your life insurance, if I were you. Thank god I'm not.";
					break;
				case 2:
					text = "I've seen this kind of fortune before. Don't worry, she lived. Kind of.";
					break;
				case 3:
					text = "I see. The next two weeks will be critical. Avoid double stuff oreos, elevators, and anyone named \"Clyde\".";
					break;
				case 4:
					text = "Luck is on your side. You will become irresistably attractive to any and all solicitors for the next four months.";
					break;
				case 5:
					text = "Your fortune...hm. Let me use an analogy. Imagine a lightning rod.";
					break;
				default:
					break;
			}
			Console.WriteLine(text);
		}

		static string CalculateVehicle(string color)
		{
			string vehicle;
			switch (color.ToLower())
			{
				case "red":
					vehicle = "WW2 tank with live ammunition";
					break;
				case "orange":
					vehicle = "steam train retrofitted with car tires";
					break;
				case "yellow":
					vehicle = "very small and improprietously painted submarine";
					break;
				case "green":
					vehicle = "blimp emblazoned with logo for the short-lived 1939 comedy troupe \"Axison Allies\"";
					break;
				case "blue":
					vehicle = "pirate ship loaded with stolen Spanish silver. Avast";
					break;
				case "indigo":
					vehicle = "featureless chrome orb that hovers ominiously over the road";
					break;
				case "violet":
					vehicle = "purple Mini Cooper with wood siding";
					break;
				default:
					vehicle = "squeaky shopping cart";
					break;
			}
			return vehicle;
		}

		static string CalculateVehicle(string color1, string color2)
		{
			color1.ToLower();
			color2.ToLower();
			int num = 49;

			string[] vehicles =
			{
				"firetruck with a medieval siege catapult bolted to the extending ladder slot",
				"several hundred stuffed animals wired together around a car frame and naked engine",
				"chinese truck that compresses to the size of a suitcase if it gets into an accident",
				"oil tanker filled with french fry grease",
				"ethereal monorail of light. Costs 3.99 per ride",
				"live 30 foot alligator trained to carry passengers",
				"bright pink steamroller",
				"motorcycle with a flaming, screaming skull fused to the wheelcase",
				"broken time machine filled with empty food containers from 2399",
				"laser pointer promotional car with rechargable gyroscopic\"sun beam\"",
				"plastic human-sized hamster ball",
				"treadmill on wheels",
				"golf cart equipped with a racing engine",
				"\"Blender,\" famous for seperating crash test dummies into 92 component pieces",
				"Mini Cooper with monster truck tires",
				"Ferrari with completely transparent frame and chassis",
				"assembly kit Build-A-Car",
				"knockoff popemobile (comes with excommunicated bishop)",
				"ice cream truck with its jingle replaced with Gregorian chanting",
				"horse drawn carriage in the shape of a pumpkin (return before midnight)",
				"non-Euclidean LoveCraft which moves without seeming to occupy any one particular space at any time",
				"giant tarantula robot",
				"limousine made of human bones",
				"family sedan with every machine noise replaced with a human voice approximation",
				"fully automated car with malevolent AI trapped inside",
				"hot air balloon filled with hydrogen",
				"serpentine junk heap animated by the will of Quetzalcoatl",
				"nuclear powered 1950s \"Car of the future.\" Don't crash!",
				"magic carpet bought from Sears",
				"stolen hotel luggage cart (it's complimentary!)",
				"giant amoeba with enzyme controls in the center",
				"CGI war elephant from the set of \"300\"",
				"whaling schooner currently being hunted for crimes against whaledom",
				"lunar rover used in 1969 (you have to go fetch it yourself though)",
				"transforming cube that can reconfigure itself into a washing machine, ping pong table or skateboard",
				"white chocolate Hershey's \"Cookie's 'n Car\" (doesn't run, but tastes delicious)",
				"former presidential airliner with the soul of Richard Nixon locked in the mini-fridge",
				"thirteen seater bike formerly owned by the Dallas Cowboys",
				"hovercar (batteries last 30 minutes)",
				"Porta-Pooly (a mobile pool services truck with poor naming sense)",
				"thick swarm of sorcerous, eerily silent rats",
				"viking funeral barge which silently bursts into flame after a journey",
				"binary bus (two speeds: stopped or 100 mph)",
				"giant worm",
				"surprisingly spacious clown car",
				"pair of roller-stilts",
				"extremely long red carpet",
				"anti-gravity nanobot cluster",
				"extensive catapult-net system",
				"squeaky shopping cart"
			};

			if (color1 == "red")
			{
				switch (color2)
				{
					case "red":
						num = 0;
						break;
					case "orange":
						num = 1;
						break;
					case "yellow":
						num = 2;
						break;
					case "green":
						num = 3;
						break;
					case "blue":
						num = 4;
						break;
					case "indigo":
						num = 5;
						break;
					case "violet":
						num = 6;
						break;
					default:
						break;
				}
			}
			else if (color1 == "orange")
			{
				switch (color2)
				{
					case "red":
						num = 7;
						break;
					case "orange":
						num = 8;
						break;
					case "yellow":
						num = 9;
						break;
					case "green":
						num = 10;
						break;
					case "blue":
						num = 11;
						break;
					case "indigo":
						num = 12;
						break;
					case "violet":
						num = 13;
						break;
					default:
						break;
				}
			}
			else if (color1 == "yellow")
			{
				switch (color2)
				{
					case "red":
						num = 14;
						break;
					case "orange":
						num = 15;
						break;
					case "yellow":
						num = 16;
						break;
					case "green":
						num = 17;
						break;
					case "blue":
						num = 18;
						break;
					case "indigo":
						num = 19;
						break;
					case "violet":
						num = 20;
						break;
					default:
						break;
				}
			}
			else if (color1 == "green")
			{
				switch (color2)
				{
					case "red":
						num = 21;
						break;
					case "orange":
						num = 22;
						break;
					case "yellow":
						num = 23;
						break;
					case "green":
						num = 24;
						break;
					case "blue":
						num = 25;
						break;
					case "indigo":
						num = 26;
						break;
					case "violet":
						num = 27;
						break;
					default:
						break;
				}
			}
			else if (color1 == "blue")
			{
				switch (color2)
				{
					case "red":
						num = 28;
						break;
					case "orange":
						num = 29;
						break;
					case "yellow":
						num = 30;
						break;
					case "green":
						num = 31;
						break;
					case "blue":
						num = 32;
						break;
					case "indigo":
						num = 33;
						break;
					case "violet":
						num = 34;
						break;
					default:
						break;
				}
			}
			else if (color1 == "indigo")
			{
				switch (color2)
				{
					case "red":
						num = 35;
						break;
					case "orange":
						num = 36;
						break;
					case "yellow":
						num = 37;
						break;
					case "green":
						num = 38;
						break;
					case "blue":
						num = 39;
						break;
					case "indigo":
						num = 40;
						break;
					case "violet":
						num = 41;
						break;
					default:
						break;
				}
			}
			else if (color1 == "violet")
			{
				switch (color2)
				{
					case "red":
						num = 42;
						break;
					case "orange":
						num = 43;
						break;
					case "yellow":
						num = 44;
						break;
					case "green":
						num = 45;
						break;
					case "blue":
						num = 46;
						break;
					case "indigo":
						num = 47;
						break;
					case "violet":
						num = 48;
						break;
					default:
						break;
				}
			}
			return vehicles[num];
		}
	}
}
