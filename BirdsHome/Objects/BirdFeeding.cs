using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BirdsHome.Persons
{
   public delegate void SendMessageHandler(string s);
   public delegate Task BirdFlyingIntoHandler(Bird brd);
   public delegate void BirdFlyingAwayHandler();
   internal class BirdFeeding : Element
   {
      public event BirdFlyingIntoHandler BirdFlyingInto;
      public event BirdFlyingAwayHandler BirdFlyingAway;
      public SendMessageHandler SendMessage { get; set; }
      public static Semaphore Sem { get; set; }
      public override string Source { get; } = "birdfeeding.png";
      public static int CountBirdNow { get; set; }
      public BirdFeeding(int capacity, int width, int height)
      {
         int[] sizeImage = new int[2] { width / 2, height / 2 };
         int[] locationImage = new int[2] { width / 2, height / 3 };
         Sem = new Semaphore(capacity, capacity);

         SetStats(new int[][] { sizeImage, locationImage }, this);
      }
      public async void FeedBirdsAsync(object obj)
      {
         Sem.WaitOne();

         Bird brd = obj as Bird;

         await BirdFlyingInto.Invoke(brd);
         SendMessage.Invoke($"{Thread.CurrentThread.Name} Влетает в кормушку");
         SendMessage.Invoke($"{Thread.CurrentThread.Name} клюёт");

         Thread.Sleep(brd.TimeBirdEating);

         SendMessage.Invoke($"{Thread.CurrentThread.Name} покидает");

         BirdFlyingAway.Invoke();

         brd.Dispose();
         Sem.Release();
      }
   }
}
