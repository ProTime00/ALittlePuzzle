using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MenuInLevel : MonoBehaviour
{
    public GameObject menu;
    private int _levelReached;
    private bool _menuState;

    private void Awake()
    {
        _levelReached = PlayerPrefs.GetInt("level");
        menu.SetActive(false);
    }

    public void ChangeMenu()
    {
        _menuState = !_menuState;
        menu.SetActive(_menuState);
    }
}
