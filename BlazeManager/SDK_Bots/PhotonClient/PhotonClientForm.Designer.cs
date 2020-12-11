
namespace PhotonClient
{
    partial class PhotonClientForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 43);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(803, 357);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "// Logs Photon Manager\r\n// Magic3000 извини, что я писал в своем коде, что ты сос" +
    "ешь член, но если так оно и есть";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 413);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(695, 20);
            this.textBox2.TabIndex = 1;
            // 
            // buttonSend
            // 
            this.buttonSend.BackColor = System.Drawing.Color.Black;
            this.buttonSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSend.ForeColor = System.Drawing.Color.Lime;
            this.buttonSend.Location = new System.Drawing.Point(711, 409);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(99, 24);
            this.buttonSend.TabIndex = 2;
            this.buttonSend.Text = "S E N D";
            this.buttonSend.UseVisualStyleBackColor = false;
            // 
            // PhotonClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 445);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "PhotonClientForm";
            this.Text = "[BlazeEngine] Photon Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button buttonSend;
    }
}