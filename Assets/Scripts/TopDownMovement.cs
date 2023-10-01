using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopDownMovement : MonoBehaviour
{
    
	public float walkSpeed = 5f;
	public Boundary boundary; // optional rectangle boundary

	float maxSpeed = 10f;
	float curSpeed;

	float sprintSpeed;
	Rigidbody _rb;

    public Camera mainCamera;
	public GameObject aimDirection;

	[SerializeField] private LayerMask groundMask;
	[SerializeField] private float maxHoriSpeed = 2f;
    [SerializeField] private float maxVertSpeed = 2f;

    public Vector3 _input;

	public GameObject GunPoint;
	public GameObject BulletPrefab;

	public float bulletCount = 1;
	public float maxBulletCount = 3;
	public bool bMaxBullet;
	public GameObject captureHitBox;

	public Text BulletCounterUI;
 
	void Start() {
		_rb = GetComponent<Rigidbody>();
		// sprintSpeed = walkSpeed + (walkSpeed / 2);
	}

	private void Update()
	{
		Aim();

		if (Input.GetMouseButtonDown(0))
        {
			Shoot();
        }

		curSpeed = walkSpeed;
		maxSpeed = curSpeed;

        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

		BulletCounterUI.text = bulletCount.ToString();

		if (bulletCount >= maxBulletCount)
		{
			bMaxBullet = true;
			captureHitBox.SetActive(false);
		} else {
			bMaxBullet = false;
			captureHitBox.SetActive(true);
		}
	}
 
	void FixedUpdate() {
        Move();

        _rb.AddForce((transform.forward * _input.z + transform.right * _input.x).normalized * curSpeed - _rb.velocity, ForceMode.Force);
		// _rb.AddForce(_input.normalized * curSpeed - _rb.velocity, ForceMode.Force);
    
    	// optional: clamp position inside a rectangle
		// _rb.position = new Vector3(
		// 	Mathf.Clamp(_rb.position.x, boundary.xMin, boundary.xMax),
		// 	_rb.position.y,
		// 	Mathf.Clamp(_rb.position.z, boundary.zMin, boundary.zMax)
		// );
	}

	private void Aim()
	{
		var (success, position) = GetMousePosition();
		if (success)
		{
			// Calculate the direction
			var direction = position - aimDirection.transform.position;

			// You might want to delete this line.
			// Ignore the height difference.
			direction.y = 0;

			// Make the transform look in the direction.
			aimDirection.transform.forward = direction;
		}
	}

	private void Shoot()
	{
		if (bulletCount == 0) return;
		GameObject bullet = ObjectPool.SharedInstance.GetPooledObject(ObjectPool.SharedInstance.bulletObjects); 
		if (bullet != null) {
			bullet.transform.position = GunPoint.transform.position;
			bullet.transform.rotation = aimDirection.transform.rotation;
			bullet.SetActive(true);
		}
		// var bullet = Instantiate(BulletPrefab, GunPoint.transform.position, aimDirection.transform.rotation);
		bullet.GetComponent<BulletMovement>().shootBullet();
		bullet.GetComponent<BulletMovement>().OnBulletEnabled();
		bulletCount--;
	}

	private void Move() {
        // if (groundDetector)
        // {
        //     if (_input == Vector3.zero && !bIsJumping && groundDetector.GetComponent<GroundDetector>().bIsGrounded) 
        //     {
        //         _rb.velocity = _rb.velocity * (retainSpeedPercentage / 100);
        //     }
        // }

        SetMaxVelocity();

        _rb.AddForce((transform.forward * _input.z + transform.right * _input.x).normalized * curSpeed - _rb.velocity, ForceMode.Force);
        // _rb.MovePosition(transform.position + (transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal")) * _speed * Time.deltaTime);
    }

	void SetMaxVelocity()
    {
        Vector3 xzVel = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
        Vector3 yVel = new Vector3(0, _rb.velocity.y, 0);

        xzVel = Vector3.ClampMagnitude(xzVel, maxHoriSpeed);
        yVel = Vector3.ClampMagnitude(yVel, maxVertSpeed);

        _rb.velocity = xzVel + yVel;
    }

	private (bool success, Vector3 position) GetMousePosition()
	{
		var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
		{
			// The Raycast hit something, return with the position.
			return (success: true, position: hitInfo.point);
		}
		else
		{
			// The Raycast did not hit anything.
			return (success: false, position: Vector3.zero);
		}
	}

}

// optional rectangle boundary
[System.Serializable]
public struct Boundary {
	public float xMin;
	public float xMax;
	public float zMin;
	public float zMax;
}