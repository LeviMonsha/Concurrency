using BirdsHome.Persons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BirdsHome
{
   public partial class Form1 : Form
   {
      int timeFlyingBirdToBranch;
      int timeBirdEatingMaxValue;
      int countBirdsInAll;
      int capacityBirdFeeding;
      Bird startBird;
      Branch branch;
      BirdFeeding birdFeeding;
      List<Element> elements;

      public Form1()
      {
         InitializeComponent();
      }

      private void button1_Click(object sender, EventArgs e)
      {
         try
         {
            timeFlyingBirdToBranch = int.Parse(textBox1.Text);
            timeBirdEatingMaxValue = int.Parse(textBox2.Text);

            Bird.TimeFlyingBirdToBranch = timeFlyingBirdToBranch;
            birdFeeding.CountBirdsMax = capacityBirdFeeding;
            outBirdsOnBirdsFeeding.Text = birdFeeding.CountBirdsNow.ToString();
            outBirdsOnBranch.Text = branch.StartBirdInBranch.ToString();

            _ = FlyingToBranch();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      private async Task FlyingToBranch()
      {
         await Task.Run(async () =>
         {
            while (true)
            {
               branch.StartBirdInBranch += 1;
               outBirdsOnBranch.Text = branch.StartBirdInBranch.ToString();
               int readyToFly = branch.StartBirdInBranch >= birdFeeding.CountBirdsMax ? birdFeeding.CountBirdsMax : branch.StartBirdInBranch;

               int freeSeats = birdFeeding.CountBirdsMax - birdFeeding.CountBirdsNow;
               if (readyToFly <= freeSeats && readyToFly != 0)
               {
                  for (int i = 0; i < readyToFly; i++)
                  {
                     countBirdsInAll += 1;
                     Bird birdInBirdHouse = null;
                     this.Invoke((MethodInvoker)delegate
                     {
                        birdInBirdHouse = CreateBird();
                        this.Controls.Add(birdInBirdHouse);
                        birdInBirdHouse.BringToFront();
                     });
                     UpdateOutput();
                     _ = FlyingToBirdHouse(birdInBirdHouse);
                  }
               }
               await Task.Delay(Bird.TimeFlyingBirdToBranch);
            }
         });
      }
      private Bird CreateBird()
      {
         Bird birdInBirdHouse = new Bird(Width, Height);
         Random rnd = new Random();
         birdInBirdHouse.TimeBirdEating = rnd.Next(300, timeBirdEatingMaxValue);
         birdInBirdHouse.Id = countBirdsInAll;
         return birdInBirdHouse;
      }

      private void UpdateOutput()
      {
         branch.StartBirdInBranch -= 1;
         birdFeeding.CountBirdsNow += 1;
         outBirdsOnBirdsFeeding.Text = birdFeeding.CountBirdsNow.ToString();
      }

      private async Task FlyingToBirdHouse(Bird brd)
      {
         await MoveBirdToFeeding(brd);
         brd.Thread = new Thread(new ParameterizedThreadStart(FeedBirdsAsync));
         brd.Thread.Name = $"{brd.Id}";
         brd.Thread.Start(brd);
      }

      private void TextBoxChanged_TextChanged(object sender, EventArgs e)
      {
         var txtBox = sender as TextBox;
         while (!int.TryParse(txtBox.Text, out _))
         {
            txtBox.BackColor = Color.Red;
            return;
         }
         txtBox.BackColor = Color.Green;
      }

      private void Form1_Load(object sender, EventArgs e)
      {
         capacityBirdFeeding = 3;
         startBird = new Bird(Width, Height);
         branch = new Branch(0, Width, Height);
         birdFeeding = new BirdFeeding(capacityBirdFeeding, Width, Height);
         elements = new List<Element> { startBird, branch, birdFeeding };

         foreach (var x in elements)
            this.Controls.Add(x);
      }

      private async Task MoveBirdToFeeding(Bird flyingBird)
      {
         await Task.Run(() =>
         {

            int finishPointX = birdFeeding.Location.X + birdFeeding.Location.X / 2;
            int finishPointY = birdFeeding.Location.Y + birdFeeding.Location.Y / 5;

            var leftOrRingth = RecognizeStartEndPoint(flyingBird.Location.X, finishPointX);
            var upOrDown = RecognizeStartEndPoint(flyingBird.Location.Y, finishPointY);
            while (true)
            {
               if (flyingBird.Location.X != finishPointX)
               {
                  flyingBird.Location = new Point(leftOrRingth(flyingBird.Location.X, 1), flyingBird.Location.Y);
               }
               if (flyingBird.Location.Y != finishPointY)
               {
                  flyingBird.Location = new Point(flyingBird.Location.X, upOrDown(flyingBird.Location.Y, 1));
               }
               if (flyingBird.Location.X == finishPointX && flyingBird.Location.Y == finishPointY)
               {
                  break;
               }
               Thread.Sleep(1);
            }
         });
      }

      delegate int isGrater(int val1, int val2);
      private isGrater RecognizeStartEndPoint(int s1, int s2)
      {
         if (s1 > s2) // если текущая позиция птицы больше остановы
         {
            return (int val1, int val2) => val1 - val2;
         }
         return (int val1, int val2) => val1 + val2;
      }
      private void FeedBirdsAsync(object obj)
      {
         BirdFeeding.Sem.WaitOne();

         Bird brd = obj as Bird;

         history.Items.Add($"{Thread.CurrentThread.Name} Влетает в кормушку");
         history.Items.Add($"{Thread.CurrentThread.Name} клюёт");

         Thread.Sleep(brd.TimeBirdEating);

         history.Items.Add($"{Thread.CurrentThread.Name} покидает");

         birdFeeding.CountBirdsNow -= 1;
         outBirdsOnBirdsFeeding.Text = birdFeeding.CountBirdsNow.ToString();

         brd.Dispose();
         BirdFeeding.Sem.Release();
      }
   }
}
