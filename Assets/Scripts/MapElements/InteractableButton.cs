using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractableButton : MonoBehaviour
{

    public List<ScriptMethodSelector> methodSelectors = new List<ScriptMethodSelector>();
    public GameObject text,button;
    public bool canBePressed, togleable;
    private bool inRange, isActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    private void Update()
    {
        if (togleable)
        {
            canBePressed = true;
        }
        if (Input.GetKeyDown(KeyCode.F) && inRange && canBePressed)
        {
            foreach (var methodSelector in methodSelectors)
            {
                methodSelector.InvokeMethod();
            }
            canBePressed = false;
        }
    }

    public void ToggleButtonSprite()
    {
        isActive = button.activeSelf;
        button.SetActive(!isActive);      
    }
     

    public void ActivateButton()
    {
        canBePressed = true;
    }
    public void AlwaysActive()
    {
        togleable = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canBePressed)
        {
            text.SetActive(true);
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            text.SetActive(false);
            inRange = false;
        }
    }

}
