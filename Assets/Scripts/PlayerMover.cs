using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerMover : MonoBehaviour, IDamageable {
  public float speed;
  public float health;

  public Slider Healthbar;

  Rigidbody2D rb;
  Animator anim;
  Vector2 moveAmount;

  private void Start() {
    rb = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();

    Healthbar.value = health;
  }

  private void Update() {
    Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    moveAmount = moveInput.normalized * speed;

    bool isRunningLeft = Input.GetAxisRaw("Horizontal") == -1;
    bool isRunningRight = Input.GetAxisRaw("Horizontal") == 1;
    anim.SetBool("isRunningLeft", isRunningLeft);
    anim.SetBool("isRunningRight", isRunningRight);
  }

  private void FixedUpdate() {
    rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
  }

  public void takeDamage(int damageAmount) {
    health -= damageAmount;

    Healthbar.value = health;

    if (health <= 0) {
      Debug.Log("You Died :(");
      Destroy(gameObject);
    }
  }

  public void equipWeapon(Weapon weapon) {
    GameObject oldWeapon = GameObject.FindGameObjectWithTag("Weapon");
    Transform oldTransform = oldWeapon.transform;
    Instantiate(weapon, oldTransform.position, oldTransform.rotation, transform);
    Pickup newPickup = Instantiate(oldWeapon.GetComponent<Weapon>().PickupObject, transform.position, transform.rotation);

    int jumpDirection = anim.GetBool("isRunningLeft") ? 2 : -2;
    newPickup.gameObject.layer = 6; // dont pick up at first
    newPickup.gameObject.transform.DOJump(transform.position + Vector3.right * jumpDirection, 2, 1, 1)
      .OnComplete(() => { newPickup.gameObject.layer = 0; });

    Destroy(oldWeapon);
  }

  private void test() { }
}
