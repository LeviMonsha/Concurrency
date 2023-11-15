using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BirdsHome.Persons
{
   internal class Bird : Element
   {
      public static int TimeFlyingBirdToBranch { get; set; }
      public int TimeBirdEating { get; set; }
      public Thread Thread { get; set; }
      public override string Source { get; } = "brd.png";
      public int Id { get; set; }
      public Bird(int width, int height)
      {
         int[] sizeImage = new int[2] { width / 14, height / 14 };
         int[] locationImage = new int[2] { width / 4, height / 3 };

         SetStats(new int[][] { sizeImage, locationImage }, this);
      }
   }
}
