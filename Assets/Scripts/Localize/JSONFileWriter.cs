using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class LocalizationData
{
    public string language;
    public Dictionary<string, string> translations;
}

public class JSONFileWriter : MonoBehaviour
{
    private void Start()
    {
        CreateJSONFile(); // 게임 시작 시 JSON 파일 생성
    }

    public void CreateJSONFile()
    {
        List<LocalizationData> localizationList = new List<LocalizationData>
        {
            new LocalizationData
            {
                language = "ko",
                translations = new Dictionary<string, string>
                {
                    { "title_working", "용접 기계 작업 시 주의사항" },
                    { "content_working", "어제 용접 화재가 꺼지지 않았습니다..." }
                }
            },
            new LocalizationData
            {
                language = "en",
                translations = new Dictionary<string, string>
                {
                    { "title_working", "When working with a welding machine" },
                    { "content_working", "Yesterday's welding fire was alive..." }
                }
            }
        };

        string jsonData = JsonUtility.ToJson(localizationList, true); // JSON 형식으로 변환
        string path = Application.dataPath + "/Scripts/LocalizationData.json"; // 저장 위치 변경
        File.WriteAllText(path, jsonData);

        Debug.Log("JSON file created at: " + path);
    }
}


