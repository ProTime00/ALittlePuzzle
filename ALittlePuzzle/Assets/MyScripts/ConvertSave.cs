using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConvertSave : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.HasKey("converted"))
        {
            return;
        }
        PlayerPrefs.SetInt("converted", 1);
        PlayerPrefs.Save();
        for (int i = 1; i < SceneManager.sceneCountInBuildSettings - 1; i++)
        {
            PlayerPrefs.SetInt($"{i}", 0);
            PlayerPrefs.Save();
        }
        for (int i = 1; i < PlayerPrefs.GetInt("level"); i++)
        {
            PlayerPrefs.SetInt($"{i}", 1);
            PlayerPrefs.Save();
        }
    }
}
