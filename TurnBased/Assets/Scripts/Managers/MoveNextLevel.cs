using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNextLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.LoadNextFight();
        }
    }
}
