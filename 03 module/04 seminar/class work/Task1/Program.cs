using System;
namespace ConsoleApplication1
{
    class PlayIsStartedEventArgs : EventArgs
    {
        public int Number { get; set; }
    }

    class Bandmaster
    {
        public event EventHandler<PlayIsStartedEventArgs> PlayIsStartedr;
        static Random random = new Random();
        public void StartPlay()
        {
            PlayIsStartedr?.Invoke(this, new PlayIsStartedEventArgs() { Number = random.Next(2, 6) });
        }
    }

    abstract class OrchestraPlayer
    {
        public string Name { get; set; }
        public abstract void PlayIsStartedEventHandler(object sender, PlayIsStartedEventArgs e);
    }

    class Violinist : OrchestraPlayer
    {
        public override void PlayIsStartedEventHandler(object sender, PlayIsStartedEventArgs e)
        {
            Console.WriteLine($"V {Name} - {e.Number}");
        }
    }

    class Hornist : OrchestraPlayer
    {
        public override void PlayIsStartedEventHandler(object sender, PlayIsStartedEventArgs e)
        {
            Console.WriteLine($"H {Name} - {e.Number}");
        }
    }

    class MainClass
    {
        public static void Main()
        {
            int n = 10;
            Random random = new Random();
            Bandmaster master = new Bandmaster();
            OrchestraPlayer[] players = new OrchestraPlayer[n];
            for (int i = 0; i < n; i++)
            {
                int k = random.Next(0, 2);
                if (k == 0)
                {
                    players[i] = new Hornist() { Name = random.Next(100).ToString() };
                }
                else
                {
                    players[i] = new Violinist() { Name = random.Next(100).ToString() };
                }
                master.PlayIsStartedr += players[i].PlayIsStartedEventHandler;
            }
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("***");
                master.StartPlay();
            }
        }
    }
}