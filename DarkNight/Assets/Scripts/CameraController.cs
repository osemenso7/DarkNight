using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private Transform playerTransform;

    private float startVerticalPos;

    // Start is called before the first frame update
    void Start()
    {
        startVerticalPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.y < startVerticalPos)
        {
            transform.position = new Vector3(playerTransform.position.x, startVerticalPos, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
        }
    }
}
