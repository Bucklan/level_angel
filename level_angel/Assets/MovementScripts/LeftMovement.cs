using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftMovement : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    bool isPressed = false;
    public GameObject player;
    Animator playerAnimator;
    public float speed = 1f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        playerAnimator = player.GetComponent<Animator>();
    }

    void Update()
    {
        if (isPressed)
        {
            MoveLeft();
        }
    }

    void MoveLeft()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        playerAnimator.SetBool("isRunning", true);
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        playerAnimator.SetBool("isRunning", false);
        player.transform.localScale = new Vector2(1, 1);

        isPressed = false;
        rb.velocity = new Vector2(0, rb.velocity.y); // Stop horizontal movement when the button is released
    }
}
