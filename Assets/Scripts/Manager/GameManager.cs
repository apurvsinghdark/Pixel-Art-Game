using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;

   private void Awake() {
       if(instance == null)
       {
           instance = this;
       }
   }

   public void Restart()
   {
       Invoke("PlayerDie",1);
   }
    void PlayerDie()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
