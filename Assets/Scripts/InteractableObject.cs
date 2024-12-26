using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractableObject : MonoBehaviour
{
    private GameManager gm;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        if (gm == null)
        {
            Debug.LogError("GameManager не найден!");
        }
    }

    public void OnSelectEnter(XRBaseInteractor interactor)
    {
        if (gm == null) return;

        if (gameObject.CompareTag("Life"))
        {
            gm.lives += 1;
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("Death"))
        {
            gm.lives -= 1;
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("Note"))
        {
            gm.noteNum += 1;
            Destroy(gameObject);
        }
        // Добавьте другие тэги и действия, если необходимо
    }
}
