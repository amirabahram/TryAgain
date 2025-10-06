using System;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public event EventHandler playerReached;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (playerReached != null)
            {
                playerReached(this, EventArgs.Empty);
                Debug.Log("Trig in Trigger");
            }
        }
    }
}
