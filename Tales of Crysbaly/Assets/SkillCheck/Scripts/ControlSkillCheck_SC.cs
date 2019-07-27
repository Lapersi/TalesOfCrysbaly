using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSkillCheck_SC : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject CheckerPrefab;
    public GameObject RayaPrefab;
    [Space(5)]

    [Header("Posiciones de Spawn")]
    public RectTransform[] PuntosSpawn;
    [Space(5)]

    [Header("Velocidades de Checkers")]
    public float RondasParaMultVelocidad = 5;
    public int rondasPasadas = 0;
    public float aumentoDeVelocidad = 0.5f;
    float multiplicador = 1;

    public bool sinCarriles = false;

    //Posiciones de rayas de cada carril
    //Vector3[] PosCarriles;

    // Start is called before the first frame update
    void Start()
    {
        //Esperar un poco a los chekers
        Invoke("SpawnChecker", 2);

        //Inicializar Rayas
        InicioRayas();
    }

    //Spawn de primeras rayas
    void InicioRayas()
    {
        //Inicializar arreglo de posiciones
        //PosCarriles = new Vector3[PuntosSpawn.Length];

        //Spawn una raya por carril
        for(int a = 0; a < PuntosSpawn.Length ; a++)
        {
            //Generar posicion aleatoria
            Vector3 _pos = new Vector3(0, Random.Range(0, 40), 0);

            //Generar Raya
            GameObject _raya = Instantiate(RayaPrefab,Vector3.zero, Quaternion.identity, PuntosSpawn[a].transform.parent);
            _raya.transform.localPosition = _pos;
        }
    }

    //Spawn Checker
    public void SpawnChecker()
    {
        rondasPasadas++;
        if(rondasPasadas % RondasParaMultVelocidad == 0)
        {
            multiplicador += aumentoDeVelocidad;
        }

        //Escoger un carril no desactivado
        int Carril = EscogerCarrilNoDesactivado();

        //No spawnear si ya no hay carriles
        if (sinCarriles)
        {
            Debug.Log("Ya no hay carriles!");
            return;
        }

        //Poner en los puntos de spawn de cierto carril
        GameObject Checker = Instantiate(CheckerPrefab, PuntosSpawn[Carril].position, Quaternion.identity,transform);
        Checker.GetComponent<Checker_SC>().Control = this;
        Checker.GetComponent<Checker_SC>().Velocidad *= multiplicador;
    }

    int EscogerCarrilNoDesactivado()
    {
        int _activos = 0;
        //Comprobar que almenos un carril este activo
        for(int x = 0; x<PuntosSpawn.Length; x++)
        {
            if (PuntosSpawn[x].transform.parent.gameObject.activeSelf)
            {
                _activos++;
            }
        }
        if (_activos == 0)
        {
            sinCarriles = true;
            return 0;
        }

        int _Carril = 0;
        for(int a = 0; a < 2; a++)
        {
            _Carril = Random.Range(0, PuntosSpawn.Length);

            if (!PuntosSpawn[_Carril].parent.gameObject.activeSelf)
            {
                a = 0;
            }
            else
            {
                break;
            }
        }
        return _Carril;
    }

    //SpawnRaya
    public void MoverRaya(Transform _posRaya)
    { 
    //Mover Raya a la derecha Eje Y
        _posRaya.transform.localPosition -= new Vector3(0, Random.Range(30, 40), 0);

        //Desactivar carril si la raya esta más atras
        if(_posRaya.transform.localPosition.y < -135)
        {
            _posRaya.transform.parent.gameObject.SetActive(false);
        }
    }
}
