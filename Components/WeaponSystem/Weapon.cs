using Godot;

namespace PauseFighterGame.Components.WeaponSystem;

public abstract class Weapon(string name)
{
    private string _name = name;
    public abstract void Use();
}