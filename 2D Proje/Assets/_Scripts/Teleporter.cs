using System;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform teleportPos;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip teleportSound;
    [SerializeField] private GameObject teleportVfx;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(teleportSound);
            other.gameObject.transform.position = teleportPos.position;
            Instantiate(teleportVfx,teleportPos.position,Quaternion.identity);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(teleportPos.position, 0.2f);
    }
}
