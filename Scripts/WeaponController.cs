using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;

    private AudioSource audioSource;
    private float nextFire;

	void Start () {
        audioSource = GetComponent<AudioSource>();
        nextFire = Time.time + delay;
	}

    private void Update()
    {
        RaycastHit hit;
        Physics.Raycast(shotSpawn.position, shotSpawn.forward, out hit, 30f);
        if (hit.transform.CompareTag("Player") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
        }
    }

    void Fire () {
        
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        audioSource.Play();

	}
}
