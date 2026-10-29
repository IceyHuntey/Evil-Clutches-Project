using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GalagaMovement : MonoBehaviour
{
    public GameObject bullet;
    public float speed = 5.0f;
    public Image[] lives;
    public int  lifeCount = 3;
    // establishes the fire rate so players can't spam too hard
    public float rateofFire = 0.75f;
    private float nextFire = 0f;
    // Update is called once per frame
    void Update()
    {
        //checks the timer every frame 
        if(nextFire > 0)
        {
            nextFire -= Time.deltaTime;
        }
        //shooting key and checking to make sure you can fire 
        if(Input.GetKeyUp(KeyCode.Space) && nextFire <= 0)
        {
            Instantiate(bullet, transform.position + new Vector3(0,.5f, 0), Quaternion.identity);
            //resets the timer
            nextFire = rateofFire;
        }
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
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.25f, 8.25f), Mathf.Clamp(transform.position.y, -4.25f, 4.25f), transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            lifeCount -= 1;
            if (lifeCount <= 0)
            {     
                lifeCount = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);    
            }
            lives[lifeCount].enabled = false;
        }
    }
}
