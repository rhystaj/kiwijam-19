using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : IPingable
{
    public GameObject Explosion;    //For the Explosion Sprite   

    [SerializeField] bool Primed = false;

    [SerializeField] Vector2 explosionSize;


    private void Start()
    {
        
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(explosionSize.x, explosionSize.y, 1));
    }

    public override void Ping()
    {

        Debug.Log(name + ": " + Primed);

        if (Primed)
        {
            GameObject Explode = Instantiate(Explosion) as GameObject;
            Explode.transform.position = transform.position;


            Collider2D[] colliders = Physics2D.OverlapBoxAll(new Vector2(transform.position.x, transform.position.y), explosionSize, 0);

            Debug.Log("Colliders: " + colliders.Length);

            foreach (Collider2D collider in colliders)
            {
                Barrel barrel = collider.GetComponent<Barrel>();
                if (barrel != null) barrel.Primed = true;
            }
          

            this.gameObject.SetActive(false);

        }

    }


}
