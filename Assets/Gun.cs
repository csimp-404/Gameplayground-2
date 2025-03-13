using UnityEngine;

public class Gun : Weapon
{
    public class GunScript : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public GameObject casingPrefab;
        public Transform muzzlePoint;
        public Transform casingEjectPoint;
        public float fireRate = 0.2f;

        private Animator anim;

        private float nextFireTime = 0f;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }
        void Update()
        {
            if (Input.GetMouseButton(0) && Time.time >= nextFireTime) // Left mouse button to shoot
            {
                anim.SetTrigger("Shoot");
                nextFireTime = Time.time + fireRate;
            }
        }

        public void Fire()
        {
            Instantiate(bulletPrefab, muzzlePoint.position, muzzlePoint.rotation); // Spawn bullet
            Instantiate(casingPrefab, casingEjectPoint.position, Quaternion.identity); // Spawn casing
        }
    }
}
