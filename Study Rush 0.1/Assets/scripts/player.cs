using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float dashMultiplier = 2.0f;
    public float maxStamina = 3.0f;
    public float staminaRegenRate = 0.5f;
    public TMP_Text staminaText;

    private float currentStamina;
    private bool isDashing;

    interact _interact;

    private void Start()
    {
        currentStamina = maxStamina;
        UpdateStaminaUI();

        _interact = FindAnyObjectByType<interact>();
    }

    private void Update()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Check if player is moving
        bool isMoving = moveVertical != 0 || moveHorizontal != 0;

        // Allow dashing only if moving and stamina is available
        if (Input.GetKey(KeyCode.LeftShift) && isMoving && currentStamina > 0)
        {
            isDashing = true;
            currentStamina -= Time.deltaTime; // Reduce stamina over time
        }
        else
        {
            isDashing = false;
            if (currentStamina < maxStamina)
            {
                currentStamina += staminaRegenRate * Time.deltaTime; // Regenerate stamina
            }
        }

        float currentSpeed = isDashing ? speed * dashMultiplier : speed;

        // Move the Main Camera (or any object this script is attached to)
        Vector3 moveDirection = (transform.forward * moveVertical + transform.right * moveHorizontal).normalized;
        moveDirection.y = 0f;

        transform.position += moveDirection * currentSpeed * Time.deltaTime;

        UpdateStaminaUI();



        if(Input.GetKeyDown(KeyCode.E))
        {
            _interact.QuizScene();
        }
    }

    private void UpdateStaminaUI()
    {
        if (staminaText != null)
        {
            staminaText.text = "Stamina: " + Mathf.Round(currentStamina * 10) / 10;
        }
    }


}
