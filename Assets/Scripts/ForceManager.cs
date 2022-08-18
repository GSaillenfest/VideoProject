using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceManager : MonoBehaviour
{

    float forceMultiplier = 0.2f;

    float force;
    AreaEffector2D areaEffector2D;

    // Start is called before the first frame update
    void Start()
    {
        areaEffector2D = GetComponent<AreaEffector2D>();
        force = FindObjectOfType<GenerateurDeParticules>().force;
    }

    // Update is called once per frame
    void Update()
    {
        areaEffector2D.forceMagnitude = forceMultiplier * GetComponent<CircleShape>().Radius * force;
    }
}
