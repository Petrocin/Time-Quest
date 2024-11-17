using UnityEngine;
using System.Collections.Generic;

public class PetFollower : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 2f;
    public float minDistance = 1f;
    public float runawayChance = 0.1f;
    public float runawayDistance = 3f;

    public float energy = 100f;
    public float energyConsumptionRate = 1f;
    public float energyRecoveryRate = 0.5f;

    private Vector2 targetPosition;
    private bool isResting;
    private float restingTime = 2f;
    private float restingTimer;
    public float health = 100f;
    public float healthDecreaseRate = 1f;
    public float healthRecoveryRate = 2f;
    private bool isSick;
    private Inventory inventory;

    void Start()
    {
        isResting = false;
        restingTimer = restingTime;
        isSick = false;
        inventory = new Inventory();
    }

    void Update()
    {
        if (health <= 0)
        {
            return;
        }

        if (energy > 0)
        {
            if (Vector2.Distance(transform.position, player.position) > minDistance && !isResting)
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
                    ConsumeEnergy();
                }
            }
            else if (isResting)
            {
                Rest();
            }
        }
        else
        {
            isResting = true;
            restingTimer -= Time.deltaTime;
            if (restingTimer <= 0)
            {
                isResting = false;
                restingTimer = restingTime;
                energy = Mathf.Min(100, energy + 20);
            }
        }

        if (!isSick)
        {
            health -= healthDecreaseRate * Time.deltaTime;
            if (health < 0)
            {
                health = 0;
            }
        }
        else
        {
            RecoverHealth();
        }
    }

    void RecoverHealth()
    {
        health += healthRecoveryRate * Time.deltaTime;
        health = Mathf.Min(100, health);
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

    void ConsumeEnergy()
    {
        energy -= energyConsumptionRate * Time.deltaTime;
        energy = Mathf.Max(0, energy);
    }

    void Rest()
    {
        energy += energyRecoveryRate * Time.deltaTime;
        energy = Mathf.Min(100, energy);
        RecoverHealth();
    }

    public float GetEnergy()
    {
        return energy;
    }

    public float GetHealth()
    {
        return health;
    }

    public bool IsSick()
    {
        return isSick;
    }

    public bool IsResting()
    {
        return isResting;
    }

    public void InteractWithItem(Item item)
    {
        inventory.AddItem(item);
        if (item.type == ItemType.Food)

        {
            energy += 30;
            energy = Mathf.Min(100, energy);
        }
    }

    private class Inventory
    {
        public List<Item> items;

        public Inventory()
        {
            items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }
    }
}

[System.Serializable]
public class Item
{
    public string name;
    public ItemType type;
}

public enum ItemType
{
    Food,
    Toy,
    Medicine
}
