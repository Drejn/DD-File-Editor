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
//using Cyotek.Windows.Forms;



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

        public Form1()
        {
            InitializeComponent();
        }

        private void b_load_dd_file_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Dungeondraft File (*.dungeondraft_map)|*.dungeondraft_map";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                l_dd_file_path.Text = openFileDialog1.FileName;
                StreamReader sr = new StreamReader(l_dd_file_path.Text);
                string json = sr.ReadToEnd();
                MapContent = JsonConvert.DeserializeObject<Rootobject>(json);
                sr.Close();
                string[] fullpath = l_dd_file_path.Text.Split('\\');
                filename = fullpath.Last();
                path = l_dd_file_path.Text.Replace(filename, "");
                filename = filename.Replace(".dungeondraft_map", "");
            }
            else
                return;
            


            TreeView.BeginUpdate();
            try
            {
                foreach (string key in MapContent.world.levels.Keys)
                {
                    Levels level = MapContent.world.levels[key];
                    TreeNode node = new TreeNode(key);
                    TreeNode childnode = new TreeNode(level.cave.ToString());
                    node.Nodes.Add(childnode);
                    childnode = new TreeNode(level.environment.ToString());
                    node.Nodes.Add(childnode);
                    childnode = new TreeNode("Level Name");
                    node.Nodes.Add(childnode);


                    childnode = new TreeNode("Layers");


                    node.Nodes.Add(childnode);
                    childnode = new TreeNode("Light");
                    for (int i = 0; i < level.lights.Count(); i++)
                    {

                        string[] lightname = level.lights[i].texture.Split('/');


                        TreeNode lightnode = new TreeNode(lightname[lightname.Length - 1]);
                        childnode.Nodes.Add(lightname[lightname.Length - 1]);
                    }

                    node.Nodes.Add(childnode);




                    childnode = new TreeNode(level.materials.ToString());
                    node.Nodes.Add(childnode);
                    childnode = new TreeNode("Object");
                    for (int i = 0; i < level.objects.Count(); i++)
                    {
                        TreeNode objectnode = new TreeNode(level.objects[i].ToString());
                        childnode.Nodes.Add(i.ToString());
                    }
                    node.Nodes.Add(childnode);



                    childnode = new TreeNode("Path");
                    for (int i = 0; i < level.paths.Count(); i++)
                    {
                        TreeNode pathsnode = new TreeNode(level.paths[i].ToString());
                        childnode.Nodes.Add(i.ToString());
                    }
                    node.Nodes.Add(childnode);



                    childnode = new TreeNode("Pattern");
                    for (int i = 0; i < level.patterns.Count(); i++)
                    {
                        TreeNode patternnode = new TreeNode(level.patterns[i].ToString());
                        childnode.Nodes.Add(i.ToString());
                    }
                    node.Nodes.Add(childnode);





                    childnode = new TreeNode(level.shapes.ToString());
                    node.Nodes.Add(childnode);
                    childnode = new TreeNode(level.terrain.ToString());
                    node.Nodes.Add(childnode);
                    childnode = new TreeNode(level.tiles.ToString());
                    node.Nodes.Add(childnode);
                    childnode = new TreeNode("Wall");
                    for (int i = 0; i < level.walls.Count(); i++)
                    {
                        TreeNode wallsnode = new TreeNode(level.walls[i].ToString());
                        childnode.Nodes.Add(i.ToString());
                    }
                    node.Nodes.Add(childnode);



                    childnode = new TreeNode(level.water.ToString());
                    node.Nodes.Add(childnode);

                    childnode = new TreeNode("Portal");
                    node.Nodes.Add(childnode);

                    TreeView.Nodes.Add(node);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            TreeView.EndUpdate();






        }


        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LayoutPanel.Controls.Clear();


            selectedlevel = "";
            
            switch (TreeView.SelectedNode.Text)
            {
                case "Cave":

                    selectedlevel = TreeView.SelectedNode.Parent.Text;
            
                    Cave cave = MapContent.world.levels[selectedlevel].cave;


                    Label l_bitmap = new Label();
                    l_bitmap.Text = "bitmap";

                    LayoutPanel.Controls.Add(l_bitmap);

                    Label bitmap = new Label();
                    bitmap.Text = cave.bitmap;

                    LayoutPanel.Controls.Add(bitmap);
                    LayoutPanel.SetFlowBreak(bitmap, true);



                    Label l_ground_color = new Label();
                    l_ground_color.Text = "Ground Color";

                    LayoutPanel.Controls.Add(l_ground_color);



                    Label ground_color = new Label();
                    ground_color.Text = cave.ground_color;

                    LayoutPanel.Controls.Add(ground_color);

                    Button colorpicker = new Button();
                    colorpicker.Click += new EventHandler((s, e1) => OpenColorPicker(s, e1, l_ground_color.Text));
                    colorpicker.Name = "ground_color";
                    colorpicker.Text = cave.ground_color;
                    colorpicker.AutoSize = true;
                    colorpicker.BackColor = System.Drawing.Color.FromArgb(Int32.Parse(cave.ground_color.Replace("#", ""), System.Globalization.NumberStyles.HexNumber));

                    LayoutPanel.Controls.Add(colorpicker);
                    LayoutPanel.SetFlowBreak(colorpicker, true);

                    Label l_wall_color = new Label();
                    l_wall_color.Text = "Wall Color";

                    LayoutPanel.Controls.Add(l_wall_color);

                    Label cavewallcolor = new Label();
                    cavewallcolor.Text = cave.wall_color;

                    LayoutPanel.Controls.Add(cavewallcolor);

                    Button colorpicker1 = new Button();
                    colorpicker1.Click += new EventHandler((s, e1) => OpenColorPicker(s, e1, l_wall_color.Text));
                    colorpicker1.Name = "wall_color";
                    colorpicker1.Text = cave.wall_color;
                    colorpicker1.AutoSize = true;
                    colorpicker1.BackColor = System.Drawing.Color.FromArgb(Int32.Parse(cave.wall_color.Replace("#", ""), System.Globalization.NumberStyles.HexNumber));

                    LayoutPanel.Controls.Add(colorpicker1);
                    LayoutPanel.SetFlowBreak(colorpicker1, true);


                    Label l_entrance_bitmap = new Label();
                    l_entrance_bitmap.Text = "Entrance Bitmap";

                    LayoutPanel.Controls.Add(l_entrance_bitmap);

                    Label entrance_bitmap = new Label();
                    entrance_bitmap.Text = cave.entrance_bitmap;

                    LayoutPanel.Controls.Add(entrance_bitmap);
                    LayoutPanel.SetFlowBreak(entrance_bitmap, true);
                    break;
                case "Environment":
                    
                    selectedlevel = TreeView.SelectedNode.Parent.Text;
                    Environment environment = MapContent.world.levels[selectedlevel].environment;



                    Label l_baked_lighting = new Label();
                    l_baked_lighting.Text = "Backed Lighting";
                    LayoutPanel.Controls.Add(l_baked_lighting);




                    CheckBox baked_lighting = new CheckBox();
                    baked_lighting.Checked = environment.baked_lighting;
                    LayoutPanel.Controls.Add(baked_lighting);
                    LayoutPanel.SetFlowBreak(baked_lighting, true);


                    Label l_ambient_light = new Label();
                    l_ambient_light.Text = "Ambient Light";
                    LayoutPanel.Controls.Add(l_ambient_light);



                    Label ambient_light = new Label();
                    ambient_light.Text = environment.ambient_light;
                    LayoutPanel.Controls.Add(ambient_light);


                    Button environmentcolor = new Button();
                    environmentcolor.Click += new EventHandler((s, e1) => OpenColorPicker(s, e1, l_ambient_light.Text));
                    environmentcolor.Name = "Ambient Light";
                    environmentcolor.Text = environment.ambient_light;
                    environmentcolor.AutoSize = true;
                    environmentcolor.BackColor = System.Drawing.Color.FromArgb(Int32.Parse(environment.ambient_light.Replace("#", ""), System.Globalization.NumberStyles.HexNumber));
                    LayoutPanel.Controls.Add(environmentcolor);
                    LayoutPanel.SetFlowBreak(environmentcolor, true);


                    break;
                case "Level Name":
                    
                    selectedlevel = TreeView.SelectedNode.Parent.Text;
                    string label = MapContent.world.levels[selectedlevel].label;

                    Label l_levelname = new Label();
                    l_levelname.Text = "Level Name";
                    LayoutPanel.Controls.Add(l_levelname);

                    TextBox levelname = new TextBox();
                    levelname.Text = label;
                    LayoutPanel.Controls.Add(levelname);

                    break;
                case "Layers":
                    
                    selectedlevel = TreeView.SelectedNode.Parent.Text;
                    foreach (string key in MapContent.world.levels[selectedlevel].layers.Keys)
                    {
                        Label depth = new Label();
                        depth.Text = key;
                        LayoutPanel.Controls.Add(depth);

                        Label name = new Label();
                        name.Text = MapContent.world.levels[selectedlevel].layers[key];
                        LayoutPanel.Controls.Add(name);
                        LayoutPanel.SetFlowBreak(name, true);
                    }

                    TextBox newdepth = new TextBox();
                    LayoutPanel.Controls.Add(newdepth);
                    TextBox newname = new TextBox();
                    LayoutPanel.Controls.Add(newname);

                    Button createnewlayer = new Button();
                    createnewlayer.Text = "Add Layer";
                    createnewlayer.Click += new EventHandler(createnewlayer_Click);
                    LayoutPanel.SetFlowBreak(newname, true);


                    break;
                case "Light":

                    
                    selectedlevel = TreeView.SelectedNode.Parent.Text;
                    Light[] lights = MapContent.world.levels[selectedlevel].lights;

                    for (int i = 0; i < lights.Length; i++)
                    {

                        string[] lightname = lights[i].texture.Split('/');
                        Label name = new Label();
                        name.Text = lightname.Last();
                        LayoutPanel.Controls.Add(name);
                        LayoutPanel.SetFlowBreak(name, true);

                        Label l_position = new Label();
                        l_position.Text = i+"_"+"Position";
                        LayoutPanel.Controls.Add(l_position);


                        Label position = new Label();
                        position.Text = lights[i].position;
                        LayoutPanel.Controls.Add(position);
                        LayoutPanel.SetFlowBreak(position, true);


                        Label l_rotation = new Label();
                        l_rotation.Text = i + "_" + "Rotation";
                        LayoutPanel.Controls.Add(l_rotation);


                        Label rotation = new Label();
                        rotation.Text = lights[i].rotation.ToString();
                        LayoutPanel.Controls.Add(rotation);
                        LayoutPanel.SetFlowBreak(rotation, true);



                        Label l_intensity = new Label();
                        l_intensity.Text = i + "_" + "Intensity";
                        LayoutPanel.Controls.Add(l_intensity);


                        Label intensity = new Label();
                        intensity.Text = lights[i].intensity.ToString();
                        LayoutPanel.Controls.Add(intensity);
                        LayoutPanel.SetFlowBreak(intensity, true);



                        Label l_lightcolor = new Label();
                        l_lightcolor.Text = i + "_" + "Color";
                        LayoutPanel.Controls.Add(l_lightcolor);




                        Button lightcolor = new Button();
                        lightcolor.Text = lights[i].color.ToUpper();
                        lightcolor.AutoSize = true;
                        lightcolor.BackColor = System.Drawing.Color.FromArgb(Int32.Parse(lights[i].color.Replace("#", ""), System.Globalization.NumberStyles.HexNumber));
                        lightcolor.Click += new EventHandler((s, e1) => OpenColorPicker(s, e1, l_lightcolor.Text));
                        LayoutPanel.Controls.Add(lightcolor);
                        LayoutPanel.SetFlowBreak(lightcolor, true);


                        Label l_texture = new Label();
                        l_texture.Text = i + "_" + "Texture";
                        LayoutPanel.Controls.Add(l_texture);


                        Label texture = new Label();
                        texture.Text = lights[i].texture;
                        LayoutPanel.Controls.Add(texture);
                        LayoutPanel.SetFlowBreak(texture, true);



                        Label l_shadow = new Label();
                        l_shadow.Text = i + "_" + "Shadow";
                        LayoutPanel.Controls.Add(l_shadow);


                        CheckBox shadow = new CheckBox();
                        shadow.Checked = lights[i].shadows;
                        LayoutPanel.Controls.Add(shadow);
                        LayoutPanel.SetFlowBreak(shadow, true);



                        Label l_nodeid = new Label();
                        l_nodeid.Text = i + "_" + "Node ID";
                        LayoutPanel.Controls.Add(l_nodeid);


                        Label nodeid = new Label();
                        nodeid.Text = lights[i].node_id;
                        LayoutPanel.Controls.Add(nodeid);
                        LayoutPanel.SetFlowBreak(nodeid, true);



                    }




                    break;
                case "Materials":

                    

                    break;
                case "Object":
                    
                    selectedlevel = TreeView.SelectedNode.Parent.Text;
                    Object[] objects = MapContent.world.levels[selectedlevel].objects;

                    for (int i = 0; i < objects.Length; i++)
                    {
                        string[] objectname = objects[i].texture.Split('/');
                        Label name = new Label();
                        name.Text = objectname.Last();
                        LayoutPanel.Controls.Add(name);
                        LayoutPanel.SetFlowBreak(name, true);

                        Label l_position = new Label();
                        l_position.Text = "Position";
                        LayoutPanel.Controls.Add(l_position);


                        Label position = new Label();
                        position.Text = objects[i].position;
                        LayoutPanel.Controls.Add(position);
                        LayoutPanel.SetFlowBreak(position, true);


                        Label l_rotation = new Label();
                        l_rotation.Text = "Rotation";
                        LayoutPanel.Controls.Add(l_rotation);


                        Label rotation = new Label();
                        rotation.Text = objects[i].rotation.ToString();
                        LayoutPanel.Controls.Add(rotation);
                        LayoutPanel.SetFlowBreak(rotation, true);

                        Label l_scale = new Label();
                        l_scale.Text = "Scale";
                        LayoutPanel.Controls.Add(l_scale);


                        Label scale = new Label();
                        scale.Text = objects[i].scale.ToString();
                        LayoutPanel.Controls.Add(scale);
                        LayoutPanel.SetFlowBreak(scale, true);

                        Label l_mirror = new Label();
                        l_mirror.Text = "Mirror";
                        LayoutPanel.Controls.Add(l_mirror);


                        CheckBox mirror = new CheckBox();
                        mirror.Checked = objects[i].mirror;
                        LayoutPanel.Controls.Add(mirror);
                        LayoutPanel.SetFlowBreak(mirror, true);

                        Label l_texture = new Label();
                        l_texture.Text = "Texture";
                        LayoutPanel.Controls.Add(l_texture);


                        Label texture = new Label();
                        texture.Text = objects[i].texture;
                        LayoutPanel.Controls.Add(texture);
                        LayoutPanel.SetFlowBreak(texture, true);

                        Label l_layer = new Label();
                        l_layer.Text = "Layer";
                        LayoutPanel.Controls.Add(l_layer);


                        Label layer = new Label();
                        layer.Text = objects[i].layer.ToString();
                        LayoutPanel.Controls.Add(layer);
                        LayoutPanel.SetFlowBreak(layer, true);

                        Label l_shadow = new Label();
                        l_shadow.Text = "Shadow";
                        LayoutPanel.Controls.Add(l_shadow);


                        CheckBox shadow = new CheckBox();
                        shadow.Checked = objects[i].shadow;
                        LayoutPanel.Controls.Add(shadow);
                        LayoutPanel.SetFlowBreak(shadow, true);

                        Label l_nodeid = new Label();
                        l_nodeid.Text = "Node ID";
                        LayoutPanel.Controls.Add(l_nodeid);

                        Label nodeid = new Label();
                        nodeid.Text = objects[i].node_id;
                        LayoutPanel.Controls.Add(nodeid);
                        LayoutPanel.SetFlowBreak(nodeid, true);
                    }
                    break;
                case "Path":
                    
                    selectedlevel = TreeView.SelectedNode.Parent.Text;
                    Path[] paths = MapContent.world.levels[selectedlevel].paths;

                    for (int i = 0; i < paths.Length; i++)
                    {
                        string[] pathname = paths[i].texture.Split('/');
                        Label name = new Label();
                        name.Text = pathname.Last();
                        LayoutPanel.Controls.Add(name);
                        LayoutPanel.SetFlowBreak(name, true);

                        Label l_position = new Label();
                        l_position.Text = "Position";
                        LayoutPanel.Controls.Add(l_position);


                        Label position = new Label();
                        position.Text = paths[i].position;
                        LayoutPanel.Controls.Add(position);
                        LayoutPanel.SetFlowBreak(position, true);


                        Label l_rotation = new Label();
                        l_rotation.Text = "Rotation";
                        LayoutPanel.Controls.Add(l_rotation);


                        Label rotation = new Label();
                        rotation.Text = paths[i].rotation.ToString();
                        LayoutPanel.Controls.Add(rotation);
                        LayoutPanel.SetFlowBreak(rotation, true);

                        Label l_scale = new Label();
                        l_scale.Text = "Scale";
                        LayoutPanel.Controls.Add(l_scale);


                        Label scale = new Label();
                        scale.Text = paths[i].scale.ToString();
                        LayoutPanel.Controls.Add(scale);
                        LayoutPanel.SetFlowBreak(scale, true);

                        Label l_editpoints = new Label();
                        l_editpoints.Text = "Edit Points";
                        LayoutPanel.Controls.Add(l_editpoints);


                        Label editpoints = new Label();
                        editpoints.Text = paths[i].edit_points.ToString();
                        LayoutPanel.Controls.Add(editpoints);
                        LayoutPanel.SetFlowBreak(editpoints, true);

                        Label l_smoothness = new Label();
                        l_smoothness.Text = "Smoothness";
                        LayoutPanel.Controls.Add(l_smoothness);


                        Label smoothness = new Label();
                        smoothness.Text = paths[i].smoothness.ToString();
                        LayoutPanel.Controls.Add(smoothness);
                        LayoutPanel.SetFlowBreak(smoothness, true);

                        Label l_texture = new Label();
                        l_texture.Text = "Texture";
                        LayoutPanel.Controls.Add(l_texture);


                        Label texture = new Label();
                        texture.Text = paths[i].texture.ToString();
                        LayoutPanel.Controls.Add(texture);
                        LayoutPanel.SetFlowBreak(texture, true);

                        Label l_width = new Label();
                        l_width.Text = "Width";
                        LayoutPanel.Controls.Add(l_width);


                        Label width = new Label();
                        width.Text = paths[i].width.ToString();
                        LayoutPanel.Controls.Add(width);
                        LayoutPanel.SetFlowBreak(width, true);

                        Label l_layer = new Label();
                        l_layer.Text = "Layer";
                        LayoutPanel.Controls.Add(l_layer);


                        Label layer = new Label();
                        layer.Text = paths[i].layer.ToString();
                        LayoutPanel.Controls.Add(layer);
                        LayoutPanel.SetFlowBreak(layer, true);


                        Label l_fadein = new Label();
                        l_fadein.Text = "Fade In";
                        LayoutPanel.Controls.Add(l_fadein);


                        CheckBox fadein = new CheckBox();
                        fadein.Checked = paths[i].fade_in;
                        LayoutPanel.Controls.Add(fadein);
                        LayoutPanel.SetFlowBreak(fadein, true);

                        Label l_fadeout = new Label();
                        l_fadeout.Text = "Fade Out";
                        LayoutPanel.Controls.Add(l_fadeout);


                        CheckBox fadeout = new CheckBox();
                        fadeout.Checked = paths[i].fade_out;
                        LayoutPanel.Controls.Add(fadeout);
                        LayoutPanel.SetFlowBreak(fadeout, true);

                        Label l_grow = new Label();
                        l_grow.Text = "Grow";
                        LayoutPanel.Controls.Add(l_grow);


                        CheckBox grow = new CheckBox();
                        grow.Checked = paths[i].grow;
                        LayoutPanel.Controls.Add(grow);
                        LayoutPanel.SetFlowBreak(grow, true);


                        Label l_shrink = new Label();
                        l_shrink.Text = "Shrink";
                        LayoutPanel.Controls.Add(l_shrink);


                        CheckBox shrink = new CheckBox();
                        shrink.Checked = paths[i].shrink;
                        LayoutPanel.Controls.Add(shrink);
                        LayoutPanel.SetFlowBreak(shrink, true);

                        Label l_loop = new Label();
                        l_loop.Text = "Loop";
                        LayoutPanel.Controls.Add(l_loop);


                        CheckBox loop = new CheckBox();
                        loop.Checked = paths[i].loop;
                        LayoutPanel.Controls.Add(loop);
                        LayoutPanel.SetFlowBreak(loop, true);

                        Label l_nodeid = new Label();
                        l_nodeid.Text = "Node ID";
                        LayoutPanel.Controls.Add(l_nodeid);


                        Label nodeid = new Label();
                        nodeid.Text = paths[i].node_id.ToString();
                        LayoutPanel.Controls.Add(nodeid);
                        LayoutPanel.SetFlowBreak(nodeid, true);

                    }


                    break;
                case "Pattern":
                    
                    selectedlevel = TreeView.SelectedNode.Parent.Text;
                    Pattern[] patterns = MapContent.world.levels[selectedlevel].patterns;

                    for (int i = 0; i < patterns.Length; i++)
                    {
                        string[] patternname = patterns[i].texture.Split('/');
                        Label name = new Label();
                        name.Text = patternname.Last();
                        LayoutPanel.Controls.Add(name);
                        LayoutPanel.SetFlowBreak(name, true);

                        Label l_position = new Label();
                        l_position.Text = i + "_" + "Position";
                        LayoutPanel.Controls.Add(l_position);


                        Label position = new Label();
                        position.Text = patterns[i].position;
                        LayoutPanel.Controls.Add(position);
                        LayoutPanel.SetFlowBreak(position, true);


                        Label l_points = new Label();
                        l_points.Text = i + "_" + "Points";
                        LayoutPanel.Controls.Add(l_points);


                        Label points = new Label();
                        points.Text = patterns[i].points.ToString();
                        LayoutPanel.Controls.Add(points);
                        LayoutPanel.SetFlowBreak(points, true);

                        Label l_layer = new Label();
                        l_layer.Text = i + "_" + "Layer";
                        LayoutPanel.Controls.Add(l_layer);


                        Label layer = new Label();
                        layer.Text = patterns[i].layer.ToString();
                        LayoutPanel.Controls.Add(layer);
                        LayoutPanel.SetFlowBreak(layer, true);


                        Label l_patterncolor = new Label();
                        l_patterncolor.Text = i + "_" + "Color";
                        LayoutPanel.Controls.Add(l_patterncolor);


                        Button patterncolor = new Button();
                        patterncolor.Text = patterns[i].color.ToUpper();
                        patterncolor.AutoSize = true;
                        patterncolor.BackColor = System.Drawing.Color.FromArgb(Int32.Parse(patterns[i].color.Replace("#", ""), System.Globalization.NumberStyles.HexNumber));
                        patterncolor.Click += new EventHandler((s, e1) => OpenColorPicker(s, e1, l_patterncolor.Text));
                        LayoutPanel.Controls.Add(patterncolor);
                        LayoutPanel.SetFlowBreak(patterncolor, true);


                        Label l_outline = new Label();
                        l_outline.Text = i + "_" + "Outline";
                        LayoutPanel.Controls.Add(l_outline);


                        CheckBox outline = new CheckBox();
                        outline.Checked = patterns[i].outline;
                        LayoutPanel.Controls.Add(outline);
                        LayoutPanel.SetFlowBreak(outline, true);


                        Label l_texture = new Label();
                        l_texture.Text = i + "_" + "Texture";
                        LayoutPanel.Controls.Add(l_texture);


                        Label texture = new Label();
                        texture.Text = patterns[i].texture.ToString();
                        LayoutPanel.Controls.Add(texture);
                        LayoutPanel.SetFlowBreak(texture, true);


                        Label l_rotation = new Label();
                        l_rotation.Text = i + "_" + "Rotation";
                        LayoutPanel.Controls.Add(l_rotation);


                        Label rotation = new Label();
                        rotation.Text = patterns[i].rotation.ToString();
                        LayoutPanel.Controls.Add(rotation);
                        LayoutPanel.SetFlowBreak(rotation, true);


                        Label l_nodeid = new Label();
                        l_nodeid.Text = i + "_" + "Node ID";
                        LayoutPanel.Controls.Add(l_nodeid);


                        Label nodeid = new Label();
                        nodeid.Text = patterns[i].node_id.ToString();
                        LayoutPanel.Controls.Add(nodeid);
                        LayoutPanel.SetFlowBreak(nodeid, true);

                    }

                    break;
                case "Shapes":

                    
                    //to be implemented
                    break;
                case "Terrain":
                    
                    //to be implemented
                    break;
                case "Tiles":
                    
                    //to be implemented
                    break;
                case "Wall":
                    
                    selectedlevel = TreeView.SelectedNode.Parent.Text;
                    Wall[] walls = MapContent.world.levels[selectedlevel].walls;

                    for (int i = 0; i < walls.Length; i++)
                    {
                        string[] wallname = walls[i].texture.Split('/');
                        Label name = new Label();
                        name.Text = wallname.Last();
                        LayoutPanel.Controls.Add(name);
                        LayoutPanel.SetFlowBreak(name, true);


                        Label l_points = new Label();
                        l_points.Text = i + "_" + "Points";
                        LayoutPanel.Controls.Add(l_points);


                        Label points = new Label();
                        points.Text = walls[i].points.ToString();
                        LayoutPanel.Controls.Add(points);
                        LayoutPanel.SetFlowBreak(points, true);


                        Label l_texture = new Label();
                        l_texture.Text = i + "_" + "Texture";
                        LayoutPanel.Controls.Add(l_texture);


                        Label texture = new Label();
                        texture.Text = walls[i].texture.ToString();
                        LayoutPanel.Controls.Add(texture);
                        LayoutPanel.SetFlowBreak(texture, true);

                        Label l_wallcolor = new Label();
                        l_wallcolor.Text = i + "_" + "Color";
                        LayoutPanel.Controls.Add(l_wallcolor);


                        Button wallcolor = new Button();
                        wallcolor.Text = walls[i].color.ToUpper();
                        wallcolor.AutoSize = true;
                        wallcolor.BackColor = System.Drawing.Color.FromArgb(Int32.Parse(walls[i].color.Replace("#", ""), System.Globalization.NumberStyles.HexNumber));
                        wallcolor.Click += new EventHandler((s, e1) => OpenColorPicker(s, e1, l_wallcolor.Text));
                        LayoutPanel.Controls.Add(wallcolor);
                        LayoutPanel.SetFlowBreak(wallcolor, true);

                        Label l_loop = new Label();
                        l_loop.Text = i + "_" + "Loop";
                        LayoutPanel.Controls.Add(l_loop);


                        CheckBox loop = new CheckBox();
                        loop.Checked = walls[i].loop;
                        LayoutPanel.Controls.Add(loop);
                        LayoutPanel.SetFlowBreak(loop, true);

                        Label l_type = new Label();
                        l_type.Text = i + "_" + "Type";
                        LayoutPanel.Controls.Add(l_type);


                        Label type = new Label();
                        type.Text = walls[i].type.ToString();
                        LayoutPanel.Controls.Add(type);
                        LayoutPanel.SetFlowBreak(type, true);

                        Label l_joint = new Label();
                        l_joint.Text = i + "_" + "Joint";
                        LayoutPanel.Controls.Add(l_joint);


                        Label joint = new Label();
                        joint.Text = walls[i].joint.ToString();
                        LayoutPanel.Controls.Add(joint);
                        LayoutPanel.SetFlowBreak(joint, true);

                        Label l_normalizeuv = new Label();
                        l_normalizeuv.Text = i + "_" + "Normalize UV";
                        LayoutPanel.Controls.Add(l_normalizeuv);


                        CheckBox normalizeuv = new CheckBox();
                        normalizeuv.Checked = walls[i].normalize_uv;
                        LayoutPanel.Controls.Add(normalizeuv);
                        LayoutPanel.SetFlowBreak(normalizeuv, true);


                        Label l_shadow = new Label();
                        l_shadow.Text = i + "_" + "Shadow";
                        LayoutPanel.Controls.Add(l_shadow);


                        CheckBox shadow = new CheckBox();
                        shadow.Checked = walls[i].shadow;
                        LayoutPanel.Controls.Add(shadow);
                        LayoutPanel.SetFlowBreak(shadow, true);


                        Label l_nodeid = new Label();
                        l_nodeid.Text = i + "_" + "Node ID";
                        LayoutPanel.Controls.Add(l_nodeid);


                        Label nodeid = new Label();
                        nodeid.Text = walls[i].node_id.ToString();
                        LayoutPanel.Controls.Add(nodeid);
                        LayoutPanel.SetFlowBreak(nodeid, true);
                    }

                    break;
                case "Water":
                    
                    //To be implemented
                    break;
                case "Portals":
                    
                    selectedlevel = TreeView.SelectedNode.Parent.Text;
                    Portal[] portals = MapContent.world.levels[selectedlevel].portals;

                    for (int i = 0; i < portals.Length; i++)
                    {

                        string[] portalname = portals[i].texture.Split('/');
                        Label name = new Label();
                        name.Text = portalname.Last();

                        LayoutPanel.Controls.Add(name);
                        LayoutPanel.SetFlowBreak(name, true);


                        Label l_position = new Label();
                        l_position.Text = i + "_" + "Position";
                        LayoutPanel.Controls.Add(l_position);


                        Label position = new Label();
                        position.Text = portals[i].position;
                        LayoutPanel.Controls.Add(position);
                        LayoutPanel.SetFlowBreak(position, true);


                        Label l_rotation = new Label();
                        l_rotation.Text = i + "_" + "Rotation";
                        LayoutPanel.Controls.Add(l_rotation);


                        Label rotation = new Label();
                        rotation.Text = portals[i].rotation.ToString();
                        LayoutPanel.Controls.Add(rotation);
                        LayoutPanel.SetFlowBreak(rotation, true);

                        Label l_scale = new Label();
                        l_scale.Text = i + "_" + "Scale";
                        LayoutPanel.Controls.Add(l_scale);


                        Label scale = new Label();
                        scale.Text = portals[i].scale.ToString();
                        LayoutPanel.Controls.Add(scale);
                        LayoutPanel.SetFlowBreak(scale, true);

                        Label l_direction = new Label();
                        l_direction.Text = i + "_" + "Direction";
                        LayoutPanel.Controls.Add(l_direction);


                        Label direction = new Label();
                        direction.Text = portals[i].direction.ToString();
                        LayoutPanel.Controls.Add(direction);
                        LayoutPanel.SetFlowBreak(direction, true);


                        Label l_texture = new Label();
                        l_texture.Text = i + "_" + "Texture";
                        LayoutPanel.Controls.Add(l_texture);


                        Label texture = new Label();
                        texture.Text = portals[i].texture.ToString();
                        LayoutPanel.Controls.Add(texture);
                        LayoutPanel.SetFlowBreak(texture, true);

                        Label l_radius = new Label();
                        l_radius.Text = i + "_" + "Radius";
                        LayoutPanel.Controls.Add(l_radius);


                        Label radius = new Label();
                        radius.Text = portals[i].radius.ToString();
                        LayoutPanel.Controls.Add(radius);
                        LayoutPanel.SetFlowBreak(radius, true);


                        Label l_wallid = new Label();
                        l_wallid.Text = i + "_" + "Wall ID";
                        LayoutPanel.Controls.Add(l_wallid);


                        Label wallid = new Label();
                        wallid.Text = portals[i].wall_id.ToString();
                        LayoutPanel.Controls.Add(wallid);
                        LayoutPanel.SetFlowBreak(wallid, true);


                        Label l_walldistance = new Label();
                        l_walldistance.Text = i + "_" + "Wall Distance";
                        LayoutPanel.Controls.Add(l_walldistance);


                        Label walldistance = new Label();
                        walldistance.Text = portals[i].wall_distance.ToString();
                        LayoutPanel.Controls.Add(walldistance);
                        LayoutPanel.SetFlowBreak(walldistance, true);

                        Label l_closed = new Label();
                        l_closed.Text = i + "_" + "Closed";
                        LayoutPanel.Controls.Add(l_closed);


                        CheckBox closed = new CheckBox();
                        closed.Checked = portals[i].closed;
                        LayoutPanel.Controls.Add(closed);
                        LayoutPanel.SetFlowBreak(closed, true);


                        Label l_nodeid = new Label();
                        l_nodeid.Text = i + "_" + "Node ID";
                        LayoutPanel.Controls.Add(l_nodeid);


                        Label nodeid = new Label();
                        nodeid.Text = portals[i].node_id.ToString();
                        LayoutPanel.Controls.Add(nodeid);
                        LayoutPanel.SetFlowBreak(nodeid, true);
                    }


                    break;
                default:
                    break;
            }



            LayoutPanel.ResumeLayout();


        }


        private void OpenColorPicker(object sender, EventArgs e,string attribute)
        {
            colorDialog1 = new ColorDialog();

            //ColorPickerDialog colorPicker = new ColorPickerDialog();
            colorDialog1.FullOpen = true;
            colorDialog1.SolidColorOnly = false;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                
            }

            /*
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {



                ((Button)sender).BackColor = colorPicker.Color;
                ((Button)sender).Text = colorPicker.Color.ToArgb().ToString("X8");
                UpdatePropertyValues(attribute,(Control)sender);
            }
            */
        }

        private void createnewlayer_Click(object sender, EventArgs e)
        {

        }


        private void UpdatePropertyValues(string control_name,Control sender)
        {
            foreach(Control control in LayoutPanel.Controls)
            {
                
                if(control.Text == control_name && control is Label)
                {
                    FindAttribute(sender, control_name);

                }
            }


        }

        private void FindAttribute(Control control,string control_name)
        {
            switch (TreeView.SelectedNode.Text)
            {
                case "Cave":
                    switch(control_name)
                    {
                        case "bitmap":
                            break;
                        case "Ground Color":
                            MapContent.world.levels[selectedlevel].cave.ground_color = control.Text;
                            break;
                        case "Wall Color":
                            MapContent.world.levels[selectedlevel].cave.wall_color = control.Text;
                            break;
                        case "Entrance Bitmap":
                            break;
                    }

                    break;
                case "Wall":
                    MapContent.world.levels[selectedlevel].walls[0].color = control.Text;

                    break;
                case "Environment":
                    switch (control_name)
                    {
                        case "Ambient Light":
                            MapContent.world.levels[selectedlevel].environment.ambient_light = control.Text;
                            break;

                                
                    }
                    

                    break;
                case "Light":

                    int nLight = int.Parse(control_name.Split('_')[0]);


                    switch (control_name)
                    {
                        case string col when col.Contains("_Color") :

                            MapContent.world.levels[selectedlevel].lights[nLight].color = control.Text;

                            break;
                    }

                    break;
                case "Pattern":
                    int nPattern = int.Parse(control_name.Split('_')[0]);


                    switch (control_name)
                    {
                        case string col when col.Contains("_Color"):

                            MapContent.world.levels[selectedlevel].patterns[nPattern].color = control.Text;

                            break;
                    }
                    break;
                default:
                    break;

            }
        }

        private void btn_Repack_Click(object sender, EventArgs e)
        {

            var setting = new JsonSerializerSettings();
            setting.NullValueHandling = NullValueHandling.Ignore;
            string json = JsonConvert.SerializeObject(MapContent, Formatting.Indented,setting);
            
            File.WriteAllText(path + filename + "_backup.dungeondraft_map",json);
            
        }
    }
}
