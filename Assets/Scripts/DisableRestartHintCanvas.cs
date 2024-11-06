using UnityEngine;

public class DisableRestartHintCanvas : MonoBehaviour
{
    public GameObject restartHintCanvas; // 비활성화할 오브젝트를 할당할 변수

    // 이 메서드를 버튼의 OnClick 이벤트에 연결합니다.
    public void DisableCanvas()
    {
        if (restartHintCanvas != null) // 오브젝트가 할당되었는지 확인
        {
            restartHintCanvas.SetActive(false); // 오브젝트 비활성화
        }
        else
        {
            Debug.LogWarning("RestartHintCanvas 오브젝트가 할당되지 않았습니다."); // 할당되지 않았을 때 경고 메시지
        }
    }
}
