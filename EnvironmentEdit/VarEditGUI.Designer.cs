namespace EnvironmentEdit
{
    partial class VarEditGUI
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
            this.NameL = new System.Windows.Forms.Label();
            this.DataL = new System.Windows.Forms.Label();
            this.NameTB = new System.Windows.Forms.TextBox();
            this.DataTB = new System.Windows.Forms.TextBox();
            this.OKB = new System.Windows.Forms.Button();
            this.CancelB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NameL
            // 
            this.NameL.AutoSize = true;
            this.NameL.Location = new System.Drawing.Point(13, 13);
            this.NameL.Name = "NameL";
            this.NameL.Size = new System.Drawing.Size(35, 13);
            this.NameL.TabIndex = 0;
            this.NameL.Text = "Name";
            // 
            // DataL
            // 
            this.DataL.AutoSize = true;
            this.DataL.Location = new System.Drawing.Point(13, 44);
            this.DataL.Name = "DataL";
            this.DataL.Size = new System.Drawing.Size(30, 13);
            this.DataL.TabIndex = 1;
            this.DataL.Text = "Data";
            // 
            // NameTB
            // 
            this.NameTB.Location = new System.Drawing.Point(54, 10);
            this.NameTB.Name = "NameTB";
            this.NameTB.Size = new System.Drawing.Size(518, 20);
            this.NameTB.TabIndex = 2;
            // 
            // DataTB
            // 
            this.DataTB.Location = new System.Drawing.Point(54, 41);
            this.DataTB.Name = "DataTB";
            this.DataTB.Size = new System.Drawing.Size(518, 20);
            this.DataTB.TabIndex = 3;
            // 
            // OKB
            // 
            this.OKB.Location = new System.Drawing.Point(416, 68);
            this.OKB.Name = "OKB";
            this.OKB.Size = new System.Drawing.Size(75, 23);
            this.OKB.TabIndex = 4;
            this.OKB.Text = "OK";
            this.OKB.UseVisualStyleBackColor = true;
            // 
            // CancelB
            // 
            this.CancelB.Location = new System.Drawing.Point(497, 68);
            this.CancelB.Name = "CancelB";
            this.CancelB.Size = new System.Drawing.Size(75, 23);
            this.CancelB.TabIndex = 5;
            this.CancelB.Text = "Cancel";
            this.CancelB.UseVisualStyleBackColor = true;
            // 
            // VarEditGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 103);
            this.Controls.Add(this.CancelB);
            this.Controls.Add(this.OKB);
            this.Controls.Add(this.DataTB);
            this.Controls.Add(this.NameTB);
            this.Controls.Add(this.DataL);
            this.Controls.Add(this.NameL);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VarEditGUI";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Edit Variable";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameL;
        private System.Windows.Forms.Label DataL;
        private System.Windows.Forms.TextBox NameTB;
        private System.Windows.Forms.TextBox DataTB;
        private System.Windows.Forms.Button OKB;
        private System.Windows.Forms.Button CancelB;
    }
}