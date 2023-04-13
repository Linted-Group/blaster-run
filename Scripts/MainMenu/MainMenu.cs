using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text coinsText;
    private Animator anim;

    private void Start(){
        anim = GetComponentInChildren<Animator>();

        int coins = PlayerPrefs.GetInt("coins");
        coinsText.text = coins.ToString();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ToShop(){
        SceneManager.LoadScene(2);
    }
    public void ToMenu(){
        SceneManager.LoadScene(0);
    }
}
