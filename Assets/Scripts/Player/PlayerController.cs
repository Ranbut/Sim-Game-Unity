using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int playerOrientation = 0; // 0 = Front; 1 = Right; 2 = Left; 3 = Back

    private Rigidbody2D rb;
    private Animator anim;

    private Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x > 0)
            playerOrientation = 1;
        else if (movement.x < 0)
            playerOrientation = 2;
        else if (movement.y < 0)
            playerOrientation = 0;
        else if (movement.y > 0)
            playerOrientation = 3;

        anim.SetInteger("Direction", playerOrientation);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}