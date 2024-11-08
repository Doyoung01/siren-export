using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject[] infoObjects; // Info 오브젝트 배열
    public Button[] buttons; // 1, 2, 3, 4, 5, 6, 7 버튼 배열

    private void Start()
    {
        // 처음 시작할 때 info1만 활성화하고 나머지는 비활성화
        for (int i = 0; i < infoObjects.Length; i++)
        {
            infoObjects[i].SetActive(i == 0); // 첫 번째 Info만 활성화
        }

        // 각 버튼에 클릭 이벤트를 할당합니다.
        buttons[0].onClick.AddListener(() => ShowInfo(0)); // 버튼 1
        buttons[1].onClick.AddListener(() => ShowInfo(1)); // 버튼 2
        buttons[2].onClick.AddListener(() => ShowInfo(2)); // 버튼 3
        buttons[3].onClick.AddListener(() => ShowInfo(3)); // 버튼 4
        buttons[4].onClick.AddListener(() => ShowInfo(4)); // 버튼 5
        buttons[5].onClick.AddListener(() => ShowInfo(5)); // 버튼 6
        buttons[6].onClick.AddListener(() => ShowInfo(6)); // 버튼 7
    }

    private void ShowInfo(int index)
    {
        // 모든 Info 오브젝트를 비활성화
        for (int i = 0; i < infoObjects.Length; i++)
        {
            infoObjects[i].SetActive(false);
        }

        // 선택한 Info 오브젝트만 활성화
        if (index >= 0 && index < infoObjects.Length)
        {
            infoObjects[index].SetActive(true);
        }
    }
}
