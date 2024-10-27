using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MushUI : MonoBehaviour
{
    public TextMeshProUGUI damageTaken;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetDmgTaken(float damage)
    {
        damageTaken.text = damage.ToString("F1");
    }
}
