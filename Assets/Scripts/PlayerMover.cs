using UnityEngine;
using UnityEngine.UI;

public class PlayerMover : MonoBehaviour, IDamageable {
  public float speed;
  private int health;

  public Image[] hearts;
  public Sprite fullHeart;
  public Sprite emptyHeart;

  Rigidbody2D rb;
  Animator anim;
  Vector2 moveAmount;

  private void Start() {
    rb = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
    health = hearts.Length;
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

  void updateHealthUI(int currentHealth) {
    for (int i = 0; i < hearts.Length; i++) {
      if (i < currentHealth) {
        hearts[i].sprite = fullHeart;
        hearts[i].transform.localScale = new Vector3(1, 1, 1);
      } else {
        hearts[i].sprite = emptyHeart;
        hearts[i].transform.localScale = new Vector3(.5f, .5f, .5f);
      }
    }
  }

  public void addHealth(int healthAmount) {
    if (health >= hearts.Length) return;

    health += healthAmount;
    updateHealthUI(health);
  }

  public void takeDamage(int damageAmount) {
    health -= damageAmount;

    updateHealthUI(health);

    if (health <= 0) {
      Debug.Log("You Died :(");
      Destroy(gameObject);
    }
  }

  public void equipWeapon(Weapon weapon) {

    Destroy(GameObject.FindGameObjectWithTag("Weapon"));
    Instantiate(weapon, transform.position, transform.rotation, transform);

    // original version + multiple at once bugfix
    // foreach (var oldWeapon in GameObject.FindGameObjectsWithTag("Weapon")) {
    //   Destroy(oldWeapon);
    // }
    // Instantiate(weapon, transform.position, transform.rotation, transform);

    // my version
    // GameObject oldWeapon = GameObject.FindGameObjectWithTag("Weapon");
    // Transform oldTransform = oldWeapon.transform;
    // Instantiate(weapon, oldTransform.position, oldTransform.rotation, transform);
    // Destroy(oldWeapon);

    // throw away old weapon;
    // GameObject oldWeapon = GameObject.FindGameObjectWithTag("Weapon");
    // Transform oldTransform = oldWeapon.transform;
    // Instantiate(weapon, oldTransform.position, oldTransform.rotation, transform);
    // Pickup newPickup = Instantiate(oldWeapon.GetComponent<Weapon>().PickupObject, transform.position, transform.rotation);
    // newPickup.tag = "Weapon";

    // int jumpDirection = anim.GetBool("isRunningLeft") ? 2 : -2;
    // newPickup.gameObject.layer = 6; // dont pick up at first
    // newPickup.gameObject.transform.DOJump(transform.position + Vector3.right * jumpDirection, 2, 1, 1)
    //   .OnComplete(() => { newPickup.gameObject.layer = 0; });

    // Destroy(oldWeapon);
  }

  private void test() { }
}
