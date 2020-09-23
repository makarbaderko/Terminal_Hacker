using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game configuration data
    string[] level1Passwords = { "books", "aisle", "self", "password", "font", "borrows"};

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
            "Press 3 for  NASA\n\n" +
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

    private void CheckPassword(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("WELL DONE!");
        } else
        {
            Terminal.WriteLine("Wrong password, sorry!");
        }
    }

    private void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            password = "donkey";
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            password = "combobulate";
            StartGame();
        }
        else if (input == "3")
        {
            level = 3;
            password = "astronaut";
            StartGame();
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
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please, enter your password:");
    }
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu("Makar");
    }

}
