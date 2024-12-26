using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    [SerializeField] Transform cameraPos;

    // Update is called once per frame
    void Update()
    {
        // Плавно поворачиваем фонарик
        transform.position = cameraPos.position;
    }
}
