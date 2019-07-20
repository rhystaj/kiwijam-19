using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : IPingable
{
    public GameObject Explosion;    //For the Explosion Sprite     

    CharacterController controller;

    public override void Ping()
    {
        controller = GetComponent<CharacterController>();

        if (controller.detectCollisions == true)
        {
            Explode((Collider2D)GetComponent<Collider2D>());
        }

    }

    private void Explode(Collider2D Self)
    {
        GameObject Explode = Instantiate(Explosion) as GameObject;
        Explode.transform.position = transform.position;
        Destroy(Self.gameObject);
        this.gameObject.SetActive(false);
    }
}
