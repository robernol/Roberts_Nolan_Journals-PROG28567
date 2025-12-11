using UnityEditor.AnimatedValues;
using UnityEngine;

public class SmileyController : MonoBehaviour
{
    public bool ball;
    public GameObject vis;
    void Start()
    {
        ball = false; 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!ball)
            {
                ball = true;
                GetComponent<CircleCollider2D>().enabled = true;
                GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<Animator>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<Rigidbody2D>().freezeRotation = false;
                vis.SetActive(false);
            }
            else
            {
                ball = false;
                GetComponent<CircleCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<Animator>().enabled = true;
                GetComponent<BoxCollider2D>().enabled = true;
                GetComponent<Rigidbody2D>().freezeRotation = true;
                vis.SetActive(true);
            }
        }
    }
}
