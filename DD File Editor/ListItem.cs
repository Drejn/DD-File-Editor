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


        //<string, obj>
        
        public Dictionary<string, Levels> mapLevels;
        Dictionary<string,string> levelFromLabel;
        public string SelectedLevel;
        public SelectedMenu currentMenu;
        public DataTable dt_objects, dt_lights, dt_walls, dt_patterns, dt_paths;
        public DataTable dt_objects_filtered, dt_lights_filtered, dt_walls_filtered, dt_patterns_filtered, dt_paths_filtered;
        public bool IsGroupEditEnabled;

        public ToggleControl tog_groupedit;

        public Dictionary<string, Light> lightsByNodeID;

        public Dictionary<string, Wall> wallsByNodeID;

        public Dictionary<string, Object> objectsByNodeID;

        public Dictionary<string, Pattern> patternsByNodeID;

        public Dictionary<string, Path> pathsByNodeID;




        public ListItem()
        {
            InitializeComponent();
            
        }

        private void ListItem_Load(object sender, EventArgs e)
        {
            levelFromLabel = new Dictionary<string, string>();
            SelectedLevel = "";
            dgv_data.CellPainting += new DataGridViewCellPaintingEventHandler(dgv_data_CellPainting);
            dgv_data.CellValueChanged += new DataGridViewCellEventHandler(dgv_data_CellValueChanged);
            
    }

        public void RefreshGrid()
        {

            switch (currentMenu)
            {
                case SelectedMenu.Objects:

                    
                    dgv_data.DataSource = null;
                    dgv_data.Rows.Clear();

                    Object[] objects = mapLevels[SelectedLevel].objects;

                    DataGridViewCheckBoxColumn object_mirror = new DataGridViewCheckBoxColumn();
                    object_mirror.HeaderText = "Mirror";
                    object_mirror.Name = "Mirror";

                    DataGridViewCheckBoxColumn object_shadow = new DataGridViewCheckBoxColumn();
                    object_shadow.HeaderText = "Shadow";
                    object_shadow.Name = "Shadow";


                    dt_objects = new DataTable();


                    dt_objects.Columns.Add("Name", typeof(string));
                    dt_objects.Columns.Add("Position", typeof(string));
                    dt_objects.Columns.Add("Rotation", typeof(float));
                    dt_objects.Columns.Add("Scale", typeof(string));
                    dt_objects.Columns.Add("Mirror", typeof(bool));
                    dt_objects.Columns.Add("Texture", typeof(string));
                    dt_objects.Columns.Add("Layer", typeof(int));
                    dt_objects.Columns.Add("Shadow", typeof(bool));
                    dt_objects.Columns.Add("Node ID", typeof(string));


                    for (int i = 0; i < objects.Count(); i++)
                    {
                        string[] objectname = objects[i].texture.Split('/');
                        dt_objects.Rows.Add(objectname.Last(), objects[i].position, objects[i].rotation, objects[i].scale, objects[i].mirror, objects[i].texture, objects[i].layer, objects[i].shadow, objects[i].node_id);

                    }


                    dgv_data.DataSource = dt_objects;
                    break;

                case SelectedMenu.Lights:

                    dgv_data.Columns.RemoveAt(5);
                    dgv_data.DataSource = null;
                    dgv_data.Rows.Clear();

                    
                    Light[] lights = mapLevels[SelectedLevel].lights;


                    DataGridViewCheckBoxColumn light_shadow = new DataGridViewCheckBoxColumn();
                    light_shadow.HeaderText = "Shadow";
                    light_shadow.Name = "Shadow";

                    DataGridViewButtonColumn light_color_edit = new DataGridViewButtonColumn();
                    light_color_edit.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    light_color_edit.Width = 30;
                    
                    dt_lights = new DataTable();

                    dt_lights.Columns.Add("Name", typeof(string));
                    dt_lights.Columns.Add("Position", typeof(string));
                    dt_lights.Columns.Add("Rotation", typeof(float));
                    dt_lights.Columns.Add("Intensity", typeof(float));
                    dt_lights.Columns.Add("Color", typeof(string));

                    dt_lights.Columns.Add("Texture", typeof(string));
                    dt_lights.Columns.Add("Shadow", typeof(bool));
                    dt_lights.Columns.Add("Node ID", typeof(string));

                    for (int i = 0; i < lights.Count(); i++)
                    {
                        string[] lighttname = lights[i].texture.Split('/');
                        dt_lights.Rows.Add(lighttname.Last(), lights[i].position, lights[i].rotation, lights[i].intensity, lights[i].color.ToUpper(), lights[i].texture, lights[i].shadows, lights[i].node_id);
                    }

                    


                    dgv_data.DataSource = dt_lights;
                    dgv_data.Columns.Insert(5, light_color_edit);
                    for (int i = 0; i < lights.Count(); i++)
                    {
                        dgv_data.Rows[i].Cells["Color"].Style.BackColor = System.Drawing.Color.FromArgb(Int32.Parse(lights[i].color.Replace("#", ""), System.Globalization.NumberStyles.HexNumber));
                    }

                    break;


                case SelectedMenu.Walls:
                    dgv_data.Columns.RemoveAt(4);
                    dgv_data.DataSource = null;
                    dgv_data.Rows.Clear();


                    Wall[] walls = mapLevels[SelectedLevel].walls;


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
                    

                    dt_walls = new DataTable();

                    dt_walls.Columns.Add("Name", typeof(string));
                    dt_walls.Columns.Add("Points", typeof(string));
                    dt_walls.Columns.Add("Texture", typeof(string));
                    dt_walls.Columns.Add("Color", typeof(string));

                    dt_walls.Columns.Add("Loop", typeof(bool));
                    dt_walls.Columns.Add("Type", typeof(int));
                    dt_walls.Columns.Add("Joint", typeof(int));
                    dt_walls.Columns.Add("Normalize UV", typeof(bool));
                    dt_walls.Columns.Add("Shadow", typeof(bool));
                    dt_walls.Columns.Add("Node ID", typeof(string));


                    for (int i = 0; i < walls.Count(); i++)
                    {
                        string[] wallname = walls[i].texture.Split('/');
                        dt_walls.Rows.Add(wallname.Last(), walls[i].points, walls[i].texture, walls[i].color.ToUpper(), walls[i].loop, walls[i].type, walls[i].joint, walls[i].normalize_uv, walls[i].shadow, walls[i].node_id);
                    }
                    


                    dgv_data.DataSource = dt_walls;
                    dgv_data.Columns.Insert(4, wall_color_edit);

                    for (int i = 0; i < walls.Count(); i++)
                    {
                        dgv_data.Rows[i].Cells["Color"].Style.BackColor = System.Drawing.Color.FromArgb(Int32.Parse(walls[i].color.Replace("#", ""), System.Globalization.NumberStyles.HexNumber));
                    }

                    break;

                case SelectedMenu.Patterns:

                    dgv_data.Columns.RemoveAt(5);
                    dgv_data.DataSource = null;
                    dgv_data.Rows.Clear();
                    
                    Pattern[] patterns = mapLevels[SelectedLevel].patterns;


                    DataGridViewCheckBoxColumn pattern_outline = new DataGridViewCheckBoxColumn();
                    pattern_outline.HeaderText = "Outline";
                    pattern_outline.Name = "Outline";


                    DataGridViewButtonColumn pattern_color_edit = new DataGridViewButtonColumn();
                    pattern_color_edit.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    pattern_color_edit.Width = 30;

                    dt_patterns = new DataTable();

                    dt_patterns.Columns.Add("Name", typeof(string));
                    dt_patterns.Columns.Add("Position", typeof(string));
                    dt_patterns.Columns.Add("Points", typeof(string));
                    dt_patterns.Columns.Add("Layer", typeof(int));

                    dt_patterns.Columns.Add("Color", typeof(string));

                    dt_patterns.Columns.Add("Outline", typeof(bool));
                    dt_patterns.Columns.Add("Texture", typeof(string));
                    dt_patterns.Columns.Add("Rotation", typeof(float));
                    dt_patterns.Columns.Add("Node ID", typeof(string));

                    for (int i = 0; i < patterns.Count(); i++)
                    {
                        string[] patternname = patterns[i].texture.Split('/');
                        dt_patterns.Rows.Add(patternname.Last(), patterns[i].position, patterns[i].points, patterns[i].layer, patterns[i].color, patterns[i].outline, patterns[i].texture, patterns[i].rotation, patterns[i].node_id);
                    }


                    dgv_data.DataSource = dt_patterns;
                    dgv_data.Columns.Insert(5, pattern_color_edit);

                    for (int i = 0; i < patterns.Count(); i++)
                    {
                        dgv_data.Rows[i].Cells["Color"].Style.BackColor = System.Drawing.Color.FromArgb(Int32.Parse(patterns[i].color.Replace("#", ""), System.Globalization.NumberStyles.HexNumber));
                    }

                    break;
                case SelectedMenu.Paths:

                    Path[] paths = mapLevels[SelectedLevel].paths;

                    DataGridViewCheckBoxColumn path_fadein = new DataGridViewCheckBoxColumn();
                    path_fadein.HeaderText = "Fade In";
                    path_fadein.Name = "Fade In";

                    DataGridViewCheckBoxColumn path_fadeout = new DataGridViewCheckBoxColumn();
                    path_fadeout.HeaderText = "Fade Out";
                    path_fadeout.Name = "Fade Out";

                    DataGridViewCheckBoxColumn path_grow = new DataGridViewCheckBoxColumn();
                    path_grow.HeaderText = "Gro w";
                    path_grow.Name = "Grow";

                    DataGridViewCheckBoxColumn path_shrink = new DataGridViewCheckBoxColumn();
                    path_shrink.HeaderText = "Shrink";
                    path_shrink.Name = "Shrink";

                    DataGridViewCheckBoxColumn path_loop = new DataGridViewCheckBoxColumn();
                    path_loop.HeaderText = "Loop";
                    path_loop.Name = "Loop";

                    dt_paths = new DataTable();

                    dt_paths.Columns.Add("Name", typeof(string));
                    dt_paths.Columns.Add("Position", typeof(string));
                    dt_paths.Columns.Add("Rotation", typeof(float));
                    dt_paths.Columns.Add("Scale", typeof(string));

                    dt_paths.Columns.Add("Edit Points", typeof(string));
                    dt_paths.Columns.Add("Smoothness", typeof(float));

                    dt_paths.Columns.Add("Texture", typeof(string));
                    dt_paths.Columns.Add("Width", typeof(float));

                    dt_paths.Columns.Add("Layer", typeof(int));
                    dt_paths.Columns.Add("Fade In", typeof(bool));
                    dt_paths.Columns.Add("Fade Out", typeof(bool));
                    dt_paths.Columns.Add("Grow", typeof(bool));
                    dt_paths.Columns.Add("Shrink", typeof(bool));
                    dt_paths.Columns.Add("Loop", typeof(bool));


                    dt_paths.Columns.Add("Node ID", typeof(string));

                    for (int i = 0; i < paths.Count(); i++)
                    {
                        string[] pathname = paths[i].texture.Split('/');
                        dt_paths.Rows.Add(pathname.Last(), paths[i].position, paths[i].rotation, paths[i].scale, paths[i].edit_points, paths[i].smoothness, paths[i].texture, paths[i].width, paths[i].layer, paths[i].fade_in, paths[i].fade_out, paths[i].grow, paths[i].shrink, paths[i].loop, paths[i].node_id);
                    }

                    dgv_data.DataSource = dt_paths;

                    break;
            }


            foreach (DataGridViewColumn column in dgv_data.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }


        void LevelSelection_Changed(object sender, EventArgs e)
        {
            if ((((RadioButton)sender).Checked))
            {
                string levelNum = levelFromLabel[((RadioButton)sender).Text];
                SelectedLevel = levelNum;
                
                objectsByNodeID = new Dictionary<string, Object>();
                lightsByNodeID = new Dictionary<string, Light>();
                wallsByNodeID = new Dictionary<string, Wall>();
                patternsByNodeID = new Dictionary<string, Pattern>();
                pathsByNodeID = new Dictionary<string, Path>();

                

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

                      
                        dt_objects = new DataTable();


                        dt_objects.Columns.Add("Name", typeof(string));
                        dt_objects.Columns.Add("Position", typeof(string));
                        dt_objects.Columns.Add("Rotation", typeof(float));
                        dt_objects.Columns.Add("Scale", typeof(string));
                        dt_objects.Columns.Add("Mirror", typeof(bool));
                        dt_objects.Columns.Add("Texture", typeof(string));
                        dt_objects.Columns.Add("Layer", typeof(int));
                        dt_objects.Columns.Add("Shadow", typeof(bool));
                        dt_objects.Columns.Add("Node ID", typeof(string));


                        for (int i = 0; i < objects.Count(); i++)
                        {
                            string[] objectname = objects[i].texture.Split('/');
                            if(!objectsByNodeID.ContainsKey(objects[i].node_id))
                                objectsByNodeID.Add(objects[i].node_id, objects[i]);
                            dt_objects.Rows.Add(objectname.Last(), objects[i].position, objects[i].rotation, objects[i].scale, objects[i].mirror, objects[i].texture, objects[i].layer, objects[i].shadow, objects[i].node_id);

                        }
                      
                        dgv_data.DataSource = dt_objects;

                        
                        break;

                    case SelectedMenu.Lights:

                        if(dgv_data.DataSource != null)
                        {
                            dgv_data.Columns.Remove("");
                            dgv_data.DataSource = null;
                            dgv_data.Rows.Clear();
                        }
                        

                        Light[] lights = mapLevels[levelNum].lights;
                        

                        DataGridViewCheckBoxColumn light_shadow = new DataGridViewCheckBoxColumn();
                        light_shadow.HeaderText = "Shadow";
                        light_shadow.Name = "Shadow";

                        DataGridViewButtonColumn light_color_edit = new DataGridViewButtonColumn();
                        light_color_edit.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        light_color_edit.Width = 30;

                       
                        dt_lights = new DataTable();

                        dt_lights.Columns.Add("Name", typeof(string));
                        dt_lights.Columns.Add("Position", typeof(string));
                        dt_lights.Columns.Add("Rotation", typeof(float));
                        dt_lights.Columns.Add("Intensity", typeof(float));
                        dt_lights.Columns.Add("Color", typeof(string));

                        dt_lights.Columns.Add("Texture", typeof(string));
                        dt_lights.Columns.Add("Shadow", typeof(bool));
                        dt_lights.Columns.Add("Node ID", typeof(string));

                        for (int i = 0; i < lights.Count(); i++)
                        {
                            string[] lighttname = lights[i].texture.Split('/');
                            if (!lightsByNodeID.ContainsKey(lights[i].node_id))
                                lightsByNodeID.Add(lights[i].node_id, lights[i]);
                            dt_lights.Rows.Add(lighttname.Last(), lights[i].position, lights[i].rotation, lights[i].intensity, lights[i].color.ToUpper(), lights[i].texture, lights[i].shadows, lights[i].node_id);
                        }
                       
                        dgv_data.DataSource = dt_lights;
                        
                        dgv_data.Columns.Insert(5, light_color_edit);
                        for (int i = 0; i < lights.Count(); i++)
                        {
                            dgv_data.Rows[i].Cells["Color"].Style.BackColor = System.Drawing.Color.FromArgb(Int32.Parse(lights[i].color.Replace("#", ""), System.Globalization.NumberStyles.HexNumber));
                        }
                        break;


                    case SelectedMenu.Walls:

                        if (dgv_data.DataSource != null)
                        {
                            dgv_data.Columns.Remove("");
                            dgv_data.DataSource = null;
                            dgv_data.Rows.Clear();
                        }

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

                        
                        dt_walls = new DataTable();

                        dt_walls.Columns.Add("Name", typeof(string));
                        dt_walls.Columns.Add("Points", typeof(string));
                        dt_walls.Columns.Add("Texture", typeof(string));
                        dt_walls.Columns.Add("Color", typeof(string));

                        dt_walls.Columns.Add("Loop", typeof(bool));
                        dt_walls.Columns.Add("Type", typeof(int));
                        dt_walls.Columns.Add("Joint", typeof(int));
                        dt_walls.Columns.Add("Normalize UV", typeof(bool));
                        dt_walls.Columns.Add("Shadow", typeof(bool));
                        dt_walls.Columns.Add("Node ID", typeof(string));


                        for (int i = 0; i < walls.Count(); i++)
                        {
                            string[] wallname = walls[i].texture.Split('/');
                            if (!wallsByNodeID.ContainsKey(walls[i].node_id))
                                wallsByNodeID.Add(walls[i].node_id, walls[i]);
                            dt_walls.Rows.Add(wallname.Last(), walls[i].points, walls[i].texture, walls[i].color.ToUpper(), walls[i].loop, walls[i].type, walls[i].joint, walls[i].normalize_uv, walls[i].shadow, walls[i].node_id);
                        }
                      
                        dgv_data.DataSource = dt_walls;
                        dgv_data.Columns.Insert(4, wall_color_edit);

                        for (int i = 0; i < walls.Count(); i++)
                        {
                            dgv_data.Rows[i].Cells["Color"].Style.BackColor = System.Drawing.Color.FromArgb(Int32.Parse(walls[i].color.Replace("#", ""), System.Globalization.NumberStyles.HexNumber));
                        }

                        break;

                    case SelectedMenu.Patterns:

                        if (dgv_data.DataSource != null)
                        {
                            dgv_data.Columns.Remove("");
                            dgv_data.DataSource = null;
                            dgv_data.Rows.Clear();
                        }

                        Pattern[] patterns = mapLevels[levelNum].patterns;
                        

                        DataGridViewCheckBoxColumn pattern_outline = new DataGridViewCheckBoxColumn();
                        pattern_outline.HeaderText = "Outline";
                        pattern_outline.Name = "Outline";


                        DataGridViewButtonColumn pattern_color_edit = new DataGridViewButtonColumn();
                        pattern_color_edit.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        pattern_color_edit.Width = 30;

                        
                        dt_patterns = new DataTable();

                        dt_patterns.Columns.Add("Name", typeof(string));
                        dt_patterns.Columns.Add("Position", typeof(string));
                        dt_patterns.Columns.Add("Points", typeof(string));
                        dt_patterns.Columns.Add("Layer", typeof(int));

                        dt_patterns.Columns.Add("Color", typeof(string));

                        dt_patterns.Columns.Add("Outline", typeof(bool));
                        dt_patterns.Columns.Add("Texture", typeof(string));
                        dt_patterns.Columns.Add("Rotation", typeof(float));
                        dt_patterns.Columns.Add("Node ID", typeof(string));

                        for (int i = 0; i < patterns.Count(); i++)
                        {
                            string[] patternname = patterns[i].texture.Split('/');
                            if (!patternsByNodeID.ContainsKey(patterns[i].node_id))
                                patternsByNodeID.Add(patterns[i].node_id, patterns[i]);
                            dt_patterns.Rows.Add(patternname.Last(), patterns[i].position, patterns[i].points, patterns[i].layer, patterns[i].color, patterns[i].outline, patterns[i].texture, patterns[i].rotation, patterns[i].node_id);
                        }
                        

                        dgv_data.DataSource = dt_patterns;
                        dgv_data.Columns.Insert(5, pattern_color_edit);

                        for (int i = 0; i < patterns.Count(); i++)
                        {
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

                        
                        dt_paths = new DataTable();

                        dt_paths.Columns.Add("Name", typeof(string));
                        dt_paths.Columns.Add("Position", typeof(string));
                        dt_paths.Columns.Add("Rotation", typeof(float));
                        dt_paths.Columns.Add("Scale", typeof(string));

                        dt_paths.Columns.Add("Edit Points", typeof(string));
                        dt_paths.Columns.Add("Smoothness", typeof(float));

                        dt_paths.Columns.Add("Texture", typeof(string));
                        dt_paths.Columns.Add("Width", typeof(float));

                        dt_paths.Columns.Add("Layer", typeof(int));
                        dt_paths.Columns.Add("Fade In", typeof(bool));
                        dt_paths.Columns.Add("Fade Out", typeof(bool));
                        dt_paths.Columns.Add("Grow", typeof(bool));
                        dt_paths.Columns.Add("Shrink", typeof(bool));
                        dt_paths.Columns.Add("Loop", typeof(bool));


                        dt_paths.Columns.Add("Node ID", typeof(string));

                        for (int i = 0; i < paths.Count(); i++)
                        {
                            string[] pathname = paths[i].texture.Split('/');
                            if (!pathsByNodeID.ContainsKey(paths[i].node_id))
                                pathsByNodeID.Add(paths[i].node_id, paths[i]);
                            dt_paths.Rows.Add(pathname.Last(), paths[i].position, paths[i].rotation, paths[i].scale, paths[i].edit_points, paths[i].smoothness, paths[i].texture, paths[i].width, paths[i].layer, paths[i].fade_in, paths[i].fade_out, paths[i].grow, paths[i].shrink, paths[i].loop, paths[i].node_id);
                        }
                        

                        dgv_data.DataSource = dt_paths;

                        break;
                }

                foreach (DataGridViewColumn column in dgv_data.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            tog_groupedit.Checked = false;
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
            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {

                string pickedcolor = OpenColorPicker(grid, e);

                if (pickedcolor != "")
                {
                    dgv_data.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Style.BackColor = System.Drawing.Color.FromArgb(Int32.Parse(pickedcolor.Replace("#", ""), System.Globalization.NumberStyles.HexNumber));
                    dgv_data.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value = pickedcolor;
                }
            }
            else if (grid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {
                string nodeid = dgv_data.Rows[e.RowIndex].Cells["Node ID"].Value.ToString();
                dgv_data.CommitEdit(DataGridViewDataErrorContexts.Commit);
                switch (currentMenu)
                {
                    case SelectedMenu.Objects:
                        if (e.ColumnIndex == 4)
                        {
                            if (IsGroupEditEnabled)
                            {
                                string groupname = dt_objects_filtered.Rows[e.RowIndex].Field<string>("Name");
                                DataRow[] dr = dt_objects.Select("Name = '" + groupname + "'");

                                for (int i = 0; i < dr.Length; i++)
                                {
                                    if (dr[i].Field<string>("Name") == groupname)
                                    {
                                        string id = dr[i].Field<string>("Node ID");

                                        objectsByNodeID[id].mirror = dt_objects_filtered.Rows[e.RowIndex].Field<bool>("Mirror");
                                    }
                                }
                            }
                            else
                            {
                                objectsByNodeID[nodeid].mirror = dt_objects.Rows[e.RowIndex].Field<bool>("Mirror");
                            }
                            
                        }
                        else if (e.ColumnIndex == 7)
                        {
                            if (IsGroupEditEnabled)
                            {
                                string groupname = dt_objects_filtered.Rows[e.RowIndex].Field<string>("Name");
                                DataRow[] dr = dt_objects.Select("Name = '" + groupname + "'");

                                for (int i = 0; i < dr.Length; i++)
                                {
                                    if (dr[i].Field<string>("Name") == groupname)
                                    {
                                        string id = dr[i].Field<string>("Node ID");

                                        objectsByNodeID[id].shadow = dt_objects_filtered.Rows[e.RowIndex].Field<bool>("Shadow");
                                    }
                                }
                            }
                            else
                            {
                                objectsByNodeID[nodeid].shadow = dt_objects.Rows[e.RowIndex].Field<bool>("Shadow");
                            }
                        }
                        break;
                    case SelectedMenu.Lights:

                        if (e.ColumnIndex == 6)
                        {
                            if (IsGroupEditEnabled)
                            {
                                string groupname = dt_lights_filtered.Rows[e.RowIndex].Field<string>("Name");
                                DataRow[] dr = dt_lights.Select("Name = '" + groupname + "'");

                                for (int i = 0; i < dr.Length; i++)
                                {
                                    if (dr[i].Field<string>("Name") == groupname)
                                    {
                                        string id = dr[i].Field<string>("Node ID");

                                        lightsByNodeID[id].shadows = dt_lights_filtered.Rows[e.RowIndex].Field<bool>("Shadow");
                                    }
                                }
                            }
                            else
                            {
                                lightsByNodeID[nodeid].shadows = dt_lights.Rows[e.RowIndex].Field<bool>("Shadow");
                            }
                        }

                        break;
                    case SelectedMenu.Walls:

                        if (e.ColumnIndex == 5)
                        {
                            if (IsGroupEditEnabled)
                            {
                                string groupname = dt_walls_filtered.Rows[e.RowIndex].Field<string>("Name");
                                DataRow[] dr = dt_walls.Select("Name = '" + groupname + "'");

                                for (int i = 0; i < dr.Length; i++)
                                {
                                    if (dr[i].Field<string>("Name") == groupname)
                                    {
                                        string id = dr[i].Field<string>("Node ID");

                                        wallsByNodeID[id].loop = dt_walls_filtered.Rows[e.RowIndex].Field<bool>("Loop");
                                    }
                                }
                            }
                            else
                            {
                                wallsByNodeID[nodeid].loop = dt_walls.Rows[e.RowIndex].Field<bool>("Loop");
                            }
                        }
                        else if (e.ColumnIndex == 8)
                        {
                            if (IsGroupEditEnabled)
                            {
                                string groupname = dt_walls_filtered.Rows[e.RowIndex].Field<string>("Name");
                                DataRow[] dr = dt_walls.Select("Name = '" + groupname + "'");

                                for (int i = 0; i < dr.Length; i++)
                                {
                                    if (dr[i].Field<string>("Name") == groupname)
                                    {
                                        string id = dr[i].Field<string>("Node ID");

                                        wallsByNodeID[id].normalize_uv = dt_walls_filtered.Rows[e.RowIndex].Field<bool>("Normalize UV");
                                    }
                                }
                            }
                            else
                            {
                                wallsByNodeID[nodeid].normalize_uv = dt_walls.Rows[e.RowIndex].Field<bool>("Normalize UV");
                            }
                        }
                        else if (e.ColumnIndex == 9)
                        {
                            if (IsGroupEditEnabled)
                            {
                                string groupname = dt_walls_filtered.Rows[e.RowIndex].Field<string>("Name");
                                DataRow[] dr = dt_walls.Select("Name = '" + groupname + "'");

                                for (int i = 0; i < dr.Length; i++)
                                {
                                    if (dr[i].Field<string>("Name") == groupname)
                                    {
                                        string id = dr[i].Field<string>("Node ID");

                                        wallsByNodeID[id].shadow = dt_walls_filtered.Rows[e.RowIndex].Field<bool>("Shadow");
                                    }
                                }
                            }
                            else
                            {
                                wallsByNodeID[nodeid].shadow = dt_walls.Rows[e.RowIndex].Field<bool>("Shadow");
                            }
                        }

                        break;
                    case SelectedMenu.Patterns:

                        if (e.ColumnIndex == 6)
                        {
                            if (IsGroupEditEnabled)
                            {
                                string groupname = dt_patterns_filtered.Rows[e.RowIndex].Field<string>("Name");
                                DataRow[] dr = dt_patterns.Select("Name = '" + groupname + "'");

                                for (int i = 0; i < dr.Length; i++)
                                {
                                    if (dr[i].Field<string>("Name") == groupname)
                                    {
                                        string id = dr[i].Field<string>("Node ID");

                                        patternsByNodeID[id].outline = dt_patterns_filtered.Rows[e.RowIndex].Field<bool>("Outline");
                                    }
                                }
                            }
                            else
                            {
                                patternsByNodeID[nodeid].outline = dt_patterns.Rows[e.RowIndex].Field<bool>("Outline");
                            }
                        }

                        break;
                    case SelectedMenu.Paths:

                        if (e.ColumnIndex == 9)
                        {
                            if (IsGroupEditEnabled)
                            {
                                string groupname = dt_paths_filtered.Rows[e.RowIndex].Field<string>("Name");
                                DataRow[] dr = dt_paths.Select("Name = '" + groupname + "'");

                                for (int i = 0; i < dr.Length; i++)
                                {
                                    if (dr[i].Field<string>("Name") == groupname)
                                    {
                                        string id = dr[i].Field<string>("Node ID");

                                        pathsByNodeID[id].fade_in = dt_paths_filtered.Rows[e.RowIndex].Field<bool>("Fade In");
                                    }
                                }
                            }
                            else
                            {
                                pathsByNodeID[nodeid].fade_in = dt_paths.Rows[e.RowIndex].Field<bool>("Fade In");
                            }
                        }
                        else if (e.ColumnIndex == 10)
                        {
                            if (IsGroupEditEnabled)
                            {
                                string groupname = dt_paths_filtered.Rows[e.RowIndex].Field<string>("Name");
                                DataRow[] dr = dt_paths.Select("Name = '" + groupname + "'");

                                for (int i = 0; i < dr.Length; i++)
                                {
                                    if (dr[i].Field<string>("Name") == groupname)
                                    {
                                        string id = dr[i].Field<string>("Node ID");

                                        pathsByNodeID[id].fade_out = dt_paths_filtered.Rows[e.RowIndex].Field<bool>("Fade Out");
                                    }
                                }
                            }
                            else
                            {
                                pathsByNodeID[nodeid].fade_out = dt_paths.Rows[e.RowIndex].Field<bool>("Fade Out");
                            }
                        }
                        else if (e.ColumnIndex == 11)
                        {
                            if (IsGroupEditEnabled)
                            {
                                string groupname = dt_paths_filtered.Rows[e.RowIndex].Field<string>("Name");
                                DataRow[] dr = dt_paths.Select("Name = '" + groupname + "'");

                                for (int i = 0; i < dr.Length; i++)
                                {
                                    if (dr[i].Field<string>("Name") == groupname)
                                    {
                                        string id = dr[i].Field<string>("Node ID");

                                        pathsByNodeID[id].grow = dt_paths_filtered.Rows[e.RowIndex].Field<bool>("Grow");
                                    }
                                }
                            }
                            else
                            {
                                pathsByNodeID[nodeid].grow = dt_paths.Rows[e.RowIndex].Field<bool>("Grow");
                            }
                        }
                        else if (e.ColumnIndex == 12)
                        {
                            if (IsGroupEditEnabled)
                            {
                                string groupname = dt_paths_filtered.Rows[e.RowIndex].Field<string>("Name");
                                DataRow[] dr = dt_paths.Select("Name = '" + groupname + "'");

                                for (int i = 0; i < dr.Length; i++)
                                {
                                    if (dr[i].Field<string>("Name") == groupname)
                                    {
                                        string id = dr[i].Field<string>("Node ID");

                                        pathsByNodeID[id].shrink = dt_paths_filtered.Rows[e.RowIndex].Field<bool>("Shrink");
                                    }
                                }
                            }
                            else
                            {
                                pathsByNodeID[nodeid].shrink = dt_paths.Rows[e.RowIndex].Field<bool>("Shrink");
                            }
                        }
                        else if (e.ColumnIndex == 13)
                        {
                            if (IsGroupEditEnabled)
                            {
                                string groupname = dt_paths_filtered.Rows[e.RowIndex].Field<string>("Name");
                                DataRow[] dr = dt_paths.Select("Name = '" + groupname + "'");

                                for (int i = 0; i < dr.Length; i++)
                                {
                                    if (dr[i].Field<string>("Name") == groupname)
                                    {
                                        string id = dr[i].Field<string>("Node ID");

                                        pathsByNodeID[id].loop = dt_paths_filtered.Rows[e.RowIndex].Field<bool>("Loop");
                                    }
                                }
                            }
                            else
                            {
                                pathsByNodeID[nodeid].loop = dt_paths.Rows[e.RowIndex].Field<bool>("Loop");
                            }
                        }

                        break;
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

        private void dgv_data_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            switch (currentMenu)
            {
                case SelectedMenu.Lights:

                    if(e.ColumnIndex == 5 && e.RowIndex > -1)
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                        var w = Properties.Resources.pencil.Width;
                        var h = Properties.Resources.pencil.Height;
                        var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                        var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                        Image img = DD_File_Editor.Properties.Resources.pencil;
                        e.Graphics.DrawImage(img, new Rectangle(x,y,w,h));

                        e.Handled = true;
                            
                    }

                    break;

                case SelectedMenu.Walls:

                    if (e.ColumnIndex == 4 && e.RowIndex > -1)
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                        var w = Properties.Resources.pencil.Width;
                        var h = Properties.Resources.pencil.Height;
                        var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                        var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                        Image img = DD_File_Editor.Properties.Resources.pencil;
                        e.Graphics.DrawImage(img, new Rectangle(x, y, w, h));

                        e.Handled = true;
                    }

                    break;

                case SelectedMenu.Patterns:

                    if (e.ColumnIndex == 5 && e.RowIndex > -1)
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                        var w = Properties.Resources.pencil.Width;
                        var h = Properties.Resources.pencil.Height;
                        var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                        var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                        Image img = DD_File_Editor.Properties.Resources.pencil;
                        e.Graphics.DrawImage(img, new Rectangle(x, y, w, h));

                        e.Handled = true;
                    }

                    break;
            }
        }

        public void OnGroupEditEnabled_Objects(Dictionary<string, Object> dictionary, bool enabled)
        {
            IsGroupEditEnabled = enabled;
            if (enabled)
            {

                dgv_data.DataSource = null;
                dgv_data.Rows.Clear();

                DataGridViewCheckBoxColumn object_mirror = new DataGridViewCheckBoxColumn();
                object_mirror.HeaderText = "Mirror";
                object_mirror.Name = "Mirror";

                DataGridViewCheckBoxColumn object_shadow = new DataGridViewCheckBoxColumn();
                object_shadow.HeaderText = "Shadow";
                object_shadow.Name = "Shadow";


                dt_objects_filtered = dt_objects.AsEnumerable().GroupBy(row => row.Field<string>("Name")).Select(g => g.First()).CopyToDataTable();

                if (dt_objects_filtered == null)
                {
                    dt_objects_filtered = new DataTable();


                    dt_objects_filtered.Columns.Add("Name", typeof(string));
                    dt_objects_filtered.Columns.Add("Position", typeof(string));
                    dt_objects_filtered.Columns.Add("Rotation", typeof(float));
                    dt_objects_filtered.Columns.Add("Scale", typeof(string));
                    dt_objects_filtered.Columns.Add("Mirror", typeof(bool));
                    dt_objects_filtered.Columns.Add("Texture", typeof(string));
                    dt_objects_filtered.Columns.Add("Layer", typeof(int));
                    dt_objects_filtered.Columns.Add("Shadow", typeof(bool));
                    dt_objects_filtered.Columns.Add("Node ID", typeof(string));



                    foreach (string key in dictionary.Keys)
                    {
                        string[] objectname = dictionary[key].texture.Split('/');

                        dt_objects_filtered.Rows.Add(objectname.Last(), dictionary[key].position, dictionary[key].rotation, dictionary[key].scale, dictionary[key].mirror, dictionary[key].texture, dictionary[key].layer, dictionary[key].shadow, dictionary[key].node_id);
                    }
                }

                dgv_data.DataSource = dt_objects_filtered;
                
            }
            
        }

        public void OnGroupEditEnabled_Lights(Dictionary<string, Light> dictionary, bool enabled)
        {
            IsGroupEditEnabled = enabled;

            dgv_data.Columns.RemoveAt(5);
            dgv_data.DataSource = null;
            dgv_data.Rows.Clear();

            
            Light[] lights = mapLevels[SelectedLevel].lights;


            DataGridViewCheckBoxColumn light_shadow = new DataGridViewCheckBoxColumn();
            light_shadow.HeaderText = "Shadow";
            light_shadow.Name = "Shadow";

            DataGridViewButtonColumn light_color_edit = new DataGridViewButtonColumn();
            light_color_edit.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            light_color_edit.Width = 30;


            dt_lights_filtered = dt_lights.AsEnumerable().GroupBy(row => row.Field<string>("Name")).Select(g => g.First()).CopyToDataTable();

            if (dt_lights_filtered == null)
            {
                dt_lights_filtered = new DataTable();

                dt_lights_filtered.Columns.Add("Name", typeof(string));
                dt_lights_filtered.Columns.Add("Position", typeof(string));
                dt_lights_filtered.Columns.Add("Rotation", typeof(float));
                dt_lights_filtered.Columns.Add("Intensity", typeof(float));
                dt_lights_filtered.Columns.Add("Color", typeof(string));
                dt_lights_filtered.Columns.Add("Texture", typeof(string));
                dt_lights_filtered.Columns.Add("Shadow", typeof(bool));
                dt_lights_filtered.Columns.Add("Node ID", typeof(string));



                foreach (string key in dictionary.Keys)
                {
                    string[] lighttname = dictionary[key].texture.Split('/');
                    dt_lights_filtered.Rows.Add(lighttname.Last(), dictionary[key].position, dictionary[key].rotation, dictionary[key].intensity, dictionary[key].color.ToUpper(), dictionary[key].texture, dictionary[key].shadows, dictionary[key].node_id);
                }
                
            }

            dgv_data.DataSource = dt_lights_filtered;
            
            dgv_data.Columns.Insert(5, light_color_edit);
            for (int i = 0; i < dgv_data.Rows.Count; i++)
            {
                dgv_data.Rows[i].Cells["Color"].Style.BackColor = System.Drawing.Color.FromArgb(Int32.Parse(dt_lights_filtered.Rows[i].Field<string>("Color").Replace("#", ""), System.Globalization.NumberStyles.HexNumber));
            }


        }

        public void OnGroupEditEnabled_Walls(Dictionary<string, Wall> dictionary, bool enabled)
        {
            IsGroupEditEnabled = enabled;

            dgv_data.Columns.RemoveAt(4);
            dgv_data.DataSource = null;
            dgv_data.Rows.Clear();

            Wall[] walls = mapLevels[SelectedLevel].walls;


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


            dt_walls_filtered = dt_walls.AsEnumerable().GroupBy(row => row.Field<string>("Name")).Select(g => g.First()).CopyToDataTable();

            if (dt_walls_filtered == null)
            {
                dt_walls_filtered = new DataTable();

                dt_walls_filtered.Columns.Add("Name", typeof(string));
                dt_walls_filtered.Columns.Add("Points", typeof(string));
                dt_walls_filtered.Columns.Add("Texture", typeof(string));
                dt_walls_filtered.Columns.Add("Color", typeof(string));

                dt_walls_filtered.Columns.Add("Loop", typeof(bool));
                dt_walls_filtered.Columns.Add("Type", typeof(int));
                dt_walls_filtered.Columns.Add("Joint", typeof(int));
                dt_walls_filtered.Columns.Add("Normalize UV", typeof(bool));
                dt_walls_filtered.Columns.Add("Shadow", typeof(bool));
                dt_walls_filtered.Columns.Add("Node ID", typeof(string));

           
                foreach (string key in dictionary.Keys)
                {
                    string[] wallname = dictionary[key].texture.Split('/');
                    dt_walls_filtered.Rows.Add(wallname.Last(), dictionary[key].points, dictionary[key].texture, dictionary[key].color.ToUpper(), dictionary[key].loop, dictionary[key].type, dictionary[key].joint, dictionary[key].normalize_uv, dictionary[key].shadow, dictionary[key].node_id);
                }
            }
            


            dgv_data.DataSource = dt_walls_filtered;

            dgv_data.Columns.Insert(4, wall_color_edit);

            for (int i = 0; i < dgv_data.Rows.Count; i++)
            {
                dgv_data.Rows[i].Cells["Color"].Style.BackColor = System.Drawing.Color.FromArgb(Int32.Parse(dt_walls_filtered.Rows[i].Field<string>("Color").Replace("#", ""), System.Globalization.NumberStyles.HexNumber));
            }
        }

        public void OnGroupEditEnabled_Patterns(Dictionary<string, Pattern> dictionary, bool enabled)
        {
            IsGroupEditEnabled = enabled;

            dgv_data.Columns.RemoveAt(5);
            dgv_data.DataSource = null;
            dgv_data.Rows.Clear();

            Pattern[] patterns = mapLevels[SelectedLevel].patterns;


            DataGridViewCheckBoxColumn pattern_outline = new DataGridViewCheckBoxColumn();
            pattern_outline.HeaderText = "Outline";
            pattern_outline.Name = "Outline";


            DataGridViewButtonColumn pattern_color_edit = new DataGridViewButtonColumn();
            pattern_color_edit.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            pattern_color_edit.Width = 30;

            dt_patterns_filtered = dt_patterns.AsEnumerable().GroupBy(row => row.Field<string>("Name")).Select(g => g.First()).CopyToDataTable();

            if (dt_patterns_filtered == null)
            {
                dt_patterns_filtered = new DataTable();

                dt_patterns_filtered.Columns.Add("Name", typeof(string));
                dt_patterns_filtered.Columns.Add("Position", typeof(string));
                dt_patterns_filtered.Columns.Add("Points", typeof(string));
                dt_patterns_filtered.Columns.Add("Layer", typeof(int));

                dt_patterns_filtered.Columns.Add("Color", typeof(string));

                dt_patterns_filtered.Columns.Add("Outline", typeof(bool));
                dt_patterns_filtered.Columns.Add("Texture", typeof(string));
                dt_patterns_filtered.Columns.Add("Rotation", typeof(float));
                dt_patterns_filtered.Columns.Add("Node ID", typeof(string));


                foreach (string key in dictionary.Keys)
                {
                    string[] patternname = dictionary[key].texture.Split('/');
                    dt_patterns_filtered.Rows.Add(patternname.Last(), dictionary[key].position, dictionary[key].points, dictionary[key].layer, dictionary[key].color, dictionary[key].outline, dictionary[key].texture, dictionary[key].rotation, dictionary[key].node_id);
                }
            }

            

            dgv_data.DataSource = dt_patterns_filtered;
            dgv_data.Columns.Insert(5, pattern_color_edit);

            
            for (int i = 0; i < dgv_data.Rows.Count; i++)
            {
                dgv_data.Rows[i].Cells["Color"].Style.BackColor = System.Drawing.Color.FromArgb(Int32.Parse(dt_patterns_filtered.Rows[i].Field<string>("Color").Replace("#", ""), System.Globalization.NumberStyles.HexNumber));
            }
        }

        public void OnGroupEditEnabled_Paths(Dictionary<string, Path> dictionary, bool enabled)
        {

            IsGroupEditEnabled = enabled;

            Path[] paths = mapLevels[SelectedLevel].paths;

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
            


            if (dt_paths_filtered == null)
            {
                dt_paths_filtered = new DataTable();

                dt_paths_filtered.Columns.Add("Name", typeof(string));
                dt_paths_filtered.Columns.Add("Position", typeof(string));
                dt_paths_filtered.Columns.Add("Rotation", typeof(float));
                dt_paths_filtered.Columns.Add("Scale", typeof(string));

                dt_paths_filtered.Columns.Add("Edit Points", typeof(string));
                dt_paths_filtered.Columns.Add("Smoothness", typeof(float));

                dt_paths_filtered.Columns.Add("Texture", typeof(string));
                dt_paths_filtered.Columns.Add("Width", typeof(float));

                dt_paths_filtered.Columns.Add("Layer", typeof(int));
                dt_paths_filtered.Columns.Add("Fade In", typeof(bool));
                dt_paths_filtered.Columns.Add("Fade Out", typeof(bool));
                dt_paths_filtered.Columns.Add("Grow", typeof(bool));
                dt_paths_filtered.Columns.Add("Shrink", typeof(bool));
                dt_paths_filtered.Columns.Add("Loop", typeof(bool));


                dt_paths_filtered.Columns.Add("Node ID", typeof(string));


                foreach (string key in dictionary.Keys)
                {
                    string[] pathname = dictionary[key].texture.Split('/');
                    dt_paths_filtered.Rows.Add(pathname.Last(), dictionary[key].position, dictionary[key].rotation, dictionary[key].scale, dictionary[key].edit_points, dictionary[key].smoothness, dictionary[key].texture, dictionary[key].width, dictionary[key].layer, dictionary[key].fade_in, dictionary[key].fade_out, dictionary[key].grow, dictionary[key].shrink, dictionary[key].loop, dictionary[key].node_id);
                }
            }
            
            dgv_data.DataSource = dt_paths_filtered;
        }


        private void dgv_data_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                switch (currentMenu)
                {
                    case SelectedMenu.Objects:

                        /*
                        dt_objects_filtered.Columns.Add("Name", typeof(string));        0
                        dt_objects_filtered.Columns.Add("Position", typeof(string));    1
                        dt_objects_filtered.Columns.Add("Rotation", typeof(float));     2
                        dt_objects_filtered.Columns.Add("Scale", typeof(string));       3
                        dt_objects_filtered.Columns.Add("Mirror", typeof(bool));        4
                        dt_objects_filtered.Columns.Add("Texture", typeof(string));     5
                        dt_objects_filtered.Columns.Add("Layer", typeof(int));          6
                        dt_objects_filtered.Columns.Add("Shadow", typeof(bool));        7
                        dt_objects_filtered.Columns.Add("Node ID", typeof(string));     8
                        */

                            break;
                    case SelectedMenu.Lights:

                        if (e.ColumnIndex == 4)
                        {
                            string nodeid = dgv_data.Rows[e.RowIndex].Cells["Node ID"].Value.ToString();
                            if (IsGroupEditEnabled)
                            {
                                string groupname = dt_lights_filtered.Rows[e.RowIndex].Field<string>("Name");
                                DataRow[] dr = dt_lights.Select("Name = '"+groupname+"'");

                                for (int i = 0; i < dr.Length; i++)
                                {
                                    if(dr[i].Field<string>("Name") == groupname)
                                    {
                                        string id = dr[i].Field<string>("Node ID");

                                        lightsByNodeID[id].color = dt_lights_filtered.Rows[e.RowIndex].Field<string>("Color");
                                    }
                                }
                            }
                            else
                            {
                                lightsByNodeID[nodeid].color = dt_lights.Rows[e.RowIndex].Field<string>(4);
                            }
                            


                            //mapLevels[SelectedLevel].lights[e.RowIndex].color = dt_lights.Rows[e.RowIndex].Field<string>(4);
                        }
                        /*
                        dt_lights_filtered.Columns.Add("Name", typeof(string));         0
                        dt_lights_filtered.Columns.Add("Position", typeof(string));     1
                        dt_lights_filtered.Columns.Add("Rotation", typeof(float));      2
                        dt_lights_filtered.Columns.Add("Intensity", typeof(float));     3
                        dt_lights_filtered.Columns.Add("Color", typeof(string));        4
                        dt_lights_filtered.Columns.Add("Texture", typeof(string));      5
                        dt_lights_filtered.Columns.Add("Shadow", typeof(bool));         6
                        dt_lights_filtered.Columns.Add("Node ID", typeof(string));      7
                        */
                        break;
                    case SelectedMenu.Walls:

                        if (e.ColumnIndex == 3)
                        {
                            string nodeid = dgv_data.Rows[e.RowIndex].Cells["Node ID"].Value.ToString();
                            if (IsGroupEditEnabled)
                            {
                                string groupname = dt_walls_filtered.Rows[e.RowIndex].Field<string>("Name");
                                DataRow[] dr = dt_walls.Select("Name = '" + groupname + "'");

                                for (int i = 0; i < dr.Length; i++)
                                {
                                    if (dr[i].Field<string>("Name") == groupname)
                                    {
                                        string id = dr[i].Field<string>("Node ID");

                                        wallsByNodeID[id].color = dt_walls_filtered.Rows[e.RowIndex].Field<string>("Color");
                                    }
                                }
                            }
                            else
                            {
                                
                                wallsByNodeID[nodeid].color = dt_walls.Rows[e.RowIndex].Field<string>(3);
                            }
                        }
                        /*
                        dt_walls_filtered.Columns.Add("Name", typeof(string));          0
                        dt_walls_filtered.Columns.Add("Points", typeof(string));        1
                        dt_walls_filtered.Columns.Add("Texture", typeof(string));       2
                        dt_walls_filtered.Columns.Add("Color", typeof(string));         3

                        dt_walls_filtered.Columns.Add("Loop", typeof(bool));            4
                        dt_walls_filtered.Columns.Add("Type", typeof(int));             5
                        dt_walls_filtered.Columns.Add("Joint", typeof(int));            6
                        dt_walls_filtered.Columns.Add("Normalize UV", typeof(bool));    7
                        dt_walls_filtered.Columns.Add("Shadow", typeof(bool));          8
                        dt_walls_filtered.Columns.Add("Node ID", typeof(string));       9
                        */
                        break;
                    case SelectedMenu.Patterns:
                        
                        if (e.ColumnIndex == 4)
                        {
                            string nodeid = dgv_data.Rows[e.RowIndex].Cells["Node ID"].Value.ToString();
                            if (IsGroupEditEnabled)
                            {
                                string groupname = dt_patterns_filtered.Rows[e.RowIndex].Field<string>("Name");
                                DataRow[] dr = dt_patterns.Select("Name = '" + groupname + "'");

                                for (int i = 0; i < dr.Length; i++)
                                {
                                    if (dr[i].Field<string>("Name") == groupname)
                                    {
                                        string id = dr[i].Field<string>("Node ID");

                                        patternsByNodeID[id].color = dt_patterns_filtered.Rows[e.RowIndex].Field<string>("Color");
                                    }
                                }
                            }
                            else
                            {
                                patternsByNodeID[nodeid].color = dt_patterns.Rows[e.RowIndex].Field<string>(4);
                            }
                        }
                        /*
                        dt_patterns_filtered.Columns.Add("Name", typeof(string));       0
                        dt_patterns_filtered.Columns.Add("Position", typeof(string));   1
                        dt_patterns_filtered.Columns.Add("Points", typeof(string));     2
                        dt_patterns_filtered.Columns.Add("Layer", typeof(int));         3
                        dt_patterns_filtered.Columns.Add("Color", typeof(string));      4
                        dt_patterns_filtered.Columns.Add("Outline", typeof(bool));      5
                        dt_patterns_filtered.Columns.Add("Texture", typeof(string));    6
                        dt_patterns_filtered.Columns.Add("Rotation", typeof(float));    7
                        dt_patterns_filtered.Columns.Add("Node ID", typeof(string));    8
                        */
                        break;
                    case SelectedMenu.Paths:


                        /*
                        dt_paths_filtered.Columns.Add("Name", typeof(string));          0
                        dt_paths_filtered.Columns.Add("Position", typeof(string));      1
                        dt_paths_filtered.Columns.Add("Rotation", typeof(float));       2
                        dt_paths_filtered.Columns.Add("Scale", typeof(string));         3
                        dt_paths_filtered.Columns.Add("Edit Points", typeof(string));   4
                        dt_paths_filtered.Columns.Add("Smoothness", typeof(float));     5
                        dt_paths_filtered.Columns.Add("Texture", typeof(string));       6
                        dt_paths_filtered.Columns.Add("Width", typeof(float));          7
                        dt_paths_filtered.Columns.Add("Layer", typeof(int));            8
                        dt_paths_filtered.Columns.Add("Fade In", typeof(bool));         9
                        dt_paths_filtered.Columns.Add("Fade Out", typeof(bool));        10
                        dt_paths_filtered.Columns.Add("Grow", typeof(bool));            11
                        dt_paths_filtered.Columns.Add("Shrink", typeof(bool));          12
                        dt_paths_filtered.Columns.Add("Loop", typeof(bool));            13
                        dt_paths_filtered.Columns.Add("Node ID", typeof(string));       14
                        */
                        break;
                }
            }   
        }
    }
}
