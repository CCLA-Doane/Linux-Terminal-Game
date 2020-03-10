using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuDisplay : MonoBehaviour
{
    enum Screen  { MainMenu, OptionsMenu, Credits };

    Screen currentScreen;
    int selection;
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.WriteLine("Bash Basics!");
        Terminal.WriteLine("A Game to Learn Terminal Commands!");
        Terminal.WriteLine("1 - Play the Game");
        Terminal.WriteLine("2 - Options");
        Terminal.WriteLine("3 - Credits");
        Terminal.WriteLine("4 - Exit");
    }

    void RunMainMenu(string input)
    {
        if (input == "1")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}