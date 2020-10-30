using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public GameObject WinUI;
    public GameObject ActiveMembers;
    public GameObject Player;
    public GameObject UI;

    public Text dText;
    public Text hText;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            SoundManager.instance.GameWinSound();
            Invoke("WinOn",1);
        }
    }

    void WinOn()
    {
        ActiveMembers.SetActive(false);
        Player.SetActive(false);
        WinUI.SetActive(true);
        UI.SetActive(false);

        dText.text = "X " + Score.instance.scorePlus.ToString();
        hText.text = "X " + PlayerDie.instance.Health;
    }
}
