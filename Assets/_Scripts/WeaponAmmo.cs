using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponAmmo : MonoBehaviour
{
    public int clipSize;
    public int extraAmmo;
    public int currentAmmo;
    public AudioClip magInSound;
    public AudioClip magOutSound;
    public AudioClip releaseSlideSound;
    [SerializeField] public Text currentAmmoText;
    [SerializeField] public Text extraAmmoText;
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = clipSize;
        UpdateAmmountUI();
    }
    void Update()
    {
        UpdateAmmountUI();
    }

    public void Reload()
    {
        if (extraAmmo >= clipSize)
        {
            int ammoToReload = clipSize - currentAmmo;
            extraAmmo -= ammoToReload;
            currentAmmo += ammoToReload;
        }
        else if (extraAmmo > 0)
        {
            if (extraAmmo + currentAmmo > clipSize)
            {
                int leftOverAmmo = extraAmmo + currentAmmo - clipSize;
                extraAmmo = leftOverAmmo;
                currentAmmo = clipSize;
            }
            else
            {
                currentAmmo += extraAmmo;
                extraAmmo = 0;
            }
        }
    }

    private void UpdateAmmountUI()
    {
        currentAmmoText.text = currentAmmo.ToString();
        extraAmmoText.text = extraAmmo.ToString();
    }
}
