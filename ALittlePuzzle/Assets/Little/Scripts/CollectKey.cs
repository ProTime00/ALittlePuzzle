using UnityEngine;

public class CollectKey : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject playerGO;
    AudioSource switchClick;
    bool switchPressed;

    private void Start() {
        switchClick = GetComponent<AudioSource>();
        if (gameManager.levelIsWithoutSwitch)
        {
            LevelWithoutSwitch();
        }
    }

    private void LevelWithoutSwitch()
    {
        gameManager.collectKey();
        switchClick.Play();
        switchPressed = true;
    }

    private void OnTriggerEnter(Collider other) {
        if (gameManager.levelIsWithoutSwitch)
        {
            Debug.Log("this should never happen");
            return;
        }
        if ((other.gameObject == playerGO && switchPressed == false)) {
            gameManager.collectKey();
            switchClick.Play();
            switchPressed = true;
        }
    }
}
