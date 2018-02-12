using Godot;
using System;

public class Player : KinematicBody
{
    private float verticalVelocity = 0f;
    private bool onFloor = false;
    private float multiplier = 1f;
    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
        
    }

    public override void _Input(InputEvent ev) {
        if (ev.IsActionPressed("jump")) {
            verticalVelocity = 5f;
        }
    }

   public override void _PhysicsProcess(float delta)
   {
       if (verticalVelocity < 0) {
           multiplier = 5f;
       } else {
           multiplier = 1f;
       }
       verticalVelocity -= 15f * multiplier * delta;
       GD.Print(verticalVelocity);
       MoveAndSlide(new Vector3(0,verticalVelocity,0), new Vector3(0,1,0));

       if (IsOnFloor()) {
           verticalVelocity = 0f;
           if (!onFloor) {
                onFloor = true;
                GD.Print("ON FLOOR");
           }
       } else {
           if (onFloor) {
               onFloor = false;
                GD.Print("NOT ON FLOOR");
           }
       }
   }
}
