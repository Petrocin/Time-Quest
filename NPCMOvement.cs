//обучающий скрипт для контролируемого движения NPC
using System.Collections;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public float speed = 2f; 
    public float changeDirectionTime = 2f; 
    public float maxDistanceFromStart = 5f; 

    private Vector2 movementDirection;
    private Vector2 startingPosition;

    void Start()
    {
        startingPosition = transform.position; 
        StartCoroutine(ChangeDirection());
    }

    void Update()
    {
        MoveNPC();
    }

    private void MoveNPC()
    {
        transform.Translate(movementDirection * speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, startingPosition) > maxDistanceFromStart)
        {
            movementDirection = -movementDirection;
        }
    }

    private IEnumerator ChangeDirection()
    {
        while (true)
        {
            movementDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

            yield return new WaitForSeconds(changeDirectionTime);
        }
    }
}
