using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DuckBehaviour : MonoBehaviour
{
    // velocidad
    private float speed = 1f;

    // Velocidad de rotación
    private float rotSpeed = 5f;

    // NavMeshAgent de cada pato
    public NavMeshAgent _agent;
    // Posición objetivo
    public Vector3 currentDestiny;

    // Animator
    private Animator anim;
    // Array que contiene las animaciones
    AnimationClip[] clips;
    // Tiempo que tarda cada animación
    private float jumpTime;
    private float walkTime;
    private float idleTime;

    // Contador
    private float counter = 0f;
    private bool startCounter = false;

    // Referencia al jugador (tambien se puede hacer public y asignarselo desde la interfaz en vez de buscarlo en Start())
    private GameObject player;
    
    // Comprueba si se ha cumplido la condición de abandonar al jugador
    public bool returnToSpawn = false;


    // Start is called before the first frame update
    void Start()
    {
        // Componente animator
        anim = GetComponent<Animator>();

        // Componente NavMeshAgent
        _agent = GetComponent<NavMeshAgent>();
        // Destino inicial
        currentDestiny = DuckGenerator.posicionAleatoriaEnRadio();
        _agent.SetDestination(currentDestiny);

        // Referencia al jugador
        player = GameObject.FindGameObjectWithTag("Agent Garcia");
        
        // Guardamos la duración en segundos de cada animación
        anim = GetComponent<Animator>();
        clips = anim.runtimeAnimatorController.animationClips;
        foreach(AnimationClip clip in clips)
        {
            switch (clip.name)
            {
                case "Walk":
                    walkTime = clip.length;
                    break;
                case "Idle":
                    idleTime = clip.length;
                    break;
                case "Jump":
                    jumpTime = clip.length;
                    break;
            }
        }

        // Iniciamos con la animación de caminar
        anim.Play("Walk");

    }

    // Update is called once per frame
    void Update()
    {
        // Si el pato no está siguiendo al jugador
        if (!GameObject.FindGameObjectWithTag("DuckSpawner").GetComponent<DuckGenerator>().followPlayer)
        {
            // Si no están siguiendo al jugador, usarán su velocidad habitual
            _agent.speed = speed;
            // Definimos la distancia a la que se detendrán del objetivo
            _agent.stoppingDistance = 0.2f;
            // Pasamos la velociadad al parámetro del Animator para que cumpla la transición de paso a andar
            anim.SetFloat("speed", speed);

            // Si se está reproduciendo Idle, aumentamos el contador
            if (startCounter)
                counter += Time.deltaTime;
            // Al terminar de reproducir la animación de Idle, el pato caminará a un nuevo destino
            if (counter >= idleTime)
            {
                counter = 0f;
                startCounter = false;

                anim.SetFloat("speed", speed);
                currentDestiny = DuckGenerator.posicionAleatoriaEnRadio();
                _agent.SetDestination(currentDestiny);

            }
            // Reducimos la velocidad del parámetro del animator cuando consideramos que está en el objetivo, activando el cronómetro y reproduciendo la animación de Idle
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                anim.SetFloat("speed", 0f);
                startCounter = true;
            }
        }
        // Si está siguiendo al jugador
        else
        {
            // Reseteamos el contador
            startCounter = false;
            counter = 0f;
            // Los patos tendrán el doble de la velocidad del jugador
            _agent.speed = 3.5f;
            // Los patos se detendrán cuando estén a esta distancia de su objetivo
            _agent.stoppingDistance = 0.2f;

            // Variable que comprobará que el destino del agente es válido
            bool stopIfUnreachable = false;
            
            // Cuando el jugador avance
            if (_agent.destination != currentDestiny)
            {
                // Comprobamos si el camino es viable
                NavMeshPath path = new NavMeshPath();
                _agent.CalculatePath(currentDestiny, path);
                if (path.status == NavMeshPathStatus.PathInvalid || path.status == NavMeshPathStatus.PathPartial)
                {
                    // Si no lo es, comprobaremos que se hace en el DuckGenerator
                    stopIfUnreachable = true;
                    returnToSpawn = true;
                }
                else
                {
                    // Si lo es, ponemos el destino actual y cambiamos la avariable de retorno
                    _agent.SetDestination(currentDestiny);
                    returnToSpawn = false;
                }

            }
            // Cuando el jugador esté quieto, se reproducirá la animación de salto mientras miran hacia él, siempre que estén en una posición válida
            if (Vector3.Distance(_agent.destination, transform.position) <= _agent.stoppingDistance || stopIfUnreachable)
            {
                Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
                anim.SetBool("jump", true);
            }
            // Cuando el jugador se encuentre en posición lo seguirán
            else
            {
                anim.SetBool("jump", false);
                anim.SetFloat("speed", 1f);
            }
        }
    }
}
