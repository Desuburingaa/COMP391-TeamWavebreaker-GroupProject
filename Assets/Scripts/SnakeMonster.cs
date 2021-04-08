using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMonster : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] LayerMask platLayer;
    Rigidbody2D rbody;
    BoxCollider2D boxCollider2d;
    bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        boxCollider2d = GetComponent<BoxCollider2D>();
        rbody.velocity = new Vector2(speed, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        

        if ((speed > 0 && facingRight && IsPlayerOnRightWall()) || (speed < 0 && !facingRight && IsPlayerOnLeftWall()))
        {
            Flip();
            speed *= -1;
            rbody.velocity = new Vector2(speed, 0.0f);
        }

    }
    private void Flip()
    {
        facingRight = !facingRight;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private bool IsPlayerOnRightWall()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.right, 0.1f, platLayer);
        //Debug.Log(raycastHit2D.collider);
        return raycastHit2D.collider != null;
    }

    private bool IsPlayerOnLeftWall()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.left, 0.1f, platLayer);
        //Debug.Log(raycastHit2D.collider);
        return raycastHit2D.collider != null;
    }



}
