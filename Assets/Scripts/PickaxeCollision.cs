using UnityEngine;

public class PickaxeCollision: MonoBehaviour
{
    [SerializeField] GameObject pickBase;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            pickBase.GetComponent<PickaxeMove>().attack(collision.gameObject);
        }
        else
        {
            pickBase.GetComponent<PickaxeMove>().noAtk();
        }
    }
}
