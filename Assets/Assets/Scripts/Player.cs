using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int score;
    public int life = 3;
    public int lifeMax;
    public GameObject bullet;
    public Transform foot;
    bool groundCheck;
    public float speed = 5, jumpStrength = 5, bulletSpeed = 8;
    float horizontal;
    public Rigidbody2D body;

    Collider2D footCollision;
    int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        lifeMax = life;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(horizontal * speed, body.velocity.y);

        //groundCheck = Physics2D.OverlapCircle(foot.position, 0.05f);
        footCollision = Physics2D.OverlapCircle(foot.position, 0.05f);
        groundCheck = footCollision;
        if (footCollision.CompareTag("Enemy"))
        {

        }
        if (Input.GetButtonDown("Jump") && groundCheck)
        {
            body.AddForce(new Vector2(0, jumpStrength * 100));
        }
        if(horizontal != 0)//Para GetAxisRaw
        {
            direction = (int)horizontal;
        }
        /*Para quem est� usando GetAxis
        if(horizontal < 0)
        {
            direction = -1;
        } else if(horizontal > 0)
        {
            direction = 1;
        }
        */
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject temp = Instantiate(bullet, transform.position, transform.rotation);
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed * direction, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //life--;
            //life -= 1;
            //life = life -1;
            life -= collision.gameObject.GetComponent<Enemy>().damage;
            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if (collision.CompareTag("Coin"))
        {
            score += 5;//score = score +5;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Divisor"))
        {
            score /= 2;//score = score / 2;
            Destroy(collision.gameObject);
        }
        */
        switch (collision.tag)
        {
            case "Coin":
                //Aqui � o efeito do Coin
                score += 5;//score = score +5;
                Destroy(collision.gameObject);
                break;
            case "Divisor":
                //Aqui � o efeito do Divisor
                score /= 2;//score = score / 2;
                Destroy(collision.gameObject);
                break;
            default:

                break;
            
        }
    }
}
