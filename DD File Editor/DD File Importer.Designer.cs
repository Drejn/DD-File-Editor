
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btn_Repack = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_paths = new System.Windows.Forms.Button();
            this.btn_patterns = new System.Windows.Forms.Button();
            this.btn_walls = new System.Windows.Forms.Button();
            this.btn_lights = new System.Windows.Forms.Button();
            this.btn_objects = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lbl_filename = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.b_load_dd_file = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.Header = new System.Windows.Forms.Panel();
            this.tog_group_edit = new DD_File_Editor.ToggleControl();
            this.btn_src_submit = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl_patterns_count = new System.Windows.Forms.Label();
            this.lbl_lights_count = new System.Windows.Forms.Label();
            this.lbl_paths_count = new System.Windows.Forms.Label();
            this.lbl_walls_count = new System.Windows.Forms.Label();
            this.lbl_objects_count = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.src_bar = new System.Windows.Forms.TextBox();
            this.PanelTab = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.Header.SuspendLayout();
            this.SuspendLayout();
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
            this.btn_Repack.Size = new System.Drawing.Size(219, 80);
            this.btn_Repack.TabIndex = 8;
            this.btn_Repack.Text = "Repack";
            this.btn_Repack.UseVisualStyleBackColor = false;
            this.btn_Repack.Click += new System.EventHandler(this.btn_Repack_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btn_paths);
            this.panel1.Controls.Add(this.btn_patterns);
            this.panel1.Controls.Add(this.btn_walls);
            this.panel1.Controls.Add(this.btn_Repack);
            this.panel1.Controls.Add(this.btn_lights);
            this.panel1.Controls.Add(this.btn_objects);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 715);
            this.panel1.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 633);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(219, 2);
            this.panel3.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 500);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(219, 2);
            this.panel2.TabIndex = 17;
            // 
            // btn_paths
            // 
            this.btn_paths.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_paths.FlatAppearance.BorderSize = 0;
            this.btn_paths.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_paths.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_paths.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_paths.Image = global::DD_File_Editor.Properties.Resources.trail;
            this.btn_paths.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_paths.Location = new System.Drawing.Point(0, 440);
            this.btn_paths.Name = "btn_paths";
            this.btn_paths.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btn_paths.Size = new System.Drawing.Size(219, 60);
            this.btn_paths.TabIndex = 16;
            this.btn_paths.Text = "   Paths";
            this.btn_paths.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
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
            this.btn_patterns.Image = global::DD_File_Editor.Properties.Resources.platform;
            this.btn_patterns.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_patterns.Location = new System.Drawing.Point(0, 380);
            this.btn_patterns.Name = "btn_patterns";
            this.btn_patterns.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btn_patterns.Size = new System.Drawing.Size(219, 60);
            this.btn_patterns.TabIndex = 15;
            this.btn_patterns.Text = "   Patterns";
            this.btn_patterns.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
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
            this.btn_walls.Image = global::DD_File_Editor.Properties.Resources.defensive_wall;
            this.btn_walls.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_walls.Location = new System.Drawing.Point(0, 320);
            this.btn_walls.Name = "btn_walls";
            this.btn_walls.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btn_walls.Size = new System.Drawing.Size(219, 60);
            this.btn_walls.TabIndex = 14;
            this.btn_walls.Text = "   Walls";
            this.btn_walls.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
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
            this.btn_lights.Image = global::DD_File_Editor.Properties.Resources.light_bulb;
            this.btn_lights.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_lights.Location = new System.Drawing.Point(0, 260);
            this.btn_lights.Name = "btn_lights";
            this.btn_lights.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btn_lights.Size = new System.Drawing.Size(219, 60);
            this.btn_lights.TabIndex = 13;
            this.btn_lights.Text = "   Lights";
            this.btn_lights.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
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
            this.btn_objects.Image = global::DD_File_Editor.Properties.Resources.wooden_crate;
            this.btn_objects.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_objects.Location = new System.Drawing.Point(0, 200);
            this.btn_objects.Name = "btn_objects";
            this.btn_objects.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btn_objects.Size = new System.Drawing.Size(219, 60);
            this.btn_objects.TabIndex = 12;
            this.btn_objects.Text = "   Objects";
            this.btn_objects.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_objects.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_objects.UseVisualStyleBackColor = true;
            this.btn_objects.Click += new System.EventHandler(this.btn_objects_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(56)))));
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.lbl_filename);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.b_load_dd_file);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(219, 200);
            this.panel6.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 120);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(219, 2);
            this.panel8.TabIndex = 19;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 198);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(219, 2);
            this.panel7.TabIndex = 18;
            // 
            // lbl_filename
            // 
            this.lbl_filename.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lbl_filename.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbl_filename.Location = new System.Drawing.Point(51, 127);
            this.lbl_filename.Name = "lbl_filename";
            this.lbl_filename.Size = new System.Drawing.Size(253, 68);
            this.lbl_filename.TabIndex = 3;
            this.lbl_filename.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.ForeColor = System.Drawing.Color.Gainsboro;
            this.label5.Location = new System.Drawing.Point(3, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Map:";
            // 
            // b_load_dd_file
            // 
            this.b_load_dd_file.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.b_load_dd_file.Dock = System.Windows.Forms.DockStyle.Top;
            this.b_load_dd_file.FlatAppearance.BorderSize = 0;
            this.b_load_dd_file.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_load_dd_file.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_load_dd_file.ForeColor = System.Drawing.Color.Gainsboro;
            this.b_load_dd_file.Location = new System.Drawing.Point(0, 0);
            this.b_load_dd_file.Name = "b_load_dd_file";
            this.b_load_dd_file.Size = new System.Drawing.Size(219, 120);
            this.b_load_dd_file.TabIndex = 1;
            this.b_load_dd_file.Text = "Load DD File";
            this.b_load_dd_file.UseVisualStyleBackColor = false;
            this.b_load_dd_file.Click += new System.EventHandler(this.b_load_dd_file_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(56)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(219, 715);
            this.panel5.TabIndex = 18;
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(86)))));
            this.Header.Controls.Add(this.label8);
            this.Header.Controls.Add(this.tog_group_edit);
            this.Header.Controls.Add(this.btn_src_submit);
            this.Header.Controls.Add(this.panel4);
            this.Header.Controls.Add(this.lbl_patterns_count);
            this.Header.Controls.Add(this.lbl_lights_count);
            this.Header.Controls.Add(this.lbl_paths_count);
            this.Header.Controls.Add(this.lbl_walls_count);
            this.Header.Controls.Add(this.lbl_objects_count);
            this.Header.Controls.Add(this.label7);
            this.Header.Controls.Add(this.label4);
            this.Header.Controls.Add(this.label6);
            this.Header.Controls.Add(this.label3);
            this.Header.Controls.Add(this.label2);
            this.Header.Controls.Add(this.label1);
            this.Header.Controls.Add(this.src_bar);
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Location = new System.Drawing.Point(219, 0);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(1148, 120);
            this.Header.TabIndex = 2;
            // 
            // tog_group_edit
            // 
            this.tog_group_edit.Location = new System.Drawing.Point(122, 40);
            this.tog_group_edit.Name = "tog_group_edit";
            this.tog_group_edit.Size = new System.Drawing.Size(56, 24);
            this.tog_group_edit.TabIndex = 19;
            this.tog_group_edit.UseVisualStyleBackColor = true;
            this.tog_group_edit.CheckedChanged += new System.EventHandler(this.tog_group_edit_CheckedChanged);
            // 
            // btn_src_submit
            // 
            this.btn_src_submit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btn_src_submit.FlatAppearance.BorderSize = 0;
            this.btn_src_submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_src_submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_src_submit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_src_submit.Location = new System.Drawing.Point(551, 82);
            this.btn_src_submit.Name = "btn_src_submit";
            this.btn_src_submit.Size = new System.Drawing.Size(66, 25);
            this.btn_src_submit.TabIndex = 16;
            this.btn_src_submit.Text = "Enter";
            this.btn_src_submit.UseVisualStyleBackColor = false;
            this.btn_src_submit.Click += new System.EventHandler(this.btn_src_submit_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 118);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1148, 2);
            this.panel4.TabIndex = 15;
            // 
            // lbl_patterns_count
            // 
            this.lbl_patterns_count.AutoSize = true;
            this.lbl_patterns_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_patterns_count.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbl_patterns_count.Location = new System.Drawing.Point(959, 43);
            this.lbl_patterns_count.Name = "lbl_patterns_count";
            this.lbl_patterns_count.Size = new System.Drawing.Size(23, 25);
            this.lbl_patterns_count.TabIndex = 13;
            this.lbl_patterns_count.Text = "0";
            // 
            // lbl_lights_count
            // 
            this.lbl_lights_count.AutoSize = true;
            this.lbl_lights_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_lights_count.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbl_lights_count.Location = new System.Drawing.Point(959, 9);
            this.lbl_lights_count.Name = "lbl_lights_count";
            this.lbl_lights_count.Size = new System.Drawing.Size(23, 25);
            this.lbl_lights_count.TabIndex = 12;
            this.lbl_lights_count.Text = "0";
            // 
            // lbl_paths_count
            // 
            this.lbl_paths_count.AutoSize = true;
            this.lbl_paths_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_paths_count.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbl_paths_count.Location = new System.Drawing.Point(728, 68);
            this.lbl_paths_count.Name = "lbl_paths_count";
            this.lbl_paths_count.Size = new System.Drawing.Size(23, 25);
            this.lbl_paths_count.TabIndex = 11;
            this.lbl_paths_count.Text = "0";
            // 
            // lbl_walls_count
            // 
            this.lbl_walls_count.AutoSize = true;
            this.lbl_walls_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_walls_count.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbl_walls_count.Location = new System.Drawing.Point(728, 40);
            this.lbl_walls_count.Name = "lbl_walls_count";
            this.lbl_walls_count.Size = new System.Drawing.Size(23, 25);
            this.lbl_walls_count.TabIndex = 10;
            this.lbl_walls_count.Text = "0";
            // 
            // lbl_objects_count
            // 
            this.lbl_objects_count.AutoSize = true;
            this.lbl_objects_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_objects_count.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbl_objects_count.Location = new System.Drawing.Point(728, 9);
            this.lbl_objects_count.Name = "lbl_objects_count";
            this.lbl_objects_count.Size = new System.Drawing.Size(23, 25);
            this.lbl_objects_count.TabIndex = 9;
            this.lbl_objects_count.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.ForeColor = System.Drawing.Color.Gainsboro;
            this.label7.Location = new System.Drawing.Point(661, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 25);
            this.label7.TabIndex = 8;
            this.label7.Text = "Paths:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(863, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Patterns:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.ForeColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(662, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 25);
            this.label6.TabIndex = 6;
            this.label6.Text = "Walls:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(883, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Lights:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(647, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Objects:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(35, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Search:";
            // 
            // src_bar
            // 
            this.src_bar.Location = new System.Drawing.Point(122, 86);
            this.src_bar.Name = "src_bar";
            this.src_bar.Size = new System.Drawing.Size(396, 22);
            this.src_bar.TabIndex = 1;
            // 
            // PanelTab
            // 
            this.PanelTab.BackColor = System.Drawing.SystemColors.MenuBar;
            this.PanelTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelTab.Location = new System.Drawing.Point(219, 120);
            this.PanelTab.Name = "PanelTab";
            this.PanelTab.Size = new System.Drawing.Size(1148, 595);
            this.PanelTab.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label8.ForeColor = System.Drawing.Color.Gainsboro;
            this.label8.Location = new System.Drawing.Point(6, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 25);
            this.label8.TabIndex = 20;
            this.label8.Text = "Group Edit:";
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
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.Header.ResumeLayout(false);
            this.Header.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btn_Repack;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_paths;
        private System.Windows.Forms.Button btn_patterns;
        private System.Windows.Forms.Button btn_walls;
        private System.Windows.Forms.Button btn_lights;
        private System.Windows.Forms.Button btn_objects;
        private System.Windows.Forms.Panel Header;
        private System.Windows.Forms.Panel PanelTab;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox src_bar;
        private System.Windows.Forms.Label lbl_objects_count;
        private System.Windows.Forms.Label lbl_patterns_count;
        private System.Windows.Forms.Label lbl_lights_count;
        private System.Windows.Forms.Label lbl_paths_count;
        private System.Windows.Forms.Label lbl_walls_count;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button b_load_dd_file;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_filename;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btn_src_submit;
        private ToggleControl tog_group_edit;
        private System.Windows.Forms.Label label8;
    }
}

