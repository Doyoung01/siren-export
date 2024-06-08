using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresButtonEx : MonoBehaviour
{
    public GameObject particleSystemObject;

    private ParticleSystem particleSystem;
    private bool isParticleSystemActive = false;

    private void Start()
    {
        particleSystem = particleSystemObject.GetComponent<ParticleSystem>();
        particleSystemObject.SetActive(false); // 파티클 시스템을 비활성화합니다.
    }

    private void Update()
    {
        // 마우스 왼쪽 버튼이 클릭되었는지 확인
        if (Input.GetMouseButtonDown(0))
        {
            // 마우스 클릭 위치에서 Ray를 발사하여 충돌 감지
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // 클릭된 오브젝트가 이 스크립트가 붙은 오브젝트인지 확인
                if (hit.collider.gameObject == gameObject)
                {
                    // 파티클 시스템 활성화
                    ToggleParticleSystem(true);
                }
            }
        }
    }

    private void ToggleParticleSystem(bool activate)
    {
        // 파티클 시스템을 활성화 또는 비활성화합니다.
        particleSystemObject.SetActive(activate);
        isParticleSystemActive = activate;

        // 파티클 시스템이 활성화된 경우 재생합니다.
        if (activate)
        {
            particleSystem.Play();
        }
        // 활성화되지 않은 경우 중지합니다.
        else
        {
            particleSystem.Stop();
        }
    }
}


