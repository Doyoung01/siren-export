using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_extinguisher : MonoBehaviour
{
    [SerializeField] private float amountExtinguishedPerSecond = 1.0f;
    [SerializeField] private GameObject extinguisherParticlePrefab; // 소화기 파티클 프리팹

    private void Update()
    {
        // 마우스 왼쪽 버튼이 클릭되었는지 확인
        if (Input.GetMouseButtonDown(0))
        {
            // 카메라의 레이를 생성하여 충돌을 감지
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
            {
                // 충돌한 오브젝트가 Fire 컴포넌트를 가지고 있는지 확인
                if (hit.collider.TryGetComponent(out Fire fire))
                {
                    // 소화기 파티클 생성
                    Instantiate(extinguisherParticlePrefab, hit.point, Quaternion.identity);

                    // 화재를 소화
                    fire.TryExtinguish(amountExtinguishedPerSecond * Time.deltaTime);
                }
            }
        }
    }
}
