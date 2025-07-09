using System.IO;
using UnityEngine;

// IMPORTANTE: Asegúrate de que tu clase DatosJuego tenga esta etiqueta [System.Serializable]
// Ejemplo:
// [System.Serializable]
// public class DatosJuego {
//     public int puntuacion;
//     public string nombreJugador;
// }

public class AdministradorDatos : MonoBehaviour
{
    [SerializeField]
    private DatosJuego infoJuego;

    private string rutaDelArchivo;

    private void Awake()
    {
        // 1. CONSTRUYE LA RUTA DE FORMA SEGURA
        // Path.Combine es la forma correcta de unir rutas de carpetas y archivos.
        // También se añade la extensión .json para mayor claridad.
        rutaDelArchivo = Path.Combine(Application.persistentDataPath, "datosJuego.json");
        Debug.Log("Ruta de guardado: " + rutaDelArchivo);
    }

    private void Start()
    {
        // Carga los datos al iniciar el juego.
        CargarDatos();
    }

    public void GuardarDatos()
    {
        try
        {
            // 2. SIMPLIFICACIÓN DEL GUARDADO
            // Convierte el objeto a JSON. El 'true' lo formatea para que sea legible.
            string json = JsonUtility.ToJson(infoJuego, true);

            // File.WriteAllText crea el archivo si no existe, y lo sobrescribe si ya existe.
            // No necesitas comprobar si existe ni crearlo manualmente.
            File.WriteAllText(rutaDelArchivo, json);

            Debug.Log("Datos guardados exitosamente.");
        }
        catch (System.Exception e)
        {
            // Se añade un bloque try-catch para capturar cualquier error al guardar.
            Debug.LogError($"Error al guardar datos en {rutaDelArchivo}: {e.Message}");
        }
    }

    public void CargarDatos()
    {
        // 3. CARGA SEGURA
        // Primero, comprueba si el archivo existe antes de intentar leerlo.
        if (File.Exists(rutaDelArchivo))
        {
            try
            {
                string json = File.ReadAllText(rutaDelArchivo);

                // FromJsonOverwrite actualiza el objeto 'infoJuego' existente
                // en lugar de crear uno nuevo. Es más eficiente.
                JsonUtility.FromJsonOverwrite(json, infoJuego);
                Debug.Log("Datos cargados exitosamente.");
            }
            catch (System.Exception e)
            {
                Debug.LogError($"Error al cargar datos desde {rutaDelArchivo}: {e.Message}");
                // Opcional: Si el archivo está corrupto, puedes cargar valores por defecto.
                // infoJuego = new DatosJuego(); 
            }
        }
        else
        {
            Debug.LogWarning("No se encontró archivo de guardado. Se usarán los valores por defecto.");
            // Si quieres, puedes crear un archivo inicial la primera vez que se juega.
            // GuardarDatos();
        }
    }
}