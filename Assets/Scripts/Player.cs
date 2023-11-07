using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float vidaJugador;
    [SerializeField]private float vidaMaxima;
    public Image Corazon;
    public RectTransform posicionPrimerCorazon;
    public Canvas myCanvas;
    private int offSet;
    private bool puedeRecibirDaño;
    private float cooldownDaño;
    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        vidaMaxima = 3f;
        vidaJugador = vidaMaxima;
        puedeRecibirDaño = true;
        cooldownDaño = 3f;
        offSet = 75;
        spriteRenderer = GetComponent<SpriteRenderer>();

        Transform PosCorazon = posicionPrimerCorazon;

        for (int i = 0; i < vidaMaxima; i++)
        {
            Image newCorazon = Instantiate(Corazon,PosCorazon.position, Quaternion.identity);
            newCorazon.transform.SetParent(myCanvas.transform);
            PosCorazon.position = new Vector2(PosCorazon.position.x + offSet, PosCorazon.position.y);
        }
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            if (!puedeRecibirDaño)
            {
                return;
            }

            puedeRecibirDaño = false;
            Color color = spriteRenderer.color;
            color.a = 0.5f;
            spriteRenderer.color = color;
            Destroy(myCanvas.transform.GetChild((int)vidaJugador+1).gameObject);
            vidaJugador -= collision.GetComponent<Enemies>().dañoCausado;
            gameObject.GetComponent<PlayerController>().AplicarGolpe();

            if (vidaJugador <= 0)
            {
                Debug.Log("Perdiste");
                Destroy(gameObject);
                Destroy(Corazon);
            }

            Invoke("ActivarDaño", cooldownDaño);
        }

        if (collision.CompareTag("lava"))
        {
            if (!puedeRecibirDaño)
            {
                return;
            }

            puedeRecibirDaño = false;
            Color color = spriteRenderer.color;
            color.a = 0.5f;
            spriteRenderer.color = color;
            Destroy(myCanvas.transform.GetChild((int)vidaJugador+1).gameObject);
            vidaJugador -= collision.GetComponent<LavaDamage>().dañoCausado;
            gameObject.GetComponent<PlayerController>().AplicarGolpe();

            if (vidaJugador <= 0)
            {
                Debug.Log("Perdiste");
                Destroy(gameObject);
                Destroy(Corazon);
            }

            Invoke("ActivarDaño", cooldownDaño);
        }  
    }

    void ActivarDaño()
    {
        puedeRecibirDaño = true;
        Color c = spriteRenderer.color;
        c.a = 1f;
        spriteRenderer.color = c;
    }
}
