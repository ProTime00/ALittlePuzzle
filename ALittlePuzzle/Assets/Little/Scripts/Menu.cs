using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public GameObject fadePanelGO;
    public GameObject resetButton;

    private Animator fadePanel;
    AudioSource optionSelectClick;

    private void Start() {
        if (AnyLevelDone())
        {
            resetButton.SetActive(true);
        }
        optionSelectClick = GetComponent<AudioSource>();
    }

    private bool AnyLevelDone()
    {
        for (int i = 1; i < SceneManager.sceneCountInBuildSettings - 1; i++)
        {
            if (PlayerPrefs.GetInt($"{i}", 0) == 1)
            {
                return true;
            }
        }

        return false;
    }

    public void startGame() {
        optionSelectClick.Play();
        fadePanelGO.SetActive(true);
        fadePanel = fadePanelGO.GetComponent<Animator>();
        StartCoroutine(startgameCo());
    }

    public void showCredits() {
        optionSelectClick.Play();
        Application.OpenURL("https://twitter.com/DanielCarroll_");
    }

    IEnumerator startgameCo() {
        fadePanel.enabled = true;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(GetFirstNotFinishedLevel());
    }

    private int GetFirstNotFinishedLevel()
    {
        for (int i = 1; i < SceneManager.sceneCountInBuildSettings - 1; i++)
        {
            if (PlayerPrefs.GetInt($"{i}", 1) == 0)
            {
                return i;
            }
        }

        return SceneManager.sceneCountInBuildSettings - 1;
    }

    public void ResetSave()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("level", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(0);
    }
}
