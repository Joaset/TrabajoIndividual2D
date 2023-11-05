using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float velocidad;
    private float fuerzaSalto;
    private Rigidbody2D rigidBody;
    [SerializeField] private LayerMask capaSuelo;
    private Animator animator;
    private float velX;
    private float velY;
    [SerializeField] private Transform suelo;
    private bool tocarSuelo;
    private float tocarSueloRadio;
    [SerializeField] private Transform FirePoint;
    [SerializeField] private GameObject Bullet;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        velocidad = 5f;
        fuerzaSalto = 12f;
        tocarSueloRadio = 0.2f;
    }

    
    void Update()
    {
        tocarSuelo = Physics2D.OverlapCircle(suelo.position,tocarSueloRadio,capaSuelo);
        CambioDireccion();

        if (tocarSuelo)
        {
            animator.SetBool("isJumping", false);
        }
        else
        {
            animator.SetBool("isJumping", true);
        }

        Ataque();

    }

    private void FixedUpdate() {
        Movimiento();
        Salto();
    }

    void Salto()
    {
        if(Input.GetButton("Jump") && tocarSuelo)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x,fuerzaSalto);
        }
    }

    void Movimiento()
    {
        velX = Input.GetAxis("Horizontal");
        velY = rigidBody.velocity.y;
        rigidBody.velocity = new Vector2(velX * velocidad, velY);

        if(rigidBody.velocity.x != 0)
        {
            animator.SetBool("isRunning", true);
            if (Input.GetButton("Fire1"))
            {
                animator.SetBool("isRunningShoot", true);
            }
            else
            {
                animator.SetBool("isRunningShoot", false);
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        //transform.Translate(velX * velocidad * Time.deltaTime,0,0);
    }

    void CambioDireccion()
    {
        if(rigidBody.velocity.x > 1)
        {
            transform.localScale = new Vector2( 3, 3);
            FirePoint.transform.eulerAngles = new Vector3(0,0,0);
        }
        else if(rigidBody.velocity.x < -1)
        {
            transform.localScale = new Vector2( -3, 3);
            FirePoint.transform.eulerAngles = new Vector3(0,180,0);
        }
    }

    void Ataque()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("isShooting", true);
            Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
        }
        else
        {
            animator.SetBool("isShooting", false);
        }
    }

}
