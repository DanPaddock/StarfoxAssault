using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject DeathFX;
    [SerializeField] Transform parent;
    [SerializeField] int ScorePerHit = 150;

    Scoreboard scoreboard;

    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
        scoreboard = FindObjectOfType<Scoreboard>();
    }

    void AddNonTriggerBoxCollider()
    {
        Collider box = gameObject.AddComponent<BoxCollider>();
        box.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        scoreboard.UpdateScore(ScorePerHit);
        GameObject explosion = Instantiate(DeathFX, transform.position, Quaternion.identity);
        explosion.transform.parent = parent;
        Destroy(gameObject);
    }
}
