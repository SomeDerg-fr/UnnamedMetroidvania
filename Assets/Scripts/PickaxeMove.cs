using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;

public class PickaxeMove: MonoBehaviour
{
    Vector2 pos;
    float mX;
    float mY;
    Vector2 direction;
    float directionAngle;
    Vector2 screenSize = new Vector2(Screen.width, Screen.height);
    [SerializeField] GameObject player;
    [SerializeField] GameObject Pickaxe;
    [SerializeField] GameObject PickTip;
    Vector2 playerPos;
    Vector2 downLeftPos;
    Vector2 upRightPos;
    float pickSpeed;
    Vector2 TPos;
    Vector2 prevTPos;
    bool attacking = false;
    float rotZ;


    void Start()
    {
    }
    void Update()
    {
        //setting varriables
        pos = transform.position;
        playerPos = player.transform.position;
        downLeftPos = GameObject.Find("CameraPosDownLeft").transform.position;
        upRightPos = GameObject.Find("CameraPosUpRight").transform.position;
        mX = Input.mousePosition.x;
        mY = Input.mousePosition.y;
        rotZ = transform.rotation.z;
        TPos = (Vector2)PickTip.transform.position;
        Vector2 tempVec = TPos-prevTPos;
        pickSpeed = tempVec.magnitude;


        //pickaxe rotating towards mouse
        direction = (Input.mousePosition/screenSize)-((playerPos-downLeftPos)/(upRightPos-downLeftPos));
        if (direction.x < 0)
        {
            directionAngle = 360 - (Mathf.Acos(direction.y / Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y))) * 180 / Mathf.PI;
        }
        else
        {
            directionAngle = Mathf.Acos(direction.y / Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y)) * 180 / Mathf.PI;
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,180,directionAngle), Time.deltaTime * 5);

        //end stuff
        prevTPos = TPos;
    }

    public void attack(GameObject enemy)
    {
        if (pickSpeed >= 0.03 && !attacking)
        {
            attacking = true;
            enemy.GetComponent<Enemy>().takeDamage(1.0f);
        }
    }
    public void noAtk()
    {
        attacking = false;
    }
}
