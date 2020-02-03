using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public int length;
    public float obstacleMaxLength;
    public double timePerObstacle;
    public GameObject bottomObstacle;
    public GameObject topObstacle;

    private double timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = timePerObstacle;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Vector3 obsPos;
            GameObject obs = null;
            int rand = Random.Range(0, 2);

            switch (rand)
            {
                // Bottom
                case 0:
                    obsPos = new Vector3(transform.position.x, transform.position.y - length);
                    obs = Instantiate(bottomObstacle, obsPos, Quaternion.identity);
                    break;
                // Top
                case 1:
                    obsPos = new Vector3(transform.position.x, transform.position.y + length);
                    obs = Instantiate(topObstacle, obsPos, Quaternion.identity);
                    break;
            }

            // Random length
            if (obs != null)
                obs.transform.localScale = new Vector3(Random.Range(1f, obstacleMaxLength), 2, 0);
            
            timer = timePerObstacle;
        }
    }

    private void OnDrawGizmos()
    {
        // Draws line representing the area in which the obstacles will spawn
        Gizmos.color = Color.white;
        Vector3 target = new Vector3(transform.position.x, transform.position.y + length);
        Gizmos.DrawLine(transform.position, target);
        target.y -= 2 * length;
        Gizmos.DrawLine(transform.position, target);
    }
}
