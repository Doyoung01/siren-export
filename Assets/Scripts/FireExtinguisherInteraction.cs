using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireExtinguisherInteraction : MonoBehaviour
{
    public Animator leftHandAnimator;   // �޼� �ִϸ�����
    public Animator rightHandAnimator;  // ������ �ִϸ�����
    public XRRayInteractor rayInteractor; // XR Ray Interactor�� ���� ����
    public Transform parentObject;  // �θ� ������Ʈ�� �̸� �Ҵ� (�̸� �ʿ� ����)

    private GameObject fireObject; // ��Ȱ��ȭ�� �ڽ� ������Ʈ�� ã�� ���� ����

    private void Start()
    {
        // XRRayInteractor���� selectEntered �̺�Ʈ�� �����մϴ�.
        if (rayInteractor != null)
        {
            rayInteractor.selectEntered.AddListener(OnSelectEntered);
        }

        // �θ� ������Ʈ�� ���� ��Ȱ��ȭ�� �ڽ� ������Ʈ ã��
        fireObject = FindInactiveChildByName(parentObject, "Fireextinguisher(fire)");

        if (fireObject == null)
        {
            Debug.LogWarning("'Fireextinguisher(fire)' ������Ʈ�� �θ�κ��� ã�� �� �����ϴ�.");
        }
        else
        {
            Debug.Log("'Fireextinguisher(fire)' ������Ʈ�� ���������� �θ�κ��� �����Ǿ����ϴ�: " + fireObject.name);
            fireObject.SetActive(false); // ���� �� ��Ȱ��ȭ ���·� ����
        }
    }

    // selectEntered �̺�Ʈ�� �߻��� �� ȣ��Ǵ� �Լ�
    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log("OnSelectEntered ȣ���");

        if (args.interactableObject.transform.CompareTag("fireextinguisher"))
        {
            Debug.Log("��ȭ�� ���õ�: " + args.interactableObject.transform.name);

            // ��ȭ�� ��Ȱ��ȭ
            DeactivateFireExtinguisher(args.interactableObject.transform.gameObject);

            // "Fireextinguisher(fire)" ������Ʈ Ȱ��ȭ
            ActivateFireObject();

            // �� �ִϸ��̼� ����
            PlayHandAnimations();
        }
    }

    // �θ� ������Ʈ���� ��Ȱ��ȭ�� �ڽ� ������Ʈ ã�� (�̸����� ã��)
    private GameObject FindInactiveChildByName(Transform parent, string childName)
    {
        if (parent != null)
        {
            foreach (Transform child in parent)
            {
                if (child.name == childName && !child.gameObject.activeSelf)
                {
                    return child.gameObject;  // ��Ȱ��ȭ�� �ڽ��� ��ȯ
                }
            }
        }
        return null;
    }

    // ��ȭ�� ������Ʈ�� ��Ȱ��ȭ�ϴ� �Լ�
    private void DeactivateFireExtinguisher(GameObject extinguisher)
    {
        if (extinguisher != null && extinguisher.activeSelf)
        {
            extinguisher.SetActive(false);
            Debug.Log("��ȭ�� ��Ȱ��ȭ��: " + extinguisher.name);
        }
    }

    // "Fireextinguisher(fire)" ������Ʈ�� Ȱ��ȭ�ϴ� �Լ�
    private void ActivateFireObject()
    {
        if (fireObject != null && !fireObject.activeSelf)
        {
            fireObject.SetActive(true);
            Debug.Log("'Fireextinguisher(fire)' ������Ʈ Ȱ��ȭ��: " + fireObject.name);
        }
        else
        {
            Debug.LogWarning("'Fireextinguisher(fire)' ������Ʈ�� null�̰ų� �̹� Ȱ��ȭ�� �����Դϴ�.");
        }
    }

    private void PlayHandAnimations()
    {
        // �޼� �ִϸ��̼� ����
        if (leftHandAnimator != null)
        {
            leftHandAnimator.SetTrigger("GrabFireExtinguisherLeft");
        }

        // ������ �ִϸ��̼� ����
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
