using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public GameObject fadePanelGO;
    public GameObject resetButton;

    private Animator fadePanel;
    AudioSource optionSelectClick;

    private void Start() {
        if (!PlayerPrefs.HasKey("level"))
        {
            PlayerPrefs.SetInt("level", 1);
            PlayerPrefs.Save();
        }

        if (PlayerPrefs.GetInt("level") == 1)
        {
            resetButton.SetActive(false);
        }
        optionSelectClick = GetComponent<AudioSource>();
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
        SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
    }

    public void ResetSave()
    {
        PlayerPrefs.SetInt("level", 1);
        for (int i = 1; i < SceneManager.sceneCount; i++)
        {
            PlayerPrefs.DeleteKey(i.ToString());
        }
        PlayerPrefs.Save();
        SceneManager.LoadScene(0);
    }
}
