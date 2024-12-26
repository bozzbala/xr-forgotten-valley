using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private float speed = 5.0f;

    void Update()
    {
        MoveTowardsPlayer();
        LookAtPlayer();
    }

    private void MoveTowardsPlayer()
    {
        Vector3 direction = (playerPos.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    private void LookAtPlayer()
    {
        Vector3 direction = (playerPos.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);
    }
}
