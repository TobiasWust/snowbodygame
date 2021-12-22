using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour, IDamageable {
  [SerializeField] int health;
  [SerializeField] GameObject hitSound;
  [SerializeField] GameObject shotSound;
  [SerializeField] GameObject deathSound;
  [SerializeField] GameObject deathEffect;
  KillCounter killCounter;
  [System.Serializable]
  public class Drop {
    public GameObject[] Pickups;
    public int pickupChance;
  }

  [HideInInspector]
  public Transform player;

  public Drop[] drops;
  public float speed;
  public float timeBetweenAttacks;
  public int damage;

  public virtual void Start() {
    player = GameObject.FindGameObjectWithTag("Player").transform;
    killCounter = GameObject.FindGameObjectWithTag("KillCounter").GetComponent<KillCounter>();
  }

  public void takeDamage(int damageAmount) {
    health -= damageAmount;

    hitShaderEffect();

    if (health > 0) playHitSound();
    if (health <= 0) {
      playDeathSound();
      if (deathEffect) Instantiate(deathEffect, transform.position, Quaternion.identity);
      throwDrop();
      killCount();
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
    SpriteRenderer[] sprites = gameObject.GetComponentsInChildren<SpriteRenderer>();

    for (int i = 0; i < sprites.Length; i++) {
      DOTween.Kill(sprites[i].material);
      sprites[i].material.SetFloat("_HitEffectBlend", 0);
      sprites[i].material.DOFloat(1, "_HitEffectBlend", .1f).SetLoops(2, LoopType.Yoyo).SetId("hit");
    }
  }

  void playHitSound() {
    if (hitSound) Instantiate(hitSound, transform.position, transform.rotation);
  }
  void playDeathSound() {
    if (deathSound) Instantiate(deathSound, transform.position, transform.rotation);
  }

  public void playShotSound() {
    if (shotSound) Instantiate(shotSound, transform.position, transform.rotation);
  }

  void killCount() {
    if (killCounter == null) return;
    killCounter.addKill();
  }
}
