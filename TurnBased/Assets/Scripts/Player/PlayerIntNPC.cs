using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIntNPC : MonoBehaviour
{
    public float areaDetect;
    public LayerMask npcLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Collider2D npcFind = Physics2D.OverlapCircle(transform.position, areaDetect, npcLayer);

        if (npcFind)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }

        Gizmos.DrawWireSphere(transform.position, areaDetect);
    }
}
