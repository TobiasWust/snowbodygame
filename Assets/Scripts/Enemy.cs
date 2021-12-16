using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour, IDamageable {
  public int health;
  public float speed;
  public float timeBetweenAttacks;
  public int damage;

  [System.Serializable]
  public class Drop {
    public GameObject[] Pickups;
    public int pickupChance;
  }

  [SerializeField] GameObject spriteParent;

  [HideInInspector]
  public Transform player;

  public Drop[] drops;

  public virtual void Start() {
    player = GameObject.FindGameObjectWithTag("Player").transform;
  }

  public GameObject deathEffect;

  public void takeDamage(int damageAmount) {
    health -= damageAmount;

    hitShaderEffect();

    if (health <= 0) {
      if (deathEffect) Instantiate(deathEffect, transform.position, Quaternion.identity);
      throwDrop();
      Destroy(gameObject);
    }
  }

  void throwDrop() {
    foreach (var drop in drops) {
      int randomNumber = Random.Range(0, 100);
      if (randomNumber <= drop.pickupChance) {
        GameObject randomPickup = drop.Pickups[Random.Range(0, drop.Pickups.Length)];
        Vector3 randomPosition = new Vector3(Random.Range(-50, 50) * .01f, Random.Range(-50, 50) * .01f, 0);

        Instantiate(randomPickup, transform.position + randomPosition, transform.rotation);
      }
    }
  }

  void hitShaderEffect() {
    SpriteRenderer[] sprites = spriteParent.GetComponentsInChildren<SpriteRenderer>();

    for (int i = 0; i < sprites.Length; i++) {
      DOTween.Kill(sprites[i].material);
      sprites[i].material.SetFloat("_HitEffectBlend", 0);
      sprites[i].material.DOFloat(1, "_HitEffectBlend", .1f).SetLoops(2, LoopType.Yoyo).SetId("hit");
    }
  }
}
