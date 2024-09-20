using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireExtinguisherInteraction : MonoBehaviour
{
    public Animator leftHandAnimator;   // 왼손 애니메이터
    public Animator rightHandAnimator;  // 오른손 애니메이터
    public XRRayInteractor rayInteractor; // XR Ray Interactor에 대한 참조
    public Transform parentObject;  // 부모 오브젝트를 미리 할당 (이름 필요 없음)

    private GameObject fireObject; // 비활성화된 자식 오브젝트를 찾기 위한 변수

    private void Start()
    {
        // XRRayInteractor에서 selectEntered 이벤트를 구독합니다.
        if (rayInteractor != null)
        {
            rayInteractor.selectEntered.AddListener(OnSelectEntered);
        }

        // 부모 오브젝트를 통해 비활성화된 자식 오브젝트 찾기
        fireObject = FindInactiveChildByName(parentObject, "Fireextinguisher(fire)");

        if (fireObject == null)
        {
            Debug.LogWarning("'Fireextinguisher(fire)' 오브젝트를 부모로부터 찾을 수 없습니다.");
        }
        else
        {
            Debug.Log("'Fireextinguisher(fire)' 오브젝트가 성공적으로 부모로부터 참조되었습니다: " + fireObject.name);
            fireObject.SetActive(false); // 시작 시 비활성화 상태로 설정
        }
    }

    // selectEntered 이벤트가 발생할 때 호출되는 함수
    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log("OnSelectEntered 호출됨");

        if (args.interactableObject.transform.CompareTag("fireextinguisher"))
        {
            Debug.Log("소화기 선택됨: " + args.interactableObject.transform.name);

            // 소화기 비활성화
            DeactivateFireExtinguisher(args.interactableObject.transform.gameObject);

            // "Fireextinguisher(fire)" 오브젝트 활성화
            ActivateFireObject();

            // 손 애니메이션 실행
            PlayHandAnimations();
        }
    }

    // 부모 오브젝트에서 비활성화된 자식 오브젝트 찾기 (이름으로 찾음)
    private GameObject FindInactiveChildByName(Transform parent, string childName)
    {
        if (parent != null)
        {
            foreach (Transform child in parent)
            {
                if (child.name == childName && !child.gameObject.activeSelf)
                {
                    return child.gameObject;  // 비활성화된 자식을 반환
                }
            }
        }
        return null;
    }

    // 소화기 오브젝트를 비활성화하는 함수
    private void DeactivateFireExtinguisher(GameObject extinguisher)
    {
        if (extinguisher != null && extinguisher.activeSelf)
        {
            extinguisher.SetActive(false);
            Debug.Log("소화기 비활성화됨: " + extinguisher.name);
        }
    }

    // "Fireextinguisher(fire)" 오브젝트를 활성화하는 함수
    private void ActivateFireObject()
    {
        if (fireObject != null && !fireObject.activeSelf)
        {
            fireObject.SetActive(true);
            Debug.Log("'Fireextinguisher(fire)' 오브젝트 활성화됨: " + fireObject.name);
        }
        else
        {
            Debug.LogWarning("'Fireextinguisher(fire)' 오브젝트가 null이거나 이미 활성화된 상태입니다.");
        }
    }

    private void PlayHandAnimations()
    {
        // 왼손 애니메이션 실행
        if (leftHandAnimator != null)
        {
            leftHandAnimator.SetTrigger("GrabFireExtinguisherLeft");
        }

        // 오른손 애니메이션 실행
        if (rightHandAnimator != null)
        {
            rightHandAnimator.SetTrigger("GrabFireExtinguisherRight");
        }
    }

    private void OnDestroy()
    {
        if (rayInteractor != null)
        {
            rayInteractor.selectEntered.RemoveListener(OnSelectEntered);
        }
    }
}
