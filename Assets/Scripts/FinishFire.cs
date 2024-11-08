using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishFire : MonoBehaviour
{
    public GameObject fireFinishEx; // FireFinishEx 오브젝트
    public List<fireScale1> fireParticles; // 모든 불 파티클들의 리스트

    private bool isFireFinishExActivated = false; // FireFinishEx가 활성화되었는지 확인하는 플래그

    private void Start()
    {
        if (fireFinishEx == null)
        {
            Debug.LogError("FireFinishEx 오브젝트가 할당되지 않았습니다.");
            return;
        }

        fireFinishEx.SetActive(false); // 시작 시 FireFinishEx 오브젝트 비활성화
    }

    private void Update()
    {
        // FireFinishEx가 활성화되지 않았고 모든 불 파티클이 소화된 경우
        if (!isFireFinishExActivated && AreAllFiresExtinguished())
        {
            fireFinishEx.SetActive(true); // 모든 불이 꺼지면 FireFinishEx 활성화
            isFireFinishExActivated = true; // 플래그를 true로 설정하여 다시 활성화되지 않도록 함
            Debug.Log("모든 불이 진압되었습니다!");
        }
    }

    // 모든 불 파티클이 꺼졌는지 확인하는 메서드
    private bool AreAllFiresExtinguished()
    {
        foreach (var fireParticle in fireParticles)
        {
            if (fireParticle.GetCurrentIntensity() > 0) // 각 파티클의 강도가 0인지 확인
            {
                return false; // 어떤 불이라도 강도가 남아있으면 false 반환
            }
        }
        return true;
    }
}
