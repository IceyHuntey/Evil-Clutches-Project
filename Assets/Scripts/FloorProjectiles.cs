using UnityEngine;

public class FloorProjectiles : Projectile
{
    void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);
        if (transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }
}
