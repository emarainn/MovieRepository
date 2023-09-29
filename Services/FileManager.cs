namespace MovieRepository.Services;

public partial class MainService
{
    //Holds read and write methods
    public class FileManager
    {
        //Add Movie
        public void Write(string filename)
        {

            int movieID = findMaxId(filename);

            Console.WriteLine($"Movie ID: {movieID}");
            string movieTitle;
            var ans = 0;

            do {
                Console.WriteLine("Enter Movie Title:");
                movieTitle = Console.ReadLine();

                var lines = File.ReadLines(filename).Skip(1);

                foreach (string line in lines)
                {
                    ans = line.IndexOf(movieTitle);

                    if (ans >= 0)
                    {
                        Console.WriteLine("Title Already Entered");
                        break;
                    }
                }
            } while (ans >= 0);

            Console.WriteLine("Enter Number of Genres: ");
            var num = Convert.ToInt32(Console.ReadLine());

            string[] movieGenre = new string[num];

            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Type in Genre: ");
                movieGenre[i] = Console.ReadLine();
            }

            IMovie movie = new Movies(movieID, movieTitle, movieGenre);
            StreamWriter sw = new StreamWriter(filename, true);
            sw.WriteLine($"{movieID},{movieTitle},{string.Join("|", movieGenre)}");
            sw.Close();
        }

        //Display SPECIFIC number of movies starting from 1st
        public void Read(string filename)
        {
            Console.Write("Enter amount of movies you want to view: ");
            int numItem = Convert.ToInt32(Console.ReadLine());

            //Shows the "titles" of the rows
            string items = File.ReadLines(filename).Skip(0).Take(1).First();
            Console.WriteLine(items);

            //skipping title of rows
            int start = 1;

            //Loop is based on numItem (user input)
            for (int i = 0; i < numItem; i++)
            {
                string line = File.ReadLines(filename).Skip(start).Take(1).First();
                start++;
                Console.WriteLine(line);
            }
        }
        public int findMaxId(string filename)
        {
            var maxId = 0;
            var lines = File.ReadLines(filename).Skip(1);

            foreach (string line in lines)
            {
                //find max ID
                var id = line.Split(",")[0];

                int newid = Convert.ToInt32(id);

                if (newid > maxId)
                {
                    maxId = newid;
                }
            }
            return maxId;
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