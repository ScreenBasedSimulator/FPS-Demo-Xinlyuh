using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

    public GameObject shootingEffect;
    public AudioClip shootingSound;
    public float Timer;

	// Use this for initialization
	void Start () {
        shootingEffect.SetActive(false);
        Timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1"))
        {
            Timer += Time.deltaTime;
            if (Timer >= 0.1f)
            {
                Camera.main.GetComponent<AudioSource>().PlayOneShot(shootingSound);
                shootingEffect.SetActive(true);
                RaycastHit hit;

                Ray MonRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

                if (Physics.Raycast(MonRay, out hit, 10f))
                {
                    if (hit.collider.gameObject.tag == "Car")
                        hit.collider.SendMessage("GotShot");
                }
            }
        }
        if (Input.GetButtonUp("Fire1")){

            Timer = 0;
            shootingEffect.SetActive(false);

        }
	}
}
