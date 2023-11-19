using BirdsHome.Persons;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BirdsHome
{
   public partial class Form1 : Form
   {
      int capacityBirdFeeding = 3;
      int timeFlyNextPixel = 1;
      int timeFlyingBirdToBranch;
      int timeBirdEatingMaxValue;
      int idBird;
      Random rnd;
      Branch branch;
      BirdFeeding birdFeeding;

      public Form1()
      {
         InitializeComponent();
      }

      private void StartFlying_Click(object sender, EventArgs e)
      {
         try
         {
            timeFlyingBirdToBranch = int.Parse(intensiveFlying.Text);
            timeBirdEatingMaxValue = int.Parse(timeEating.Text);
            Bird.TimeFlyingBirdToBranch = timeFlyingBirdToBranch;
            OutputInfo();
            InitionalStartBirds();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      private void InitionalStartBirds()
      {
         start.Enabled = false;
         _ = BirdsFlyToBranch();
      }

      private async Task BirdsFlyToBranch()
      {
         await Task.Run(() =>
         {
            while (true)
            {
               branch.StartBirdInBranch += 1;
               idBird += 1;
               OutputInfo();
               CreateBirdToFly();
               Thread.Sleep(timeFlyingBirdToBranch);
            }
         });
      }

      private void CreateBirdToFly() 
      {
         Bird birdInBirdHouse = new Bird(Width, Height, idBird);
         this.Invoke((MethodInvoker)delegate
         {
            birdInBirdHouse.TimeBirdEating = GetRandomNum(timeBirdEatingMaxValue / 2, timeBirdEatingMaxValue);
            this.Controls.Add(birdInBirdHouse);
            birdInBirdHouse.BringToFront();
         });
         OutputInfo();
      }

      private int GetRandomNum(int min, int max) => rnd.Next(min, max);
      
      private void OutputInfo()
      {
         this.Invoke((MethodInvoker)delegate
         {
            outBirdsOnBirdsFeeding.Text = BirdFeeding.CountBirdNow.ToString();
            outBirdsOnBranch.Text = branch.StartBirdInBranch.ToString();
         });
      }

      private async Task MoveBirdToBirdHome(object brd)
      {
         var flyingBird = brd as Bird;
         BirdFeeding.CountBirdNow += 1;
         branch.StartBirdInBranch -= 1;
         int finishPointX = birdFeeding.Location.X + birdFeeding.Location.X / 3;
         int finishPointY = birdFeeding.Location.Y + birdFeeding.Location.Y / 6;

         var leftOrRingth = RecognizeStartEndPoint(flyingBird.Location.X, finishPointX);
         var upOrDown = RecognizeStartEndPoint(flyingBird.Location.Y, finishPointY);
         while (true)
         {
            if (flyingBird.Location.X != finishPointX)
               flyingBird.Location = new Point(leftOrRingth(flyingBird.Location.X, 1), flyingBird.Location.Y);
            if (flyingBird.Location.Y != finishPointY)
               flyingBird.Location = new Point(flyingBird.Location.X, upOrDown(flyingBird.Location.Y, 1));
            if (flyingBird.Location.X == finishPointX && flyingBird.Location.Y == finishPointY)
               break;
            Thread.Sleep(timeFlyNextPixel);
         }
         flyingBird.Visible = false;
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
         branch = new Branch(0, Width, Height);
         birdFeeding = new BirdFeeding(capacityBirdFeeding, Width, Height);
         var elements = new List<Element> { new Bird(Width, Height), branch, birdFeeding };
         rnd = new Random();
         BirdFeeding.Sem = new Semaphore(3, 3);


         birdFeeding.BirdFlyingInto += MoveBirdToBirdHome;
         birdFeeding.BirdFlyingAway += LeaveBird;
         birdFeeding.SendMessage = OutputStateBirdFeeding;
         Bird.OnBirdAction += birdFeeding.FeedBirdsAsync;

         foreach (var x in elements)
         {
            this.Controls.Add(x);
         }
      }

      public void LeaveBird()
      {
         BirdFeeding.CountBirdNow -= 1;
         OutputInfo();
      }

      public void OutputStateBirdFeeding(string s)
      {
         history.Items.Add(s);
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

      private void reload_Click(object sender, EventArgs e)
      {
         history.Items.Clear();
      }
   }
}
