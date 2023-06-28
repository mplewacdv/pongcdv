using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public void SpeedUpBall(BallController p_ballController)
    {
        p_ballController.rb2D.velocity *= 1.5f;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Speed")
        {
            SpeedUpBall(collision.GetComponent<BallController>());
            Destroy(gameObject);
        }
        
        //if (collision.gameObject.tag == "Shrink")
        {
            //PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
           //playerController.transform.localScale *= 0.5f; 
            //Destroy(gameObject);
        }
    }
}
 