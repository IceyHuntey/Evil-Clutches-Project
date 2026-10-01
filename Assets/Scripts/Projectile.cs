using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 6.0f;
    public int points = 100;
    void Update()
    {
        transform.Translate(-transform.right * speed * Time.deltaTime);
        if(transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }

}
