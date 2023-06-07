using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;
using System;

public class ControlAppsFlyerUI : MonoBehaviour
{
    private static ControlAppsFlyerUI _instance;
    [SerializeField] private AppsFlyerObjectScript appsFlyerObj;
    [SerializeField] private Image deepLinkParamsScreen;
    [SerializeField] private Image conversionDataScreen;
    [SerializeField] private TMP_Text conversionDataText;
    [SerializeField] private TMP_Text DeepLinkParamsText;

    private string _persistentpath = "";
    private PlayerData _playerData;

    [SerializeField] private TMP_InputField referrerNameInput;

    private static Dictionary<string, object> ConvertionData { get => _instance.appsFlyerObj.ConversionData; }
    // Start is called before the first frame update

    public static Dictionary<string, object> DeepLinkParams { get => _instance.appsFlyerObj.DeepLinkParams; }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            InIt();
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        ShowConversionDataScreen();
        ShowDeepLinkParamsScreen();
    }

    // Update is called once per frame
    void Update()
    {
        if (appsFlyerObj.DidReceivedDeepLink)
        {
            appsFlyerObj.DidReceivedDeepLink = false;
            ShowDeepLinkParamsScreen();
        }
    }

    public static void ShareUserIniviteLink(string referrerName)
    {
        // start at level 1, with five extra butterflies, with no extra point, and give five extra buterflies to the inviter
        _instance.appsFlyerObj.generateAppsFlyerLink(referrerName, "1", "5", "0", 5);
        _instance.StartCoroutine(_instance.ShareLink(referrerName));

    }
    private void ShareUserInviteLink()
    {
        string referrerName = referrerNameInput.text;
        ShareUserIniviteLink(referrerName);
    }

    public void ShowConversionDataScreen()
    {
        conversionDataScreen.gameObject.SetActive(true);
        Dictionary<string, object> convertionData = _instance.appsFlyerObj.ConversionData;
        string text = "Conversion Data Loading...";
        if (convertionData != null)
        {
            if (convertionData.ContainsKey("convertion_data_error"))
            {
                text = "Conversion Data Error.";
            }
            else
            {
                text = "";
                foreach (KeyValuePair<string, object> entry in convertionData)
                {
                    text += entry.Key + ": ";
                    if (entry.Value != null)
                    {
                        text += entry.Value.ToString() + '\n';
                    }
                    else
                    {
                        text += "null\n";
                    }
                }
            }
        }
        conversionDataText.text = text;
        Debug.Log(conversionDataText.text);
    }
    public static void ShowDeepLinkParamsScreen()
    {
        _instance.deepLinkParamsScreen.gameObject.SetActive(true);

        Dictionary<string, object> deepLinkParams = _instance.appsFlyerObj.DeepLinkParams;
        string text = "No bonuses have received yet. You can check again in a bit.";
        if (deepLinkParams != null)
        {
            string[] headlines = { "Start level", "Extra butterflies", "Extra points", "Referrer name" };
            if (deepLinkParams.ContainsKey("deep_link_error"))
            {
                text = "Bonuses Loading Error.";
            }
            else if (deepLinkParams.ContainsKey("deep_link_not_found"))
            {
                text = "Can Not Find Bonuses.";
            }
            else
            {
                int i = 0;
                text = "";
                foreach (KeyValuePair<string, object> entry in deepLinkParams)
                {
                    if (i < deepLinkParams.Count)
                    {
                        text += headlines[i] + ": ";
                        if (entry.Value != null)
                        {
                            text += entry.Value.ToString() + '\n';
                        }
                        else
                        {
                            text += "null\n";
                        }
                        i++;
                    }
                }
                if (i == 0)
                {
                    text = "Deep Link Received With No Bonuses.";
                }
            }
        }
        _instance.DeepLinkParamsText.text = text;
    }

    private void InIt()
    {
        initializeConstantFields();

        initializePlayerData();
    }

    private void initializeConstantFields()
    {

        _persistentpath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
    }

    private void initializePlayerData()
    {
        try
        {
            using (StreamReader reader = new StreamReader(_persistentpath))
            {
                string readJson = reader.ReadToEnd();
                if (readJson == null || readJson == "")
                {
                    using (StreamWriter writer = new StreamWriter(_persistentpath))
                    {
                        string writeJson = JsonUtility.ToJson(_playerData);
                        writer.Write(writeJson);
                    }
                }
                else
                {
                    _playerData = JsonUtility.FromJson<PlayerData>(readJson);
                    Debug.Log(_playerData);
                }

            }
        }
        catch (FileNotFoundException e)
        {
            _playerData = new PlayerData(true, 0);
        }
    }



    private IEnumerator ShareLink(string referrerName)
    {
        yield return new WaitForSeconds(2);

        if (appsFlyerObj.UserInviteLink != null)
        {
            new NativeShare()
               .SetUrl(appsFlyerObj.UserInviteLink)
               .SetText("Hello! " + referrerName + " has invited you to join FlappyDD and get a spacial gift!\nClick on the link to download/open the game:")
               .Share();
        }
        else
        {
            Debug.Log("unlucky...");
        }
    }
}


[Serializable]
public class PlayerData
{

    public bool isFirstLaunch;
    public int highestScore;
    public int currentLevel;




    public PlayerData(bool isFirstLaunch, int highestScore, int currentLevel = 1)
    {
        this.isFirstLaunch = isFirstLaunch;
        this.highestScore = highestScore;
        this.currentLevel = currentLevel;
    }
}