using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : Enemy {
  public float minX;
  public float minY;
  public float maxX;
  public float maxY;

  private Vector2 targetPosition;
  private Animator anim;

  public float timeBetweenSummons;
  private float summonTime;

  public Enemy EnemyToSummon;

  public GameObject Poof;

  public override void Start() {
    base.Start();
    float randomX = Random.Range(minX, maxX);
    float randomY = Random.Range(minY, maxY);
    targetPosition = new Vector2(randomX, randomY);

    anim = GetComponent<Animator>();
  }

  private void Update() {
    if (player != null) {
      if (Vector2.Distance(transform.position, targetPosition) > 0.5f) {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
      } else {
        if (Time.time >= summonTime) {
          summonTime = Time.time + timeBetweenSummons;
          anim.SetTrigger("summon");
        }
      }
    }
  }

  public void Summon() {
    if (player != null) {
      Instantiate(Poof, transform.position, transform.rotation);
      playShotSound();
      int numberOfBunnys = Random.Range(1, 3);
      for (int i = 0; i < numberOfBunnys; i++) {
        Instantiate(EnemyToSummon, transform.position, transform.rotation);
      }
    }
  }

}
