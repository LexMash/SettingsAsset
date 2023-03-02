using System;
using SettingsAggregator;
using SettingsAggregator.Graphics;
using SettingsAggregator.Implementation;
using UnityEngine;
using GameSettingsData = SettingsAggregator.Examples.GameSettingsData;

public class SettingsExample : MonoBehaviour
{
    [SerializeField] private string prefsKey = "Settings";
    [SerializeField] private WidgetGameSettings widgetGameSettings;

    private GameSettings gameSettings;
    private GameSettingsData cachedGameSettingsData;
    
    private void Start()
    {
        Load();
        
        widgetGameSettings.Setup(gameSettings);
    }

    private void OnDestroy()
    {
        Save();
    }

    private void Save()
    {
        var json = JsonUtility.ToJson(cachedGameSettingsData);
        
        PlayerPrefs.SetString(prefsKey, json);
        
        Debug.Log($"Settings saved. JSON: {json}");
    }

    private void Load()
    {
        var json = PlayerPrefs.GetString(prefsKey);
        Debug.Log($"Settings loaded. JSON: {json}");

        cachedGameSettingsData = JsonUtility.FromJson<GameSettingsData>(json);

        if (cachedGameSettingsData == null)
        {
            cachedGameSettingsData = GameSettingsData.Default;
            Debug.Log($"JSON is empty. Loaded default settings");
        }
        
        var graphicsQuality = new GraphicsQualityLevel(cachedGameSettingsData.GraphicsQualityLevelData);
        var resolutionSetting = new ResolutionSettings(cachedGameSettingsData.ScreenSettingsData);
        var fullScreenSetting = new ScreenMode(cachedGameSettingsData.ScreenSettingsData);
        var graphicSettings = new GraphicsSettings(graphicsQuality, resolutionSetting, fullScreenSetting);
            
        gameSettings = new GameSettings(graphicSettings);
    }
}
