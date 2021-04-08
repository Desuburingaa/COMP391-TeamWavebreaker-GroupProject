using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] GameObject slashVFX;
    [SerializeField] GameObject slashSpawner;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerRun(bool state)
    {
        anim.SetBool("IsRunning", state);
        anim.SetBool("IsJumping", false);
        anim.SetBool("Idle", false);
        anim.SetBool("IsAttacking", false);
        //Debug.Log("animation set to IsRunning to true");


    }

    public void PlayerJump(bool state)
    {
        anim.SetBool("IsJumping", state);
        anim.SetBool("IsRunning", false);
        anim.SetBool("Idle", false);
        anim.SetBool("IsAttacking", false);
        //Debug.Log("animation set to IsJumping to true");
    }

    public void PlayerIdle(bool state)
    {
        anim.SetBool("Idle", state);
        anim.SetBool("IsRunning", false);
        anim.SetBool("IsJumping", false);
        anim.SetBool("IsAttacking", false);
        //Debug.Log("animation set to PlayerIdle to true");
    }

    public void AttackAnim(bool state)
    {
        anim.SetBool("IsAttacking", true);
        anim.SetBool("Idle", false);
        anim.SetBool("IsRunning", false);
        anim.SetBool("IsJumping", false);

    }



}
