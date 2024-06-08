using UnityEngine;
using System.Collections;

public class ParticleSystemController : MonoBehaviour
{
    public ParticleSystem particleSystem; // 파티클 시스템 참조

    public float growthDuration = 20f;   // 속성 증가 지속 시간
    public float startDelay = 2f;        // 시작 지연 시간
    private float timeElapsed = 0f;      // 경과 시간
    public float endSize = 8f; // 파티클 크기의 최종 값
    public float endRate = 10f; // 파티클 방출 속도의 최종 값
    public float endRadius = 3f; // 파티클 반경의 최종 값

    void Update()
    {
        if (particleSystem != null)
        {
            timeElapsed += Time.deltaTime; // 경과 시간 증가

            var main = particleSystem.main;
            var emission = particleSystem.emission;
            var shape = particleSystem.shape;

            if (timeElapsed >= startDelay) // 지연 후 값 변화 시작
            {
                float startSize = 1f;
                
                float sizeIncrement = (endSize - startSize) / (growthDuration - startDelay);
                float currentSize = Mathf.Min(startSize + sizeIncrement * (timeElapsed - startDelay), endSize);

                main.startSize = currentSize; // 파티클 크기 설정

                float startRate = 1f; // 초기 방출 속도
                
                float rateIncrement = (endRate - startRate) / (growthDuration - startDelay);
                float currentRate = Mathf.Min(startRate + rateIncrement * (timeElapsed - startDelay), endRate);

                emission.rateOverTime = currentRate; // 방출 속도 설정

                float startRadius = 1f; // 초기 반경
                
                float radiusIncrement = (endRadius - startRadius) / (growthDuration - startDelay);
                float currentRadius = Mathf.Min(startRadius + radiusIncrement * (timeElapsed - startDelay), endRadius);

                shape.radius = currentRadius; // 반경 설정
            }
            
            if (timeElapsed >= growthDuration) // 20초 이후 모든 값 고정
            {
                main.startSize = endSize; // 크기 고정
                emission.rateOverTime = endRate; // 방출 속도 고정
                shape.radius = endRadius; // 반경 고정
            }
        }
    }
}