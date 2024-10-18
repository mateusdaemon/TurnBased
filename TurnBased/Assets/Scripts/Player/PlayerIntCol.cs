using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIntCol : MonoBehaviour
{
    public float areaDetect;
    public LayerMask collectableLayer;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D chestFound = Physics2D.OverlapCircle(transform.position, areaDetect, collectableLayer);

        if (chestFound)
        {
            Debug.Log("Chest found!");
        }
    }
}
