using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    private LineRenderer linerenderer;
    [SerializeField]
    private Transform startposition;

    private float line_width = 0.05f;

     void Awake()
    {
        linerenderer = GetComponent<LineRenderer>();
        linerenderer.startWidth = line_width;
        linerenderer.enabled = false;
    }
    void Start()
    {
        
    }
    public void renderline(Vector3 endposition, bool enablerenderer)
    {
        if (enablerenderer)
        {
            if (!linerenderer.enabled)
            {
                linerenderer.enabled = true;
            }

            linerenderer.positionCount = 2;
        }

        else
        {
            linerenderer.positionCount = 0;
            if(linerenderer.enabled )
            {
                linerenderer.enabled = false;
            }
        }
        if(linerenderer.enabled )
        {
            Vector3 temp = startposition.position;
            temp.z = -10f;
            startposition.position = temp;
            temp = endposition;
            temp.z = 0f;
            endposition = temp;
            linerenderer.SetPosition(0, startposition.position);
            linerenderer.SetPosition(1, endposition);
        }
    }
}
