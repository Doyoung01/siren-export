using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    public List<GameObject> fireFlames; // fire flame 오브젝트들을 저장할 리스트
    public Transform startPoint; // 시작 위치
    public float activationInterval = 2f; // 오브젝트가 활성화되는 간격 (초 단위)

    private float timer = 0f;
    private int currentIndex = 0;

    private void Start()
    {
        // fireFlames 리스트를 시작 위치에서 가까운 순으로 정렬
        fireFlames.Sort((a, b) =>
            Vector3.Distance(startPoint.position, a.transform.position).CompareTo(
            Vector3.Distance(startPoint.position, b.transform.position)));

        // 모든 오브젝트 비활성화
        foreach (var fire in fireFlames)
        {
            fire.SetActive(false);
        }
    }

    private void Update()
    {
        // 타이머를 활성화 간격과 비교
        timer += Time.deltaTime;
        if (timer >= activationInterval && currentIndex < fireFlames.Count)
        {
            // 가까운 순서로 오브젝트를 하나씩 활성화
            fireFlames[currentIndex].SetActive(true);
            currentIndex++;
            timer = 0f; // 타이머 초기화
        }
    }
}

