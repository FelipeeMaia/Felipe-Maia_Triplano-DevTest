using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    [SerializeField] private float terrainSpeed;
    [SerializeField] private float terrainLength;

    private Vector3 distanceInBetween => Vector3.forward * terrainLength;

    private Queue<Transform> terrains;
    private Transform lastTerrain;

    // Start is called before the first frame update
    void Start()
    {
        EnqueueTerrains();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 terrainMovement = Vector3.back * terrainSpeed * Time.fixedDeltaTime;

        foreach(Transform terrain in terrains)
        {
            terrain.position += terrainMovement;
        }

        if (terrains.Peek().position.z < -terrainLength)
        {
            Transform firstTerrain = terrains.Dequeue();
            firstTerrain.position = lastTerrain.position + distanceInBetween;

            lastTerrain = firstTerrain;
            terrains.Enqueue(lastTerrain);
        }
    }

    private void EnqueueTerrains()
    {
        terrains = new Queue<Transform>();
        int childQuantity = transform.childCount;
        int counter = 0;

        foreach(Transform terrain in transform)
        {
            terrain.position = distanceInBetween * counter;
            terrains.Enqueue(terrain);

            if(counter == childQuantity - 1)
            {
                lastTerrain = terrain;
            }
            counter++;
        }
    }
}
