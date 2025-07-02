using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float intervalMin = 0.5f;
    public float intervalMax = 3f;

    private Transform target;
    private float interval;
    private float timeAfterSpawn;
    // Start is called before the first frame update
    void Start()
    {
        interval = Random.Range(intervalMin, intervalMax);
        timeAfterSpawn = 0f;

        target= FindAnyObjectByType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if(timeAfterSpawn >= interval)
        {
            GameObject bullet
                = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);

            interval = Random.Range(intervalMin, intervalMax);
            timeAfterSpawn = 0f;
        }
    }
}
