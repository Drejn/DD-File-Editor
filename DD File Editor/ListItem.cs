/*
 * This software uses Third Party Libraries
 * 
 * Cyotek.Windows.Forms.ColorPicker Library
 * https://github.com/cyotek/Cyotek.Windows.Forms.ColorPicker
 * Copyright © 2013-2017 Cyotek Ltd.
 * MIT License
 * 
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Cyotek.Windows.Forms;


namespace DD_File_Editor
{
    public partial class ListItem : Form
    {

        public enum SelectedMenu
        {
            Objects,
            Lights,
            Walls,
            Patterns,
            Paths
        }

        public Dictionary<string, Levels> mapLevels;
        Dictionary<string,string> levelFromLabel;
        public string SelectedLevel;
        public SelectedMenu currentMenu;
        
       
        public ListItem()
        {
            InitializeComponent();
            
    }

        private void ListItem_Load(object sender, EventArgs e)
        {
            levelFromLabel = new Dictionary<string, string>();
            SelectedLevel = "";
            
        }


        void LevelSelection_Changed(object sender, EventArgs e)
        {
            if ((((RadioButton)sender).Checked))
            {
                string levelNum = levelFromLabel[((RadioButton)sender).Text];
                SelectedLevel = levelNum;

                switch (currentMenu)
                {
                    case SelectedMenu.Objects:

                        
                        Object[] objects = mapLevels[levelNum].objects;
                        

                        DataGridViewCheckBoxColumn object_mirror = new DataGridViewCheckBoxColumn();
                        object_mirror.HeaderText = "Mirror";
                        object_mirror.Name = "Mirror";

                        DataGridViewCheckBoxColumn object_shadow = new DataGridViewCheckBoxColumn();
                        object_shadow.HeaderText = "Shadow";
                        object_shadow.Name = "Shadow";

                        dgv_data.Columns.Add("Name", "Name");
                        dgv_data.Columns.Add("Position", "Position");
                        dgv_data.Columns.Add("Rotation", "Rotation");
                        dgv_data.Columns.Add("Scale", "Scale");
                        dgv_data.Columns.Add(object_mirror);
                        dgv_data.Columns.Add("Texture", "Texture");
                        dgv_data.Columns.Add("Layer", "Layer");
                        dgv_data.Columns.Add(object_shadow);
                        dgv_data.Columns.Add("Node ID", "Node ID");

                        
                        for (int i = 0; i < objects.Count(); i++)
                        {
                            string[] objectname = objects[i].texture.Split('/');

                            dgv_data.Rows.Add(objectname.Last(), objects[i].position, objects[i].rotation, objects[i].scale, objects[i].mirror, objects[i].texture, objects[i].layer, objects[i].shadow, objects[i].node_id);
                        }

                        break;

                    case SelectedMenu.Lights:

                        
                        Light[] lights = mapLevels[levelNum].lights;
                        

                        DataGridViewCheckBoxColumn light_shadow = new DataGridViewCheckBoxColumn();
                        light_shadow.HeaderText = "Shadow";
                        light_shadow.Name = "Shadow";

                        DataGridViewButtonColumn light_color_edit = new DataGridViewButtonColumn();
                        light_color_edit.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        light_color_edit.Width = 30;

                        dgv_data.Columns.Add("Name", "Name");
                        dgv_data.Columns.Add("Position", "Position");
                        dgv_data.Columns.Add("Rotation", "Rotation");
                        dgv_data.Columns.Add("Intensity", "Intensity");
                        dgv_data.Columns.Add("Color", "Color");
                        dgv_data.Columns.Add(light_color_edit);
                        dgv_data.Columns.Add("Texture", "Texture");
                        dgv_data.Columns.Add(light_shadow);
                        dgv_data.Columns.Add("Node ID", "Node ID");

                        for (int i = 0; i < lights.Count(); i++)
                        {
                            string[] lighttname = lights[i].texture.Split('/');
                            dgv_data.Rows.Add(lighttname.Last(), lights[i].position, lights[i].rotation, lights[i].intensity, lights[i].color.ToUpper(),"",lights[i].texture, lights[i].shadows, lights[i].node_id);
                            dgv_data.Rows[i].Cells["Color"].Style.BackColor = System.Drawing.Color.FromArgb(Int32.Parse(lights[i].color.Replace("#", ""), System.Globalization.NumberStyles.HexNumber));
                            
                        }

                        break;


                    case SelectedMenu.Walls:

                        Wall[] walls = mapLevels[levelNum].walls;


                        DataGridViewCheckBoxColumn wall_shadow = new DataGridViewCheckBoxColumn();
                        wall_shadow.HeaderText = "Shadow";
                        wall_shadow.Name = "Shadow";

                        DataGridViewCheckBoxColumn wall_loop = new DataGridViewCheckBoxColumn();
                        wall_loop.HeaderText = "Loop";
                        wall_loop.Name = "Loop";

                        DataGridViewCheckBoxColumn wall_normalizeuv = new DataGridViewCheckBoxColumn();
                        wall_normalizeuv.HeaderText = "Normalize UV";
                        wall_normalizeuv.Name = "Normalize UV";

                        DataGridViewButtonColumn wall_color_edit = new DataGridViewButtonColumn();
                        wall_color_edit.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        wall_color_edit.Width = 30;

                        dgv_data.Columns.Add("Name", "Name");
                        dgv_data.Columns.Add("Points", "Points");
                        dgv_data.Columns.Add("Texture", "Texture");
                        dgv_data.Columns.Add("Color", "Color");
                        dgv_data.Columns.Add(wall_color_edit);
                        
                        dgv_data.Columns.Add(wall_loop);
                        dgv_data.Columns.Add("Type", "Type");
                        dgv_data.Columns.Add("Joint", "Joint");
                        dgv_data.Columns.Add(wall_normalizeuv);
                        dgv_data.Columns.Add(wall_shadow);
                        dgv_data.Columns.Add("Node ID", "Node ID");


                        for (int i = 0; i < walls.Count(); i++)
                        {
                            string[] wallname = walls[i].texture.Split('/');
                            dgv_data.Rows.Add(wallname.Last(), walls[i].points, walls[i].texture, walls[i].color.ToUpper(), "", walls[i].loop, walls[i].type, walls[i].joint, walls[i].normalize_uv, walls[i].shadow, walls[i].node_id);
                            dgv_data.Rows[i].Cells["Color"].Style.BackColor = System.Drawing.Color.FromArgb(Int32.Parse(walls[i].color.Replace("#", ""), System.Globalization.NumberStyles.HexNumber));

                        }


                        break;

                    case SelectedMenu.Patterns:

                        Pattern[] patterns = mapLevels[levelNum].patterns;

                        DataGridViewCheckBoxColumn pattern_outline = new DataGridViewCheckBoxColumn();
                        pattern_outline.HeaderText = "Outline";
                        pattern_outline.Name = "Outline";


                        DataGridViewButtonColumn pattern_color_edit = new DataGridViewButtonColumn();
                        pattern_color_edit.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        pattern_color_edit.Width = 30;

                        dgv_data.Columns.Add("Name", "Name");
                        dgv_data.Columns.Add("Position", "Position");
                        dgv_data.Columns.Add("Points", "Points");
                        dgv_data.Columns.Add("Layer", "Layer");

                        dgv_data.Columns.Add("Color", "Color");
                        dgv_data.Columns.Add(pattern_color_edit);

                        dgv_data.Columns.Add(pattern_outline);
                        dgv_data.Columns.Add("Texture", "Texture");
                        dgv_data.Columns.Add("Rotation", "Rotation");
                        dgv_data.Columns.Add("Node ID", "Node ID");

                        for (int i = 0; i < patterns.Count(); i++)
                        {
                            string[] patternname = patterns[i].texture.Split('/');
                            dgv_data.Rows.Add(patternname.Last(), patterns[i].position, patterns[i].points, patterns[i].layer, patterns[i].color,"", patterns[i].outline, patterns[i].texture, patterns[i].rotation, patterns[i].node_id);
                            dgv_data.Rows[i].Cells["Color"].Style.BackColor = System.Drawing.Color.FromArgb(Int32.Parse(patterns[i].color.Replace("#", ""), System.Globalization.NumberStyles.HexNumber));
                        }


                        break;
                    case SelectedMenu.Paths:

                        Path[] paths = mapLevels[levelNum].paths;

                        DataGridViewCheckBoxColumn path_fadein = new DataGridViewCheckBoxColumn();
                        path_fadein.HeaderText = "Fade In";
                        path_fadein.Name = "Fade In";

                        DataGridViewCheckBoxColumn path_fadeout = new DataGridViewCheckBoxColumn();
                        path_fadeout.HeaderText = "Fade Out";
                        path_fadeout.Name = "Fade Out";

                        DataGridViewCheckBoxColumn path_grow = new DataGridViewCheckBoxColumn();
                        path_grow.HeaderText = "Grow";
                        path_grow.Name = "Grow";

                        DataGridViewCheckBoxColumn path_shrink = new DataGridViewCheckBoxColumn();
                        path_shrink.HeaderText = "Shrink";
                        path_shrink.Name = "Shrink";

                        DataGridViewCheckBoxColumn path_loop = new DataGridViewCheckBoxColumn();
                        path_loop.HeaderText = "Loop";
                        path_loop.Name = "Loop";

                        dgv_data.Columns.Add("Name", "Name");
                        dgv_data.Columns.Add("Position", "Position");
                        dgv_data.Columns.Add("Rotation", "Rotation");
                        dgv_data.Columns.Add("Scale", "Scale");

                        dgv_data.Columns.Add("Edit Points", "Edit Points");
                        dgv_data.Columns.Add("Smoothness", "Smoothness");

                        dgv_data.Columns.Add("Texture", "Texture");
                        dgv_data.Columns.Add("Width", "Width");

                        dgv_data.Columns.Add("Layer", "Layer");
                        dgv_data.Columns.Add(path_fadein);
                        dgv_data.Columns.Add(path_fadeout);
                        dgv_data.Columns.Add(path_grow);
                        dgv_data.Columns.Add(path_shrink);
                        dgv_data.Columns.Add(path_loop);

                        


                        dgv_data.Columns.Add("Node ID", "Node ID");

                        for (int i = 0; i < paths.Count(); i++)
                        {
                            string[] pathname = paths[i].texture.Split('/');
                            dgv_data.Rows.Add(pathname.Last(), paths[i].position, paths[i].rotation, paths[i].scale, paths[i].edit_points, paths[i].smoothness, paths[i].texture, paths[i].width, paths[i].layer, paths[i].fade_in, paths[i].fade_out, paths[i].grow, paths[i].shrink, paths[i].loop, paths[i].node_id);
                        }

                        break;
                }

                foreach (DataGridViewColumn column in dgv_data.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }


            }
        }





        public void SetupObjects(Dictionary<string, Levels> levels)
        {
            mapLevels = levels;
            foreach(string key in levels.Keys)
            {
                RadioButton levelname = new RadioButton();
                levelname.Text = levels[key].label;
                levelname.Size = new Size(90,40);
                levelname.CheckAlign = ContentAlignment.TopCenter;
                levelname.BackColor = Color.LightSteelBlue;
                levelname.ImageAlign = ContentAlignment.BottomCenter;
                levelname.TextAlign = ContentAlignment.BottomCenter;
                levelname.CheckedChanged += new EventHandler(LevelSelection_Changed);
                PanelLevelSelect.Controls.Add(levelname);
                levelFromLabel.Add(levels[key].label, key);
            }

        }





        public void SetupLights(Dictionary<string, Levels> levels)
        {
            mapLevels = levels;
            foreach (string key in levels.Keys)
            {
                RadioButton levelname = new RadioButton();
                levelname.Text = levels[key].label;
                levelname.Size = new Size(90, 40);
                levelname.CheckAlign = ContentAlignment.TopCenter;
                levelname.BackColor = Color.LightSteelBlue;
                levelname.ImageAlign = ContentAlignment.BottomCenter;
                levelname.TextAlign = ContentAlignment.BottomCenter;
                levelname.CheckedChanged += new EventHandler(LevelSelection_Changed);
                PanelLevelSelect.Controls.Add(levelname);
                levelFromLabel.Add(levels[key].label, key);
            }
            
        }

        public void SetupWalls(Dictionary<string, Levels> levels)
        {
            mapLevels = levels;
            foreach (string key in levels.Keys)
            {
                RadioButton levelname = new RadioButton();
                levelname.Text = levels[key].label;
                levelname.Size = new Size(90, 40);
                levelname.CheckAlign = ContentAlignment.TopCenter;
                levelname.BackColor = Color.LightSteelBlue;
                levelname.ImageAlign = ContentAlignment.BottomCenter;
                levelname.TextAlign = ContentAlignment.BottomCenter;
                levelname.CheckedChanged += new EventHandler(LevelSelection_Changed);
                PanelLevelSelect.Controls.Add(levelname);
                levelFromLabel.Add(levels[key].label, key);
            }
        }

        public void SetupPatterns(Dictionary<string, Levels> levels)
        {
            mapLevels = levels;
            foreach (string key in levels.Keys)
            {
                RadioButton levelname = new RadioButton();
                levelname.Text = levels[key].label;
                levelname.Size = new Size(90, 40);
                levelname.CheckAlign = ContentAlignment.TopCenter;
                levelname.BackColor = Color.LightSteelBlue;
                levelname.ImageAlign = ContentAlignment.BottomCenter;
                levelname.TextAlign = ContentAlignment.BottomCenter;
                levelname.CheckedChanged += new EventHandler(LevelSelection_Changed);
                PanelLevelSelect.Controls.Add(levelname);
                levelFromLabel.Add(levels[key].label, key);
            }
        }

        public void SetupPaths(Dictionary<string, Levels> levels)
        {
            mapLevels = levels;
            foreach (string key in levels.Keys)
            {
                RadioButton levelname = new RadioButton();
                levelname.Text = levels[key].label;
                levelname.Size = new Size(90, 40);
                levelname.CheckAlign = ContentAlignment.TopCenter;
                levelname.BackColor = Color.LightSteelBlue;
                levelname.ImageAlign = ContentAlignment.BottomCenter;
                levelname.TextAlign = ContentAlignment.BottomCenter;
                levelname.CheckedChanged += new EventHandler(LevelSelection_Changed);
                PanelLevelSelect.Controls.Add(levelname);
                levelFromLabel.Add(levels[key].label, key);
            }
        }

        private void dgv_data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            if(grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                
                string pickedcolor = OpenColorPicker(grid, e);

                if(pickedcolor != "")
                {
                    dgv_data.Rows[e.RowIndex].Cells[e.ColumnIndex-1].Style.BackColor = System.Drawing.Color.FromArgb(Int32.Parse(pickedcolor.Replace("#", ""), System.Globalization.NumberStyles.HexNumber));
                    dgv_data.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value = pickedcolor;
                }
            }
        }



        private string OpenColorPicker(DataGridView sender, DataGridViewCellEventArgs e)
        {

            ColorPickerDialog colorPicker = new ColorPickerDialog();

            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                return colorPicker.Color.ToArgb().ToString("X8");
            }
            return "";
        }
    }
}
