using Godot;
using System;
using PauseFighterGame.Components.Player;

public partial class CameraFollow : Node3D
{
    [Export] public Node3D Target;
    [Export] public PlayerData Data;
    [Export] public Vector3 Offset { get; set; }
    [Export] public Vector3 CamRotation { get; set; }

    [Export] public float Interpolation = 0.1f;
    
    private Camera3D camera;

    public override void _Ready()
    {
        camera = GetNode<Camera3D>("Camera3D");
    }

    private const float RayLength = 1000.0f;

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton eventMouseButton && eventMouseButton.Pressed && eventMouseButton.ButtonIndex == MouseButton.Left)
        {
            
            var from = camera.ProjectRayOrigin(eventMouseButton.Position);
            var to = from + camera.ProjectRayNormal(eventMouseButton.Position) * RayLength;
            
            Data.UseCurrentWeapon(float.Atan2Pi(to.X, to.Z) * 180f);
            
            //GD.Print(float.Atan2Pi(to.X,to.Z)*180f); //
        }
    }

    public override void _Process(double delta)
    {
        camera.Position = Offset;
        camera.SetRotationDegrees(CamRotation);
        
        SetPosition(GlobalPosition.Lerp(Target.Position, Interpolation));
        
    }
}
