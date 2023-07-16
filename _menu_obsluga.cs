using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _menu_obsluga : MonoBehaviour
{
    public GameObject menu_gameobject;
    public Slider _dzwiek_slaider;
    
    public GameObject @car;
    public Vector3 startPosition ;
    public Quaternion startRotation ;
    public Vector3 rota;
    public Toggle toggle;




    void Start()
    {
        Aktywuj_menu(false);
        _dzwiek_slaider.value = AudioListener.volume;
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
        startPosition = new Vector3(299, 2, 155);
        rota = new Vector3(0, 270, 0);
        startRotation = Quaternion.Euler(rota);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Aktywuj_menu(!menu_gameobject.activeInHierarchy);

    }

    public void Aktywuj_menu(bool _b)
    {
        menu_gameobject.SetActive(_b);
        if(_b)Cursor.lockState = CursorLockMode.None;
         else Cursor.lockState = CursorLockMode.Locked;
    }

    public void Wyjdz()
    {
        Application.Quit();
    }

    public void Zmien_pelny_ekran(bool _b)
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
    public void Dzwiek_wlacz(bool _b)
    {
        AudioListener.pause = !_b;

    }
    public void Zmien_glosnosc(float _f)
    {
        AudioListener.volume=_f;
    }
    public void Restart()
    {
        car.transform.position = startPosition;
        car.transform.rotation = startRotation;
        CarTimer.startTime = Time.time;
        PrometeoCarController.carSpeed = 0;
        Update();


    }

    public void OnToggleValueChanged(bool isOn)
    {
        isOn = true;
        if (isOn)
        {

            startPosition = new Vector3(299, 2, 155);
            rota = new Vector3(0, 270, 0);
            startRotation = Quaternion.Euler(rota);

            


         }
        else
        {
            startPosition = new Vector3(341, 3, 514);
            startRotation = Quaternion.Euler(rota);


        }
    }
}


