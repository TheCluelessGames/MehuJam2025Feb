using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public LayerMask layerMask;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] Transform start;
    [SerializeField] float maxDistance;
    [SerializeField] Transform laserHit;
    public bool isFacingRight = true;
    RaycastHit2D hit;

    // Start is called before the first frame update
    void Awake()
    {
        lineRenderer.enabled = false;
        lineRenderer.useWorldSpace = true;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            ShootLaser();
        }
        if(Input.GetKeyUp(KeyCode.Q))
        {
            TurnOffLaser();
        }
    }

    public void ShootLaser()
    {

        if (isFacingRight)
        {
            hit = Physics2D.Raycast(start.transform.position, Vector2.right, maxDistance, layerMask);
            laserHit.position = hit.point;
            Debug.DrawLine(transform.position, hit.point);
        }
        else
        {
            hit = Physics2D.Raycast(start.transform.position, Vector2.left, maxDistance, layerMask);
            Debug.DrawLine(transform.position, hit.point);
            laserHit.position = hit.point;
        }

        lineRenderer.SetPosition(0, start.position);
        lineRenderer.SetPosition(1, laserHit.transform.position);
        lineRenderer.enabled = true;
        try
        {
            if (hit.collider.CompareTag("Chain"))
            {
                hit.collider.gameObject.GetComponent<Meltable>().IncreaseRedValue(0.001f);   
            }
        }
        catch (Exception e) { }
    }

    private void TurnOffLaser()
    {
        lineRenderer.enabled = false;
    }
}
