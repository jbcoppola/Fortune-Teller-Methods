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
					"Enter your favorite ROYGBIV color (type 'help' if you do not know what this is)",
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
				string color = "";

				//since all the inputs are different data types we can't just put them in an array, so we have the ugly solution
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
										"Type your favorite one of these colors.");

						input = Console.ReadLine();
					}

					switch (i)
					{
						case 0:
							input = firstName;
							break;
						case 1:
							input = lastName;
							Greeter(firstName, lastName);
							break;
						case 2:
							age = int.Parse(input);
							break;
						case 3:
							birthMonth = int.Parse(input);
							break;
						case 4:
							color = input;
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
				string favoriteVehicle = CalculateVehicle(color);

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
	}
}

