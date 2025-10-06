using System;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    [SerializeField] Trigger triger;
    private Animator anim;
    void Start()
    {
        triger.playerReached += StartAnimations;
        anim = GetComponent<Animator>();
    }
    void StartAnimations(object sender, EventArgs e)
    {
        anim.SetBool("PlayerReached", true);
        Debug.Log("Tring in GroundControl");
    }


}
