using System;
using System.Net;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    
    public SaveData saveData;
    
    private string filePath;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            {
                Destroy(gameObject);
            }
        }
        
        saveData = GetComponent<SaveData>();
        filePath = Application.persistentDataPath + "/SaveData.save";
    }

    public bool WriteSaveToFile()
    {
        try
        {
            string saveDatajson = saveData.saveDataSo.SavaDataToJson();
            File.WriteAllText(filePath, saveDatajson);
            Debug.Log("Save data written to file" + filePath);
            return true;
        }

        catch (Exception e)
        {
            Debug.Log(e.Message);
            return false;
        }
    }

    public bool LoadSaveFromFile()
    {
        try
        {
            if (File.Exists(filePath))
            {
                string saveDatajson = File.ReadAllText(filePath);
                saveData.saveDataSo.LoadDataFromJson(saveDatajson);
                Debug.Log("Save data loaded from file" + filePath);
                return true;
            }
            else
            {
                Debug.LogWarning("No save file found" + filePath);
                return false;
            }
            
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            return false;
        }
    }
}
