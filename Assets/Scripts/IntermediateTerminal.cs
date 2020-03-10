using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntermediateTerminal : MonoBehaviour
{


    string userPrompt = "[ccla-learner@terminal-learn";
    string home = " ~s]";
    const string backPrompt = "cd ..";
    // Start is called before the first frame update
    const string menuHint = "You may type menu at any time.";

    string[] fileDirectory = { "Desktop", "Documents", "Downloads", "Music", "Pictures", "Public", "Templates", "Videos" };

    string fileOutDir;

    int level;

    string dirChange;
    string currDirectory;
    enum Screen {Selection, whoami, pwd, cd, ls};

    Screen currentScreen;
    void Start()
    {
        SelectTutorial();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Gather user input to pass in functions
    void OnUserInput(string input)
    {
        getCurrScreen(input);

    }

    void getCurrScreen(string input)
    {
        if (input == "1")
        {

        }
    }
    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3" || input == "4");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            
        }
        else if (input == "nostromo")
        {
            easterEgg();
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level: ");
        }
    }







    
    //display menu
    void SelectTutorial()
    {
        currentScreen = Screen.Selection;
        Terminal.ClearScreen();

        Terminal.WriteLine("Now let's move on to some intermediate skill checks!");
        Terminal.WriteLine("For navigating the terminal.");
    }

    void easterEgg()
    {
        Terminal.WriteLine("PRIORITY ONE");
        Terminal.WriteLine("INSURE RETURN OF ORGANISM");
        Terminal.WriteLine("FOR ANALYSIS.");
        Terminal.WriteLine("ALL OTHER CONSIDERATIONS SECONDARY.");
        Terminal.WriteLine("CREW EXPENDABLE.");
    }

    //if the player decides to go back to the previous menu
    void ToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    void CommandLine(string input)
    {
        Terminal.WriteLine("You can type menu at any time to go back");

        if (input == "clear")
        {
            Terminal.ClearScreen();
            Terminal.WriteLine(userPrompt + currDirectory);
        }

        if (input == "whoami")
        {
            Terminal.WriteLine("ccla-learner");
            Terminal.WriteLine(userPrompt + currDirectory);
        }

        // Iterate along the array of fileDirectory to print
        if (input == "ls")
        {
            fileOutDir = "";
            for (int i = 0; i < fileDirectory.Length; i++)
            {
                fileOutDir += fileDirectory[i];
                fileOutDir += " ";
            }
            Terminal.WriteLine(fileOutDir);
            Terminal.WriteLine(userPrompt + currDirectory);
        }

        if (input == "pwd")
        {
            Terminal.WriteLine("/home/ccla-learner");
        }

        if (input.Substring(0, 2) == "cd")
        {
            dirChange = input.Substring(2, input.Length - 2);
            currDirectory = dirChange;
            Terminal.WriteLine(userPrompt + dirChange + "]");
        }
    }
}
