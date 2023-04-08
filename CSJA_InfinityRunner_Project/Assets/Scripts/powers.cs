using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powers : MonoBehaviour
{
    [SerializeField] private float yMin, yMax;
    private float timeValue = 0.0f;

    public float xPos;
    public float xVeloc;
    private Transform position;

    private void Start()
    {
        position = transform;
        Destroy(gameObject, 10f);
    }


    void Update()
    {
        // Compute the sin position.
        float yValue = Mathf.Sin(timeValue * 3.0f);

        // Now compute the Clamp value.
        float yPos = Mathf.Clamp(yValue, yMin, yMax);

        // Update the position of the cube.
        transform.position = new Vector3(transform.position.x + xPos, position.position.y + yPos, 0.0f);

        xPos -= xVeloc;

        // Increase animation time.
        timeValue = timeValue + Time.deltaTime;

        // Reset the animation time if it is greater than the planned time.
        if (yValue > Mathf.PI / 2.0f)
        {
            timeValue = 0.0f;
        }
    }
}
