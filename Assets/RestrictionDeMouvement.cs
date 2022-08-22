using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestrictionDeMouvement : MonoBehaviour
{
    [SerializeField]
    Transform tuteurTransform;
    [SerializeField]
    float xLeftBoundary;
    [SerializeField]
    float xRightBoundary;
    [SerializeField]
    float yBottomBoundary;
    [SerializeField]
    float yTopBoundary;

    float y;

    // Start is called before the first frame update
    void Start()
    {
        y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
        Mathf.Clamp(tuteurTransform.position.x, xLeftBoundary, xRightBoundary),
        y);
    }
}
