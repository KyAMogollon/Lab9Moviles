using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGlobalAdditive : MonoBehaviour
{
    private void Awake()
    {
       
    }
    public void EscenaCargaContinue(SceneAsset scene)
    {
        Invoke("EscenaDescargaContinue", 0.1f);
        SceneManager.LoadSceneAsync(scene.name, LoadSceneMode.Additive);
    }
    public void EscenaDescargaContinue()
    {
        Debug.Log("Entro a descarga");
        SceneManager.UnloadSceneAsync("Inicio");
    }
    public void EscenaCargaPlay(SceneAsset scene)
    {
        Invoke("EscenaDescargaPlay", 0.1f);
        SceneManager.LoadSceneAsync(scene.name, LoadSceneMode.Additive);
    }
    public void EscenaDescargaPlay()
    {
        SceneManager.UnloadSceneAsync("Menu");
    }
    public void EscenaCargaResultados(SceneAsset scene)
    {
        Invoke("EscenaDescargaPlay", 0.1f);
        SceneManager.LoadSceneAsync(scene.name,LoadSceneMode.Additive);
    }
    public void EscenaCargaResultadosGame(SceneAsset scene)
    {
        Invoke("EscenaDescargaGame", 0.1f);
        Debug.Log("LE DI AL BOTON CORRECTO");
        SceneManager.LoadSceneAsync(scene.name, LoadSceneMode.Additive);
    }
    public void EscenaDescargaGame()
    {
        Debug.Log("Entre a RESULTADOS");
        SceneManager.UnloadSceneAsync("Game");
    }
    private void ReferenciaDeObjetoPrincipal(SceneAsset scene, bool active)
    {
        GameObject tmp = GameObject.Find(scene.name);
        tmp.SetActive(active);
    }
    public void Leave()
    {
        Application.Quit();
    }
}
