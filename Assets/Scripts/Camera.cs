using UnityEngine;

public class Camera: MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject DownLeft;
    [SerializeField] GameObject UpRight;
    [SerializeField] float cameraSpeed;
    [SerializeField] float cameraRangeX;
    [SerializeField] float cameraRangeUp;
    [SerializeField] float cameraRangeDown;

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
        if (top - cameraRangeUp < playerY)
        {
            if (playerY - (top - cameraRangeUp) > cameraSpeed)
            {
                move += new Vector2(0, cameraSpeed);
            }
            else
            {
                move += new Vector2(0, playerY - (top - cameraRangeUp));
            }
        }
        //move down
        if (bottom + cameraRangeDown > playerY)
        {
            if (bottom + cameraRangeDown - playerY > cameraSpeed)
            {
                move += new Vector2(0, -cameraSpeed);
            }
            else
            {
                move -= new Vector2(0, bottom + cameraRangeDown - playerY);
            }
        }
        //move left
        if (left + cameraRangeX > playerX)
        {
            if (left + cameraRangeX - playerX > cameraSpeed)
            {
                move += new Vector2(-cameraSpeed, 0);
            }
            else
            {
                move -= new Vector2(left + cameraRangeX - playerX, 0);
            }
        }
        //move right
        if (right - cameraRangeX < playerX)
        {
            if (playerX - (right - cameraRangeX) > cameraSpeed)
            {
                move += new Vector2(cameraSpeed, 0);
            }
            else
            {
                move += new Vector2(playerX - (right - cameraRangeX), 0);
            }
        }
        transform.Translate(move);
    }
}
