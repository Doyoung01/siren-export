using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GameController : MonoBehaviour
{
    private void Start()
    {
        // 해당 스크립트가 적용된 GameObject가 ray interactor를 가지고 있는지 확인
        XRDirectInteractor directInteractor = GetComponent<XRDirectInteractor>();
        if (directInteractor == null)
        {
            Debug.LogError("This script requires XRDirectInteractor component. Add XR Direct Interactor to the GameObject.");
            return;
        }

        // 이벤트 리스너 등록
        directInteractor.selectEntered.AddListener(OnSelectEntered);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Ray interactor가 GameObject에 닿았을 때 호출되는 함수
        GameObject selectedObject = args.interactable.gameObject;

        // 'gameController' 태그를 가진 경우 해당 GameObject를 제거
        if (selectedObject.CompareTag("GameController"))
        {
            Destroy(selectedObject);
        }
    }
}
