using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookScripts : MonoBehaviour
{
    [SerializeField]
    private Transform itemholder;
    private bool itemattached;
    private Movement  hookmovement;
    private PlayerAnimation playeranim; 

    void Awake()
    {
        hookmovement = GetComponentInParent<Movement>();
        playeranim = GetComponentInParent<PlayerAnimation>(); 
    }


    
    private void OnTriggerEnter2D(Collider2D target )
    {
        if (target.tag == Tags.small_gold || target.tag == Tags.middle_gold || target.tag == Tags.large_gold || target.tag == Tags.large_stone || target.tag == Tags.middle_stone)
        {
            itemattached = true;
            target.transform.parent = itemholder;
            target.transform.position = itemholder.position;
            hookmovement.move_speed = target.GetComponent<ItemScript>().hook_speed;
            hookmovement.hookattacheditem();
           
            Debug.Log(itemattached);
            playeranim.pullingitemanimation();

            if (target.tag == Tags.small_gold || target.tag == Tags.middle_gold || target.tag == Tags.large_gold)
            {
                SoundManager.instance.hookgrab_gold();   
            }
            else if (target.tag == Tags.middle_stone || target.tag == Tags.large_stone)
            {
                SoundManager.instance.hookgrab_stone();   
            }
            SoundManager.instance.pullsound(true);   
        }
        if(target.tag == Tags.deliver_item)
        {
            if(itemattached)
            {
                itemattached = false;
                Transform objchild = itemholder.GetChild(0);
                objchild.parent = null;
                objchild.gameObject.SetActive(false);
                playeranim.idleanimation(); 
                SoundManager.instance.pullsound(false);  

            }
        }
    }
}
