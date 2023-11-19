using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsHome.Persons
{
   internal class Branch : Element
   {
      public override string Source { get; } = "branch.png";
      public int StartBirdInBranch { get; set; }
      public Branch(int countStartBirds, int width, int height)
      {
         int[] sizeImage = new int[2] { width / 3, height / 3 };
         int[] locationImage = new int[2] { 0, height / 3 };
         StartBirdInBranch = countStartBirds;

         SetStats(new int[][] { sizeImage, locationImage }, this);
      }
   }
}
