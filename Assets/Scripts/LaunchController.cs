using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchController : MonoBehaviour
{
    public float launchPower = 5f;
    public float rotationSpeed = 5f;
    public GameObject projectiles;
    public Transform shotPoint;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LaunchShoot();
        }
    }
    void LaunchShoot()
    {
        // instantiates the projectile at the shotpoint of the launcher
        GameObject firedProjectile = Instantiate(projectiles, shotPoint.position, shotPoint.rotation);

        // sets the velocity of the projectile, taking the transform y value and multiplying it by the launchpower
        firedProjectile.GetComponent<Rigidbody>().velocity = shotPoint.transform.up * launchPower;
        Destroy(firedProjectile, 5f);
    }
  void OnMouseDrag()
    {
        float XaxisRotation = Input.GetAxis("Mouse X") * rotationSpeed;
        float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSpeed;
        transform.Rotate(Vector3.down, XaxisRotation);
        transform.Rotate(Vector3.right, YaxisRotation);
    }
}
