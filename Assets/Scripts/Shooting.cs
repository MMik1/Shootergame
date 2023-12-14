using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Shooting : MonoBehaviour
{
    public Camera cam;
    public int maxAmmo = 10;
    public int reserveAmmo = 50;
    public AudioSource reloadSound;
    public AudioSource shootSound;
    public GameObject muzzleFlashPrefab;
    public Transform muzzleFlashPosition;
    public TextMeshProUGUI killCountText;
    public TextMeshProUGUI ammoText; // Add this line for ammo display
    public TextMeshProUGUI reserveAmmoText; // Add this line for reserve ammo display
    public Animator animator;

    private int currentAmmo;
    private bool isReloading = false;
    private bool isMuzzleFlashActive = false;
    private RaycastHit hit;
    public int damagePerShot = 10;
    public int killCountToWin = 10;
    private int killCount = 0;
    private void Start()
    {
        currentAmmo = maxAmmo;

        // Ensure that you have assigned the TextMeshProUGUI components to these variables in the Unity Editor
        if (killCountText == null || ammoText == null || reserveAmmoText == null)
        {
            Debug.LogError("Text elements are not assigned!");
        }
    }

    private void Update()
    {
        if (isReloading)
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo && reserveAmmo > 0)
        {
            StartCoroutine(Reload());
        }

        // Update ammo and reserve ammo text
        UpdateAmmoText();
        UpdateReserveAmmoText();
    }

    private void Shoot()
    {
        if (!isMuzzleFlashActive && currentAmmo > 0)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            GameObject muzzleFlash = Instantiate(muzzleFlashPrefab, muzzleFlashPosition.position, muzzleFlashPosition.rotation);
            Destroy(muzzleFlash, 0.1f);

            isMuzzleFlashActive = true;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    Destroy(hit.collider.gameObject);
                    killCount++;

                    // Update the kill count text
                    UpdateKillCountText();
                }
                else
                {
                    // Debug.Log for a miss
                    Debug.Log("Missed the shot!");
                }
            }

            currentAmmo--;

            if (currentAmmo <= 0)
            {
                Debug.Log("Out of ammo!");
            }

            if (shootSound != null)
            {
                shootSound.Play();
                Debug.Log("Shooting sound played.");
            }
            else
            {
                Debug.LogWarning("shootSound is null. Check the AudioSource component.");
            }

            StartCoroutine(ResetMuzzleFlash());
        }
        else if (currentAmmo <= 0)
        {
            Debug.Log("Out of ammo!");
        }
    }

    private IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        animator.SetBool("Reloading", true);

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
        animator.SetBool("Reloading", false);
    }

    private IEnumerator ResetMuzzleFlash()
    {
        yield return new WaitForSeconds(0.1f);
        isMuzzleFlashActive = false;
    }

    private void UpdateKillCountText()
    {
        // Update the TextMeshProUGUI element with the current kill count
        if (killCountText != null)
        {
            killCountText.text = "" + killCount;
        }
    }

    private void UpdateAmmoText()
    {
        // Update the TextMeshProUGUI element with the current ammo count
        if (ammoText != null)
        {
            ammoText.text = "" + currentAmmo;
        }
    }

    private void UpdateReserveAmmoText()
    {
        // Update the TextMeshProUGUI element with the current reserve ammo count
        if (reserveAmmoText != null)
        {
            reserveAmmoText.text = "" + reserveAmmo;
        }
    }
}
