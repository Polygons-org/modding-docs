using Godot;

public class Mod
{
    public void Init(Node root)
    {
        // Runs only when the game first starts
        GD.Print("Modded!");

        // Runs every time MainMenu loads (So that if you reload the main menu the text doesnt reset)
        ModLoader.RegisterNodeCallback("/root/MainMenu/CenterUI/Title", (node) =>
        {
            ((Label)node).Text = "Polygons Modded!";
        });

        // Runs every time OnlineLevelsMenu loads
        ModLoader.RegisterNodeCallback("/root/OnlineLevelsMenu/BackButton", (node) =>
        {
            ((Button)node).Text = "Did you know that the game is modded?";
        });
    }
}