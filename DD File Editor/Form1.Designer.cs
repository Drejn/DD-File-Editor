
namespace DD_File_Editor
{
    partial class Form1
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
            this.TreeView = new System.Windows.Forms.TreeView();
            this.b_load_dd_file = new System.Windows.Forms.Button();
            this.l_dd_file_path = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Layout_Properties = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TreeView
            // 
            this.TreeView.Location = new System.Drawing.Point(12, 120);
            this.TreeView.Name = "TreeView";
            this.TreeView.Size = new System.Drawing.Size(166, 583);
            this.TreeView.TabIndex = 0;
            // 
            // b_load_dd_file
            // 
            this.b_load_dd_file.Location = new System.Drawing.Point(15, 24);
            this.b_load_dd_file.Name = "b_load_dd_file";
            this.b_load_dd_file.Size = new System.Drawing.Size(109, 45);
            this.b_load_dd_file.TabIndex = 1;
            this.b_load_dd_file.Text = "Load DD File";
            this.b_load_dd_file.UseVisualStyleBackColor = true;
            this.b_load_dd_file.Click += new System.EventHandler(this.b_load_dd_file_Click);
            // 
            // l_dd_file_path
            // 
            this.l_dd_file_path.Location = new System.Drawing.Point(164, 35);
            this.l_dd_file_path.Name = "l_dd_file_path";
            this.l_dd_file_path.ReadOnly = true;
            this.l_dd_file_path.Size = new System.Drawing.Size(518, 22);
            this.l_dd_file_path.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "DD File Directory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "DD Map Content";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Layout_Properties
            // 
            this.Layout_Properties.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Layout_Properties.Location = new System.Drawing.Point(203, 120);
            this.Layout_Properties.Name = "Layout_Properties";
            this.Layout_Properties.Size = new System.Drawing.Size(883, 583);
            this.Layout_Properties.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(200, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Configuration Editor";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(785, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 45);
            this.button1.TabIndex = 7;
            this.button1.Text = "Load DD File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 715);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Layout_Properties);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.l_dd_file_path);
            this.Controls.Add(this.b_load_dd_file);
            this.Controls.Add(this.TreeView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView TreeView;
        private System.Windows.Forms.Button b_load_dd_file;
        private System.Windows.Forms.TextBox l_dd_file_path;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FlowLayoutPanel Layout_Properties;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}

