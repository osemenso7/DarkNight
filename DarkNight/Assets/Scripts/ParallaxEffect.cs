using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{

    [SerializeField] float parallexSpeed = 1f;

    private Transform cameraTransform;
    private Vector3 previousCameraPosition;

    private float backgroundWidth, startBackground;

    // Start is called before the first frame update
    void Start()
    {
        // Components for the parallax effect with the camera
        cameraTransform = Camera.main.transform;
        previousCameraPosition = cameraTransform.position;

        // Components for the infinite scroll bacground
        backgroundWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        startBackground = transform.position.x;
    }

    // We use Late update to assure the code it's executed after the movement of the camera
    void LateUpdate()
    {
        // Distance we move from one frame to another depending on the parallaxSpeed
        float difX = (cameraTransform.position.x - previousCameraPosition.x) * parallexSpeed;

        // Distance lost between the camera and the layer of the background
        float moveAmount = cameraTransform.position.x * (1 - parallexSpeed);

        transform.Translate(new Vector3(difX, 0, 0));
        previousCameraPosition = cameraTransform.position;

        // Depending on the position of the camera we update the layers to one side or another
        if (moveAmount > startBackground + backgroundWidth)
        {
            // We update the positon of the background to the right
            transform.Translate(new Vector3(backgroundWidth, 0, 0));
            startBackground += backgroundWidth;
        }
        else if (moveAmount < startBackground - backgroundWidth)
        {
            // We update the positon of the background to the left
            transform.Translate(new Vector3(-backgroundWidth, 0, 0));
            startBackground -= backgroundWidth;
        }
    }
}
