using UnityEngine;
using UnityEngine.Rendering;

public class PickaxeMove: MonoBehaviour
{
    Vector2 pos;
    float mX;
    float mY;
    Vector2 direction;
    Vector2 screenSize = new Vector2(Screen.width, Screen.height);
    GameObject player;
    Vector2 playerPos;
    Vector2 upLeftPos;
    Vector2 downRightPos;
    void Start()
    {
        player = GameObject.Find("player");
    }
    void Update()
    {
        pos = transform.position;
        playerPos = player.transform.position;
        upLeftPos = GameObject.Find("CameraPosUpLeft").transform.position;
        downRightPos = GameObject.Find("CameraPosDownRight").transform.position;
        mX = Input.mousePosition.x;
        mY = Input.mousePosition.y;

        direction = (Input.mousePosition/screenSize)-((playerPos-upLeftPos)/(downRightPos-upLeftPos));
        Debug.Log(direction);
    }
}
