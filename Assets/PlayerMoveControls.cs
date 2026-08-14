using UnityEngine;

public class PlayerMoveControls : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    private int direction = 1;
    private GatherInput gatherInput;
    private Rigidbody2D rigidbody2d;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gatherInput = GetComponent<GatherInput>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }
    private void Move()
    {
        Flip();
        rigidbody2d.velocity = 
            new Vector2(gatherInput.valueX * speed, 
                rigidbody2d.velocity.y);
    }
    private void Flip()
    {
        // => direction +
        // <= direction -
        if (gatherInput.valueX * direction < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
            direction *= -1;
        }
    }
    private void Jump()
    {
        if(gatherInput.jumpInput)
        {
            rigidbody2d.velocity = 
                new Vector2(rigidbody2d.velocity.x, 
                jumpForce);
        }
        gatherInput.jumpInput = false;
    }
}