using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 8.0f;
    [SerializeField]
    private float runningMultiplier = 1.8f;
    [SerializeField]
    private float slowWalkMultiplier = 0.4f;

    protected void Sneak(bool isAiming)
    {
        // Sneak animation
        Move(speed * slowWalkMultiplier, isAiming);
    }
    protected void AimingWalk()
    {
        // Aiming walk animation
        Move(speed * slowWalkMultiplier, true);
    }
    protected void Run()
    {
        // Run animation
        Move(speed * runningMultiplier, false);
    }
    protected void Walk()
    {
        // Walk animation
        Move(speed, false);
    }

    private void Move(float speed, bool isAiming)
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement.normalized * speed * Time.deltaTime, Space.World);

        if (!isAiming && (moveHorizontal != 0f || moveVertical != 0f))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movement), 0.3f);
        }
    }
}
