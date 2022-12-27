using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

[Serializable]

public class _Data_
{
    public int record_score;
    public float music_value, effects_value;
}

public class SettingsKeeper : MonoBehaviour
{
    public float music_value, effects_value;
    public int record_score;

    public AudioSource music, effects;
    public Slider music_slider, effects_slider;
    public Text record_value;

    // Start is called before the first frame update
    void Start()
    {
        if (LoadData() == 1)
        {
            InitComponents();
            SetMusicVolume();
            SetEffectsVolume();
        }
        else
        {
            ResetData();
            SetDefaultValues();
            SaveData();

            InitComponents();
            SetMusicVolume();
            SetEffectsVolume();
        }
    }

    public void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
          + "/progress.dat");
        _Data_ data = new _Data_();

        data.record_score = record_score;
        data.music_value = music_value;
        data.effects_value = effects_value;

        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game progress saved!");
    }

    public int LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/progress.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
              File.Open(Application.persistentDataPath
              + "/progress.dat", FileMode.Open);

            _Data_ data = (_Data_)bf.Deserialize(file);
            file.Close();

            record_score = data.record_score;
            music_value = data.music_value;
            effects_value = data.effects_value;

            //Debug.Log(record_score);

            Debug.Log("Game data loaded!");
            return 1;
        }
        else
        {
            Debug.LogError("There is no save progress!");
            return 0;
        }
    }
    public void ResetData()
    {
        if (File.Exists(Application.persistentDataPath
          + "/save.dat"))
        {
            File.Delete(Application.persistentDataPath
              + "/save.dat");

            Debug.Log("Data reset complete!");
        }
        else
            Debug.LogError("No save data to delete.");
    }

    void SetDefaultValues()
    {
        record_score = 0;
        music_value = 0.5f;
        effects_value = 0.5f;
    }

    void InitComponents()
    {
        music.volume = music_value;
        music_slider.value = music_value;

        effects.volume = effects_value;
        effects_slider.value = effects_value;

        record_value.text = record_score.ToString();
    }

    public void SetMusicVolume()
    {
        music_value = music_slider.value;
        SaveData();
        music.volume = music_value;
    }

    public void SetEffectsVolume()
    {
        effects_value = effects_slider.value;
        SaveData();
        effects.volume = effects_value;
    }
}
