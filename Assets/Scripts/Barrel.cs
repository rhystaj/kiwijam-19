using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : IPingable
{
    public Animator Explosion;    //For the Explosion Sprite   
    public AudioSource ExplosionSound;

    private SpriteRenderer Sprite;
    private Color Col;

    [SerializeField] bool Preprimed;

    [SerializeField] Vector2 explosionSize;

    [HideInInspector] public int explodeOnTurn = -1;


    private void Start()
    {
        if (Preprimed) explodeOnTurn = 0;
        Explosion = this.GetComponent<Animator>();
        ExplosionSound = this.GetComponent<AudioSource>();
        Sprite = this.GetComponent<SpriteRenderer>();
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(explosionSize.x, explosionSize.y, 1));
    }

    public override void Ping(int turn)
    {


        if (turn == explodeOnTurn)
        {
            Col = Sprite.color;
            Explosion.SetBool("Explode", true);
            ExplosionSound.Play();

            Collider2D[] colliders = Physics2D.OverlapBoxAll(new Vector2(transform.position.x, transform.position.y), explosionSize, 0);

            Debug.Log("Colliders: " + colliders.Length);

            foreach (Collider2D collider in colliders)
            {
                Explodable explodable = collider.GetComponent<Explodable>();
                if (explodable != null && !Destroyed)
                {
                    explodable.DetectExplosion(turn);
                }
            }

            base.DetectExplosion(turn);

        }

    }

    public override void ResetExplodable()
    {
        if (Preprimed)
        {
            explodeOnTurn = 0;
        }
        else
        {
            explodeOnTurn = -1;
        }
        Explosion.SetBool("Explode", false);
        Sprite.color = Col;
        base.ResetExplodable();
    }

    public override void DetectExplosion(int turn)
    {
        explodeOnTurn = turn + 1;
    }
}
