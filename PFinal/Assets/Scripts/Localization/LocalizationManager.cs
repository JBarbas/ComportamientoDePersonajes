using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager instance;

    private Dictionary<string, string> localizedText;

    private bool ready = false;

    private string missingKey = "Key not found";

    
    private void Awake()
    {
        
        // Comprobamos que sea la única instancia
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);

        loadLocalizedText("esp.json");

        // Al cambiar de escenas mantenemos este gameObject
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.P))
            loadLocalizedText("gal.json");
        if (Input.GetKeyDown(KeyCode.O))
            loadLocalizedText("eng.json");*/
    }

    public void loadLocalizedText(string fileName)
    {
        localizedText = new Dictionary<string, string>();
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);

            for(int i = 0; i < loadedData.items.Length; i++){
                localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);
            }
        }
        else
        {
            Debug.Log("File not found");
        }

        ready = true;
    }

    public string getValue(string key)
    {
        string value = missingKey;
        if (localizedText.ContainsKey(key))
        {
            value = localizedText[key];
        }
        return value;
    }

    public bool isReady()
    {
        return ready;
    }

}
