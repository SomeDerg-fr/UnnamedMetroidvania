using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpHeight;
    Vector2 playerPos;
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10) * jumpHeight);
        }
        transform.position = playerPos;
    }
}