using System;
using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int fruits = 0;
    [SerializeField] private TextMeshProUGUI text;
    
    [SerializeField] private AudioClip collectSound;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject fruitVfx;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fruits"))
        {
            Instantiate(fruitVfx,other.gameObject.transform.position,Quaternion.identity);
            Destroy(other.gameObject);
            audioSource.PlayOneShot(collectSound);
            fruits++;
            text.text = "Fruits : " + fruits;
        }
    }




}
