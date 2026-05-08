using UnityEngine;


[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptable Objects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public string playerName;
    public string description;

    public int playerSpeed;
    public int playerStrength;
    public int playerHealth;

}
