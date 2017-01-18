using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

    [SerializeField]
    GameObject explosionParticle;

    [SerializeField]
    Vector3 explodePosition;

    public TimeManager timeManager;

    public float radius = 50.0f;
    public float power = 10000.0f;
	// Use this for initialization
	void Start () {
        explodePosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.T)) {
            Explode();
        }
	}

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(explodePosition, radius);

        Instantiate(explosionParticle, explodePosition, transform.rotation);
        //timeManager.DoSlowMotion();
        foreach (Collider hit in colliders) {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, explodePosition, radius, 3.0f);
            }
        }
    }
}
