using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grandma : MonoBehaviour
{
    private int grandmaState;

    [SerializeField] private float speed;
    [SerializeField] private float minimumDistanceToTarget;

    [SerializeField] private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(grandmaState == 0)
        {
            FollowTarget();
        }

        else if(grandmaState == 1)
        {
            Wait();
        }

        if (Input.GetButtonDown("GrandmaCommand"))
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
}
