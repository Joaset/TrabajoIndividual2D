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
    public int offSet;
    
    void Start()
    {
        vidaMaxima = 3f;
        vidaJugador = vidaMaxima;

        Transform PosCorazon = posicionPrimerCorazon;

        for (int i = 0; i < vidaMaxima; i++)
        {
            Image newCorazon = Instantiate(Corazon,PosCorazon.position, Quaternion.identity);
            newCorazon.transform.parent = myCanvas.transform;
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
            Destroy(myCanvas.transform.GetChild((int)vidaJugador+1).gameObject);
            vidaJugador -= collision.GetComponent<Enemies>().dañoCausado;
            if (vidaJugador <= 0)
            {
                Debug.Log("Perdiste");
                Destroy(gameObject);
                Destroy(Corazon);
            }
        }  
    }
}
