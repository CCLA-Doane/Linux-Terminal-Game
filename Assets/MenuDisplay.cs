using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuDisplay : MonoBehaviour
{
    enum Screen  { MainMenu, Credits };
    
    //A hint for the player
    const string menuHint = "You may type menu at any time.";
    const string prevDirectory = "cd ..";
    const string exit = "exit";
    
    Screen currentScreen;
    int selection;
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Bash Basics!");
        Terminal.WriteLine("A Game to Learn Terminal Commands!");
        Terminal.WriteLine("1 - Play the Game");
        Terminal.WriteLine("2 - Credits");
        Terminal.WriteLine("3 - Exit");
    }

    void OnUserInput(string input)
    {
        if (input == "1")
        {
            PlayGame();
        }else if (input == "quit" || input == "close" || input == "exit" || input =="3")
        {
            Application.Quit();
        }else if (input == "2")
        {
            Credits(input);
        }
    }


    void Credits(string input)
    {
        currentScreen = Screen.Credits;
        Terminal.ClearScreen();
        Terminal.WriteLine("Game Designed for the Doane Center for Computing in the Liberal Arts by Ryan Mueller 2020");
        Terminal.WriteLine("Assets courtesy of: ");
        Terminal.WriteLine("GameDev.tv's 'Terminal Hacker' Tutorial Game");
        Terminal.WriteLine("Redistribution Rights Licensed under the MIT License 2017");
        Terminal.WriteLine("For Full Licensing, Please Visit: ");
        Terminal.WriteLine("https://github.com/CompleteUnityDeveloper2/2_Terminal_Hacker/blob/master/LICENSE");
        Terminal.WriteLine(menuHint);

        if (input == "menu")
        {
            ShowMainMenu();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}