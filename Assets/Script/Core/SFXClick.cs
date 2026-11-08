using UnityEngine;

public class SFXClick : MonoBehaviour
{
    [SerializeField] AudioSource source;
    public void Play() => source.Play();
}