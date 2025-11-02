using Godot;
using System;

public partial class CameraFollow : Node3D
{
    [Export] public Node3D Target;
    
    [Export] public Vector3 Offset { get; set; }
    [Export] public Vector3 CamRotation { get; set; }

    [Export] public float Interpolation = 0.1f;
    
    private Camera3D camera;

    public override void _Ready()
    {
        camera = GetNode<Camera3D>("Camera3D");
    }
    
    public override void _Process(double delta)
    {
        camera.Position = Offset;
        camera.SetRotationDegrees(CamRotation);
        
        SetPosition(GlobalPosition.Lerp(Target.Position, Interpolation));
        
    }
}
