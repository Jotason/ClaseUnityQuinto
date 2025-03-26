using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[SerializeField]
public class AdministradorDatos : MonoBehaviour
{
    [SerializeField] DatosJuego infoJuego;

    string nombreDeArchivo;




    private void Start()
    {

        nombreDeArchivo = Application.persistentDataPath + "/DatosJuego";
        //GuardarDatos();
        CargarDatos();

    }


    public void GuardarDatos() { 
    
        

        Debug.Log(nombreDeArchivo);
        string json = JsonUtility.ToJson(infoJuego);



        //Debug.Log(File.Exists(nombreDeArchivo));

        if (File.Exists(nombreDeArchivo) == false)
        {
            //Codigo si no existe el archivo

            //Crea un archivo de texto en una ubicación predefinida según el dispositivo 

            File.CreateText(nombreDeArchivo).Close();
        }

        File.WriteAllText(nombreDeArchivo, json );

    }


    private void CargarDatos() {

        string json = File.ReadAllText(nombreDeArchivo);
        Debug.Log(json);

        infoJuego = JsonUtility.FromJson<DatosJuego>(json);

    }

    


}
