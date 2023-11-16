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
