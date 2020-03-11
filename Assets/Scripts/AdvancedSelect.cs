using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdvancedSelect : MonoBehaviour
{

    const string aptUpdate = "sudo apt-get update";
    const string pacmanUpdate = "sudo pacman -Syu";
    string userPrompt = "[ccla-learner@terminal-learn";
    string home = " ~s]";
    const string backPrompt = "cd ..";
    // Start is called before the first frame update
    const string menuHint = "You may type menu at any time.";

    string[] fileDirectory = { "SpyStuff","Desktop", "Documents", "Downloads", "Music", "Pictures", "Public", "Templates", "Videos" };

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
    enum Screen {Selection, update, cp, remove};

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
        }else if (input == "4" || input == "back")
        {
            Terminal.ClearScreen();
            ToMainMenu();
        }else if (currentScreen == Screen.cp)
        {
            copyTutorial(input);
        }else if (currentScreen == Screen.remove)
        {
            rmTutorial(input);
        }else if (currentScreen == Screen.update)
        {
            updateTutorial(input);
        }

    }

    void getCurrScreen(string input)
    {
        if (input == "1")
        {
            currentScreen = Screen.cp;
        }else if (input == "2")
        {
            currentScreen = Screen.remove;
        }else if(input == "3")
        {
            currentScreen = Screen.update;
        }else if (input == "4")
        {
            ToMainMenu();
        }else if(input == "5")
        {
            currDirectory = home;
            easterEgg();
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
        currDirectory = home;
        Terminal.WriteLine("Now let's move on to some advanced skill checks!");
        Terminal.WriteLine("For navigating the terminal.");
        Terminal.WriteLine("Press 1 - Copy secret files to an external drive");
        Terminal.WriteLine("Press 2 - Remove a folder with no longer needed information");
        Terminal.WriteLine("Press 3 - Update a server for a new load");
        Terminal.WriteLine("Press 4 - Return to the Main Menu");
        Terminal.WriteLine("Press 5 - An Easter Egg!");
    }

    void copyTutorial(string input)
    {
        currDirectory = home;
        Terminal.WriteLine("You are a secret agent once again!");
        Terminal.WriteLine("This time, your goal is to copy a series of passcodes");
        Terminal.WriteLine("to get you into enemy territories. You do this with the copy command.");
        Terminal.WriteLine("You don't want the original file moved to you device. The file name is 'passcodes.json'");
        Terminal.WriteLine("It will look similar to move, except now you type 'cp'");
        Terminal.WriteLine("You want to move it to /mnt/MyThumbDrive");
        Terminal.WriteLine(userPrompt + currDirectory);
        CommandLine(input);
    }

    void rmTutorial(string input)
    {
        Terminal.WriteLine("Now you have to remove a folder that was gathering information against you!");
        Terminal.WriteLine("This is done with the remove command 'rm'");
        Terminal.WriteLine("'rm -rf [folderName]' removes a folder and everything inside");
        Terminal.WriteLine("Don't forget that these are arugment names!");
        Terminal.WriteLine("'rm 'is remove, then you have a space '-rf' then another space, and 'folderName'");
        Terminal.WriteLine("you want to remove the folder SpyStuff");
        Terminal.WriteLine(userPrompt + currDirectory);
        CommandLine(input);
    }

    void updateTutorial(string input)
    {   
        currDirectory = home;
        Terminal.WriteLine("Imagine you are hosting a large server for Minecraft in Linux");
        Terminal.WriteLine("But you need to update the operating system");
        Terminal.WriteLine("This is done through the package manager of the Linux Distribution.");
        Terminal.WriteLine("There are many to choose from, but you will be able to use:");
        Terminal.WriteLine("The apt packagem manager, used in Debian based distributions (Ubuntu for example)");
        Terminal.WriteLine("And the Pacman package manager, used in Arch based distributions");
        Terminal.WriteLine("With apt are similar, you type 'sudo apt get-update'");
        Terminal.WriteLine("pacman is a little different, you type 'sudo pacman -Syu'");
        Terminal.WriteLine("After the '-' in pacman, you are telling the computer to SYnc and Update.");
        Terminal.WriteLine(userPrompt + currDirectory);
        CommandLine(input);
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }

    void CommandLine(string input)
    {
        if (input == "menu")
        {
            Terminal.ClearScreen();
            SelectTutorial();
        }

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
            newDirectory = input.Substring(5, input.Length - 5);
            addFile.Add(newDirectory);
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
            Terminal.WriteLine(userPrompt + currDirectory);
        }

        if(input.Substring(0, 2) == "cp")
        {
            if (input == "cp passcodes.json /mnt/MyThumbDrive")
            {
                Terminal.WriteLine("Copied Securely");
                Terminal.WriteLine("Note: Normally Linux will tell you nothing");
                Terminal.WriteLine("with these commands if they work.");
            }else{
                Terminal.WriteLine("That is not the correct file to move or folder to move to.");
            }
            Terminal.WriteLine(userPrompt + currDirectory);
        }

        if(input.Substring(0, 6) == "rm -rf")
        {
            if (input.Contains("SpyStuff")){
                addFile.Remove("SpyStuff");
                Terminal.WriteLine("File Removed Successfully");
            }else{
                Terminal.WriteLine("Incorrect folder");
            }
        }

        if(input == aptUpdate || input == pacmanUpdate)
        {   System.Random rand = new System.Random();
            int updateNums = rand.Next(0, 1000);
            for (int i = 0; i < updateNums; i++)
            {
                Terminal.WriteLine("Updating system...");
            }
            Terminal.WriteLine("Update Complete");
            Terminal.WriteLine(userPrompt + currDirectory);
        }

        if(input == "nostromo")
        {
            easterEgg();
        }
    }
}
