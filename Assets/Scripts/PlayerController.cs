using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private SoundConfig movementSFX;
    [SerializeField] private AudioSource _compAudioSource;
    [SerializeField] private Rigidbody _compRigidbody;
    [SerializeField] private float velocity;
    private bool booleano = false;
    public bool interactiveNPC = false;
    private Vector2 movement;

    void Awake()
    {
        _compAudioSource = GetComponent<AudioSource>();
        _compRigidbody = GetComponent<Rigidbody>();

        if (movementSFX != null)
        {
            _compAudioSource.clip = movementSFX.SoundClip;
        }
    }
    private void FixedUpdate()
    {
        _compRigidbody.velocity = new Vector3(movement.x, _compRigidbody.velocity.y, movement.y);
    }
    private void Update()
    {
        PlaySoundMovement();
    }

    private void PlaySoundMovement()
    {
        if (booleano == true)
        {
            if (!_compAudioSource.isPlaying)
            {
                _compAudioSource.Play();
            }
        }
        else
        {
            _compAudioSource.Stop();
        }
    }
    
 
    public void Movement(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>() * velocity;
        booleano = movement.magnitude > 0;
    }
    public void OnInteraction(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            interactiveNPC = true;
        }
        else if (context.canceled)
        {
            interactiveNPC = false;
        }
    }
}
