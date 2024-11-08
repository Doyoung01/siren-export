using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject[] infoObjects; // Info 오브젝트 배열
    public Button[] buttons; // 버튼 배열

    private void Start()
    {
        // 먼저 infoObjects 배열에서 첫 번째 요소만 활성화하고 나머지는 비활성화
        for (int i = 0; i < infoObjects.Length; i++)
        {
            infoObjects[i].SetActive(i == 0); // 첫 번째 Info만 활성화
        }

        // buttons 배열과 infoObjects 배열의 최소 길이까지만 이벤트 할당
        int maxLength = Mathf.Min(buttons.Length, infoObjects.Length); // 두 배열의 최소 길이 사용
        for (int i = 0; i < maxLength; i++)
        {
            int index = i; // 변수로 인덱스 고정
            buttons[i].onClick.AddListener(() => ShowInfo(index));
        }
    }

    private void ShowInfo(int index)
    {
        // 모든 Info 오브젝트 비활성화
        foreach (var info in infoObjects)
        {
            info.SetActive(false);
        }

        // 선택한 Info 오브젝트만 활성화
        if (index >= 0 && index < infoObjects.Length)
        {
            infoObjects[index].SetActive(true);
        }
    }
}
