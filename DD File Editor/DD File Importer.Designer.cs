
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
            this.b_load_dd_file = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btn_Repack = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_paths = new System.Windows.Forms.Button();
            this.btn_patterns = new System.Windows.Forms.Button();
            this.btn_walls = new System.Windows.Forms.Button();
            this.btn_lights = new System.Windows.Forms.Button();
            this.btn_objects = new System.Windows.Forms.Button();
            this.Corner = new System.Windows.Forms.Panel();
            this.lbl_filename = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Header = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.PanelTab = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.Corner.SuspendLayout();
            this.Header.SuspendLayout();
            this.SuspendLayout();
            // 
            // b_load_dd_file
            // 
            this.b_load_dd_file.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_load_dd_file.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_load_dd_file.ForeColor = System.Drawing.Color.Gainsboro;
            this.b_load_dd_file.Location = new System.Drawing.Point(84, 20);
            this.b_load_dd_file.Name = "b_load_dd_file";
            this.b_load_dd_file.Size = new System.Drawing.Size(141, 45);
            this.b_load_dd_file.TabIndex = 1;
            this.b_load_dd_file.Text = "Load DD File";
            this.b_load_dd_file.UseVisualStyleBackColor = true;
            this.b_load_dd_file.Click += new System.EventHandler(this.b_load_dd_file_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            // 
            // btn_Repack
            // 
            this.btn_Repack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(86)))));
            this.btn_Repack.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_Repack.FlatAppearance.BorderSize = 0;
            this.btn_Repack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Repack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btn_Repack.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_Repack.Location = new System.Drawing.Point(0, 635);
            this.btn_Repack.Name = "btn_Repack";
            this.btn_Repack.Size = new System.Drawing.Size(304, 80);
            this.btn_Repack.TabIndex = 8;
            this.btn_Repack.Text = "Repack";
            this.btn_Repack.UseVisualStyleBackColor = false;
            this.btn_Repack.Click += new System.EventHandler(this.btn_Repack_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panel1.Controls.Add(this.btn_paths);
            this.panel1.Controls.Add(this.btn_patterns);
            this.panel1.Controls.Add(this.btn_walls);
            this.panel1.Controls.Add(this.btn_Repack);
            this.panel1.Controls.Add(this.btn_lights);
            this.panel1.Controls.Add(this.btn_objects);
            this.panel1.Controls.Add(this.Corner);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 715);
            this.panel1.TabIndex = 9;
            // 
            // btn_paths
            // 
            this.btn_paths.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_paths.FlatAppearance.BorderSize = 0;
            this.btn_paths.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_paths.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_paths.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_paths.Location = new System.Drawing.Point(0, 360);
            this.btn_paths.Name = "btn_paths";
            this.btn_paths.Size = new System.Drawing.Size(304, 60);
            this.btn_paths.TabIndex = 16;
            this.btn_paths.Text = "Paths";
            this.btn_paths.UseVisualStyleBackColor = true;
            this.btn_paths.Click += new System.EventHandler(this.btn_paths_Click);
            // 
            // btn_patterns
            // 
            this.btn_patterns.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_patterns.FlatAppearance.BorderSize = 0;
            this.btn_patterns.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_patterns.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_patterns.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_patterns.Location = new System.Drawing.Point(0, 300);
            this.btn_patterns.Name = "btn_patterns";
            this.btn_patterns.Size = new System.Drawing.Size(304, 60);
            this.btn_patterns.TabIndex = 15;
            this.btn_patterns.Text = "Patterns";
            this.btn_patterns.UseVisualStyleBackColor = true;
            this.btn_patterns.Click += new System.EventHandler(this.btn_patterns_Click);
            // 
            // btn_walls
            // 
            this.btn_walls.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_walls.FlatAppearance.BorderSize = 0;
            this.btn_walls.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_walls.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_walls.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_walls.Location = new System.Drawing.Point(0, 240);
            this.btn_walls.Name = "btn_walls";
            this.btn_walls.Size = new System.Drawing.Size(304, 60);
            this.btn_walls.TabIndex = 14;
            this.btn_walls.Text = "Walls";
            this.btn_walls.UseVisualStyleBackColor = true;
            this.btn_walls.Click += new System.EventHandler(this.btn_walls_Click);
            // 
            // btn_lights
            // 
            this.btn_lights.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_lights.FlatAppearance.BorderSize = 0;
            this.btn_lights.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_lights.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_lights.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_lights.Location = new System.Drawing.Point(0, 180);
            this.btn_lights.Name = "btn_lights";
            this.btn_lights.Size = new System.Drawing.Size(304, 60);
            this.btn_lights.TabIndex = 13;
            this.btn_lights.Text = "Lights";
            this.btn_lights.UseVisualStyleBackColor = true;
            this.btn_lights.Click += new System.EventHandler(this.btn_lights_Click);
            // 
            // btn_objects
            // 
            this.btn_objects.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_objects.FlatAppearance.BorderSize = 0;
            this.btn_objects.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_objects.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_objects.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_objects.Location = new System.Drawing.Point(0, 120);
            this.btn_objects.Name = "btn_objects";
            this.btn_objects.Size = new System.Drawing.Size(304, 60);
            this.btn_objects.TabIndex = 12;
            this.btn_objects.Text = "Objects";
            this.btn_objects.UseVisualStyleBackColor = true;
            this.btn_objects.Click += new System.EventHandler(this.btn_objects_Click);
            // 
            // Corner
            // 
            this.Corner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(86)))));
            this.Corner.Controls.Add(this.lbl_filename);
            this.Corner.Controls.Add(this.label5);
            this.Corner.Controls.Add(this.b_load_dd_file);
            this.Corner.Dock = System.Windows.Forms.DockStyle.Top;
            this.Corner.Location = new System.Drawing.Point(0, 0);
            this.Corner.Name = "Corner";
            this.Corner.Size = new System.Drawing.Size(304, 120);
            this.Corner.TabIndex = 11;
            // 
            // lbl_filename
            // 
            this.lbl_filename.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lbl_filename.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbl_filename.Location = new System.Drawing.Point(45, 68);
            this.lbl_filename.Name = "lbl_filename";
            this.lbl_filename.Size = new System.Drawing.Size(253, 49);
            this.lbl_filename.TabIndex = 3;
            this.lbl_filename.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.ForeColor = System.Drawing.Color.Gainsboro;
            this.label5.Location = new System.Drawing.Point(3, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Map:";
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.Color.SteelBlue;
            this.Header.Controls.Add(this.label4);
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Location = new System.Drawing.Point(304, 0);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(1063, 120);
            this.Header.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(494, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 32);
            this.label4.TabIndex = 0;
            this.label4.Text = "HOME";
            // 
            // PanelTab
            // 
            this.PanelTab.BackColor = System.Drawing.SystemColors.MenuBar;
            this.PanelTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelTab.Location = new System.Drawing.Point(304, 120);
            this.PanelTab.Name = "PanelTab";
            this.PanelTab.Size = new System.Drawing.Size(1063, 595);
            this.PanelTab.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 715);
            this.Controls.Add(this.PanelTab);
            this.Controls.Add(this.Header);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Dungeondraft File Editor";
            this.panel1.ResumeLayout(false);
            this.Corner.ResumeLayout(false);
            this.Corner.PerformLayout();
            this.Header.ResumeLayout(false);
            this.Header.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button b_load_dd_file;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btn_Repack;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_paths;
        private System.Windows.Forms.Button btn_patterns;
        private System.Windows.Forms.Button btn_walls;
        private System.Windows.Forms.Button btn_lights;
        private System.Windows.Forms.Button btn_objects;
        private System.Windows.Forms.Panel Corner;
        private System.Windows.Forms.Panel Header;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_filename;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel PanelTab;
    }
}

