using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTrigger : MonoBehaviour
{
    public GameObject bfg;
    private bool visited = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Grandma") && !visited)
        {
            StartCoroutine(GiveGun());
            visited = false;
        }        
    }

    IEnumerator GiveGun()
    {
        yield return new WaitForSeconds(6f);
        bfg.SetActive(true);
        
    }

}
