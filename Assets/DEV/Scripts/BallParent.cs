using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallParent : MonoBehaviour
{
    public Ball ball;
    public GameObject explosion;
    public Color color;
    public TrailRenderer trailRenderer;
    private void OnEnable()
    {
        trailRenderer.material.SetColor("_BaseColor", color);
        Explosion();
    }
    public void Explosion() 
    {
        GameObject copy = Instantiate(explosion, ball.transform.position, Quaternion.identity);
        copy.GetComponent<ParticleSystem>().GetComponent<ParticleSystemRenderer>().material.SetColor("_TintColor", color);
        Destroy(copy.gameObject, 2f);
    }
}
