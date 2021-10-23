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

        DataTable dt_objects, dt_lights, dt_walls, dt_patterns, dt_paths;

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

             
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                string json = sr.ReadToEnd();
                JsonSerializerSettings setting = new JsonSerializerSettings();

                MapContent = JsonConvert.DeserializeObject<Rootobject>(json);
                sr.Close();


                string[] fullpath = openFileDialog1.FileName.Split('\\');
                filename = fullpath.Last();


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

            int objcounter = 0;
            int wallcounter = 0;
            int patterncounter = 0;
            int lightcounter = 0;
            int pathcounter = 0;

            foreach (string key in MapContent.world.levels.Keys)
            {
                objcounter += MapContent.world.levels[key].objects.Count();
                wallcounter += MapContent.world.levels[key].walls.Count();
                patterncounter += MapContent.world.levels[key].patterns.Count();
                lightcounter += MapContent.world.levels[key].lights.Count();
                pathcounter += MapContent.world.levels[key].paths.Count();

                foreach (Object obj in MapContent.world.levels[key].objects)
                {
                    string[] objectname = obj.texture.Split('/');
                    if (!dic_objects.ContainsKey(objectname.Last()))
                    {
                        dic_objects.Add(objectname.Last(), obj);
                    }
                }
                foreach (Light light in MapContent.world.levels[key].lights)
                {
                    string[] lightname = light.texture.Split('/');
                    if (!dic_lights.ContainsKey(lightname.Last()))
                    {
                        dic_lights.Add(lightname.Last(), light);
                    }
                }
                foreach (Wall wall in MapContent.world.levels[key].walls)
                {
                    string[] wallname = wall.texture.Split('/');
                    if (!dic_walls.ContainsKey(wallname.Last()))
                    {
                        dic_walls.Add(wallname.Last(), wall);
                    }
                }
                foreach (Pattern pattern in MapContent.world.levels[key].patterns)
                {
                    string[] patternname = pattern.texture.Split('/');
                    if (!dic_patterns.ContainsKey(patternname.Last()))
                    {
                        dic_patterns.Add(patternname.Last(), pattern);
                    }
                }
                foreach (Path path in MapContent.world.levels[key].paths)
                {
                    string[] pathname = path.texture.Split('/');
                    if (!dic_paths.ContainsKey(pathname.Last()))
                    {
                        dic_paths.Add(pathname.Last(), path);
                    }
                }
            }

            lbl_objects_count.Text = objcounter.ToString();
            lbl_lights_count.Text = lightcounter.ToString();
            lbl_walls_count.Text = wallcounter.ToString();
            lbl_patterns_count.Text = patterncounter.ToString();
            lbl_paths_count.Text = pathcounter.ToString();

            src_bar.KeyDown += new KeyEventHandler(src_bar_KeyDown);

            
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
            if(MapContent == null)
            {
                return;
            }
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
            li.dt_objects = dt_objects;
            li.dt_lights = dt_lights;
            li.dt_walls = dt_walls;
            li.dt_patterns = dt_patterns;
            li.dt_paths = dt_paths;

            li.tog_groupedit = tog_group_edit;


            li.TopLevel = false;
            PanelTab.Controls.Add(li);
            li.Dock = DockStyle.Fill;
            
            li.Show();

            li.currentMenu = ListItem.SelectedMenu.Objects;

            li.SetupObjects(MapContent.world.levels);
            Application.DoEvents();
            if (selectedlevel != "" && selectedlevel != null) { 
            
                for (int i = 0; i < li.PanelLevelSelect.Controls.Count; i++)
                {
                    if (((RadioButton)li.PanelLevelSelect.Controls[i]).Text == MapContent.world.levels[selectedlevel].label)
                    {
                        ((RadioButton)li.PanelLevelSelect.Controls[i]).Checked = true;
                    }
                }
            }

            tog_group_edit.Checked = false;
        }

        private void btn_lights_Click(object sender, EventArgs e)
        {
            if (MapContent == null)
            {
                return;
            }
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
            li.dt_objects = dt_objects;
            li.dt_lights = dt_lights;
            li.dt_walls = dt_walls;
            li.dt_patterns = dt_patterns;
            li.dt_paths = dt_paths;

            li.tog_groupedit = tog_group_edit;

            li.TopLevel = false;
            li.SelectedLevel = selectedlevel;
            PanelTab.Controls.Add(li);
            li.Dock = DockStyle.Fill;
            li.Show();

            li.currentMenu = ListItem.SelectedMenu.Lights;
            
            li.SetupLights(MapContent.world.levels);
            Application.DoEvents();
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

            tog_group_edit.Checked = false;
        }

        private void btn_walls_Click(object sender, EventArgs e)
        {
            if (MapContent == null)
            {
                return;
            }
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
            li.dt_objects = dt_objects;
            li.dt_lights = dt_lights;
            li.dt_walls = dt_walls;
            li.dt_patterns = dt_patterns;
            li.dt_paths = dt_paths;

            li.tog_groupedit = tog_group_edit;

            li.TopLevel = false;
            PanelTab.Controls.Add(li);
            li.Dock = DockStyle.Fill;
            li.Show();

            li.currentMenu = ListItem.SelectedMenu.Walls;

            li.SetupWalls(MapContent.world.levels);
            Application.DoEvents();
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

            tog_group_edit.Checked = false;
        }

        private void btn_patterns_Click(object sender, EventArgs e)
        {
            if (MapContent == null)
            {
                return;
            }
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
            li.dt_objects = dt_objects;
            li.dt_lights = dt_lights;
            li.dt_walls = dt_walls;
            li.dt_patterns = dt_patterns;
            li.dt_paths = dt_paths;

            li.tog_groupedit = tog_group_edit;

            li.TopLevel = false;
            PanelTab.Controls.Add(li);
            li.Dock = DockStyle.Fill;
            li.Show();

            li.currentMenu = ListItem.SelectedMenu.Patterns;

            li.SetupPatterns(MapContent.world.levels);
            Application.DoEvents();
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

            tog_group_edit.Checked = false;
        }

        private void btn_paths_Click(object sender, EventArgs e)
        {
            if (MapContent == null)
            {
                return;
            }
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
            li.dt_objects = dt_objects;
            li.dt_lights = dt_lights;
            li.dt_walls = dt_walls;
            li.dt_patterns = dt_patterns;
            li.dt_paths = dt_paths;

            li.tog_groupedit = tog_group_edit;

            li.TopLevel = false;
            PanelTab.Controls.Add(li);
            li.Dock = DockStyle.Fill;
            li.Show();
            li.currentMenu = ListItem.SelectedMenu.Paths;

            li.SetupPaths(MapContent.world.levels);
            Application.DoEvents();
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

            tog_group_edit.Checked = false;
        }

        private void tog_group_edit_CheckedChanged(object sender, EventArgs e)
        {
            if(li != null)
            {
                if (((ToggleControl)sender).Checked){
                    if (li.dgv_data.Rows.Count <= 0)
                    {
                        li.IsGroupEditEnabled = false;
                        ((ToggleControl)sender).Checked = false;
                        return;
                    }

                    
                    switch (li.currentMenu)
                    {
                        case ListItem.SelectedMenu.Objects:
                            if (li.dgv_data.Rows.Count > 0)
                            {
                                li.OnGroupEditEnabled_Objects(dic_objects, ((ToggleControl)sender).Checked);

                            }
                            
                            break;
                        case ListItem.SelectedMenu.Lights:
                            if (li.dgv_data.Rows.Count > 0)
                            {
                                li.OnGroupEditEnabled_Lights(dic_lights, ((ToggleControl)sender).Checked);

                            }
                            
                            break;
                        case ListItem.SelectedMenu.Walls:
                            if (li.dgv_data.Rows.Count> 0)
                            {
                                li.OnGroupEditEnabled_Walls(dic_walls, ((ToggleControl)sender).Checked);
                            }
                            
                            break;
                        case ListItem.SelectedMenu.Patterns:
                            if (li.dgv_data.Rows.Count > 0)
                            {
                                li.OnGroupEditEnabled_Patterns(dic_patterns, ((ToggleControl)sender).Checked);
                            }
                            
                            break;
                        case ListItem.SelectedMenu.Paths:
                            if (li.dgv_data.Rows.Count > 0)
                            {
                                li.OnGroupEditEnabled_Paths(dic_paths, ((ToggleControl)sender).Checked);
                            }
                            
                            break;
                    }
                }
                else
                {
                    li.IsGroupEditEnabled = false;
                    if (li.dgv_data.Rows.Count > 0)
                    {
                        UpdateCurrentView();
                        li.RefreshGrid();
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

                    dt_objects = li.dt_objects;

                    MapContent.world.levels[selectedlevel].objects = li.objectsByNodeID.Values.ToArray();

                    /*
                    for(int i =0;i< li.dgv_data.Rows.Count;i++)
                    {
                        if(tog_group_edit.Checked == true)
                        {
                            
                        }
                        else
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
                    }
                    */
                    break;
                case ListItem.SelectedMenu.Lights:

                    dt_lights = li.dt_lights;
                    MapContent.world.levels[selectedlevel].lights = li.lightsByNodeID.Values.ToArray();
                    

                    /*
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
                    */
                    break;
                case ListItem.SelectedMenu.Walls:

                    dt_walls = li.dt_walls;
                    MapContent.world.levels[selectedlevel].walls = li.wallsByNodeID.Values.ToArray();
                    /*
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
                    */
                    break;
                case ListItem.SelectedMenu.Patterns:

                    dt_patterns = li.dt_patterns;

                    MapContent.world.levels[selectedlevel].patterns = li.patternsByNodeID.Values.ToArray();

                    /*
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
                    */
                    break;
                case ListItem.SelectedMenu.Paths:

                    dt_paths = li.dt_paths;

                    MapContent.world.levels[selectedlevel].paths = li.pathsByNodeID.Values.ToArray();
                    /*
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
                    */
                    break;
            }
        }



        private void btn_src_submit_Click(object sender, EventArgs e)
        {
            if (li != null)
            {
                if (src_bar.Text == "")
                {
                    (li.dgv_data.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    (li.dgv_data.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name LIKE '%{0}%'", src_bar.Text);
                }
            }
        }


        private void src_bar_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                btn_src_submit_Click(sender, e);
        }


    }
}
