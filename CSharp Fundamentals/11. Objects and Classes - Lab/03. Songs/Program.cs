namespace _03._Songs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Song> playlist = new List<Song>();

            for (int i = 0; i < n; i++)
            {
                string[] songDetails = Console.ReadLine().Split("_");
                Song song = new Song();
                song.TypeList = songDetails[0];
                song.Name = songDetails[1];
                song.Time = songDetails[2];

                playlist.Add(song);
            }

            string command = Console.ReadLine();
            if (command == "all")
            {
                foreach (var song in playlist)
                {
                    Console.WriteLine(song.Name);
                }

                return;
            }

            foreach (Song song in playlist)
            {
                if (song.TypeList == command)
                {
                    Console.WriteLine(song.Name);
                }
            }
        }
    }

    class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }
}
