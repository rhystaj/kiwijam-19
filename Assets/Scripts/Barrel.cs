using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : IPingable
{
    public GameObject Explosion;    //For the Explosion Sprite   

    [SerializeField] bool Preprimed;

    [SerializeField] Vector2 explosionSize;

    [HideInInspector] public int explodeOnTurn = -1;

    private bool exploded = false;

    private void Start()
    {
        if (Preprimed) explodeOnTurn = 0;   
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(explosionSize.x, explosionSize.y, 1));
    }

    public override void Ping(int turn)
    {

        Debug.Log(name + " " + turn + " " + explodeOnTurn);

        if (turn == explodeOnTurn)
        {
            GameObject Explode = Instantiate(Explosion) as GameObject;
            Explode.transform.position = transform.position;


            Collider2D[] colliders = Physics2D.OverlapBoxAll(new Vector2(transform.position.x, transform.position.y), explosionSize, 0);

            Debug.Log("Colliders: " + colliders.Length);

            foreach (Collider2D collider in colliders)
            {
                Barrel barrel = collider.GetComponent<Barrel>();
                if (barrel != null && !exploded) barrel.explodeOnTurn = turn + 1;
            }

            exploded = true;

            gameObject.SetActive(false);

        }

    }


}
