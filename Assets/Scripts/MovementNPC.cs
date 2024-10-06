using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MovementNPC : MonoBehaviour
{

    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private float speed = 4f;
    [SerializeField] private float waitTime = 1f;
    [SerializeField] public Image textoFondo;
    [SerializeField] public TMP_Text text;
    [SerializeField] private float interactionTime = 2f;
    [SerializeField] private int currentPatrolIndex = 0;
    bool interactionPlayer = false;
    bool puedoPatrullar = true;

    [SerializeField] PlayerController player;
    private void Update()
    {
        if (puedoPatrullar && interactionPlayer == false)
        {
            MovePosition(currentPatrolIndex);
        }
        if (Vector3.Distance(transform.position, patrolPoints[currentPatrolIndex].position) < 0.01f)
        {
            currentPatrolIndex++;
            if (currentPatrolIndex >= patrolPoints.Length)
            {
                currentPatrolIndex = 0;
            }
            puedoPatrullar = false;
            StartCoroutine(Patrol());
        }

    }
    void MovePosition(int currentPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPosition].position, speed * Time.deltaTime);
    }
    IEnumerator Patrol()
    {
        if (currentPatrolIndex == 3)
        {
            yield return new WaitForSecondsRealtime(3f);
        }
        else
        {
            yield return new WaitForSecondsRealtime(waitTime);
        }
        puedoPatrullar = true;
    }
    IEnumerator NoCollisionPlayer()
    {
        yield return new WaitForSecondsRealtime(interactionTime);
        interactionPlayer = false;
        textoFondo.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (player.interactiveNPC == true)
            {
                interactionPlayer = true;
                StartCoroutine(NoCollisionPlayer());
                textoFondo.gameObject.SetActive(true);
                text.gameObject.SetActive(true);
            }
        }
    }
}

