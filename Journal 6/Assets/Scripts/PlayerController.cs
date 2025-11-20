using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum FacingDirection
    {
        left, right
    }

    public KeyCode lastPressed;
    public bool moving, grounded;
    Vector2 acc, vel;

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

        Vector2 playerInput = new Vector2();

        if (Input.GetKey(KeyCode.A))
        {
            playerInput.x -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerInput.x += 1;
        }

        MovementUpdate(playerInput);

    }

    private void MovementUpdate(Vector2 playerInput)
    {
        acc.x += playerInput.x / 10 * Time.deltaTime;

        vel += acc;

        vel *= 0.9f;
        acc *= 0.9f;

        Vector3 temp = transform.position;
        temp.x += vel.x;
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
        grounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }
}
