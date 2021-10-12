using System;
using System.Collections.Generic;

public class Rootobject
{
    public Header header { get; set; }
    public World world { get; set; }
}

public class Header
{
    public string creation_build { get; set; }
    public Creation_Date creation_date { get; set; }
    public bool uses_default_assets { get; set; }
    public Asset_Manifest[] asset_manifest { get; set; }
    public Editor_State editor_state { get; set; }
}


public class Creation_Date
{
    public int year { get; set; }
    public int month { get; set; }
    public int day { get; set; }
    public int weekday { get; set; }
    public bool dst { get; set; }
    public int hour { get; set; }
    public int minute { get; set; }
    public int second { get; set; }
}




/// <summary>
/// Looks like some settings that are loaded with the map   
/// </summary>
public class Editor_State
{
    public int current_level { get; set; }
    public string camera_position { get; set; }
    public float camera_zoom { get; set; }
    public string guide_position { get; set; }
    public TraceImage trace_image { get; set; }
    public Color_Palettes color_palettes { get; set; }
    public Object_Tags_Memory object_tags_memory { get; set; }
    public Scatter_Tags_Memory scatter_tags_memory { get; set; }
    public Object_Library_Memory object_library_memory { get; set; }
    public Scatter_Library_Memory scatter_library_memory { get; set; }
    public PathLibraryMemory path_library_memory { get; set; }
    public bool sharpen_fonts { get; set; }

}

public class TraceImage
{
    public string image { get; set; }
    public double scale { get; set; }
    public double opacity { get; set; }
    public string position { get; set; }
}

public class Color_Palettes
{
    public string[] object_custom_colors { get; set; }
    public string[] scatter_custom_colors { get; set; }
    public string[] light_colors { get; set; }
    public string[] grid_colors { get; set; }
    public string[] deep_water_colors { get; set; }
    public string[] shallow_water_colors { get; set; }
    public string[] cave_ground_colors { get; set; }
    public string[] cave_wall_colors { get; set; }
}

public class Object_Tags_Memory
{
    public int set { get; set; }
    public string[] tags { get; set; }
}

public class Scatter_Tags_Memory
{
    public int set { get; set; }
    public Object[] tags { get; set; }
}

public class Object_Library_Memory
{
    public string mode { get; set; }
    public int scroll { get; set; }
    public string[] selected { get; set; }
    public float search_strictness { get; set; }
}

public class Scatter_Library_Memory
{
    public string mode { get; set; }
    public int scroll { get; set; }
    public string[] selected { get; set; }
    public float search_strictness { get; set; }
}

public class PathLibraryMemory
{
    public double scroll { get; set; }
    public string[] selected { get; set; }
    public double search_strictness { get; set; }
}

/// <summary>
/// Contains Info about the installed asset packs installed
/// </summary>

public class Asset_Manifest
{
    public string name { get; set; }
    public string id { get; set; }
    public string version { get; set; }
    public string author { get; set; }
    public CustomColorOverrides custom_color_overrides { get; set; }
}


public class CustomColorOverrides
{
    public bool enabled { get; set; }
    public double min_redness { get; set; }
    public int min_saturation { get; set; }
    public double red_tolerance { get; set; }
}

/// <summary>
/// Master Class for all informations related to the actual Map
/// </summary>

public class World
{
    public int format { get; set; }
    public int width { get; set; }
    public int height { get; set; }
    public string next_node_id { get; set; }
    public string next_prefab_id { get; set; }
    public Msi msi { get; set; }
    public Grid grid { get; set; }
    public string building_wear { get; set; }
    public Embedded embedded { get; set; }
    public Dictionary<string,Levels> levels { get; set; }
}


/// <summary>
/// contains info about the map size
/// </summary>

public class Msi
{
    public int offset_map_size { get; set; }
    public float max_offset_distance { get; set; }
    public int cell_size { get; set; }
    public string seed { get; set; }
}


/// <summary>
/// defines informations about the grid (only color?)
/// </summary>


public class Grid
{
    public string color { get; set; }
    public string texture { get; set; }
}

/// <summary>
/// Contains info on embedded images (copy/pasted)
/// </summary>

public class Embedded
{
}


/// <summary>
/// Stores a list of Levels
/// </summary>


public class Levels
{
    
    public string label { get; set; }
    
    public Environment environment { get; set; }


    public Dictionary<string, string> layers { get; set; }
    //public Layers layers { get; set; }
    
    public Shapes shapes { get; set; }
    
    public Tiles tiles { get; set; }
    public Pattern[] patterns { get; set; }
    
    public Wall[] walls { get; set; }

    
    public Cave cave { get; set; }
    public Terrain terrain { get; set; }
    
    public Water water { get; set; }
    public Materials materials { get; set; }
    public Path[] paths { get; set; }
    public Object[] objects { get; set; }
    
    public Light[] lights { get; set; }
    
    public Roofs roofs { get; set; }
    
    public object[] texts { get; set; }

    public Portal[] portals { get; set; }

}
public class Cave
{
    public string bitmap { get; set; }
    public string ground_color { get; set; }
    public string wall_color { get; set; }
    public string entrance_bitmap { get; set; }
}

public class Environment
{
    public bool baked_lighting { get; set; }
    public string ambient_light { get; set; }
}


public class Layers
{
    public string __400 { get; set; }
    public string __100 { get; set; }
    public string _100 { get; set; }
    public string _200 { get; set; }
    public string _300 { get; set; }
    public string _400 { get; set; }
    public string _700 { get; set; }
    public string _900 { get; set; }
}


public class Light
{

    public string position { get; set; }

    public float rotation { get; set; }

    public float range { get; set; }
    public float intensity { get; set; }

    public string color { get; set; }

    public string texture { get; set; }

    public bool shadows { get; set; }

    public string node_id { get; set; }

}


public class Materials
{
}


public class Object
{
    public string position { get; set; }
    public float rotation { get; set; }
    public string scale { get; set; }
    public bool mirror { get; set; }
    public string texture { get; set; }
    public int layer { get; set; }
    public bool shadow { get; set; }
    public bool block_light { get; set; }
    
    public string custom_color { get; set; }

    public string node_id { get; set; }
}


public class Path
{
    public string position { get; set; }
    public float rotation { get; set; }
    public string scale { get; set; }
    public string edit_points { get; set; }
    public float smoothness { get; set; }
    public string texture { get; set; }
    public float width { get; set; }
    public int layer { get; set; }
    public bool fade_in { get; set; }
    public bool fade_out { get; set; }
    public bool grow { get; set; }
    public bool shrink { get; set; }
    public bool loop { get; set; }
    public string node_id { get; set; }
}



public class Pattern
{
    public string position { get; set; }
    public int shape_rotation { get; set; }
    public string scale { get; set; }
    public string points { get; set; }
    public int layer { get; set; }
    public string color { get; set; }
    public bool outline { get; set; }
    public string texture { get; set; }
    public float rotation { get; set; }
    public string node_id { get; set; }
}

public class Shapes
{
    public string[] polygons { get; set; }
    public string[] walls { get; set; }
}


public class Terrain
{
    public bool enabled { get; set; }
    public bool expand_slots { get; set; }
    public bool smooth_blending { get; set; }
    public string texture_1 { get; set; }
    public string texture_2 { get; set; }
    public string texture_3 { get; set; }
    public string texture_4 { get; set; }
    public string texture_5 { get; set; }
    public string texture_6 { get; set; }
    public string texture_7 { get; set; }
    public string texture_8 { get; set; }
    public string splat { get; set; }
    public string splat2 { get; set; }
}

public class Tiles
{
    public string cells { get; set; }
    public string[] colors { get; set; }
    public Dictionary<string, string> lookup { get; set; }
}


public class Wall
{
    public string points { get; set; }
    public string texture { get; set; }
    public string color { get; set; }
    public bool loop { get; set; }
    public int type { get; set; }
    public int joint { get; set; }
    public bool normalize_uv { get; set; }
    public bool shadow { get; set; }
    public string node_id { get; set; }
    public Portal[] portals { get; set; }
}

public class Water
{
    public bool disable_border { get; set; }
    public Tree tree { get; set; }
}

public class Roofs
{
    public bool shade { get; set; }
    public float shade_contrast { get; set; }
    public int sun_direction { get; set; }
    public Object[] roofs { get; set; }
}

public class Portal
{
    public string position { get; set; }
    public float rotation { get; set; }
    public string scale { get; set; }
    public string direction { get; set; }
    public string texture { get; set; }
    public int radius { get; set; }
    public string wall_id { get; set; }
    public float wall_distance { get; set; }
    public bool closed { get; set; }
    public string node_id { get; set; }
}

public class Tree
{
    public int _ref { get; set; }
    public string polygon { get; set; }
    public int join { get; set; }
    public int end { get; set; }
    public bool is_open { get; set; }
    public string deep_color { get; set; }
    public string shallow_color { get; set; }
    public int blend_distance { get; set; }
    public Child[] children { get; set; }
}

public class Child
{
    public int _ref { get; set; }
    public string polygon { get; set; }
    public int join { get; set; }
    public int end { get; set; }
    public bool is_open { get; set; }
    public string deep_color { get; set; }
    public string shallow_color { get; set; }
    public int blend_distance { get; set; }
    public object[] children { get; set; }
}
