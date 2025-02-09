using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    [SerializeField] Transform movingPlatform;
    [SerializeField] Transform startPoint;
    [SerializeField] Transform endPoint;

    [SerializeField] float moveSpeed = 5.0f;

    private bool canmove,movingRight = true;
    private void Awake()
    {
        StartPlatform();
    }
    private void FixedUpdate()
    {
        if (movingRight)
        {
            MovePlatform(endPoint);
        }
        else
        {
            MovePlatform(startPoint);
        }

    }

    public void StartPlatform()
    {
        canmove = true;
    }

    private void MovePlatform(Transform target)
    {
        if (canmove)
        {
            movingPlatform.transform.position = Vector3.MoveTowards(movingPlatform.transform.position,
                target.transform.position, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(movingPlatform.position, target.position) < 0.01f)
            {
                canmove = false;
                movingRight = !movingRight;
            }
        }
    }
}
