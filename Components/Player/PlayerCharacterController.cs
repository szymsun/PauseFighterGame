using Godot;
using System;

public partial class PlayerCharacterController : CharacterBody3D
{
    [Export] public float Speed = 200f;

    private Vector3 _moveVector;
    private Vector2 _moveInput;
    
    public override void _Ready()
    {
        MotionMode = MotionModeEnum.Floating;
    }
    
    public override void _PhysicsProcess(double delta)
    {
        Velocity = _moveVector;
        MoveAndSlide();
    }

    public override void _Input(InputEvent @event)
    {
        
    }

    public override void _Process(double delta)
    {
        _moveInput = Input.GetVector("character_move_backward", "character_move_forward",
            "character_move_right", "character_move_left");
        _moveVector = (Vector3.Forward * _moveInput.X + Vector3.Left * _moveInput.Y) * Speed * (float)delta;
        GD.Print(GetDirection());
    }

    public float GetDirection()
    {
        return float.Atan2Pi(_moveInput.Y, _moveInput.X);
    }

}
