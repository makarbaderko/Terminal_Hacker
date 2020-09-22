using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game State
    private int level;

    enum Screen { MainMenu, Password, Win };
    Screen current_screen = Screen.MainMenu;


    void ShowMainMenu(string name)
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello " + name);
        Terminal.WriteLine("Where would you like to hack into?\n\n" +
            "Press 1 for the local library\n" +
            "Press 2 for the police station\n" +
            "Press 3 for  NASA\n\n" +
            "Enter your selection:");
    }
    void OnUserInput(string input)
    {
        if (input == "1")
        {
            level = 1;
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            StartGame();

        }
        else if (input == "3")
        {
            level = 3;
            StartGame();
        }
        else if (input == "007")
        {
            Terminal.ClearScreen();
            ShowMainMenu("James Bond!");
        }
        else if (input == "menu")
        {
            Terminal.ClearScreen();
            ShowMainMenu("Makar");
        }
        else
        {
            Terminal.WriteLine("Write valid input");
        }
    }
    void StartGame()
    {
        current_screen = Screen.Password;
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please, enter your password:");
    }
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu("Makar");
    }

}
