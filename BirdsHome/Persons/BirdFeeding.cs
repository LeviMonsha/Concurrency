using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BirdsHome.Persons
{
   internal class BirdFeeding : Element
   {
      public static Semaphore Sem { get; set; }
      public override string Source { get; } = "birdfeeding.png";
      public int CountBirdsNow { get; set; }
      public int CountBirdsMax { get; set; }
      public BirdFeeding(int capacity, int width, int height)
      {
         int[] sizeImage = new int[2] { width / 2, height / 2 };
         int[] locationImage = new int[2] { width / 2, height / 3 };
         Sem = new Semaphore(capacity, capacity);

         SetStats(new int[][] { sizeImage, locationImage }, this);
      }
   }
}
