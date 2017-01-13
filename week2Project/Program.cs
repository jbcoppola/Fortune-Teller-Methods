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
			while (input != "quit" && endQuit == false)
			{
				Console.WriteLine("Welcome to the Fortune Teller. Type \"quit\" to quit, or \"restart\" to restart.");

				string[] questionArray =
				{
					"Enter your first name.",
					"Enter your last name.",
					"Enter your age.",
					"Enter your birthmonth as a digit (1-12)",
					"Enter your favorite ROYGBIV color (type 'help' if you do not know what this is)",
					"Enter how many siblings you have."
				};

				//breaks and continue can't be used in a method to break from the while loop, so we have to repeat code after each method call
				//this also prevents using a for loop, since it needs to exit immediately
				input = Program.Question(questionArray[0]);
				if (input.ToLower() == "quit")
				{
					break;
				}
				else if (input.ToLower() == "restart")
				{
					continue;
				}
				string firstName = input;

				input = Program.Question(questionArray[1]);
				if (input.ToLower() == "quit")
				{
					break;
				}
				else if (input.ToLower() == "restart")
				{
					continue;
				}
				string lastName = input;

				Console.WriteLine(Greeter(firstName, lastName));

				input = Program.Question(questionArray[2]);
				if (input.ToLower() == "quit")
				{
					break;
				}
				else if (input.ToLower() == "restart")
				{
					continue;
				}
				int age = int.Parse(input);

				input = Program.Question(questionArray[3]);
				if (input.ToLower() == "quit")
				{
					break;
				}
				else if (input.ToLower() == "restart")
				{
					continue;
				}
				int birthMonth = int.Parse(input);

				input = Program.Question(questionArray[4]);
				string color = input;
				while (color.ToLower() == "help")
				{
					Console.WriteLine("ROYGBIV is the color spectrum. It consists of:\n\n" +
										"Red\nOrange\nYellow\nGreen\nBlue\nIndigo\nViolet\n\n" +
										"Type your favorite one of these colors.");

					color = Console.ReadLine();
				};
				input = color;
				if (input.ToLower() == "quit")
				{
					break;
				}
				else if (input.ToLower() == "restart")
				{
					continue;
				}

				input = Program.Question(questionArray[5]);
				if (input.ToLower() == "quit")
				{
					break;
				}
				else if (input.ToLower() == "restart")
				{
					continue;
				}
				int siblings = int.Parse(input);

				int retire = CalculateRetirement(age);
				double bankCash = CalclulateCash(birthMonth);
				string vacationHome = CalculateVacationHome(siblings);
				string favoriteVehicle = CalculateVehicle(color);

				Console.WriteLine(firstName + ' ' + lastName + " will retire in " + retire + " years with $" + bankCash + " in the bank, " +
									"a vacation home in " + vacationHome + " and a " + favoriteVehicle + '.');
				FortuneJudger();
				endQuit = true;
			}
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
	}
}

