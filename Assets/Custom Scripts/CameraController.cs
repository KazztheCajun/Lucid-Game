using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Range(0, 100)]
    public float speed;
    public Transform playerTrans;
    public Vector3 offset;

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
        //Debug.Log(Vector3.Distance(playerTrans.position, transform.position));
        Vector3 move = Vector3.MoveTowards(
            this.transform.position, 
            playerTrans.position,
            speed * Time.deltaTime);
        move.z = startZ;
        //move.y += 1;
        //transform.position = new Vector3(move.x, offset.y, -10);
        transform.position = new Vector3(playerTrans.position.x, playerTrans.position.y, startZ);
    }
}
