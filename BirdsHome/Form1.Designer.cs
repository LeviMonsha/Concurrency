namespace BirdsHome
{
   partial class Form1
   {
      /// <summary>
      /// Обязательная переменная конструктора.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Освободить все используемые ресурсы.
      /// </summary>
      /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Код, автоматически созданный конструктором форм Windows

      /// <summary>
      /// Требуемый метод для поддержки конструктора — не изменяйте 
      /// содержимое этого метода с помощью редактора кода.
      /// </summary>
      private void InitializeComponent()
      {
         this.history = new System.Windows.Forms.ListBox();
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.textBox2 = new System.Windows.Forms.TextBox();
         this.start = new System.Windows.Forms.Button();
         this.label3 = new System.Windows.Forms.Label();
         this.outBirdsOnBirdsFeeding = new System.Windows.Forms.Label();
         this.outBirdsOnBranch = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // history
         // 
         this.history.FormattingEnabled = true;
         this.history.ItemHeight = 20;
         this.history.Location = new System.Drawing.Point(12, 12);
         this.history.Name = "history";
         this.history.Size = new System.Drawing.Size(273, 144);
         this.history.TabIndex = 0;
         // 
         // textBox1
         // 
         this.textBox1.Location = new System.Drawing.Point(290, 23);
         this.textBox1.Name = "textBox1";
         this.textBox1.Size = new System.Drawing.Size(143, 26);
         this.textBox1.TabIndex = 1;
         this.textBox1.TextChanged += new System.EventHandler(this.TextBoxChanged_TextChanged);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(292, 64);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(141, 20);
         this.label1.TabIndex = 2;
         this.label1.Text = "частота подлёта";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(454, 64);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(143, 20);
         this.label2.TabIndex = 4;
         this.label2.Text = "время кормления";
         // 
         // textBox2
         // 
         this.textBox2.Location = new System.Drawing.Point(454, 23);
         this.textBox2.Name = "textBox2";
         this.textBox2.Size = new System.Drawing.Size(143, 26);
         this.textBox2.TabIndex = 3;
         this.textBox2.TextChanged += new System.EventHandler(this.TextBoxChanged_TextChanged);
         // 
         // start
         // 
         this.start.Location = new System.Drawing.Point(490, 102);
         this.start.Name = "start";
         this.start.Size = new System.Drawing.Size(75, 32);
         this.start.TabIndex = 5;
         this.start.Text = "start";
         this.start.UseVisualStyleBackColor = true;
         this.start.Click += new System.EventHandler(this.button1_Click);
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(651, 114);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(139, 20);
         this.label3.TabIndex = 6;
         this.label3.Text = "Птиц в кормушке";
         // 
         // outBirdsOnBirdsFeeding
         // 
         this.outBirdsOnBirdsFeeding.AutoSize = true;
         this.outBirdsOnBirdsFeeding.Location = new System.Drawing.Point(617, 114);
         this.outBirdsOnBirdsFeeding.Name = "outBirdsOnBirdsFeeding";
         this.outBirdsOnBirdsFeeding.Size = new System.Drawing.Size(18, 20);
         this.outBirdsOnBirdsFeeding.TabIndex = 7;
         this.outBirdsOnBirdsFeeding.Text = "0";
         // 
         // outBirdsOnBranch
         // 
         this.outBirdsOnBranch.AutoSize = true;
         this.outBirdsOnBranch.Location = new System.Drawing.Point(38, 401);
         this.outBirdsOnBranch.Name = "outBirdsOnBranch";
         this.outBirdsOnBranch.Size = new System.Drawing.Size(18, 20);
         this.outBirdsOnBranch.TabIndex = 9;
         this.outBirdsOnBranch.Text = "0";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(72, 401);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(118, 20);
         this.label5.TabIndex = 8;
         this.label5.Text = "Птиц на ветке";
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(800, 450);
         this.Controls.Add(this.outBirdsOnBranch);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.outBirdsOnBirdsFeeding);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.start);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.textBox2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.textBox1);
         this.Controls.Add(this.history);
         this.Name = "Form1";
         this.Text = "Form1";
         this.Load += new System.EventHandler(this.Form1_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ListBox history;
      private System.Windows.Forms.TextBox textBox1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox textBox2;
      private System.Windows.Forms.Button start;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label outBirdsOnBirdsFeeding;
      private System.Windows.Forms.Label outBirdsOnBranch;
      private System.Windows.Forms.Label label5;
   }
}

