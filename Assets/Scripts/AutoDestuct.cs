using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestuct : MonoBehaviour
{
    [SerializeField] float boundary;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < boundary) Destroy(gameObject);
    }
}
