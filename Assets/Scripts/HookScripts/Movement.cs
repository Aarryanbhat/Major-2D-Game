using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float min_z = -55f, max_z = 55f;
    public float rotate_speed = 5f;

    private float rotate_angle;
    private bool rotate_right;
    private bool canrotate;

    public float move_speed = 3f;
    private float initial_move_speed;

    public float min_y = -2.5f;
    private float initial_y;
    private bool movedown;

    private RopeRenderer roperenderer;
     void Awake()
    {
        roperenderer = GetComponent<RopeRenderer>();   
    }
    void Start()
    {
        initial_y = transform.position.y;
        initial_move_speed = move_speed;
        canrotate = true;
    }

    // Update is called once per frame
    void Update()
    {
        rotate();
        getinput();
        moverope();
    }
    void rotate()
    {
        if (!canrotate)
            return;
        if(rotate_right)
        {
            rotate_angle += rotate_speed * Time.deltaTime;
        }
        else
        {
            rotate_angle -= rotate_speed * Time.deltaTime;
        }
        transform.rotation = Quaternion.AngleAxis(rotate_angle, Vector3.forward);
        if(rotate_angle >=max_z)
        {
            rotate_right = false;
        }
        else if(rotate_angle <=min_z)
        {
            rotate_right = true;
        }
    }
    void getinput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(canrotate)
            {
                canrotate = false;
                movedown = true;
                SoundManager.instance.ropestretch(true);
            }
        }
    }
    void moverope()
    {
        if (canrotate)
            return;
        if(!canrotate)
        {
             
            Vector3 temp = transform.position;
            if(movedown)
            {
                temp -= transform.up * Time.deltaTime * move_speed;
            }
            else
            {
                temp += transform.up * Time.deltaTime * move_speed;
            }
            transform.position = temp;
            if(temp.y <= min_y)
            {
                movedown = false;
            }
            if(temp.y >= initial_y)
            {
                canrotate = true;
                roperenderer.renderline(temp, false);
                move_speed = initial_move_speed;
                SoundManager.instance.ropestretch(false);   
            }
            roperenderer.renderline(temp, true);
        }
    }
    public void hookattacheditem()
    {
        movedown = false;
    }
}
