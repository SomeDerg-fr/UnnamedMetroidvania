using System.Collections;
using UnityEngine;

public class Enemy: MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float health;
    [SerializeField] float speed;
    Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }
    private void Update()
    {
        //die
        if (health <= 0)
        {
            enabled = false;
            Destroy(GetComponent<Rigidbody>());
            Destroy(enemy, 0.5f);
        }

        //move towards player
        if ((((Vector2)GameObject.Find("Player").transform.position)-(Vector2)transform.position).magnitude <= 500)
        {
            if (transform.position.x - ((GameObject.Find("Player").transform.position.x)) > 2)
            {
                transform.position = (Vector2)transform.position + new Vector2(-speed, 0);
                //move left
            }
            else if (transform.position.x - ((GameObject.Find("Player").transform.position.x)) < 2)
            {
                transform.position = (Vector2)transform.position + new Vector2(speed, 0);
                //move right
            }
        }
    }    
    public void takeDamage(float dmg)
    {
        health -= dmg;
        Debug.Log("ouch");
        StartCoroutine(hurt());
    }
    IEnumerator hurt()
    {
        renderer.material.color = Color.red;
        yield return new WaitForSecondsRealtime(0.5f);
        renderer.material.color = Color.white;
    }
}
