using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishFire : MonoBehaviour
{
    public GameObject finishFireEx; // FinishFireEx 오브젝트
    public List<fireScale1> fireParticles; // 모든 불 파티클들을 할당할 리스트

    private void Start()
    {
        if (finishFireEx == null)
        {
            Debug.LogError("FinishFireEx 오브젝트가 할당되지 않았습니다.");
            return;
        }

        finishFireEx.SetActive(false); // 시작 시 FinishFireEx 오브젝트 비활성화
    }

    private void Update()
    {
        if (AreAllFiresExtinguished())
        {
            finishFireEx.SetActive(true); // 모든 불이 꺼지면 FinishFireEx 활성화
            Debug.Log("모든 불이 진압되었습니다!");
        }
    }

    // 모든 불 파티클이 꺼졌는지 확인하는 메서드
    private bool AreAllFiresExtinguished()
    {
        foreach (var fireParticle in fireParticles)
        {
            if (fireParticle.GetCurrentIntensity() > 0) // GetCurrentIntensity() 메서드를 통해 접근
            {
                return false;
            }
        }
        return true;
    }
}
