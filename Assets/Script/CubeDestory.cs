using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CubeDestory : MonoBehaviour
{
    public float power = 10f;
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        Vector3 baseDirection = transform.up;

        // 기준 방향에 무작위 벡터를 섞음
        Vector3 randomOffset = new Vector3(
            Random.Range(-0.5f, 0.5f),
            Random.Range(-0.1f, 0.1f),  // Y축 흔들림은 줄일 수도 있음
            Random.Range(-0.5f, 0.5f)
        );

        // 방향 벡터 정규화
        Vector3 finalDirection = (baseDirection + randomOffset).normalized;

        // 무작위 세기
        float randomPower = Random.Range(5f, 10f);

        // 힘 적용
        rb.AddForce(finalDirection * randomPower, ForceMode.Impulse);
        Invoke("Destroy", 2f);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
