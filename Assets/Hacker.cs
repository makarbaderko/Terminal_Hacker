using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game configuration data
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrows"};
    string[] level2Passwords = { "police", "gun", "holster", "arrest", "prison", "judge" };
    string[] level3Passwords = { "starfield", "telescope", "environment", "exploration", "astronauts" };
    const string menuHint = "You may type menu at any time.";

    //Game State
    private int level;
    private string password;

    enum Screen { MainMenu, Password, Win };
    Screen currentScreen = Screen.MainMenu;

    void ShowMainMenu(string name)
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello " + name);
        Terminal.WriteLine("Where would you like to hack into?\n\n" +
            "Press 1 for the local library\n" +
            "Press 2 for the police station\n" +
            "Press 3 for NASA!\n\n" +
            "Enter your selection:");
    }
    //this should only decide who to handle the input, not to do
    void OnUserInput(string input)
    {
        if (input == "menu") //user can always go to the menu
        {
            currentScreen = Screen.MainMenu;
            Terminal.ClearScreen();
            ShowMainMenu("Makar");
        }
        else if (currentScreen == Screen.MainMenu)
        { //If tou are in the menu, you can select the level
            RunMainMenu(input);
        } else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        } else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"

       _________
      /        //
     /        //
    /_______ //
    (_______(/
                ");
                break;
            case 2:
                Terminal.WriteLine("You got the prison key!");
                Terminal.WriteLine(@"
 __
/0 \_______
\__/-=' = '         
"
                );
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
            case 3:
                Terminal.WriteLine(@"
 _ __   __ _ ___  __ _
| '_ \ / _` / __|/ _` |
| | | | (_| \__ \ (_| |
|_| |_|\__,_|___)\__,_|
"
                );
                Terminal.WriteLine("Welcome to NASA's internal system!");
                break;
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidNumber = (input == "1" || input == "2" || input == "3");
        if (isValidNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "007")
        {
            //Easter Egg
            Terminal.ClearScreen();
            ShowMainMenu("James Bond!");

        }
        else
        {
            Terminal.WriteLine("Write valid input");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Please, enter your password: hint: " + password.Anagram());
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invaid level number");
                break;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu("Makar");
    }

}
