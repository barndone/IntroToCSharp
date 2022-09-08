namespace AIE
{
    class Program
    { 
        static void Main()
        {
            //writing text to a file
            using (StreamWriter writer = new StreamWriter("aboutBrandonEiler.txt"))
            {
                writer.WriteLine("Brandon Eiler");
                writer.WriteLine("Favorite color? Mint Green");
                writer.WriteLine("Favorite Number? 71.");
            }

            //reading text from a file
            using (StreamReader reader = new StreamReader("aboutBrandonEiler.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Console.WriteLine(line);
                }
            }

            /*
             *      level=5
             *      exp=10
             *      atk=2
             */

            //
            // hello save file
            //
            //writing text to a file
            using (StreamWriter writer = new StreamWriter("saveData.txt"))
            {
                writer.WriteLine("level=5");
                writer.WriteLine("exp=10");
                writer.WriteLine("atk=2");
            }

            //reading text from a file
            using (StreamReader reader = new StreamReader("saveData.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split('=');
                    Console.WriteLine(parts[0] + " is " +parts[1]);
                }
            }
        }
    }

}
