using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public enum FacingDirection
    {
        left, right
    }

    public KeyCode lastPressed;
    public bool moving, grounded, jumpInit, balling, dash, doubleJump;
    public GameObject blueDirt;
    public Vector2 acc, vel;
    public Vector3 dashVect;
    public float dashTime, dashAngle;

    void Start()
    {
        lastPressed = KeyCode.None;
        balling = false;
        dash = false;
        doubleJump = true;
    }

    void Update()
    {
        // The input from the player needs to be determined and
        // then passed in the to the MovementUpdate which should
        // manage the actual movement of the character.

        if (grounded)
        {
            doubleJump = true;
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!balling)
            {
                GetComponent<Rigidbody2D>().gravityScale = 1;
                balling = true;
            }
            else
            {
                transform.position = (new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z));
                GetComponent<Rigidbody2D>().gravityScale = 0;
                balling = false;
                transform.eulerAngles = Vector3.zero;
            }
        }

        if (Input.GetMouseButtonDown(0) && (!dash))
        {
            dash = true;
            dashVect = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
            dashVect.z = 0;
            dashTime = Time.time + 0.5f;
            dashAngle = Mathf.Atan2(dashVect.y, dashVect.x) * Mathf.Rad2Deg;
        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = Vector3.zero;
        }


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
        else if (Input.GetKeyDown(KeyCode.Space) && doubleJump)
        {
            jumpInit = true;
            doubleJump = false;
        }

    }

    private void FixedUpdate()
    {
        if (!balling && !dash)
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

        if (balling)
        {

            if (Input.GetKey(KeyCode.A))
            {
                Vector3 temp = transform.eulerAngles;
                temp.z -= 3;
                transform.eulerAngles = temp;
            }
            if (Input.GetKey(KeyCode.D))
            {
                Vector3 temp = transform.eulerAngles;
                temp.z += 3;
                transform.eulerAngles = temp;
            }
            Vector3 mov = transform.position;
            mov.x += vel.x;
            mov.y += vel.y;
            transform.position = mov;
            vel *= 0.99f;
        }

        if (dash)
        {
            if (!balling) { transform.eulerAngles = (new Vector3(0, 0, dashAngle)); }
            Vector3 tem = transform.position;
            tem += (dashVect.normalized * 0.4f);
            transform.position = tem;

            blueDirt.GetComponent<TilemapCollider2D>().enabled = false;

            if (dashTime < Time.time)
            {
                dash = false;
                transform.eulerAngles = Vector3.zero;
            }
        }
        else
        {
            blueDirt.GetComponent<TilemapCollider2D>().enabled = true;
        }

    }

    private void MovementUpdate(Vector2 playerInput)
    {
        acc.x += playerInput.x / 10 * Time.deltaTime;

        if (playerInput.y > 0)
        {
            acc.y = 0.07f;
            if (!grounded)
            {
                vel.y = 0;
            }
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

        if (dash)
        {
            dash = false;
            transform.eulerAngles = Vector3.zero;
            grounded = true;
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
