using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Microsoft.Extensions.Logging;
using MovieRepository.Dao;

namespace MovieRepository.Services;

public partial class MainService : IMainService
{
    private readonly ILogger<MainService> _logger;
    private readonly IRepository _repository;

    public MainService(ILogger<MainService> logger, IRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public void Invoke()
    {
        FileManager dataManager = new FileManager();
        string filename = $"{Environment.CurrentDirectory}/files/movies.csv";
        //trying to create an enviroment variable and make a current directory

        //Checking to see if file exists
        if (File.Exists(filename))
        {
            Console.WriteLine("Yay File FOUND");
            string choice;
            do
            {
                Console.Write("\n1) Add Movie" +
                    "\n2) Display Movies" +
                    "\n3) Exit Application" +
                    "\nEnter Corisponding Number: ");
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    dataManager.Write(filename);
                }
                else if (choice == "2")
                {
                    dataManager.Read(filename);
                }
            }
            while (choice != "3");
            Console.WriteLine("Bye");
        }
        else
        {
            Console.WriteLine("No File Found");
        }
    }
}

/*

                //find title
                string title = line.Split(",")[1];
                string line1 = "1, Toy Story (2000), Action|Comedy";
                var user = "Toy Story (2000)";
                var movieExists = line.IndexOf(user);

                String.Compare(line1, user, StringComparison.InvariantCultureIgnoreCase);
                line1.StartsWith(user);

 */




//OG Code from Invoke
/*        
        var menu = new Menu();

        Menu.MenuOptions menuChoice;
        do
        {
            menuChoice = menu.ChooseAction();

            switch (menuChoice)
            {
                case Menu.MenuOptions.ListFromStudentRepository:
                    _repository.Read();
                    _repository.Display();
                    break;
                case Menu.MenuOptions.ListFromFileRepository:
                    var factory1 = LoggerFactory.Create(b => b.AddConsole());
                    var logger1 = factory1.CreateLogger<FileRepository>();
                    var fileRepository1 = new FileRepository(logger1);
                    fileRepository1.Read();
                    fileRepository1.Display();
                    break;
                case Menu.MenuOptions.Add:
                    _logger.LogInformation("Adding a new movie");
                    var factory2 = LoggerFactory.Create(b => b.AddConsole());
                    var logger2 = factory2.CreateLogger<FileRepository>();
                    var fileRepository2 = new FileRepository(logger2);
                    fileRepository2.Read();
                    fileRepository2.Write(999999, "My Title", "Horror|Action");
                    //menu.GetUserInput();
                    break;
                case Menu.MenuOptions.Update:
                    _logger.LogInformation("Updating an existing movie");
                    break;
                case Menu.MenuOptions.Delete:
                    _logger.LogInformation("Deleting a movie");
                    break;
            }
        }
        while (menuChoice != Menu.MenuOptions.Exit);

        menu.Exit();

        Console.WriteLine("\nThanks for using the Movie Library!");
*/