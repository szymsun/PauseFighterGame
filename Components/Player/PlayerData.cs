using Godot;
using PauseFighterGame.Components.WeaponSystem;

namespace PauseFighterGame.Components.Player;

public partial class PlayerData : Node
{
    public PlayerCharacterController PhysicalPlayer;

    public Weapon[] WeaponsInv;
    private int _currentWeaponIndex = 0;
    
    public void UseCurrentWeapon(float angle)
    {
        
    }
}