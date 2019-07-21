using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Checker_SC : MonoBehaviour
{
    [Header("Variables")]
    public Tecla tecla;
    public bool EnRaya = false;
    public float Velocidad = 1;
    public GameObject ParticulasAtinar;
    public GameObject ParticulasNoAtinar;
    [Space(5)]

    [Header("Teclas")]
    public bool Btn_A = false;
    public bool Btn_W = false;
    public bool Btn_S = false;
    public bool Btn_D = false;
    [Space(5)]

    [Header("ControlSkillCheck")]
    public ControlSkillCheck_SC Control; 


    //Variables Privadas
    TextMeshProUGUI LetraRender;
    Transform _posRaya = null;

    //debugs
    bool vivo = true;    

    //Teclas
    public enum Tecla
    {
        A,W,S,D
    }

    #region Inicio
    // Start is called before the first frame update
    void Start()
    {
        //Asignar renderer
        LetraRender = GetComponentInChildren<TextMeshProUGUI>();

        //Inicializar el checker
        SeleccionTecla();
    }

    //Hacer seleccion aleatoria de tecla
    void SeleccionTecla()
    {
        //Seleccionar y assignar tecla
        int _random = Random.Range(0, 4);
        switch (_random)
        {
            case 0:
                tecla = Tecla.A;
                break;
            case 1:
                tecla = Tecla.W;
                break;
            case 2:
                tecla = Tecla.S;
                break;
            case 3:
                tecla = Tecla.D;
                break;
            default:
                tecla = Tecla.D;
                break;
        }

        //Poner letra en renderer
        LetraRender.text = tecla.ToString();
    }
    #endregion

    #region Update
    // Update is called once per frame
    void Update()
    {
        Movimiento();
        DetectarInput();
    }

    //Movimiento del Checker
    void Movimiento()
    {
        //mover hacia la derecha
        transform.Translate(new Vector3(Velocidad, 0, 0));
    }
    
    void DetectarInput()
    {
        Btn_A = Input.GetButtonDown("BotonA");
        Btn_W = Input.GetButtonDown("BotonW");
        Btn_S = Input.GetButtonDown("BotonS");
        Btn_D = Input.GetButtonDown("BotonD");

        //Si esta fuera de raya
        if ((Btn_A || Btn_W || Btn_S || Btn_D) && !EnRaya)
        {
            Desctruccion("Se adelanto!");

            return;
        }else

        //Si esta en raya
        if(EnRaya)
        {
            //Tecla A
            if(tecla == Tecla.A)
            {
                //Acerto -----------------------------------------!
                if (Btn_A)
                {
                    Desctruccion("Atino!");
                }
                //Tecla incorrecta
                else if (Btn_W || Btn_S || Btn_D)
                {
                    Desctruccion("Tecla Incorrecta!");
                    return;
                }                
            }else

            //Tecla W
            if (tecla == Tecla.W)
            {
                //Acerto
                if (Btn_W)
                {
                    Desctruccion("Atino!");
                }
                //Tecla incorrecta
                else if (Btn_A || Btn_S || Btn_D)
                {
                    Desctruccion("Tecla Incorrecta!");
                    return;
                }
            }else

            //Tecla W
            if (tecla == Tecla.S)
            {
                //Acerto
                if (Btn_S)
                {
                    Desctruccion("Atino!");
                }
                //Tecla incorrecta
                else if (Btn_A || Btn_W || Btn_D)
                {
                    Desctruccion("Tecla Incorrecta!");
                    return;
                }
            }

            //Tecla W
            if (tecla == Tecla.D)
            {
                //Acerto
                if (Btn_D)
                {
                    Desctruccion("Atino!");
                }
                //Tecla incorrecta
                else if (Btn_A || Btn_S || Btn_W)
                {
                    Desctruccion("Tecla Incorrecta!");
                    return;
                }
            }
            
        }
    }
    #endregion

    #region Deteccion de raya
    //Detectar raya o final INICIO
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //esta tocando la raya
        if(collision.tag == "Raya")
        {
            EnRaya = true;

            _posRaya = collision.gameObject.transform;
        }
    }

    //Detectar raya FINAL
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Esta saliendo de la raya, destruir el checker
        if (collision.tag == "Raya")
        {
            EnRaya = false;
            
            Desctruccion("No atino!");
        }
    }
    #endregion

    void Desctruccion(string _resultado)
    {
        if (vivo)
        {
            //debug resultado
            Debug.Log(_resultado);

            //prevencion doble llamada
            vivo = false;

            //Mover Raya
            if (_posRaya != null)
            {
                Control.MoverRaya(_posRaya);
            }

            //Spawn nuevo Checker
            Control.SpawnChecker();

            //Destruir con Fade y deshabilitar este script
            //Destroy(gameObject, 0.5f);
            //Destruir en instanciar particulas
            PonerParticulas();
            Destroy(gameObject);

            this.enabled = false;
        }
    }

    void PonerParticulas()
    {
        //Si atino
        if (EnRaya)
        {
            Instantiate(ParticulasAtinar, transform.position, Quaternion.identity);
        }
        else
        {
            //Si no atino
            Instantiate(ParticulasNoAtinar, transform.position, Quaternion.identity);
        }
    }

    
}
