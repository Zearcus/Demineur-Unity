using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyTileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject EmptyTile;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(EmptyTile, new Vector2(1, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
