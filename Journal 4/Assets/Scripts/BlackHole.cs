using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BlackHole : MonoBehaviour
{
    public GameObject bat, sprite;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(Vector3.forward, -0.5f);
        Vector3 rand = new Vector3(Random.Range(0.9f, 1.1f), Random.Range(0.9f, 1.1f), Random.Range(0.9f, 1.1f));
        sprite.transform.localScale = rand;
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        GameObject body = coll.gameObject;
        if ((body == bat) && ((body.transform.position - transform.position).magnitude >= 2.5)) { }
        else
        {
            if (body.GetComponentInParent<Bat>() != null)
            {
                Destroy(body.GetComponentInParent<Bat>());
            }

            Vector3 gravity = (((transform.position - body.transform.position).normalized) / 100) * ((transform.position - body.transform.position).magnitude);

            if (body.GetComponent<Asteroid>() != null)
            {
                body.GetComponent<Asteroid>().vel = gravity;
            }
            if (body.GetComponent<Player>() != null)
            {
                body.GetComponent<Player>().vel = gravity;
            }

            body.transform.RotateAround(transform.position, Vector3.forward, (-0.001f * (Mathf.Pow((20 - (transform.position - body.transform.position).magnitude), 3))));

            body.transform.localScale *= 0.99f;
            if ((body.transform.position - transform.position).magnitude < 0.005f)
            {
                Destroy(body);
            }
        }
    }
}
