using UnityEngine;

public class Spawner : MonoBehaviour
{
    //range they can spawn across
    public float xMax = 0f;
    public float xMin = -8.75f;
    
    //projectile timers
    private float floorprojectileWait = 2;
    private float floorprojectileTimer = 0;
    public GameObject floorprojectile;
    
    // Update is called once per frame
    void Update()
    {
        floorprojectileTimer += Time.deltaTime;

        //manages the time they spawn
        if (floorprojectileTimer > floorprojectileWait)
        {
            //finds a random x range
            float randomX = Random.Range(xMin, xMax);
            Vector3 randomSpawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);

           //makes them spawn within time constraints
            Instantiate(floorprojectile, randomSpawnPosition, Quaternion.identity);
            floorprojectileTimer = 0;
            floorprojectileWait = Random.Range(1.75f, 2.75f);
        }
    
    }
}
