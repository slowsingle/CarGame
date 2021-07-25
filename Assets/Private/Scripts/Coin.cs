using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider))]
public class Coin : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(PlaySoundAndDestroy());
        }
    }

    private IEnumerator PlaySoundAndDestroy()
    {
        audioSource.Play();
        transform.localScale = Vector3.zero;
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
