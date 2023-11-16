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

            string movieTitle = FindTitle(filename);

            string[] movieGenre = FindGenres(filename);

            IMovie movie = new Movies(movieID, movieTitle, movieGenre);
            StreamWriter sw = new StreamWriter(filename, true);
            sw.WriteLine($"{movieID},{movieTitle},{string.Join("|", movieGenre)}");
            sw.Close();
        }

        //Display SPECIFIC number of movies starting from 1st
        public void Read(string filename)
        {
            int numItem;
            Console.Write("Enter amount of movies you want to view: ");
            
            while (!int.TryParse(Console.ReadLine(), out numItem) || numItem <= 0)
            {
                Console.WriteLine("**Must Enter Number Greater Than 0**");
                Console.WriteLine("Enter amount of movies you want to view: ");
            }

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
                maxId++;
            }
            return maxId;
        }

        public string FindTitle(string filename)
        {
            string movieTitle;
            var ans = 0;

            do
            {
                Console.WriteLine("Enter Movie Title:");
                movieTitle = Console.ReadLine();

                if (movieTitle == "")
                {
                    Console.WriteLine("**Must Enter Movie Title**");
                }

                var lines = File.ReadLines(filename).Skip(1);

                foreach (string line in lines)
                {
                    ans = line.IndexOf(movieTitle);

                    if (ans >= 0 && movieTitle != "")
                    {
                        Console.WriteLine("Title Already Exists");
                        break;
                    }
                    
                }
            } while (ans >= 0 || movieTitle == "");

            return movieTitle;
        }

        public string[] FindGenres(string filename)
        {
            int num;
            Console.WriteLine("Enter Number of Genres: ");
            
            while (!int.TryParse(Console.ReadLine(), out num) || num <= 0) 
            {  
                Console.WriteLine("**Must Enter Number Greater Than 0**");
                Console.WriteLine("Enter Number of Genres: ");
            }


            //I don't know why I cant do input validation :(
            string[] movieGenre = new string[num];
            int i = 0;

                for (i = 0; i < num; i++)
                {
                    Console.WriteLine("Type in Genre: ");
                    movieGenre[i] = Console.ReadLine();

                }
           
            return movieGenre;

        }
    }
}
