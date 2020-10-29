using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public GameObject WinUI;

    public Text dText;
    public Text hText;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            Invoke("WinOn",1);
        }
    }

    void WinOn()
    {
        WinUI.SetActive(true);

        dText.text = "X " + Score.instance.scorePlus.ToString();
        hText.text = "X " + PlayerDie.instance.Health;
    }
}
