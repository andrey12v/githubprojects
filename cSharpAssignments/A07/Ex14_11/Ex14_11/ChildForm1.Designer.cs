namespace Ex14_11
{
    partial class ChildForm1
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
            this.SuspendLayout();
            // 
            // ChildForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 375);
            this.Name = "ChildForm1";
            this.Text = "ChildForm1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChildForm1_FormClosed);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PainterForm_MouseUp);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PainterForm_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PainterForm_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion


    }
}