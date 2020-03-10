using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;


public class CommandLine : MonoBehaviour
{
    AnimateUpdate kernelUpdate;
    // Game configuration data
    const string menuHint = "You may type menu at any time.";
    const string aptUpdate = "sudo apt-get upgrade";
    const string pacmanUpdate = "sudo pacman -Syu";
    const string yumUpdate = "sudo yum update";
    const string prevDirectory = "cd ..";


    string[] level1Structure = { "Desktop", "Documents", "Downloads", "Music", "Pictures", "Public", "Templates", "Videos" };

    // Game state
    int level;
    enum Screen { MainMenu, BashPrompt, Desktop, Documents, Downloads, Music, Pictures, Public, Templates, Videos };
    Screen currentScreen;
    string fileStruct;
    const string userPrompt = "learn@user:~s";
    // Use this for initialization
    void Start()
    {
        ShowMainMenu();
    }

    void Update()
    {
       // kernelUpdate.GetUpdatedProgressBar();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("1 - help a friend find their final paper");
        Terminal.WriteLine("2 - update the operating system");
        Terminal.WriteLine("3 - help a secret agent copy files to an external device");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu") // we can always go direct to main menu
        {
            ShowMainMenu();
        }
        else if (input == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("If on the web close the tab.");
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.BashPrompt)
        {
            CheckPrompt(input);
        }
        else if (currentScreen == Screen.Documents)
        {
            DocumentsPrompt(input);
        }
        else if (currentScreen == Screen.Desktop)
        {
            DesktopPrompt(input);
        }
        else if (currentScreen == Screen.Downloads)
        {
            DownloadPrompt(input);
        }
        else if (currentScreen == Screen.Music)
        {
            MusicPrompt(input);
        }
        else if (currentScreen == Screen.Pictures)
        {
            PicturesPrompt(input);
        }
        else if (currentScreen == Screen.Public)
        {
            PublicPrompt(input);
        }
        else if (currentScreen == Screen.Templates)
        {
            TemplatePrompt(input);
        }else if (currentScreen == Screen.Videos)
        {
            VideoPrompt(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            
            CommandPrompt();
            FirstTutorial();
        }
        else if (input == "nostromo")
        {
            easterEgg();
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
            Terminal.WriteLine(menuHint);
        }
    }

    void CommandPrompt()
    {
        currentScreen = Screen.BashPrompt;
        Terminal.ClearScreen();
        Terminal.WriteLine(userPrompt);
    }

    void CheckPrompt(string input)
    {
        if (input == "clear")
        {
            CommandPrompt();
        }

        //whoami
        if (input == "whoami")
        {
            Terminal.WriteLine("learn");
        }

        //Change to: a structure that can be navigated
        if (input == "ls")
        {
            fileStruct = "";
            
            for (int i = 0; i < level1Structure.Length; i++)
            {
                fileStruct += level1Structure[i];
                fileStruct += " ";             
            }
            Terminal.WriteLine(fileStruct);
            Terminal.WriteLine("learn@learn-user:~s");
        }

        //mkdir

        //cd Documents
        if (input == "cd Documents")
        {
            DocumentsPrompt(input);
            Terminal.WriteLine(userPrompt + " Documents");
        }

        //cd Desktop
        if (input == "cd Desktop")
        {
            DesktopPrompt(input);
            Terminal.WriteLine("learn@learn-user:~s");
        }

        //cd Pictures
        if (input == "cd Pictures")
        {
            PicturesPrompt(input);
            Terminal.WriteLine("learn@learn-user:~s");
        }

        //cd Templates
        if (input == "cd Music")
        {
            TemplatePrompt(input);
            Terminal.WriteLine("learn@learn-user:~s");
        }

        //cd public
        if (input == "cd Public")
        {
            DesktopPrompt(input);
            Terminal.WriteLine("learn@learn-user:~s");
        }

        //cd Download
        if (input == "cd Download")
        {
            DownloadPrompt(input);
            Terminal.WriteLine("learn@learn-user:~s");
        }

        //cd Desktop
        if (input == "cd Videos")
        {
            VideoPrompt(input);
            Terminal.WriteLine("learn@learn-user:~s");
        }

        //a little easter egg
        if (input == "nostromo")
        {
            easterEgg();
            Terminal.WriteLine("learn@learn-user:~s");
        }

        if (input == prevDirectory)
        {
            ShowMainMenu();
        }

        //package manager updates
        if (input == aptUpdate)
        {
            
        }

        if (input == pacmanUpdate)
        {
           
        }
        
        if (input == yumUpdate)
        {
            
        }
    }

    void DocumentsPrompt(string input)
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Documents;



        if (input == prevDirectory)
        {
            CommandPrompt();
        }
    }

    void DesktopPrompt(string input)
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Desktop;



        if (input == prevDirectory)
        {
            CommandPrompt();
        }
    }

    void DownloadPrompt(string input)
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Downloads;



        if (input == prevDirectory)
        {
            CommandPrompt();
        }
    }

    void PicturesPrompt(string input)
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Pictures;



        if (input == prevDirectory)
        {
            CommandPrompt();
        }
    }

    void VideoPrompt(string input)
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Videos;



        if (input == prevDirectory)
        {
            CommandPrompt();
        }
    }

    void MusicPrompt(string input)
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Music;



        if (input == prevDirectory)
        {
            CommandPrompt();
        }
    }

    void PublicPrompt(string input)
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Public;



        if (input == prevDirectory)
        {
            CommandPrompt();
        }
    }

    void TemplatePrompt(string input)
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Templates;



        if (input == prevDirectory)
        {
            CommandPrompt();
        }
    }

    void easterEgg()
    {
        Terminal.WriteLine("PRIORITY ONE");
        Terminal.WriteLine("INSURE RETURN OF ORGANISM");
        Terminal.WriteLine("FOR ANALYSIS.");
        Terminal.WriteLine("ALL OTHER CONSIDERATIONS SECONDARY.");
        Terminal.WriteLine("CREW EXPENDABLE.");
    }

    void FirstTutorial()
    {
        Terminal.WriteLine("Welcome to a game that will teach you basic Linux");
        Terminal.WriteLine("terminal commands. There are several scenarios");
        Terminal.WriteLine("designed to help you remember commands better.");
        Terminal.WriteLine("We are going to start with something very simple: ");
        Terminal.WriteLine("Help a student find their missng paper.");
        Terminal.WriteLine("Start by typing 'whoami' in the command prompt.");
    }
}