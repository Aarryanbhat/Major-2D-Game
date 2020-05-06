using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
     void Awake()
    {
        anim = GetComponent<Animator>();  
    }
    public void idleanimation()
    {
        anim.Play(animationtags.idle_animation); 
    }
    public void pullingitemanimation()    
    {
        anim.Play(animationtags.rope_wrap_animation);
    }

}
