using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio; //Работа с аудио

public class Script : MonoBehaviour
{

public AudioMixer audioMixer; //Регулятор громкости
  
//Функция, которая запускает сцену с новой игрой
    public void GameButton()
        {
            SceneManager.LoadScene("Game1");
            Debug.Log("Game!");
        }

//Функция, которая запускает сцену с магазином
    public void ShopButton()
        {
            SceneManager.LoadScene("Shop");
            Debug.Log("Shop");
        }

//Функция, которая запускает сцену с настройками
    public void SettingsButton()
        {
            SceneManager.LoadScene("Settings");
            Debug.Log("Settings");
        }    

//Функция, которая запускает сцену с главным меню
    public void MenuButton()
        {
            audioMixer.SetFloat("MyExposedParam", 0);
            SceneManager.LoadScene("Menu");
            Debug.Log("Menu");
        }  

        public void MenuButton1()
        {
            SceneManager.LoadScene("Menu");
            Debug.Log("Menu");
        }       
//Функция, которая закрывает приложение
    public void ExitButton()
        {
            Application.Quit();
            Debug.Log("Exit!");
        }

public void AudioVolume(float sliderValue)
    {
        //Метод SetFloat принимает значенияслайдера и присваивает это значение параметру “masterVolume”.
        audioMixer.SetFloat("MyExposedParam", sliderValue);
        Debug.Log(sliderValue);
    }

//Функция для сохранения измененных настроек
public void SaveSettings()
{
    SceneManager.LoadScene("Menu");
  
}
   /* public AudioMixer am; //ссылка на AudioMixer

    public void AudioVolume(float sliderValue)
    {
        //Метод SetFloat принимает значенияслайдера и присваивает это значение параметру “masterVolume”.
        am.SetFloat("masterVolume", sliderValue);
    }*/
}
