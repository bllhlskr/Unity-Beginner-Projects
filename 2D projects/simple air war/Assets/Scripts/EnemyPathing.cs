using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
     WaveConfig waveConfig;
     List<Transform> waypoints;
    int waypointIndex = 0;
    


    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWayPoints();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }



    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }
    


        private void Move() {


        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetposition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = waveConfig.GetmoveSpeed() * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, targetposition, movementThisFrame);
            if (transform.position == targetposition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

