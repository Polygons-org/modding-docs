# Polygons Modding Documentation
Polygons mods use c# scripts for modding, you don't need to compile to a dll.

In this readme I'll go over the most basic concepts in polygons modding.

## mod.json
Every mod needs to have a mod.json file. A mod.json needs to look something like this:
```json
{
  "name": "test",
  "version": "1.0.0",
  "enabled": "1",
  "entry": "main.cs"
}
```

If enabled is 0 then the mod wont load into the game.

Entry is the cs file that runs automatically when the game loads the mod. You can include extra files for functions and stuff.

## Basics
The class in your entry file HAS to be "Mod" or else it won't load

Your entry file needs to have an Init function. Example:

```cs
using Godot;

public class Mod
{
    public void Init(Node root)
    {
        // Runs when the game starts
        GD.Print("Modded!");
    }
}
```

Since you can't access nodes in other scenes until the scene loads theres a function for that!

I genuinely dont know how to explain so just look at the example mod. The function name is ModLoader.RegisterNodeCallback()
