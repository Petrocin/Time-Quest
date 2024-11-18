using System.Collections;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float changeDirectionTime = 2f;
    [SerializeField] private float maxDistanceFromStart = 5f;

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
            SetRandomDirection();
            yield return new WaitForSeconds(changeDirectionTime);
        }
    }

    private void SetRandomDirection()
    {
        movementDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
