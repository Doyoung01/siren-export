using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEXParticle : MonoBehaviour
{
    public ParticleSystem fire; // 불 파티클 시스템
    public ParticleSystem[] smokeParticles = new ParticleSystem[6]; // 최대 6개의 연기 파티클 시스템 배열

    private int collisionCounter = 0; // 충돌 횟수 기록

    private void OnParticleCollision(GameObject other)
    {
        // FireParticle 스크립트가 있는 오브젝트와만 충돌 반응
        FireParticle fireParticleComponent = other.gameObject.GetComponent<FireParticle>();
        if (fireParticleComponent != null)
        {
            // 충돌 횟수를 증가
            collisionCounter++;
            Debug.Log("소화기 파티클과 충돌 중. 충돌 횟수: " + collisionCounter);

            // `fire` 파티클과 연기 파티클들의 Emission 모듈 활성화 및 초기화
            if (fire == null) fire = other.GetComponentInChildren<ParticleSystem>();

            var fireEmission = fire.emission;
            fireEmission.enabled = true;

            // 연기 파티클 Emission 설정 및 활성화
            foreach (ParticleSystem smoke in smokeParticles)
            {
                if (smoke != null)
                {
                    var smokeEmission = smoke.emission;
                    smokeEmission.enabled = true;
                }
            }

            // 충돌 횟수에 따라 불과 연기의 Emission rateOverTime을 점진적으로 줄임
            if (collisionCounter >= 110)
            {
                fireEmission.rateOverTime = Mathf.Lerp(100.0f, 0.0f, collisionCounter * 0.05f);
                
                foreach (ParticleSystem smoke in smokeParticles)
                {
                    if (smoke != null)
                    {
                        var smokeEmission = smoke.emission;
                        smokeEmission.rateOverTime = Mathf.Lerp(5.0f, 0.0f, collisionCounter * 0.05f);
                    }
                }

                // 불이 완전히 진압되었을 때 모든 파티클 시스템 정지
                if (fireEmission.rateOverTime.constant <= 0.1f)
                {
                    Debug.Log("불이 완전히 진압되었습니다.");
                    fire.Stop();
                    
                    foreach (ParticleSystem smoke in smokeParticles)
                    {
                        if (smoke != null)
                        {
                            smoke.Stop();
                        }
                    }
                }
            }
        }
    }
}
