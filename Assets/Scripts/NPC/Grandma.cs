using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grandma : MonoBehaviour
{
    private int grandmaState;

    [SerializeField] private float speed;
    [SerializeField] private float minimumDistanceToTarget;

    [SerializeField] private bool grandmaDead;

    [SerializeField] private Transform target;

    EventManager eventManager;

    private void Awake()
    {
        eventManager = FindObjectOfType<EventManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!grandmaDead && grandmaState == 0)
        {
            FollowTarget();
        }

        else if(!grandmaDead && grandmaState == 1)
        {
            Wait();
        }

        if (!grandmaDead && Input.GetButtonDown("GrandmaCommand"))
        {
            if (grandmaState == 0)
            {
                grandmaState = 1;
            }
            else
            {
                grandmaState = 0;
            }
        }

    }

    private void FollowTarget()
    {
        if (Vector2.Distance(transform.position, target.position) > minimumDistanceToTarget)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    private void Wait()
    {
        transform.position = transform.position;
    }

    public void SetTarget(Transform targetTransform)
    {
        target = targetTransform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            grandmaDead = true;
            GrandmaDeath();
        }
    }

    private void GrandmaDeath()
    {
        eventManager.ShowGameOver();
        Destroy(gameObject);    
    }
}
