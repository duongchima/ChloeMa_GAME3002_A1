using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawProjection : MonoBehaviour
{
    [SerializeField]
    LaunchController launchController;
    [SerializeField]
    LineRenderer lineRenderer;

    // num of points on the line
    public int numPoints = 50;

    // distance between those points on the line
    public float timeBetweenPoints = 0.1f;

    // the physics layers that will cause the line to stop being drawn
    public LayerMask CollidableLayers;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // line renderer takes in this amount of pts
        lineRenderer.positionCount = numPoints;
        // instantiates a list of vector3 points
        List<Vector3> points = new List<Vector3>();
        // sets the start position of the line at the shotpoint position
        Vector3 startPos = launchController.shotPoint.position;
        // sets the starting velocity to be the same as the projectile
        Vector3 startVelo = launchController.shotPoint.up * launchController.launchPower;

        // draws the line
        for (float t = 0; t < numPoints; t += timeBetweenPoints)
        {
            // takes care of the x and z component of the new point
        
            Vector3 newPoint = startPos + t * startVelo;
            // y = y0 + v0y * t - 1/2 * g * t^2
            newPoint.y = startPos.y + startVelo.y * t + Physics.gravity.y / 2f * t * t;
            // adds the new point
            points.Add(newPoint);

            // stops the line renderer
            if (Physics.OverlapSphere(newPoint, 2, CollidableLayers).Length > 0)
            {
                lineRenderer.positionCount = points.Count;
                break;
            }
        }
        lineRenderer.SetPositions(points.ToArray());
    }
}
