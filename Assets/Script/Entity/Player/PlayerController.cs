using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget();
    }


    public void MoveToTarget()
    {
        //목표지점 설정
        Vector3 targetPos = target.transform.position + target.transform.forward * 1.5f;
        targetPos.y = 0f;

        float distance = Vector3.Distance(transform.position, targetPos);
        if(distance >= 0.1f)
        {
            Vector3 MoveDirection = (targetPos - transform.position).normalized;

            transform.position += MoveDirection * moveSpeed * Time.deltaTime;
        }
    }
}
