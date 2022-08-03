using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_manager : MonoBehaviour
{
    [SerializeField] GameObject Startscreen;

    public void PlayGame()
    {
        Startscreen.SetActive(false);
    }
}