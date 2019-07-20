using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : IPingable
{
    public GameObject Explosion;    //For the Explosion Sprite   
    private int Status = 0;

    CharacterController controller;

    public int BarrelStatus()
    {
        controller = GetComponent<CharacterController>();

        if ((controller.collisionFlags == CollisionFlags.Sides) || (controller.collisionFlags == CollisionFlags.Above) || (controller.collisionFlags == CollisionFlags.Below))
        {
            Status = 1;
        }

        else
        {
            Status = 0;
        }

        return Status;
    }

    public override void Ping()
    {
        if (BarrelStatus() == 1)
        {
            GameObject Explode = Instantiate(Explosion) as GameObject;
            Explode.transform.position = transform.position;
            Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }

    }

    private void Explode(Collider2D Self)
    {

    }
}
