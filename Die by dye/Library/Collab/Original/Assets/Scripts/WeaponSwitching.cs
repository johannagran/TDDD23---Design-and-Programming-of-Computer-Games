using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Using enable and disable of child objects instead of array, so we don't need to update lists and costum data objects.

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;
    private CompKeyboard keys;
    private CompKeyboard Hej;
    public Sprite KeyboardAllWhiteUp;
    public Sprite KeyboardOneDown;
    public Image Keyboards;

    public float timer;
    public Text TimerText;
	private bool flashActive;
	public float flashLenght;

    void Start()
    {
        SelectWeapon();
    }

    void Update()
    {
	
        int previousSelectedWeapon = selectedWeapon;

        if (timer <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                selectedWeapon = 0;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
            {
                selectedWeapon = 1;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
            {
                selectedWeapon = 2;
            }

            if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
            {
                selectedWeapon = 3;
            }
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }

		if (selectedWeapon == 4) {
            Keyboards.sprite = KeyboardAllWhiteUp;
            timer -= Time.deltaTime;
            TimerText.text = "Rainbow weapon: " + (int)timer;
            TimerText.enabled = true;

            if (flashActive) {
				if (timer > flashLenght * 1f) {  //0.66 makes two blinks
					TimerText.color = new Color (0.5f, 0f, 0f, 1f);	
				} else if (timer > 4f) {
					TimerText.color = new Color (1f, 1f, 1f, 1f);
				}
				else if (timer >  3f) {
					TimerText.color = new Color (0.5f, 0f, 0f, 1f);
				}
				else if (timer >  2f) {
					TimerText.color = new Color (1f, 1f, 1f, 1f);
				}
				else if (timer >  1f) {
					TimerText.color = new Color (0.5f, 0f, 0f, 1f);
				}
				else if(timer > 0f){
					TimerText.color = new Color (1f, 1f, 1f, 1f);	
					flashActive = false;
				}
			}

			if(timer <= 0)
			{
				previousSelectedWeapon = selectedWeapon;
				selectedWeapon = 0;
                TimerText.enabled = false;
                Keyboards.sprite = KeyboardOneDown;

                if (previousSelectedWeapon != selectedWeapon)
				{				
					SelectWeapon ();
				}
			}



		}

    }

public void rainbowWeapon()
	{
            timer = 10f;
			int previousSelectedWeapon = selectedWeapon;
			selectedWeapon = 4;
            Keyboards.sprite = KeyboardAllWhiteUp;

	
			if (previousSelectedWeapon != selectedWeapon) {				
				SelectWeapon ();
			}
		flashActive = true;
	}

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            i++;
        }
    }
}
