using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateurDeParticules : MonoBehaviour
{

    [SerializeField] GameObject particlePrefab;
    [SerializeField] [Range(0.1f, 100f)] float cadence = 1f;
    [SerializeField] float rayon = 5f;
    [SerializeField] Transform parent;

    [SerializeField] public float force = 20f;
    
    Vector2 spawnPos;
    float instantiateTime;

    // Start is called before the first frame update
    void Start()
    {
        instantiateTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= instantiateTime)
        {
            spawnPos = new Vector2(transform.position.x,transform.position.y) + (Random.insideUnitCircle * rayon);
            GameObject newParticle = Instantiate(particlePrefab, spawnPos, Quaternion.identity, parent);
            newParticle.GetComponent<Rigidbody2D>().AddForce(transform.right * force, ForceMode2D.Impulse);
            
            //Color color = Random.ColorHSV();
            newParticle.GetComponent<TrailRenderer>().startColor = Color.yellow;
            newParticle.GetComponent<TrailRenderer>().endColor = Color.black;
            newParticle.GetComponent<Renderer>().material.color = Color.yellow;
            instantiateTime = Time.time + 1/cadence;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, rayon);
    }
}
