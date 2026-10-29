using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4;
    private int scoreVal = 0;
    public TextMeshProUGUI scoreBox;
    void Update()
    {
        //traveling up
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(transform.up * speed * Time.deltaTime);
        }
        //traveling down
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-transform.up * speed * Time.deltaTime);
        }
        //traveling right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        //traveling left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }
        transform.position = new Vector3( Mathf.Clamp(transform.position.x, -8.25f, 0.5f), Mathf.Clamp(transform.position.y, -4.17f, 4.13f), transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            if (collision.GetComponent<Projectile>() != null)
            {
                scoreVal += collision.GetComponent<Projectile>().points;
                scoreBox.text = "Score: " + scoreVal;
            }
            Destroy(collision.gameObject);
        }
    }
}