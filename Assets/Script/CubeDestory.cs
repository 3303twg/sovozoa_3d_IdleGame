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

        // ���� ���⿡ ������ ���͸� ����
        Vector3 randomOffset = new Vector3(
            Random.Range(-0.5f, 0.5f),
            Random.Range(-0.1f, 0.1f),  // Y�� ��鸲�� ���� ���� ����
            Random.Range(-0.5f, 0.5f)
        );

        // ���� ���� ����ȭ
        Vector3 finalDirection = (baseDirection + randomOffset).normalized;

        // ������ ����
        float randomPower = Random.Range(5f, 10f);

        // �� ����
        rb.AddForce(finalDirection * randomPower, ForceMode.Impulse);
        Invoke("Destroy", 2f);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
