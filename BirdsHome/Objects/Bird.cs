using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace BirdsHome.Persons
{
   public delegate void HandlerBirdAction(object brd);
   public class Bird : Element
   {
      public static HandlerBirdAction OnBirdAction;
      public static int TimeFlyingBirdToBranch { get; set; }
      public int TimeBirdEating { get; set; }
      public Thread MyThread { get; set; }
      public override string Source { get; } = "brd.png";
      public Bird(int width, int height)
      {
         int[] sizeImage = new int[2] { width / 14, height / 14 };
         int[] locationImage = new int[2] { width / 4, height / 3 };

         SetStats(new int[][] { sizeImage, locationImage }, this);
      }
      public Bird(int width, int height, int name) : this(width, height) 
      {
         MyThread = new Thread(new ParameterizedThreadStart(OnBirdAction));
         MyThread.Name = name.ToString();
         MyThread.Start(this);
      }
   }
}
