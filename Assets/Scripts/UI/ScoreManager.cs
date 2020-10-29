using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
     public static int score;
 
     public static int highscore;
 
     public Text text;
 
     void Start()
     {
         //text = GetComponent<Text> ();
 
         score = 0;
 
         highscore = PlayerPrefs.GetInt ("highscore", score);
     }
 
     void Update()
     {
        //  if (score > highscore)
        //     highscore = score;
         
         text.text = "X " + score.ToString();
 
         PlayerPrefs.SetInt ("highscore", 0);
         score = highscore;
     }
 
     public static void AddPoints (int pointsToAdd)
     {
         score += pointsToAdd;
     }
 
     public static void Reset()
     {
         score = 0;
     }
}
