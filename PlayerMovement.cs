using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Настройки движения")]
    public float moveSpeed = 5f;
    public float sprintSpeed = 10f;

    [Header("Настройки спринта")]
    public float maxSprintTime = 5f;
    public float sprintRegenRate = 2f;

    private Rigidbody2D rb;
    private float currentSprintTime;
    private bool isSprinting = false;

    [Header("UI Элементы")]
    public Image sprintBar;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSprintTime = maxSprintTime;
    }

    private void Update()
    {
        HandleMovement();
        UpdateSprintStatus();
        RegenerateSprint();
        UpdateSprintBar();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Разрешаем только одно направление (горизонтальное/вертикальное) активным одновременно
        if (horizontalInput != 0)
        {
            verticalInput = 0;
        }
        else if (verticalInput != 0)
        {
            horizontalInput = 0;
        }

        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput).normalized;
        ApplyMovement(movementDirection);
    }

    private void ApplyMovement(Vector2 direction)
    {
        float speed = isSprinting ? sprintSpeed : moveSpeed;
        rb.velocity = direction * speed;
    }

    private void UpdateSprintStatus()
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

    private void RegenerateSprint()
    {
        if (!isSprinting && currentSprintTime < maxSprintTime)
        {
            currentSprintTime += sprintRegenRate * Time.deltaTime;
            if (currentSprintTime > maxSprintTime)
            {
                currentSprintTime = maxSprintTime;
            }
        }
    }

    private void UpdateSprintBar()
    {
        if (sprintBar != null)
        {
            sprintBar.fillAmount = currentSprintTime / maxSprintTime;
        }
    }
}
