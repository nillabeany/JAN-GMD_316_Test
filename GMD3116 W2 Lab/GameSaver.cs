using UnityEngine;
using System.IO;

public class GameSaver : MonoBehaviour
{
    [Header("Drag ScriptableObject to inspector.")]
    public PlayerStats realPlayerStats;

    private string savePath;

    void Awake()
    {
        // drive save path
        savePath = Application.persistentDataPath + "/saveData.dat";
    }

    public void SaveGame()
    {
        // Scriptable Object to JSON
        string jsonToSave = JsonUtility.ToJson(realPlayerStats);

        // JSON Encryption
        string encryptedData = EncryptionAES.Encrypt(jsonToSave);

        // Write Save
        File.WriteAllText(savePath, encryptedData);
        Debug.Log("Game Saved to " + savePath);
    }

    public void LoadGame()
    {
        if (File.Exists(savePath))
        {
            // 1. Read the encrypted file
            string loadedEncryptedData = File.ReadAllText(savePath);

            // 2. Decrypt it back to a JSON string
            string decryptedJson = EncryptionAES.Decrypt(loadedEncryptedData);

            // 3. Overwrite the existing ScriptableObject with the loaded data
            JsonUtility.FromJsonOverwrite(decryptedJson, realPlayerStats);
            Debug.Log("Load Success");
        }
        else
        {
            Debug.LogWarning("No data");
        }
    }
}
