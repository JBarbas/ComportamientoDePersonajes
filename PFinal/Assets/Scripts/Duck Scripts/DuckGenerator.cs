using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DuckGenerator : MonoBehaviour
{

    // Prefab del pato
    public GameObject duckPrefab;
    // Distancia máxima con zona de aparición
    public static int spawnZone = 3;
    // Centro del área de expansión de la bandada
    public static Vector3 objective;

    // Numero de patos y lista que los almacena
    public static int numDucks = 5;
    public static List<GameObject> allDucks;

    // Jugador
    private GameObject player;

    // Comprueba que se sigue al jugador
    public bool followPlayer = false;
    public static bool duckIsNearPlayer;
    
    // Cuenta cuantos patos que siguen al jugador no pueden alcanzar su destino
    public int contactLost = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Asignamos al jugador
        player = GameObject.FindGameObjectWithTag("Agent Garcia");

        // Inicializamos la posición del objetivo como el lugar de aparición de los patos
        objective = transform.position;
        allDucks = new List<GameObject>();
        // Hacemos aparecer el número deseado de patos
        for (int i = 0; i < numDucks; i++)
        {
            Vector3 pos = posicionAleatoriaEnRadio();
            // Instanciamos el prefab en la ubicación y lo añadimos a la lista
            allDucks.Add((GameObject)Instantiate(duckPrefab, pos, Quaternion.identity));
        }

    }

    // Update is called once per frame
    void Update()
    {
        duckIsNearPlayer = followPlayer;

        // Si el jugador usa la tecla interactuar
        if (PlayerInventory.equipedDAC == "ZAPAPATOS")
        {
            // En el radio del generador de patos, lo siguen
            if (Vector3.Distance(player.transform.position, transform.position) <= spawnZone)
            {
                followPlayer = true;
                if (!followPlayer)
                    for (int i = 0; i < numDucks; i++)
                    {
                        allDucks[i].GetComponent<DuckBehaviour>()._agent.SetDestination(posicionAleatoriaEnRadio());
                        allDucks[i].GetComponent<Animator>().SetBool("jump", false);
                    }
            }
            // Mientras lo siguen, dejan de seguirlo
            else if (followPlayer)
            {
                //followPlayer = !followPlayer;
                for (int i = 0; i < numDucks; i++)
                {
                    allDucks[i].GetComponent<DuckBehaviour>()._agent.SetDestination(posicionAleatoriaEnRadio());
                    allDucks[i].GetComponent<Animator>().SetBool("jump", false);
                }
            }

        }
        else
        {
            followPlayer = false;
        }
        // Si siguen al jugador
        if (followPlayer) {
            // Comprobamos cuantos patos pueden llegar a su posición
            for (int i = 0; i < numDucks; i++)
            {
                if (allDucks[i].GetComponent<DuckBehaviour>().returnToSpawn)
                    contactLost++;

            }
            // Si ningún pato puede, abandonan al jugador
            if (contactLost == numDucks)
            {
                followPlayer = false;
                for (int i = 0; i < numDucks; i++)
                {
                    allDucks[i].GetComponent<DuckBehaviour>()._agent.SetDestination(posicionAleatoriaEnRadio());
                    allDucks[i].GetComponent<DuckBehaviour>().returnToSpawn = false;
                    allDucks[i].GetComponent<Animator>().SetBool("jump", false);
                }
            }
            else
            {
                // Si al menos un pato puede, los que no probarán a posicionarse del otro lado
                Vector3 posPlayer = new Vector3(player.transform.position.x, 7.798413f, player.transform.position.z);

                NavMeshHit hit;
                NavMesh.SamplePosition(posPlayer + (player.transform.forward + new Vector3(0, 0, 2.5f)) / 3, out hit, spawnZone, NavMesh.AllAreas);

                //if (allDucks[0].GetComponent<DuckBehaviour>().returnToSpawn)
                    allDucks[0].GetComponent<DuckBehaviour>().currentDestiny = hit.position;
                /*else
                    allDucks[0].GetComponent<DuckBehaviour>().currentDestiny = posPlayer + player.transform.forward + new Vector3(0, 0, 2.5f);*/

                NavMesh.SamplePosition(posPlayer + (player.transform.forward + new Vector3(2.5f, 0, 1.5f)) / 3, out hit, spawnZone, NavMesh.AllAreas);

                //if (allDucks[1].GetComponent<DuckBehaviour>().returnToSpawn)
                allDucks[1].GetComponent<DuckBehaviour>().currentDestiny = hit.position;
                /*else
                    allDucks[1].GetComponent<DuckBehaviour>().currentDestiny = posPlayer + player.transform.forward + new Vector3(2.5f, 0, 1.5f);*/

                NavMesh.SamplePosition(posPlayer + (player.transform.forward + new Vector3(1.5f, 0, -2.5f)) / 3, out hit, spawnZone, NavMesh.AllAreas);

                //if (allDucks[2].GetComponent<DuckBehaviour>().returnToSpawn)
                allDucks[2].GetComponent<DuckBehaviour>().currentDestiny = hit.position;
                /*else
                    allDucks[2].GetComponent<DuckBehaviour>().currentDestiny = posPlayer + player.transform.forward + new Vector3(1.5f, 0, -2.5f);*/

                NavMesh.SamplePosition(posPlayer + (player.transform.forward + new Vector3(-1.5f, 0, -2.5f)) / 3, out hit, spawnZone, NavMesh.AllAreas);

                //if (allDucks[3].GetComponent<DuckBehaviour>().returnToSpawn)
                allDucks[3].GetComponent<DuckBehaviour>().currentDestiny = hit.position;
                /*else
                    allDucks[3].GetComponent<DuckBehaviour>().currentDestiny = posPlayer + player.transform.forward + new Vector3(-1.5f, 0, -2.5f);*/

                NavMesh.SamplePosition(posPlayer + (player.transform.forward + new Vector3(-2.5f, 0, 1.5f)) / 3, out hit, spawnZone, NavMesh.AllAreas);

                //if (allDucks[4].GetComponent<DuckBehaviour>().returnToSpawn)
                allDucks[4].GetComponent<DuckBehaviour>().currentDestiny = hit.position;
                /*else
                    allDucks[4].GetComponent<DuckBehaviour>().currentDestiny = posPlayer + player.transform.forward + new Vector3(-2.5f, 0, 1.5f);*/

            }
            contactLost = 0;
        }
    }

    private void OnDrawGizmos()
    {
        // Dibujamos el radio de la zona de aparición
        //UnityEditor.Handles.color = Color.green;
        //UnityEditor.Handles.DrawWireDisc(objective, Vector3.up, spawnZone);
    }

    public static Vector3 posicionAleatoriaEnRadio()
    {
        // Calculamos posiciones aleatorias en un círculo de radio spawnZone
        Vector2 cPos = Random.insideUnitCircle * spawnZone;
        Vector3 pos = new Vector3(cPos.x, 0, cPos.y);
        pos += objective;
        return pos;
    }
}
