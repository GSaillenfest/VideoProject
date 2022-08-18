using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remplissage : MonoBehaviour
{

    public float compteur = 0;
    [SerializeField] Canvas ecranDeFin;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Particles"))
        {
            if (compteur <= 100f)
            {
                compteur++;
                collision.gameObject.layer = 0;
                collision.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
                collision.GetComponent<TrailRenderer>().enabled = false;
            }
            else
            {
                Destroy(collision.gameObject, 5f);
                ecranDeFin.gameObject.SetActive(true);
            }

        }
    }
}
