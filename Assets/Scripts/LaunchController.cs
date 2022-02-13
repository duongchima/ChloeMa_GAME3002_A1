using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchController : MonoBehaviour
{
    [SerializeField] private Vector3 rotation;
    public float launchPower = 5f;
    public float timerTotal = 3f;
    float currentTime = 0f;
    public GameObject projectiles;
    public Transform shotPoint;
    float x;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= timerTotal)
        {
            LaunchShoot();
            currentTime -= timerTotal;
        }
        transform.Rotate(rotation * Time.deltaTime);
    }
    void LaunchShoot()
    {
        GameObject firedProjectile = Instantiate(projectiles, shotPoint.position, shotPoint.rotation);
        firedProjectile.GetComponent<Rigidbody>().velocity = shotPoint.transform.up * launchPower;
    }
}
