
namespace DD_File_Editor
{
    partial class ListItem
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_data = new System.Windows.Forms.DataGridView();
            this.rdb_levelname = new System.Windows.Forms.RadioButton();
            this.colorEditorManager1 = new Cyotek.Windows.Forms.ColorEditorManager();
            this.PanelLevelSelect = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).BeginInit();
            this.PanelLevelSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_data
            // 
            this.dgv_data.AllowUserToAddRows = false;
            this.dgv_data.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dgv_data.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_data.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_data.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_data.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_data.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_data.EnableHeadersVisualStyles = false;
            this.dgv_data.GridColor = System.Drawing.SystemColors.Control;
            this.dgv_data.Location = new System.Drawing.Point(0, 60);
            this.dgv_data.Name = "dgv_data";
            this.dgv_data.RowHeadersVisible = false;
            this.dgv_data.RowHeadersWidth = 51;
            this.dgv_data.RowTemplate.Height = 24;
            this.dgv_data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_data.Size = new System.Drawing.Size(907, 481);
            this.dgv_data.TabIndex = 0;
            this.dgv_data.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_data_CellContentClick);
            // 
            // rdb_levelname
            // 
            this.rdb_levelname.AutoSize = true;
            this.rdb_levelname.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rdb_levelname.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.rdb_levelname.Location = new System.Drawing.Point(3, 3);
            this.rdb_levelname.Name = "rdb_levelname";
            this.rdb_levelname.Size = new System.Drawing.Size(87, 37);
            this.rdb_levelname.TabIndex = 0;
            this.rdb_levelname.TabStop = true;
            this.rdb_levelname.Text = "Level Name";
            this.rdb_levelname.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.rdb_levelname.UseVisualStyleBackColor = true;
            this.rdb_levelname.Visible = false;
            // 
            // PanelLevelSelect
            // 
            this.PanelLevelSelect.BackColor = System.Drawing.Color.LightSteelBlue;
            this.PanelLevelSelect.Controls.Add(this.rdb_levelname);
            this.PanelLevelSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelLevelSelect.Location = new System.Drawing.Point(0, 0);
            this.PanelLevelSelect.Name = "PanelLevelSelect";
            this.PanelLevelSelect.Size = new System.Drawing.Size(907, 60);
            this.PanelLevelSelect.TabIndex = 2;
            // 
            // ListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 541);
            this.Controls.Add(this.dgv_data);
            this.Controls.Add(this.PanelLevelSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ListItem";
            this.ShowInTaskbar = false;
            this.Text = "ListItem";
            this.Load += new System.EventHandler(this.ListItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).EndInit();
            this.PanelLevelSelect.ResumeLayout(false);
            this.PanelLevelSelect.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgv_data;
        private Cyotek.Windows.Forms.ColorEditorManager colorEditorManager1;
        private System.Windows.Forms.RadioButton rdb_levelname;
        public System.Windows.Forms.FlowLayoutPanel PanelLevelSelect;
    }
}