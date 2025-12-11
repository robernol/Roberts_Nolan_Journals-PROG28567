using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public enum FacingDirection
    {
        left, right
    }

    public KeyCode lastPressed;
    public bool moving, grounded, jumpInit;
    public Vector2 acc, vel;

    void Start()
    {
        lastPressed = KeyCode.None;
    }

    void Update()
    {
        // The input from the player needs to be determined and
        // then passed in the to the MovementUpdate which should
        // manage the actual movement of the character.
            
        if (Input.GetKeyDown(KeyCode.A))
        {
            lastPressed = KeyCode.A;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            lastPressed = KeyCode.D;
        }
        if ((Input.GetKeyUp(KeyCode.A)) && (Input.GetKey(KeyCode.D)))
        {
            lastPressed = KeyCode.D;
        }
        if ((Input.GetKeyUp(KeyCode.D)) && (Input.GetKey(KeyCode.A)))
        {
            lastPressed = KeyCode.A;
        }
        GetFacingDirection();

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            jumpInit = true;
        }

    }

    private void FixedUpdate()
    {
        Vector2 playerInput = new Vector2();

        if (Input.GetKey(KeyCode.A))
        {
            playerInput.x -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerInput.x += 1;
        }
        if (jumpInit)
        {
            playerInput.y = 1;
            jumpInit = false;
        }
        MovementUpdate(playerInput);
        

    }

    private void MovementUpdate(Vector2 playerInput)
    {
        acc.x += playerInput.x / 10 * Time.deltaTime;

        if (playerInput.y > 0)
        {
            acc.y = 0.07f;
            grounded = false;
        }

        vel += acc;

        vel.x *= 0.9f;
        acc.x *= 0.9f;
        acc.y *= 0.9f;

        if (!IsWalking())
        {
            vel.x *= 0.9f;
            acc.x *= 0.9f;
        }

        if (!grounded)
        {
            acc.y -= 0.005f;
        }
        else
        {
            vel.y = 0;
            acc.y = 0;
        }

        if (vel.y < -0.5f)
        {
            vel.y = -0.5f;
        }

        Vector3 temp = transform.position;
        temp.x += vel.x;
        temp.y += vel.y;
        transform.position = temp;
    }

    public bool IsWalking()
    {
        if ((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.D)))
        {
            return true;
        }
        else { return false; }
    }
    public bool IsGrounded()
    {
        return grounded;

    }

    public FacingDirection GetFacingDirection()
    {
        if (lastPressed == KeyCode.A)
        {
            return FacingDirection.left;
        }
        else
        {
            return FacingDirection.right;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            if ((collision.GetContact(i).point.y < transform.position.y) && (collision.GetContact(i).point.x <= transform.position.x + 0.5f) && (collision.GetContact(i).point.x >= transform.position.x - 0.5f))
            {
                grounded = true;
                vel.y = 0;
                acc.y = 0;
            }
            else if ((collision.GetContact(i).point.y > transform.position.y) && (collision.GetContact(i).point.x <= transform.position.x + 0.5f) && (collision.GetContact(i).point.x >= transform.position.x - 0.5f))
            {
                vel.y = 0;
                acc.y = 0;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            if ((collision.GetContact(i).point.y < transform.position.y) && (collision.GetContact(i).point.x <= transform.position.x + 0.5f) && (collision.GetContact(i).point.x >= transform.position.x - 0.5f))
            {
                grounded = true;
                vel.y = 0;
                acc.y = 0;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }
}
