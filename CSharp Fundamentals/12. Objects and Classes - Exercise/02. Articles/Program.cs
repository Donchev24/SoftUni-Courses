namespace _02._Articles
{
        class Article
        {
            public Article(string title, string content, string author)
            {
                Title = title;
                Content = content;
                Author = author;
            }

            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }

            public void Rename(string newTitle)
            {
                Title = newTitle;
            }
            public void Edit(string newContent)
            {
                Content = newContent;
            }

            public void ChangeAuthor(string newAuthor)
            {
                Author = newAuthor;
            }

            public override string ToString()
            {
                return $"{Title} - {Content}: {Author}";
            }

        }


        internal class Program
        {
            static void Main(string[] args)
            {
                string[] articleDetails = Console.ReadLine().Split(", ");

                Article article = new Article(articleDetails[0], articleDetails[1], articleDetails[2]);

                int n = int.Parse(Console.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    string[] command = Console.ReadLine().Split(": ");

                    string commandFunction = command[0];
                    string commandValue = command[1];

                    if (commandFunction == "Rename")
                    {
                        article.Rename(commandValue);
                    }
                    else if (commandFunction == "Edit")
                    {
                        article.Edit(commandValue);
                    }
                    else
                    {
                        article.ChangeAuthor(commandValue);
                    }

                }

                Console.WriteLine(article);
            }
        }
    }
}
