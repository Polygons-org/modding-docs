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

        // These functions are both on the same node so we can register them in the same callback
        ModLoader.RegisterNodeCallback("Player", (node) => {
            var player = (Player)node;
            var originalDie = player.DieAction;
            // Die takes no arguments so put nothing in the parentheses
            // If you want to know if a function has arguments go into the source of the game
            // Go to the script with the function and just check if it has any parameters
            player.DieAction = () => {
                GD.Print("Before death!");
                originalDie?.Invoke();
                GD.Print("After Death!");
            };

            var originalIsOnGround = player.IsOnGroundAction;
            // IsOnGround takes a RigidBody2D as an argument so put (rb) in the parentheses
            player.IsOnGroundAction = (rb) => {
                var result = originalIsOnGround.Invoke(rb);
                if (result == true) {
                    GD.Print("Player is on the ground!");
                }
                return result;
            };
        });
    }
}
