using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public PowerUp[] inventory = new PowerUp[3];

    // Pick up
    public bool AddPower(PowerUp newPower)
    {
        // Find first slot
        for (int i = 0; i < inventory.Length; i++)
        {
         
            if (inventory[i] == null)
            {
                // Add
                inventory[i] = newPower;

                // Log
                Debug.Log("Power Collected" + newPower.name);

                return true;
            }
        }

        // Full inventory
        Debug.Log("All power slots are full" + newPower.name);
        return false;
    }
}
