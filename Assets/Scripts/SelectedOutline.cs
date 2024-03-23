using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SelectedOutline : MonoBehaviour
{
    public XRRayInteractor rayInteractor; // XR Ray Interactor�� ���� ����

    private Material outline;
    private Renderer renderers;
    private List<Material> materialList = new List<Material>();

    private void Start()
    {
        outline = new Material(Shader.Find("Custom/OutlineShader"));
        rayInteractor.selectEntered.AddListener(OnSelectEnter); // �̺�Ʈ ������ �߰�
    }

    private void OnDestroy()
    {
        rayInteractor.selectEntered.RemoveListener(OnSelectEnter); // �̺�Ʈ ������ ����
    }

    private void OnSelectEnter(SelectEnterEventArgs args)
    {
        if (args.interactableObject.transform == this.transform)
        {
            ApplyOutline();
        }
    }

    private void ApplyOutline()
    {
        renderers = GetComponent<Renderer>();
        materialList.Clear();
        materialList.AddRange(renderers.sharedMaterials);
        materialList.Add(outline);
        renderers.materials = materialList.ToArray();
    }
}