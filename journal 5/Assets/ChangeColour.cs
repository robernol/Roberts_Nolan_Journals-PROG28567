using UnityEngine;

public class ChangeColour : MonoBehaviour
{
    public Collider2D col;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Collider2D>().IsTouching(col))
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.gray;
        }
    }

}