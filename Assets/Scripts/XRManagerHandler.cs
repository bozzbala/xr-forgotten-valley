using UnityEngine;

public class XRManagerHandler : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject); // Сохранить объект при смене сцены
    }

    void Start()
    {
        // Проверка XR устройства
        if (UnityEngine.XR.XRSettings.isDeviceActive)
        {
            Debug.Log("XR устройство активно.");
        }
        else
        {
            Debug.LogError("XR устройство не активно.");
        }
    }
}
