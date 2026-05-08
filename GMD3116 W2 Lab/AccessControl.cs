using UnityEngine;

public enum UserRole
{
    Guest,
    Player,
    Admin
}

// Session Authentication
public class UserSession
{
    public string Username { get; private set; }
    public UserRole Role { get; private set; }

    // In a real application, NEVER store plain-text passwords. Use hashed strings (e.g., SHA-256).
    private string passwordHash;

    public UserSession(string username, string passwordHash, UserRole role)
    {
        Username = username;
        this.passwordHash = passwordHash;
        Role = role;
    }

    // Method to authenticate the user's password
    public bool ValidatePassword(string inputHash)
    {
        return passwordHash == inputHash;
    }
}

// Authorization
public class SecureDataManager : MonoBehaviour
{
    // Define sensitive stuff
    private int playerHealth = 100;

    // Role Based access
    public void AdjustHealth(UserSession currentUser, int amount)
    {
        if (currentUser.Role != UserRole.Admin)
        {
            Debug.LogError($"Access Denied: User '{currentUser.Username}' is a {currentUser.Role}. Only Admins can grant bonus coins.");
            return; // Eject immediately
        }

        playerHealth += amount;
        Debug.Log($"<color=green>Success:</color> Admin '{currentUser.Username}' granted {amount} coins.");
    }

    // Password rejection and validator
    public void DeleteAccount(UserSession currentUser, string passwordAttemptHash)
    {
        if (!currentUser.ValidatePassword(passwordAttemptHash))
        {
            Debug.LogError("Access Denied: Incorrect password. Action aborted.");
            return; // Eject if wrong
        }

        // If password correct
        Debug.Log($"<color=red>Account Deleted</color> for user: {currentUser.Username}");
    }
}

