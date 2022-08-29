using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bicho2Script : MonoBehaviour
{
    public float velocidad;
    public Transform player;
    public Rigidbody2D Rigidbody2D;

    // Update is called once per frame
    void Update()
    {
        Vector2 objetivo = new Vector2(player.position.x, player.position.y);
        Vector2 nuevaPos = Vector2.MoveTowards(Rigidbody2D.position, objetivo, velocidad * Time.deltaTime);
        Rigidbody2D.MovePosition(nuevaPos);
    }
}
