using UnityEngine;

public class ParralaxingTime : MonoBehaviour
{
    public GameObject front, middle, back, player;
    public float basePos, pos;
    void Start()
    {
        basePos = 3.53f;
        
    }

    void Update()
    {
        pos = player.transform.position.x;
        pos -= basePos;
        ScreenSlider(front, 0.1f, 1);
        ScreenSlider(middle, 0.3f, 2);
    }

    private void ScreenSlider(GameObject screen, float modifier, int z)
    {
        Vector3 temp = screen.transform.position;
        temp.x = pos * modifier;
        temp.z = z;
        screen.transform.position = temp;
    }
}
