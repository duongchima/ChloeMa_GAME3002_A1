using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObj : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnPref;
    public float respawnTime = 2.0f;

    [SerializeField]
    private GameObject backWall;
    [SerializeField]
    private GameObject leftWall;
    [SerializeField]
    private GameObject rightWall;
    [SerializeField]
    private GameObject frontWall;

    void Start()
    {
        StartCoroutine(spawning());
    }
    private void Spawn()
    {
        GameObject a = Instantiate(spawnPref) as GameObject;
        a.transform.position = new Vector3(Random.Range(leftWall.transform.position.x, rightWall.transform.position.x), Random.Range(1, 5), Random.Range(backWall.transform.position.z, frontWall.transform.position.z));

        Destroy(a, 5f);
    }

    IEnumerator spawning()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            Spawn();
        }
    }
}
