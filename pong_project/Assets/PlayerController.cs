using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public KeyCode UpKey = KeyCode.W;
    public KeyCode DownKey = KeyCode.S;

    void Update()
    {
        if (Input.GetKey(UpKey) && transform.position.y < 3.9)
        {
            transform.position += Vector3.up * Time.deltaTime * speed;
        }
        
        if (Input.GetKey(DownKey) && transform.position.y > -3.9)
        {
            transform.position += Vector3.down * Time.deltaTime * speed;
        }
    }
}
