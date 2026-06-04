using System.Linq;
using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpHeight;
    Vector2 playerPos;
    bool canJump = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            canJump = true;
        }
    }

    void Update()
    {
        playerPos = transform.position;
        if (Input.GetKey(KeyCode.A))
        {
            playerPos += new Vector2(-moveSpeed, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerPos += new Vector2(moveSpeed, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10) * jumpHeight);
            canJump = false;
        }
        transform.position = playerPos;
    }
}