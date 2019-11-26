﻿using System.Collections;
using System.Collections.Generic;


// this is the class we will use to store player information
// static classes can be accessed from all scenes so any other information we need to pass around will go here
// feel free to add anything you think you will need to this class

// NOTE: we should probably store potion/alchemy recipes and pretty much the entire logic behind the crafting
// system elsewhere since thats only going to be used in the crafting menu and we should try not to put all our
// information in a static class. Try looking at things like Object.DontDestroyOnLoad for things you want to keep
// throughout scene changes but are only used in the one scene

public static class Global
{
    // days that have passed
    // will increment by 1 each cycle
    public static int day = 1;

    // may be renamed to gold or something similar later, but this is the currency
    // amount also subject to change
    public static int gold = 1000;


    // dictionary interface containing all the materials the player has
    // not sure if this is the best way to store so many variables so open to alternatives
    public static IDictionary<int, int> materials = new Dictionary<int, int>()
    {
        //City Materials
        [0] = 2,     
        [1] = 1,      
        [2] = 1,
        [3] = 0,
        [4] = 0,
        [5] = 0,
        [6] = 0,
        [7] = 0,
        [8] = 0,

        //Wild Materials
        [9] = 0,
        [10] = 0,
        [11] = 0,
        [12] = 0,
        [13] = 0,
        [14] = 0,
        [15] = 0,
        [16] = 0,
        [17] = 0,

        //Dungeon Materials
        [18] = 0,
        [19] = 0,
        [20] = 0,
        [21] = 0,
        [22] = 0,
        [23] = 0,
        [24] = 0,
        [25] = 0,
        [26] = 0
    };
    public static List<RecipeInfo> recipes = new List<RecipeInfo>();
    public static List<RecipeInfo> recipeHistory = new List<RecipeInfo>();
    public static List<int> materialsUsed = new List<int>();
    public static List<int> FoundMaterials = new List<int>(){19, 21};
    public static int moneyMade = 0;
    public static Dictionary<string, int> gatherers = new Dictionary<string, int>()
    {
        //Dungeon Gatherers
        ["Adventurer"] = 0,
        ["Veteran"] = 0,
        ["Hero"] = 0,

        //Wilds Gatherers
        ["Explorer"] = 0,
        ["Ranger"] = 0,
        ["Beast Hunter"] = 0,

        //City Gatherers
        ["Trader"] = 0,
        ["Merchant"] = 0,
        ["Black Marketeer"] = 0,
    };

    public static Dictionary<string, int> gathererCost = new Dictionary<string, int>()
    {
        ["Adventurer"] = 10,
        ["Veteran"] = 100,
        ["Hero"] = 500,

        //Wilds Gatherers
        ["Explorer"] = 10,
        ["Ranger"] = 100,
        ["Beast Hunter"] = 500,

        //City Gatherers
        ["Trader"] = 10,
        ["Merchant"] = 100,
        ["Black Marketeer"] = 500,

    };
    


}
