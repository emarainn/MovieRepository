namespace MovieRepository.Services;

public partial class MainService
{
    public interface IMovie
    {
        //public int MovieID { get; set; }
        public int MovieID { get; set; }
        public string MovieTitle { get; set; }
        public string MovieGenre { get; set; }
    }




}

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