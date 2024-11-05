using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_IOS
using UnityEngine.ParticleSystemModule;
#endif

public class fireScale1 : MonoBehaviour
{
    public GameObject fire;

    [SerializeField, Range(0f, 1f)] private float currentIntensity = 0.1f; // 초기 강도를 낮게 설정
    private float startIntensity = 0f;

    [SerializeField] private ParticleSystem firePS;

    private float time = 0f;
    [SerializeField] private float spreadSpeed = 0.001f; // 불 번지는 속도

    private ParticleSystem.EmissionModule emissionModule;
    private ParticleSystem.MainModule mainModule;

    private void Start()
    {
        if (firePS == null)
        {
            Debug.LogError("firePS가 연결되지 않았습니다.");
            return;
        }

        // ParticleSystem 인스턴스에서 Emission과 Main 모듈을 직접 참조
        emissionModule = firePS.emission;
        mainModule = firePS.main;

        startIntensity = emissionModule.rateOverTime.constant;
        Debug.Log("초기 강도: " + startIntensity);

        mainModule.startSize = new ParticleSystem.MinMaxCurve(0.2f); // 시작 크기를 작게 설정
        firePS.Play(); // 파티클 시스템을 활성화
    }

    private void Update()
    {
        if (firePS == null)
            return;

        SpreadFire();
        ChangeIntensity();
        IncreaseParticleSize();
    }

    private void ChangeIntensity()
    {
        // 이미 firePS에서 가져온 emissionModule을 사용
        emissionModule.rateOverTime = new ParticleSystem.MinMaxCurve(currentIntensity * startIntensity);
    }

    // 불이 점점 번지는 효과를 주기 위한 메서드
    private void SpreadFire()
    {
        if (currentIntensity < 1f)
        {
            currentIntensity += spreadSpeed * Time.deltaTime; // 점진적으로 강도 증가
        }
        else
        {
            currentIntensity = 1f; // 최대 강도 제한
        }
    }

    // 파티클 크기를 점점 증가시키는 메서드, 최대 크기인 4에 도달하면 그 크기를 유지
    private void IncreaseParticleSize()
    {
        // 이미 firePS에서 가져온 mainModule을 사용
        if (mainModule.startSize.constant < 4f)
        {
            float newSize = Mathf.Min(mainModule.startSize.constant + 0.5f * Time.deltaTime, 4f); // 크기 증가, 1초에 0.5씩 증가
            mainModule.startSize = new ParticleSystem.MinMaxCurve(newSize); // 새로운 크기를 설정
        }
    }
}
