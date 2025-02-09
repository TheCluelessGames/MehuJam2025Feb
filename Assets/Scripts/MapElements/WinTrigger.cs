using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    EventManager eventManager;

    // Start is called before the first frame update
    void Start()
    {
        eventManager = FindObjectOfType<EventManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            eventManager.ShowVictory();
        }
    }
}
