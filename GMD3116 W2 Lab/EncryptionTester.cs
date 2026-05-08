using UnityEngine;


public class EncryptionTester : MonoBehaviour
{
    public SecureDataManager dataManager;

    void Start()
    {
        // Log on for 2 different users
        UserSession playerUser = new UserSession("User", "pass_A", UserRole.Player);
        UserSession adminUser = new UserSession("Developer", "pass_B", UserRole.Admin);

        // user attempts to add 200 health
        dataManager.AdjustHealth(playerUser, 200); 

        // admin attempts to adjust health
        dataManager.AdjustHealth(adminUser, 50);

        // player tries to delete account fail
        dataManager.DeleteAccount(playerUser, "wrong_password_hash");

        // player tries to delete account success
        dataManager.DeleteAccount(playerUser, "hashed_pass_A");
    }
}
