using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public int length;
    public double timePerObstacle;
    public GameObject bottomObstacle;

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
            Vector3 obsPos = new Vector3(transform.position.x, transform.position.y - length);
            Instantiate(bottomObstacle, obsPos, Quaternion.identity);
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
