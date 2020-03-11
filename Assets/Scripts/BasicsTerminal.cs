using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicsTerminal : MonoBehaviour
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
    ArrayList addFile = new ArrayList();

    void fillDir()
    {
        for (int i = 0; i < fileDirectory.Length; i++)
        {
            addFile.Add(fileDirectory[i].ToString());
        }
    }
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
        if (input == "menu")
        {
            SelectTutorial();
        }
        if (input == "5" || input == "back")
        {
            Terminal.ClearScreen();
            ToMainMenu();
        }else if (currentScreen == Screen.whoami)
        {
            Terminal.ClearScreen();
            WAITutorial(input);
        }else if (currentScreen == Screen.pwd)
        {
            Terminal.ClearScreen();
            PWDTutorial(input);
        }else if (currentScreen == Screen.cd)
        {
            Terminal.ClearScreen();
            cdTutorial(input);
        }else if (currentScreen == Screen.ls)
        {   
            Terminal.ClearScreen();
            lsTutorial(input);
        }
    }

    void getCurrScreen(string input)
    {
        if (input == "1")
        {
            currentScreen = Screen.whoami;
        }else if (input == "2")
        {
            currentScreen = Screen.pwd;
        }
        else if (input == "3")
        {
            currentScreen = Screen.ls;
        }else if (input == "4")
        {
            currentScreen = Screen.cd;
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
    //whoami
    void WAITutorial(string input)
    {
        currentScreen = Screen.whoami;
        Terminal.ClearScreen();
        currDirectory = home;
        Terminal.WriteLine("We are going to start with something very simple:");
        Terminal.WriteLine("Start by typing 'whoami' in the command prompt.");
        Terminal.WriteLine(userPrompt + home);
        CommandLine(input);
    }

    //print working directory
    void PWDTutorial(string input)
    {
        currentScreen = Screen.pwd;
        Terminal.ClearScreen();
        currDirectory = home;
        Terminal.WriteLine("You are going to learn how to find out where you are");
        Terminal.WriteLine("in a computer. We do this with:");
        Terminal.WriteLine("the PRINT WORKING DIRECTORY command, which is 'pwd'");
        Terminal.WriteLine(userPrompt + home);
        CommandLine(input);
    }

    //cd
    void cdTutorial(string input)
    {
        currentScreen = Screen.cd;
        Terminal.ClearScreen();
        currDirectory = home;
        Terminal.WriteLine("Move to a new folder with the CHANGE DIRECTORY command.");
        Terminal.WriteLine("This is done with 'cd'.");
        Terminal.WriteLine("You can start by typing 'ls' to see where you can go");
        Terminal.WriteLine("Then type 'cd' followed by the name of the folder to go there");
        Terminal.WriteLine(userPrompt + currDirectory);
        CommandLine(input);
    }

    //ls
    void lsTutorial(string input)
    {
        currentScreen = Screen.ls;
        Terminal.ClearScreen();
        currDirectory = home;
        Terminal.WriteLine("You are going to learn how to list file information");
        Terminal.WriteLine("This is done with the 'ls' command");
        Terminal.WriteLine("Type 'ls'");
        Terminal.WriteLine(userPrompt + home);
        CommandLine(input);
    }
    
    //display menu
    void SelectTutorial()
    {
        currentScreen = Screen.Selection;
        Terminal.ClearScreen();

        Terminal.WriteLine("Before we get too in depth, let's learn some basics!");
        Terminal.WriteLine("Below are a series of items to learn that will be essential");
        Terminal.WriteLine("For navigating the terminal. To learn press the following buttons:");
        Terminal.WriteLine("Press 1 - Find out who is logged in to the terminal");
        Terminal.WriteLine("Press 2 - Find out where you are in the computer");
        Terminal.WriteLine("Press 3 - List everything in your current location in the computer");
        Terminal.WriteLine("Press 4 - Move to a different place in the computer");
        Terminal.WriteLine("Press 5 - Return to the Main Game Menu");
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    void CommandLine(string input)
    {
        Terminal.WriteLine("You can type menu at any time to go back");

        if (input == "menu")
        {
            Terminal.ClearScreen();
            SelectTutorial();
        }

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

        if(input == "nostromo")
        {
            easterEgg();
        }
    }
}
