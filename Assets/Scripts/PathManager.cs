using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PathController : MonoBehaviour
{
    public GameObject[] planePrefabs;
    public float zSpawn = 0;
    public float planeLength = 30;
    public int numberOfPlanes = 8;
    public Transform playerTransform;
    private List<GameObject> activePlanes=new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numberOfPlanes; i++)
        {
            if (i == 0)
            {
                spawnPlane(0);
            }
            else
            {
                spawnPlane(Random.Range(0, planePrefabs.Length));
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z-105>zSpawn-(numberOfPlanes* planeLength))
        {
            spawnPlane(Random.Range(0, planePrefabs.Length));
            DeletePlane();
        }
    }
    public void spawnPlane(int planeIndex)
    {
       GameObject planes= Instantiate(planePrefabs[planeIndex], transform.forward * zSpawn, transform.rotation);
        activePlanes.Add(planes);
        zSpawn += planeLength;

    }
    private void DeletePlane()
    {
        Destroy(activePlanes[0]);
        activePlanes.RemoveAt(0);
    }
}
