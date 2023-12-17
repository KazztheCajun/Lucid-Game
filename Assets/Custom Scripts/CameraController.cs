using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Range(0, 100)]
    public float speed;
    public Transform playerTrans;

    private float startY;
    private float startZ;


    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
        startZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = Vector3.MoveTowards(this.transform.position, playerTrans.position, speed * Time.deltaTime);
        move.z = startZ;
        move.y = startY;
        transform.position = move;
    }
}
