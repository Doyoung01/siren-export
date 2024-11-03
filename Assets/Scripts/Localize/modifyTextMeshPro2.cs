using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class modifyTextMeshPro : MonoBehaviour
{
    public GameObject prefab;
    public Transform parent;
    public LocalizationManager localizationManager;

    private List<string> ftitleList;
    private List<string> fcontentList1;
    private List<string> fcontentList2;

    private void Start()
    {
        ftitleList = localizationManager.GetLocalizedTextList("ftitleList");
        fcontentList1 = localizationManager.GetLocalizedTextList("fcontentList1");
        fcontentList2 = localizationManager.GetLocalizedTextList("fcontentList2");
    }

    // 기존 코드에서 ftitleList, fcontentList1, fcontentList2를 사용하던 곳에 변경된 값을 반영합니다.
}
