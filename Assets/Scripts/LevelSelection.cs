using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelection : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        ShowMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //display the menu
    void ShowMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Press 1 - Basics");
        Terminal.WriteLine("Press 2 - Intermediate");
        Terminal.WriteLine("Press 3 - Advanced");
        Terminal.WriteLine("Press 4 - Go Back to Main Menu");
    }

    /**
    * Checks for user input
    */
    void OnUserInput(string input)
    {
        if (input == "1")
        {
            PlayBasics();
        }else if (input == "2")
        {
            PlayIntermediate();
        }else if (input == "3")
        {
            PlayAdvanced();
        }else if (input == "4")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    //Go to basics screen
    void PlayBasics()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Go to intermediate screen
    void PlayIntermediate()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    //Go to advanced screen
    void PlayAdvanced()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
