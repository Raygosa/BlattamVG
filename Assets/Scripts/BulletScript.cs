using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed;
    public AudioClip Sound;

    private Rigidbody2D Rigidbody2D;
    private Vector3 Direction;
 
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector3 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject); //Destroy es una funcion de unity
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LionMovement lion = collision.GetComponent<LionMovement>();
        BichoScript bicho = collision.GetComponent<BichoScript>();
        if(lion != null)
        {
            lion.HitLion();
        }
        if(bicho != null)
        {
            bicho.Hit();
        }
        DestroyBullet();
    }
}
