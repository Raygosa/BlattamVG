using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BichoScript : MonoBehaviour
{
    public GameObject Lion;
    public GameObject BulletPrefab;
    private int Health = 1;

    private float LastShoot;

    void Update()
    {
        if (Lion == null) return;

        Vector3 direction = Lion.transform.position - transform.position;
        if(direction.x >= 0.0f) transform.localScale = new Vector3(0.3f, 0.3f, 1.0f);
        else transform.localScale = new Vector3(-0.3f, 0.3f, 1.0f);

        float distance = Mathf.Abs(Lion.transform.position.x - transform.position.x);

        if(distance < 1.0f && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        Vector3 direction = new Vector3(transform.localScale.x, 0.0f, 0.0f);

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.5f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    public void Hit()
    {
        Health = Health - 1;
        if(Health == 0) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CaidaAlVacio")
        {
            Debug.Log("Muerte por caida al vacio el bicho");
            pierdeVidaBicho();
        }
    }

     private void pierdeVidaBicho()
    {
        Destroy(gameObject);
    }
}
