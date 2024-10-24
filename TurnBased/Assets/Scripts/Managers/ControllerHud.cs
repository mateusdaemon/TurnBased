using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerHud : MonoBehaviour
{
    public GameObject controllerHUD;
    public Button interactBtn;
    public static ControllerHud Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void DisableControllerHUD()
    {
        controllerHUD.SetActive(false);
    }

    public void EnableControllerHUD()
    {
        controllerHUD.SetActive(true);
    }
}
