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
using Newtonsoft.Json;
using System.IO;
using System.Windows.Media;
using Cyotek.Windows.Forms;



namespace DD_File_Editor
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// The class that stores the informations from and to the Json Map File
        /// </summary>
        Rootobject MapContent;

        /// <summary>
        /// the loaded file name without extension
        /// </summary>
        string filename;

        /// <summary>
        /// tracks the current selected map level
        /// </summary>
        string selectedlevel;
        
        /// <summary>
        /// the path where the loaded file is located
        /// </summary>
        string path;

        Dictionary<string, Light> dic_lights;

        Dictionary<string, Wall> dic_walls;

        Dictionary<string, Object> dic_objects;

        Dictionary<string, Pattern> dic_patterns;

        Dictionary<string, Path> dic_paths;

        ListItem li;

        public Form1()
        {
            InitializeComponent();
        }

        private void b_load_dd_file_Click(object sender, EventArgs e)
        {
            PanelTab.Controls.Clear();

            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Dungeondraft File (*.dungeondraft_map)|*.dungeondraft_map";
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                //l_dd_file_path.Text = openFileDialog1.FileName;
                //StreamReader sr = new StreamReader(l_dd_file_path.Text);

                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                string json = sr.ReadToEnd();
                JsonSerializerSettings setting = new JsonSerializerSettings();

                MapContent = JsonConvert.DeserializeObject<Rootobject>(json);
                sr.Close();

                //string[] fullpath = l_dd_file_path.Text.FileName.Split('\\');

                string[] fullpath = openFileDialog1.FileName.Split('\\');
                filename = fullpath.Last();

                //path = l_dd_file_path.Text.Replace(filename, "");

                path = openFileDialog1.FileName.Replace(filename, "");
                filename = filename.Replace(".dungeondraft_map", "");

                lbl_filename.Text = filename;
            }
            else
                return;

            dic_lights = new Dictionary<string, Light>();
            dic_objects = new Dictionary<string, Object>();
            dic_paths = new Dictionary<string, Path>();
            dic_patterns = new Dictionary<string, Pattern>();
            dic_walls = new Dictionary<string, Wall>();

        }


        private void btn_Repack_Click(object sender, EventArgs e)
        {
            if (li != null)
            {
                UpdateCurrentView();
            }
            var setting = new JsonSerializerSettings();
            setting.NullValueHandling = NullValueHandling.Ignore;
            string json = JsonConvert.SerializeObject(MapContent, Formatting.Indented,setting);
            
            File.WriteAllText(path + filename + "_backup.dungeondraft_map",json);
            
        }






        private void btn_objects_Click(object sender, EventArgs e)
        {
            if (li != null)
            {
                UpdateCurrentView();
            }

            PanelTab.Controls.Clear();
            
            
            btn_objects.BackColor = System.Drawing.Color.SteelBlue;
            btn_lights.BackColor = System.Drawing.Color.FromArgb(51, 51, 76);
            btn_walls.BackColor = System.Drawing.Color.FromArgb(51, 51, 76);
            btn_patterns.BackColor = System.Drawing.Color.FromArgb(51, 51, 76);
            btn_paths.BackColor = System.Drawing.Color.FromArgb(51, 51, 76);

            li = new ListItem();
            li.TopLevel = false;
            PanelTab.Controls.Add(li);
            li.Dock = DockStyle.Fill;
            li.Show();

            li.currentMenu = ListItem.SelectedMenu.Objects;

            li.SetupObjects(MapContent.world.levels);

            if (selectedlevel != "" && selectedlevel != null) { 
            
                for (int i = 0; i < li.PanelLevelSelect.Controls.Count; i++)
                {
                    if (((RadioButton)li.PanelLevelSelect.Controls[i]).Text == MapContent.world.levels[selectedlevel].label)
                    {
                        ((RadioButton)li.PanelLevelSelect.Controls[i]).Checked = true;
                    }
                }
            }
            
           
        }

        private void btn_lights_Click(object sender, EventArgs e)
        {
            if (li != null)
            {
                UpdateCurrentView();
            }


            PanelTab.Controls.Clear();

            btn_objects.BackColor = System.Drawing.Color.FromArgb(51, 51, 76);
            btn_lights.BackColor = System.Drawing.Color.SteelBlue;
            btn_walls.BackColor = System.Drawing.Color.FromArgb(51, 51, 76);
            btn_patterns.BackColor = System.Drawing.Color.FromArgb(51, 51, 76);
            btn_paths.BackColor = System.Drawing.Color.FromArgb(51, 51, 76);

            li = new ListItem();
            li.TopLevel = false;
            li.SelectedLevel = selectedlevel;
            PanelTab.Controls.Add(li);
            li.Dock = DockStyle.Fill;
            li.Show();

            li.currentMenu = ListItem.SelectedMenu.Lights;

            li.SetupLights(MapContent.world.levels);

            if (selectedlevel != "" && selectedlevel != null)
            {
                for (int i = 0; i < li.PanelLevelSelect.Controls.Count; i++)
                {
                    if (((RadioButton)li.PanelLevelSelect.Controls[i]).Text == MapContent.world.levels[selectedlevel].label)
                    {
                        ((RadioButton)li.PanelLevelSelect.Controls[i]).Checked = true;
                    }
                }
            }
            
            
          
        }

        private void btn_walls_Click(object sender, EventArgs e)
        {
            if (li != null)
            {
                UpdateCurrentView();
            }

            PanelTab.Controls.Clear();

            btn_objects.BackColor = System.Drawing.Color.FromArgb(51, 51, 76);
            btn_lights.BackColor = System.Drawing.Color.FromArgb(51, 51, 76);
            btn_walls.BackColor = System.Drawing.Color.SteelBlue;
            btn_patterns.BackColor = System.Drawing.Color.FromArgb(51, 51, 76);
            btn_paths.BackColor = System.Drawing.Color.FromArgb(51, 51, 76);

            li = new ListItem();
            li.TopLevel = false;
            PanelTab.Controls.Add(li);
            li.Dock = DockStyle.Fill;
            li.Show();

            li.currentMenu = ListItem.SelectedMenu.Walls;

            li.SetupWalls(MapContent.world.levels);

            if (selectedlevel != "" && selectedlevel != null)
            {
                for (int i = 0; i < li.PanelLevelSelect.Controls.Count; i++)
                {
                    if (((RadioButton)li.PanelLevelSelect.Controls[i]).Text == MapContent.world.levels[selectedlevel].label)
                    {
                        ((RadioButton)li.PanelLevelSelect.Controls[i]).Checked = true;
                    }
                }
            }
            
           
        }

        private void btn_patterns_Click(object sender, EventArgs e)
        {
            if (li != null)
            {
                UpdateCurrentView();
            }

            PanelTab.Controls.Clear();

            btn_objects.BackColor = System.Drawing.Color.FromArgb(51, 51, 76);
            btn_lights.BackColor = System.Drawing.Color.FromArgb(51, 51, 76);
            btn_walls.BackColor = System.Drawing.Color.FromArgb(51, 51, 76);
            btn_patterns.BackColor = System.Drawing.Color.SteelBlue;
            btn_paths.BackColor = System.Drawing.Color.FromArgb(51, 51, 76);

            li = new ListItem();
            li.TopLevel = false;
            PanelTab.Controls.Add(li);
            li.Dock = DockStyle.Fill;
            li.Show();

            li.currentMenu = ListItem.SelectedMenu.Patterns;

            li.SetupPatterns(MapContent.world.levels);

            if (selectedlevel != "" && selectedlevel != null)
            {
                for (int i = 0; i < li.PanelLevelSelect.Controls.Count; i++)
                {
                    if (((RadioButton)li.PanelLevelSelect.Controls[i]).Text == MapContent.world.levels[selectedlevel].label)
                    {
                        ((RadioButton)li.PanelLevelSelect.Controls[i]).Checked = true;
                    }
                }
            }
            
            
        }

        private void btn_paths_Click(object sender, EventArgs e)
        {
            if (li != null)
            {
                UpdateCurrentView();
            }

            PanelTab.Controls.Clear();

            btn_objects.BackColor = System.Drawing.Color.FromArgb(51, 51, 76);
            btn_lights.BackColor = System.Drawing.Color.FromArgb(51, 51, 76);
            btn_walls.BackColor = System.Drawing.Color.FromArgb(51, 51, 76);
            btn_patterns.BackColor = System.Drawing.Color.FromArgb(51, 51, 76);
            btn_paths.BackColor = System.Drawing.Color.SteelBlue;

            li = new ListItem();
            
            li.TopLevel = false;
            PanelTab.Controls.Add(li);
            li.Dock = DockStyle.Fill;
            li.Show();
            li.currentMenu = ListItem.SelectedMenu.Paths;

            li.SetupPaths(MapContent.world.levels);

            if (selectedlevel != "" && selectedlevel != null)
            {
                for (int i = 0; i < li.PanelLevelSelect.Controls.Count; i++)
                {
                    if (((RadioButton)li.PanelLevelSelect.Controls[i]).Text == MapContent.world.levels[selectedlevel].label)
                    {
                        ((RadioButton)li.PanelLevelSelect.Controls[i]).Checked = true;
                    }
                }
            }
            
            
        }


        private void UpdateCurrentView()
        {
            selectedlevel = li.SelectedLevel;

            switch (li.currentMenu)
            {
                case ListItem.SelectedMenu.Objects:
                    
                    for(int i =0;i< li.dgv_data.Rows.Count;i++)
                    {
                        
                        MapContent.world.levels[selectedlevel].objects[i].position = li.dgv_data.Rows[i].Cells["Position"].Value.ToString();
                        MapContent.world.levels[selectedlevel].objects[i].rotation = (float)li.dgv_data.Rows[i].Cells["Rotation"].Value;
                        MapContent.world.levels[selectedlevel].objects[i].scale = li.dgv_data.Rows[i].Cells["Scale"].Value.ToString();
                        MapContent.world.levels[selectedlevel].objects[i].mirror = (bool)li.dgv_data.Rows[i].Cells["Mirror"].Value;
                        MapContent.world.levels[selectedlevel].objects[i].texture = li.dgv_data.Rows[i].Cells["Texture"].Value.ToString();
                        MapContent.world.levels[selectedlevel].objects[i].layer = (int)li.dgv_data.Rows[i].Cells["Layer"].Value;
                        MapContent.world.levels[selectedlevel].objects[i].shadow = (bool)li.dgv_data.Rows[i].Cells["Shadow"].Value;
                        MapContent.world.levels[selectedlevel].objects[i].node_id = li.dgv_data.Rows[i].Cells["Node ID"].Value.ToString();
                        
                    }
                    break;
                case ListItem.SelectedMenu.Lights:
                    for (int i = 0; i < li.dgv_data.Rows.Count; i++)
                    {
                        MapContent.world.levels[selectedlevel].lights[i].position = li.dgv_data.Rows[i].Cells["Position"].Value.ToString();
                        MapContent.world.levels[selectedlevel].lights[i].rotation = (float)li.dgv_data.Rows[i].Cells["Rotation"].Value;
                        MapContent.world.levels[selectedlevel].lights[i].intensity = (float)li.dgv_data.Rows[i].Cells["Intensity"].Value;
                        MapContent.world.levels[selectedlevel].lights[i].color = li.dgv_data.Rows[i].Cells["Color"].Value.ToString();
                        MapContent.world.levels[selectedlevel].lights[i].texture = li.dgv_data.Rows[i].Cells["Texture"].Value.ToString();
                        MapContent.world.levels[selectedlevel].lights[i].shadows = (bool)li.dgv_data.Rows[i].Cells["Shadow"].Value;
                        MapContent.world.levels[selectedlevel].lights[i].node_id = li.dgv_data.Rows[i].Cells["Node ID"].Value.ToString();

                    }
                    break;
                case ListItem.SelectedMenu.Walls:
                    for (int i = 0; i < li.dgv_data.Rows.Count; i++)
                    {
                        MapContent.world.levels[selectedlevel].walls[i].points = li.dgv_data.Rows[i].Cells["Points"].Value.ToString();
                        MapContent.world.levels[selectedlevel].walls[i].color = li.dgv_data.Rows[i].Cells["Color"].Value.ToString();
                        MapContent.world.levels[selectedlevel].walls[i].texture = li.dgv_data.Rows[i].Cells["Texture"].Value.ToString();
                        MapContent.world.levels[selectedlevel].walls[i].loop = (bool)li.dgv_data.Rows[i].Cells["Loop"].Value;
                        MapContent.world.levels[selectedlevel].walls[i].type = (int)li.dgv_data.Rows[i].Cells["Type"].Value;
                        MapContent.world.levels[selectedlevel].walls[i].joint = (int)li.dgv_data.Rows[i].Cells["Joint"].Value;
                        MapContent.world.levels[selectedlevel].walls[i].normalize_uv = (bool)li.dgv_data.Rows[i].Cells["Normalize UV"].Value;
                        MapContent.world.levels[selectedlevel].walls[i].shadow = (bool)li.dgv_data.Rows[i].Cells["Shadow"].Value;
                        MapContent.world.levels[selectedlevel].walls[i].node_id = li.dgv_data.Rows[i].Cells["Node ID"].Value.ToString();

                    }
                    break;
                case ListItem.SelectedMenu.Patterns:
                    for (int i = 0; i < li.dgv_data.Rows.Count; i++)
                    {
                        MapContent.world.levels[selectedlevel].patterns[i].position = li.dgv_data.Rows[i].Cells["Position"].Value.ToString();
                        MapContent.world.levels[selectedlevel].patterns[i].points = li.dgv_data.Rows[i].Cells["Points"].Value.ToString();
                        MapContent.world.levels[selectedlevel].patterns[i].layer = (int)li.dgv_data.Rows[i].Cells["Layer"].Value;
                        MapContent.world.levels[selectedlevel].patterns[i].color = li.dgv_data.Rows[i].Cells["Color"].Value.ToString();
                        MapContent.world.levels[selectedlevel].patterns[i].outline = (bool)li.dgv_data.Rows[i].Cells["Outline"].Value;
                        MapContent.world.levels[selectedlevel].patterns[i].texture = li.dgv_data.Rows[i].Cells["Texture"].Value.ToString();
                        MapContent.world.levels[selectedlevel].patterns[i].rotation = (float)li.dgv_data.Rows[i].Cells["Rotation"].Value;
                        MapContent.world.levels[selectedlevel].patterns[i].node_id = li.dgv_data.Rows[i].Cells["Node ID"].Value.ToString();

                    }
                    break;
                case ListItem.SelectedMenu.Paths:
                    for (int i = 0; i < li.dgv_data.Rows.Count; i++)
                    {

                        MapContent.world.levels[selectedlevel].paths[i].position = li.dgv_data.Rows[i].Cells["Position"].Value.ToString();
                        MapContent.world.levels[selectedlevel].paths[i].rotation = (float)li.dgv_data.Rows[i].Cells["Rotation"].Value;
                        MapContent.world.levels[selectedlevel].paths[i].scale = li.dgv_data.Rows[i].Cells["Scale"].Value.ToString();
                        MapContent.world.levels[selectedlevel].paths[i].edit_points = li.dgv_data.Rows[i].Cells["Edit Points"].Value.ToString();
                        MapContent.world.levels[selectedlevel].paths[i].smoothness = (float)li.dgv_data.Rows[i].Cells["Smoothness"].Value;
                        MapContent.world.levels[selectedlevel].paths[i].texture = li.dgv_data.Rows[i].Cells["Texture"].Value.ToString();
                        MapContent.world.levels[selectedlevel].paths[i].width = (float)li.dgv_data.Rows[i].Cells["Width"].Value;
                        MapContent.world.levels[selectedlevel].paths[i].layer = (int)li.dgv_data.Rows[i].Cells["Layer"].Value;
                        MapContent.world.levels[selectedlevel].paths[i].fade_in = (bool)li.dgv_data.Rows[i].Cells["Fade In"].Value;
                        MapContent.world.levels[selectedlevel].paths[i].fade_out = (bool)li.dgv_data.Rows[i].Cells["Fade Out"].Value;
                        MapContent.world.levels[selectedlevel].paths[i].grow = (bool)li.dgv_data.Rows[i].Cells["Grow"].Value;
                        MapContent.world.levels[selectedlevel].paths[i].shrink = (bool)li.dgv_data.Rows[i].Cells["Shrink"].Value;
                        MapContent.world.levels[selectedlevel].paths[i].loop = (bool)li.dgv_data.Rows[i].Cells["Loop"].Value;
                        MapContent.world.levels[selectedlevel].paths[i].node_id = li.dgv_data.Rows[i].Cells["Node ID"].Value.ToString();

                    }
                    break;
            }


        }
    }
}
