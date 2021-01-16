using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player;

    public float width = 10.0f; //width from 0 on both sides, 5 gives the range from -5 - 5
    public float height = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -width, width), Mathf.Clamp(transform.position.y, -height, height), transform.position.z);
    }
}
