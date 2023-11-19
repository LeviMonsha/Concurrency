using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BirdsHome.Persons
{
   public abstract class Element : PictureBox
   {
      public abstract string Source { get; }
      public void SetStats(int[][] stats, Element obj)
      {
         obj.Size = new Size(stats[0][0], stats[0][1]);
         obj.Location = new Point(stats[1][0], stats[1][1]);
         obj.Image = Image.FromFile(obj.Source);
         obj.SizeMode = PictureBoxSizeMode.Zoom;
      }
   }
}
