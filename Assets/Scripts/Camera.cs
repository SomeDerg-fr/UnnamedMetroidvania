using UnityEngine;

public class Camera: MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject DownLeft;
    [SerializeField] GameObject UpRight;
    [SerializeField] float cameraSpeed;
    [SerializeField] float cameraRangeX;
    [SerializeField] float cameraRangeY;

    float playerX;
    float playerY;
    float top;
    float bottom;
    float left;
    float right;
    Vector2 move;

    private void Update()
    {
        //set all stuffff
        playerX = player.transform.position.x;
        playerY = player.transform.position.y;
        top = UpRight.transform.position.y;
        bottom = DownLeft.transform.position.y;
        left = DownLeft.transform.position.x;
        right = UpRight.transform.position.x;
        move = new Vector2(0, 0);

        //Camera Movement logic
        //move up
        if (top - playerY < cameraRangeY)
        {
            if (top - playerY < cameraSpeed)
            {
                move += new Vector2(0, cameraSpeed);
                Debug.Log("1");
            }
            else
            {
                move += new Vector2(0, top - playerY);
                Debug.Log("2");
            }
        }
        //move down
        if (bottom - playerY > cameraRangeY)
        {
            if (bottom - playerY > -cameraSpeed)
            {
                move += new Vector2(0, -cameraSpeed);
                Debug.Log("3");
            }
            else
            {
                move += new Vector2(0, bottom - playerY);
                Debug.Log("4");
            }
        }
        //move left
        if (left + cameraRangeX > playerX)
        {
            if (left + cameraRangeX - playerX > cameraSpeed)
            {
                move += new Vector2(-cameraSpeed, 0);
                Debug.Log("5");
            }
            else
            {
                move += new Vector2(left + cameraRangeX - playerX, 0);
                Debug.Log("6");
            }
        }
        //move right
        if (right - cameraRangeX < playerX)
        {
            if (right - cameraRangeX - playerX > -cameraSpeed)
            {
                move += new Vector2(cameraSpeed, 0);
                Debug.Log("5");
            }
            else
            {
                move += new Vector2(bottom - playerY, 0);
                Debug.Log("6");
            }
        }
        transform.position = (Vector2)transform.position + move;
    }
}
