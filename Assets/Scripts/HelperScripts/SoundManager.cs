using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField]
    private AudioSource hookgrab_gold_fx, hookgrab_stone_fx, playerlaugh_fx, pullsoundfx, ropestretchfx, timerunningout_fx, gameEnd_fx;

     void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public void hookgrab_gold()

    {
        hookgrab_gold_fx.Play();  
    }
    public void hookgrab_stone()
    {
        hookgrab_stone_fx.Play();  
    }
    public void playerlaugh()
    {
        playerlaugh_fx.Play();  
    }
    public void ropestretch(bool playfx)
    {
        if (playfx)
        {
            if (!ropestretchfx.isPlaying)
            {
                ropestretchfx.Play();
            }
        }
        else
        {
            if (ropestretchfx.isPlaying)
            {
                ropestretchfx.Stop();
            }
        }
        
          
    }
    
   public void pullsound(bool playfx)
    {
        if(playfx)
        {
            if(!pullsoundfx.isPlaying)
            {
                pullsoundfx.Play();  
            }
        }
        else
        {
            if(pullsoundfx.isPlaying)
            {
                pullsoundfx.Stop();  
            }
        }
    }
    public void timerunningout(bool playfx)
    {
        if (playfx)
        {
            if (!timerunningout_fx.isPlaying)
            {
                timerunningout_fx.Play();
            }
        }
        else
        {
            if (timerunningout_fx.isPlaying)
            {
                timerunningout_fx.Stop();
            }
        }
    }
    public void gameEnd()
    {
        gameEnd_fx.Play(); 
    }
}
