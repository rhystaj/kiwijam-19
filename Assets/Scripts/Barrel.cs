using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : IPingable
{
    public Animator Explosion;    //For the Explosion Sprite   
    public AudioSource ExplosionSound;

    private SpriteRenderer Sprite;
    [SerializeField] GameObject ExplosionArea;
    private Color Col;

    private Color Invisble;
    private Color ColorExplosion;

    [SerializeField] bool Preprimed;

    [SerializeField] Vector2 explosionSize;

    [SerializeField] GameObject warningSquare;

    [HideInInspector] public int explodeOnTurn = -1;
    GameObject ExplosionSquare;


    private void Start()
    {
        Invisble.a = 0;
        Invisble.r = 0;
        Invisble.g = 0;
        Invisble.b = 0;
        
        Explosion = this.GetComponent<Animator>();
        ExplosionSound = this.GetComponent<AudioSource>();
        Sprite = this.GetComponent<SpriteRenderer>();

        Vector3 Vector = transform.position;
        ExplosionSquare = Instantiate(ExplosionArea, Vector, Quaternion.identity);
        Vector2 vec2 = transform.localScale;
        vec2.x = explosionSize.x;
        vec2.y = explosionSize.y;

        ExplosionSquare.transform.localScale = vec2;

        ColorExplosion = ExplosionSquare.GetComponent<SpriteRenderer>().color;

        ExplosionSquare.GetComponent<SpriteRenderer>().color = Invisble;

        if (Preprimed) { explodeOnTurn = 0; DetectExplosion(-1); }

        //warningSquare = Instantiate(warningSquare, transform);
        //warningSquare.transform.localScale = explosionSize;
        //warningSquare.SetActive(false);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(explosionSize.x, explosionSize.y, 1));
    }

    public override void Ping(int turn)
    {
        if (turn == explodeOnTurn)
        {
            Col = Sprite.color;
            
            Explosion.SetBool("Explode", true);
            ExplosionSquare.GetComponent<SpriteRenderer>().color = Invisble;
            ExplosionSquare.SetActive(false);
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
            DetectExplosion(-1);
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
        //warningSquare.SetActive(false);
        explodeOnTurn = turn + 1;
        ExplosionSquare.GetComponent<SpriteRenderer>().color = ColorExplosion;
    }
}
