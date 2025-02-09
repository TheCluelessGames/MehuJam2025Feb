using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grandma : MonoBehaviour
{
    private int grandmaState;
    private int previousGrandmaState;

    [SerializeField] private float speed;
    [SerializeField] private float minimumDistanceToTarget;

    [SerializeField] private Transform target;

    EventManager eventManager;
    GameManager gameManager;

    private void OnEnable()
    {
        eventManager = FindObjectOfType<EventManager>();
        eventManager.onGrandmaTalking += GrandmaTalks;
        eventManager.onGrandmaStoppingTalking += ActivateGrandma;
    }

    private void OnDisable()
    {
        eventManager.onGrandmaTalking -= GrandmaTalks;
    }

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.gameState == GameStates.Game && grandmaState == 0)
        {
            FollowTarget();
        }

        else if(gameManager.gameState == GameStates.Game && grandmaState == 1)
        {
            Wait();
        }

        if (gameManager.gameState == GameStates.Game && Input.GetButtonDown("GrandmaCommand"))
        {
            if (grandmaState == 0)
            {
                grandmaState = 1;
                eventManager.StopCurrentDialogue(); 
                eventManager.StartDialogue("WaitCommand");
            }
            else
            {
                grandmaState = 0;
                eventManager.StopCurrentDialogue();
                eventManager.StartDialogue("FollowCommand");
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
            GrandmaDeath();
        }
    }

    private void GrandmaDeath()
    {
        eventManager.ShowGameOver();
        Destroy(gameObject);    
    }

    private void GrandmaTalks()
    {
        previousGrandmaState = grandmaState;
        grandmaState = 1;
    }

    private void ActivateGrandma()
    {
        grandmaState = previousGrandmaState;
    }
}
