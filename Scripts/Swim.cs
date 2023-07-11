using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swim : MonoBehaviour
{
    public float speed = 2;
    public int direction;
    // Start is called before the first frame update

    void Start()
    {
        if (transform.position.x > 0)
        {
            direction = -1;
        }
        else {
            direction = 1;
        }

        transform.localScale = new Vector3(direction * transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == 1)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else if(direction == -1)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }
}
