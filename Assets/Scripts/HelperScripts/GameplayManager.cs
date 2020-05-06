using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;
    [SerializeField]
    public Text countdowntext;
    public int countdowntimer = 60;
    [SerializeField]
    private Text scoretext;
    private int scorecount;
    [SerializeField]
    private Image scorefillui;
     void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        DisplayScore(0);
        countdowntext.text = countdowntimer.ToString();
        StartCoroutine("countdown"); 
    }

    IEnumerator countdown()
    {
        yield return new WaitForSeconds(1f);
        countdowntimer -= 1;
        countdowntext.text = countdowntimer.ToString();
        if(countdowntimer <=10 )
        {
            SoundManager.instance.timerunningout(true);   
        }
        StartCoroutine("countdown");
        if(countdowntimer <= 0)
        {
            StopCoroutine("countdown");
            SoundManager.instance.gameEnd();
            SoundManager.instance.timerunningout(false);
            StartCoroutine(RestartGame()); 
        }
    }
    public void DisplayScore(int scorevalue)
    {
        if(scoretext == null)
        
            return;
            scorecount += scorevalue;
            scoretext.text = "$" + scorecount;
            scorefillui.fillAmount = (float)scorecount / 100f;
            
        if(scorecount >= 100)
        {
            StopCoroutine("countdown");
            SoundManager.instance.gameEnd();   
        }
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(4f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");  
    }
}
