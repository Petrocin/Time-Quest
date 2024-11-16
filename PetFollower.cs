using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetFollower : MonoBehaviour
{
  using UnityEngine;

public class PetFollower : MonoBehaviour
{
    public Transform player; 
    public float followSpeed = 2f; 
    public float minDistance = 1f;
    public float runawayChance = 0.1f;
    public float runawayDistance = 3f; 

    private Vector2 targetPosition;

    void Update()
    {
    
        if (Vector2.Distance(transform.position, player.position) > minDistance)
        {
        
            Vector2 direction = (player.position - transform.position).normalized;

      
            if (Random.value < runawayChance)
            {

                GetAwayFromPlayer(direction);
            }
            else
            {
           
                targetPosition = (Vector2)player.position - direction * minDistance;
                MoveTowardsTarget();
            }
        }
    }

    void MoveTowardsTarget()
    {

        Vector2 newPosition = Vector2.MoveTowards(transform.position, targetPosition, followSpeed * Time.deltaTime);
        if (Mathf.Abs(newPosition.x - transform.position.x) > Mathf.Abs(newPosition.y - transform.position.y))
        {
            newPosition.y = transform.position.y;
        }
        else
        {
            newPosition.x = transform.position.x;
        }
        transform.position = newPosition;
    }

    void GetAwayFromPlayer(Vector2 direction)
    {
     
        targetPosition = (Vector2)transform.position - direction * runawayDistance;
        MoveTowardsTarget();
    }
}

}
