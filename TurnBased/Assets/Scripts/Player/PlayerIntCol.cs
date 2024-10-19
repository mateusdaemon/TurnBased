using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIntCol : MonoBehaviour
{
    public float areaDetect;
    public LayerMask collectableLayer;
    Collider2D chestFound;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        chestFound = Physics2D.OverlapCircle(transform.position, areaDetect, collectableLayer);
    }
}
