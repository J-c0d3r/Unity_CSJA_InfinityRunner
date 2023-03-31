using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoke : MonoBehaviour
{
    public GameObject smokePrefab;    

    public void createSmoke()
    {
        Instantiate(smokePrefab, transform.position, transform.rotation);        
    }
}
