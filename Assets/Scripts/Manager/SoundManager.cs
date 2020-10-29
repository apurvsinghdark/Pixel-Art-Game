using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]private AudioSource gameWin, gameEnd, coinSound, jumpSound, fireSound, playerDie, healthPick, clickSound;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void GameStartSound()
    {
        gameWin.Play();
    }
    public void GameEndSound()
    {
        gameEnd.Play();
    }
    public void PickedUpCoin()
    {
        coinSound.Play();
    }
    public void PickedUpHealth()
    {
        healthPick.Play();
    }
    public void JumpSound()
    {
        jumpSound.Play();
    }   
    public void FireSound()
    {
        fireSound.Play();
    }   
    public void DieSound()
    {
        playerDie.Play();
    }   
    public void ClickSound()
    {
        clickSound.Play();
    }   
}
