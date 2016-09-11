
partial class BankUIForm
{
   /// <summary>
   /// Required designer variable.
   /// </summary>
   private System.ComponentModel.IContainer components = null;

   /// <summary>
   /// Clean up any resources being used.
   /// </summary>
   /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
   protected override void Dispose(bool disposing)
   {
      if (disposing && (components != null))
      {
         components.Dispose();
      }
      base.Dispose(disposing);
   }

   #region Windows Form Designer generated code

   /// <summary>
   /// Required method for Designer support - do not modify
   /// the contents of this method with the code editor.
   /// </summary>
   private void InitializeComponent()
   {
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.accountTextBox = new System.Windows.Forms.TextBox();
      this.firstNameTextBox = new System.Windows.Forms.TextBox();
      this.lastNameTextBox = new System.Windows.Forms.TextBox();
      this.balanceTextBox = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(50, 53);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(43, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Account";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(50, 98);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(53, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "First Name";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(49, 145);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(54, 13);
      this.label3.TabIndex = 2;
      this.label3.Text = "Last Name";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(49, 187);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(42, 13);
      this.label4.TabIndex = 3;
      this.label4.Text = "Balance";
      // 
      // accountTextBox
      // 
      this.accountTextBox.Location = new System.Drawing.Point(149, 44);
      this.accountTextBox.Name = "accountTextBox";
      this.accountTextBox.Size = new System.Drawing.Size(153, 20);
      this.accountTextBox.TabIndex = 4;
      // 
      // firstNameTextBox
      // 
      this.firstNameTextBox.Location = new System.Drawing.Point(149, 91);
      this.firstNameTextBox.Name = "firstNameTextBox";
      this.firstNameTextBox.Size = new System.Drawing.Size(153, 20);
      this.firstNameTextBox.TabIndex = 5;
      // 
      // lastNameTextBox
      // 
      this.lastNameTextBox.Location = new System.Drawing.Point(149, 138);
      this.lastNameTextBox.Name = "lastNameTextBox";
      this.lastNameTextBox.Size = new System.Drawing.Size(153, 20);
      this.lastNameTextBox.TabIndex = 6;
      // 
      // balanceTextBox
      // 
      this.balanceTextBox.Location = new System.Drawing.Point(149, 184);
      this.balanceTextBox.Name = "balanceTextBox";
      this.balanceTextBox.Size = new System.Drawing.Size(153, 20);
      this.balanceTextBox.TabIndex = 7;
      // 
      // BankUIForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(353, 261);
      this.Controls.Add(this.balanceTextBox);
      this.Controls.Add(this.lastNameTextBox);
      this.Controls.Add(this.firstNameTextBox);
      this.Controls.Add(this.accountTextBox);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "BankUIForm";
      this.ResumeLayout(false);
      this.PerformLayout();

   }

   #endregion

   public System.Windows.Forms.TextBox accountTextBox;
   public System.Windows.Forms.Label label1;
   public System.Windows.Forms.Label label2;
   public System.Windows.Forms.Label label3;
   public System.Windows.Forms.Label label4;
   public System.Windows.Forms.TextBox firstNameTextBox;
   public System.Windows.Forms.TextBox lastNameTextBox;
   public System.Windows.Forms.TextBox balanceTextBox;
}

