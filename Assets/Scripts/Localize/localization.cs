using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class LocalizationManager : MonoBehaviour
{
    private Dictionary<string, Dictionary<string, List<string>>> localizedData;

    private string currentLanguage = "ko"; // 기본 언어 설정

    private void Start()
    {
        LoadLocalizationData();
    }

    private void LoadLocalizationData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "Localization.json");
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            localizedData = JsonUtility.FromJson<LocalizationWrapper>(jsonData).localizationData;

            if (!localizedData.ContainsKey(currentLanguage))
            {
                Debug.LogError("언어 데이터를 찾을 수 없습니다.");
            }
        }
        else
        {
            Debug.LogError("Localization.json 파일이 존재하지 않습니다.");
        }
    }

    public List<string> GetLocalizedTextList(string listName)
    {
        if (localizedData != null && localizedData.ContainsKey(currentLanguage))
        {
            if (localizedData[currentLanguage].ContainsKey(listName))
            {
                return localizedData[currentLanguage][listName];
            }
        }
        return new List<string>();
    }

    // 언어 변경
    public void ChangeLanguage(string newLanguage)
    {
        currentLanguage = newLanguage;
        LoadLocalizationData();
    }

    [System.Serializable]
    private class LocalizationWrapper
    {
        public Dictionary<string, Dictionary<string, List<string>>> localizationData;
    }
}

