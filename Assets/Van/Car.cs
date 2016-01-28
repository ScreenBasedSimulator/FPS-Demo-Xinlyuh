using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour
{
    public GameObject smokeEffect;
    public GameObject fireEffect;
    public GameObject explosionEffect;
    int health;

	// Use this for initialization
	void Start () {

        health = 20;
        smokeEffect.SetActive(false);
        fireEffect.SetActive(false);
        explosionEffect.SetActive(false);

	}

    public void GotShot(){
        health--;
        if (health <= 10)
        {
            smokeEffect.SetActive(true);
        }
        if (health <= 0)
        {
            fireEffect.SetActive(true);
            if (health == 0)
            {
                explosionEffect.SetActive(true);
                this.GetComponent<Rigidbody>().AddForce(this.transform.up * 300);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
