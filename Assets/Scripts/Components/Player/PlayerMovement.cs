using UnityEngine;

public class PlayerMovement : CharacterMovement
{
    private Camera mainCamera;

    [SerializeField]
    private LayerMask _floorLayer = 8;
    [SerializeField]
    private float _raycastDistance = 10000f;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {   // Arrumar Left Shift para ser um botão personalizável
        bool isAiming = Input.GetKey(KeyCode.Mouse1);
        bool isSneaking = Input.GetKey(KeyCode.LeftControl);
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        if (isAiming)
        {
            RotateTowardsMouse();

            if (isSneaking)
            {
                Sneak(isAiming);
            }
            else
            {
                AimingWalk();
            }
        }
        else if (isSneaking)
        {
            Sneak(isAiming);
        }
        else if (isRunning)
        {
            Run();
        }
        else
        {
            Walk();
        }
    }

    private void RotateTowardsMouse()
    {
        Ray camRay = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(camRay, out RaycastHit floorHit, _raycastDistance, _floorLayer))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;

            playerToMouse.y = 0f;

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(playerToMouse), 0.3f);
        }
    }

    /*    #region Data

        private Camera mainCamera;

        [SerializeField]
        private LayerMask _floorLayer = 8;
        [SerializeField]
        private float _raycastDistance = 10000f;

        [SerializeField]
        private float speed = 8.0f;
        [SerializeField]
        private float runningMultiplier = 1.8f;
        [SerializeField]
        private float slowWalkMultiplier = 0.4f;

        #endregion

        #region  Logical

        private void Awake()
        {
            mainCamera = Camera.main;
        }

        void Update()
        {   // Arrumar Left Shift para ser um botão personalizável
            bool isAiming = Input.GetKey(KeyCode.Mouse1);
            bool isSneaking = Input.GetKey(KeyCode.LeftControl);
            bool isRunning = Input.GetKey(KeyCode.LeftShift);

            if (isAiming)
            {
                RotateTowardsMouse();

                if (isSneaking)
                {
                    Sneak(isAiming);
                }
                else
                {
                    AimingWalk();
                }
            }
            else if (isSneaking)
            {
                Sneak(isAiming);
            }
            else if (isRunning)
            {   
                Run();
            }
            else
            {
                Walk();
            }
        }

        private void RotateTowardsMouse()
        {
            Ray camRay = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(camRay, out RaycastHit floorHit, _raycastDistance, _floorLayer))
            {
                Vector3 playerToMouse = floorHit.point - transform.position;

                playerToMouse.y = 0f;

                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(playerToMouse), 0.3f);
            }
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

        #endregion

        #region Animated

        private void Sneak(bool isAiming)
        {
            // Sneak animation
            Move(speed * slowWalkMultiplier, isAiming);
        }

        private void AimingWalk()
        {
            // Aiming walk animation
            Move(speed * slowWalkMultiplier, true);
        }

        private void Run()
        {
            // Run animation
            Move(speed * runningMultiplier, false);
        }

        private void Walk()
        {
            // Walk animation
            Move(speed, false);
        }

        #endregion
        */
}
