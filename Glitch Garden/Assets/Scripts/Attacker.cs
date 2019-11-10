using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour

{
    [Range(0f,5f)] float currentSpeed = 1f;
    GameObject currentTarget;

    private void Awake()
    {
        LevelController lvlController = FindObjectOfType<LevelController>();
        if(lvlController != null)
        {
            lvlController.AttackerKilled();
        }


    }
   private void OnDestroy()
    {
        FindObjectOfType<LevelController>().AttackerKilled();
    }
  // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }
    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }
    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }
  public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);

        }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
    }
}
