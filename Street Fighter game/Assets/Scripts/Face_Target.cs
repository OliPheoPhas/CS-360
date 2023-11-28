using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face_Target : MonoBehaviour
{
    public Transform otherCharacter;
    private bool isFacingRight = true;

    // Update is called once per frame
    void Update()
    {
        FlipIfNeeded();
    }

    void FlipIfNeeded()
    {
        if (otherCharacter != null)
        {
            if (transform.position.x < otherCharacter.position.x && !isFacingRight)
            {
                Flip();
            }
            else if (transform.position.x > otherCharacter.position.x && isFacingRight)
            {
                Flip();
            }
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

}
