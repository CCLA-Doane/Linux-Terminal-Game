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

    ArrayList addFile = new ArrayList();

    void fillDir()
    {
        for (int i = 0; i < fileDirectory.Length; i++)
        {
            addFile.Add(fileDirectory[i].ToString());
        }
    }

    string fileOutDir;

    int level;

    string newDirectory;

    string dirChange;
    string currDirectory;
    enum Screen {Selection, mkdir, find, copy};

    void getCurrScreen(string input)
    {
        if (input == "1")
        {
            currentScreen = Screen.mkdir;
        }else if (input == "2")
        {
            currentScreen = Screen.find;
        }
        else if (input == "3")
        {
            currentScreen = Screen.copy;
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

        if (input == "4" || input == "back")
        {
            Terminal.ClearScreen();
            ToMainMenu();
        }else if (currentScreen == Screen.find)
        {
            Terminal.ClearScreen();
            findTutorial(input);
        }else if (currentScreen == Screen.mkdir)
        {
            Terminal.ClearScreen();
            mkdirTutorial(input);
        }else if (currentScreen == Screen.copy)
        {
            Terminal.ClearScreen();
            moveTutorial(input);
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


    void findTutorial(string input)
    {
        currentScreen = Screen.find;
        Terminal.ClearScreen();
        currDirectory = home;

        Terminal.WriteLine("A student has come to you saying they cannot find a file named:");
        Terminal.WriteLine("'SeniorProject.docx'. There's a simple linux command that can help you!");
        Terminal.WriteLine("Type 'find' and the name of the file you are searching for!");
        Terminal.WriteLine(userPrompt + currDirectory);
        CommandLine(input);
    }

    void mkdirTutorial(string input)
    {
        currDirectory = home;
        Terminal.WriteLine("What if you need to create a new folder?");
        Terminal.WriteLine("There's a simple way to do this: type 'mkdir' or Make Directory");
        Terminal.WriteLine("Followed by the name of the new folder");
        Terminal.WriteLine("Then you can type 'ls' command to see if it has been added.");
        Terminal.WriteLine(userPrompt + currDirectory);
        CommandLine(input);
    }

    void moveTutorial(string input)
    {
        currDirectory = home;
        Terminal.WriteLine("Now imagine for a moment you are a secret agent!");
        Terminal.WriteLine("Got it? Good. You are now deep under cover and have discovered");
        Terminal.WriteLine("that the enemy has a list of your operatives in the field.");
        Terminal.WriteLine("Can you move that file to a secure other drive?");
        Terminal.WriteLine("To do this, you will use the MOVE command, which is shortened to 'mv'.");
        Terminal.WriteLine("Type mv 'filename' then a new directory /directory name.");
        Terminal.WriteLine("In this case, the file you are moving is titled 'IMFOperatives.csv'");
        Terminal.WriteLine("Move the file to location '/mnt/SecureDrive'");
        Terminal.WriteLine("Now let's learn some formatting!");
        Terminal.WriteLine("The terminal takes commands in: command space argument space argument");
        Terminal.WriteLine("In the case of move our arguments are 'filename' and 'location'");
        Terminal.WriteLine(userPrompt + currDirectory);
        CommandLine(input);
    }
    
    //display menu
    void SelectTutorial()
    {
        currentScreen = Screen.Selection;
        Terminal.ClearScreen();

        Terminal.WriteLine("Now let's move on to some intermediate skill checks!");
        Terminal.WriteLine("For navigating the terminal.");
        Terminal.WriteLine("Press 1 - Create a new folder");
        Terminal.WriteLine("Press 2 - Help a student find a missing file.");       
        Terminal.WriteLine("Press 3 - Move Top Secret Files to another folder");
        Terminal.WriteLine("Press 4 - Return to the Main Menu");
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
            for (int i = 0; i < addFile.Count; i++)
            {
                fileOutDir += addFile[i];
                fileOutDir += " ";
            }
            Terminal.WriteLine(fileOutDir);
            Terminal.WriteLine(userPrompt + currDirectory);
        }

        //Add a new directory
        if (input.Substring(0, 5) == "mkdir")
        {
            addFile.Clear();
            fillDir();
            newDirectory = input.Substring(5, input.Length - 5);
            addFile.Add(newDirectory.ToString());
            
        }

        if (input == "pwd")
        {
            Terminal.WriteLine("/home/ccla-learner");
            
        }

        if (input.Substring(0, 2) == "cd")
        {
            dirChange = input.Substring(2, input.Length - 2);
            if (addFile.Contains(input))
            {
                currDirectory = dirChange;
                Terminal.WriteLine(userPrompt + dirChange + "]");
            }else{
                Terminal.WriteLine("bash: cd: " + dirChange + ": No such file or directory");
            }
        }

        if (input.Substring(0, 4) == "find")
        {
            if (input == "find SeniorProject.docx")
            {
                Terminal.WriteLine("Found it in " + currDirectory);
            }else {
                Terminal.WriteLine("That is not the correct file name!");
            }
        }

        if(input.Substring(0, 2) == "mv")
        {
            if (input == "mv IMFOperatives.csv /mnt/SecureDrive")
            {
                Terminal.WriteLine("File moved securely!");
            }else{
                Terminal.WriteLine("That is not the correct folder!");
                Terminal.WriteLine("Try again before your operatives are in danger!");
            }
        }
        if(input == "nostromo")
        {
            easterEgg();
        }
    }
}
