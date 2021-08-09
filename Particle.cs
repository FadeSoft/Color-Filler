using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public Material particleSystemMaterial;
    public ParticleSystemRenderer particleSystemRenderer;
    public ParticleSystem particleSystem;
    public Vector3 fallow;

    public GameObject player;
    public void push(Color obstacleColor)
    {
        particleSystemMaterial.color = obstacleColor;
        particleSystemRenderer.material = particleSystemMaterial;
        particleSystem.Play();

        particleSystem.gameObject.transform.position = player.transform.position+fallow;

    }
    private void Update()
    {
        gameObject.transform.position = player.transform.position;

    }
    public void tran()
    {
    }
}
