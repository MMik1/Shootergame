using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Camera cam;
    public GameObject muzzleFlashPrefab;
    public int maxAmmo = 10;
    public int reserveAmmo = 50;
    public AudioSource reloadSound;

    private int currentAmmo;
    private bool isReloading = false;

    private RaycastHit hit;
    private Ray ray;

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        if (isReloading)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) && currentAmmo > 0)
        {
            Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo && reserveAmmo > 0)
        {
            StartCoroutine(Reload());
        }
    }

    void Shoot()
    {
        if (currentAmmo > 0)
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    Destroy(hit.collider.gameObject);
                    Debug.Log("Tymon = mijn poekiebeeertje");

                    Instantiate(muzzleFlashPrefab, hit.point, Quaternion.identity);

                    currentAmmo--;
                }
            }
        }
        else
        {
            Debug.Log("Out of ammo!");
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        if (reloadSound != null)
        {
            reloadSound.Play();
        }
        else
        {
            Debug.LogWarning("Reload sound not assigned!");
        }

        yield return new WaitForSeconds(2f);

        
        int ammoToFill = Mathf.Min(maxAmmo - currentAmmo, reserveAmmo);
        currentAmmo += ammoToFill;
        reserveAmmo -= ammoToFill;

        isReloading = false;
    }
}
