using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;

    public Transform moveSpots;
    
    
    private float waitTime;
    public float startWaitTime;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ; 
    //variables hold coordinates for patrol area
    //Z was set as Y

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        moveSpots.position = new Vector2(Random.Range(minX, maxX), Random.Range(minZ, maxZ));
        //guard moves to random positions throughout the scene
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots.position, speed * Time.deltaTime);
        

        if (Vector2.Distance(transform.position, moveSpots.position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                moveSpots.position = new Vector2(Random.Range(minX, maxX), Random.Range(minZ, maxZ));
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
