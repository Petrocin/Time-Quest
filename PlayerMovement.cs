//движение игрока

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintSpeed = 10f;
    public float maxSprintTime = 5f;
    public float sprintRegenRate = 2f;

    private Rigidbody2D rb;

    private float currentSprintTime;
    private bool isSprinting = false;
    public Image SprintBar;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        currentSprintTime = maxSprintTime;
    }
    private void Update() {
        HandleMovement();
        RegenerateSprint();
        UpdateSprintBar();
    }
    private void FixedUpdate() {
        HandleSprint();
    }
    private void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0)
        {
            vertical = 0;
        }
        else if (vertical != 0)
        {
            horizontal = 0;
        }
        Vector2 movement = new Vector2(horizontal, vertical).normalized;
        rb.velocity = movement * (isSprinting ? sprintSpeed : moveSpeed);
    }

    private void HandleSprint()
    {
        if (Input.GetKey(KeyCode.LeftShift) && currentSprintTime > 0f)
        {
            isSprinting = true; 
        }
        else
        {
            isSprinting = false;
        }
        if (isSprinting)
        {
            currentSprintTime -= Time.deltaTime;
            if (currentSprintTime <= 0f)
            {
                isSprinting = false; 
            }
        }
    }
    private void RegenerateSprint() {
        if (!isSprinting && currentSprintTime < maxSprintTime) {
            currentSprintTime += sprintRegenRate * Time.deltaTime;
            if (currentSprintTime > maxSprintTime) {
                currentSprintTime = maxSprintTime;
            }
        }
    }
    private void UpdateSprintBar() {
        if (SprintBar != null) {
            SprintBar.fillAmount = currentSprintTime / maxSprintTime;
        }
    }
}
