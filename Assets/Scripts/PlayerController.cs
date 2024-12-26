using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private GameManager gm;

    private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Note"))
            {
                Destroy(other.gameObject);
                gm.noteNum += 1;
            }
            if (other.CompareTag("Life"))
            {
                Destroy(other.gameObject);
                gm.lives += 1;
            }
            if (other.CompareTag("Death"))
            {
                Destroy(other.gameObject);
                gm.lives -= 1;
            }
            if (other.CompareTag("Enemy"))
            {
                other.gameObject.transform.position = new Vector3(-60, 1, -45);
                gm.lives -= 1;
            }
    }
}
