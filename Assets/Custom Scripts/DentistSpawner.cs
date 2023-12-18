using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DentistSpawner : MonoBehaviour
{
    public Transform spawnLocation;
    public GameObject dentistPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Instantiate(dentistPrefab, spawnLocation.position, Quaternion.identity);
        }
    }
}
