using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meltable : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; 
    public GameObject targetObject;
    public float redValue = 0f; 
    public float maxLimit = 1f; 

    private Rigidbody2D targetRigidbody;

    private void Start()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        if (targetObject != null)
        {
            targetRigidbody = targetObject.GetComponent<Rigidbody2D>();
            if (targetRigidbody != null)
            {
                targetRigidbody.isKinematic = true; // Disable physics initially
            }
        }
    }

    private void Update()
    {
        redValue = Mathf.Clamp(redValue, 0f, 1f);

        Color currentColor = spriteRenderer.color;
        spriteRenderer.color = new Color(redValue, 1- redValue, 1 - redValue, currentColor.a);
        

        if (redValue >= maxLimit)
        {            
            targetRigidbody.isKinematic = false; 
            gameObject.SetActive(false);
        }
    }

    
    public void IncreaseRedValue(float amount)
    {
        redValue += amount;
    }
}
