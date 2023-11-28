using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange = 2f;
    public int damage = 10;
    public float attackCooldown = 2f;

    private bool canAttack = true;

    void Update()
    {
        // Assuming the player has a tag "Player". Adjust accordingly.
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

            if (distanceToPlayer < attackRange && canAttack)
            {
                // Perform the attack
                AttackPlayer();

                // Start cooldown
                StartCoroutine(AttackCooldown());
            }
        }
    }

    void AttackPlayer()
    {
        // TODO: Implement logic for attacking the player, such as dealing damage.
        // For example, you might have a PlayerHealth script on the player object.

        // Assuming the player has a script named PlayerHealth.
        PlayerHealth playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }

    System.Collections.IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
