using SettingsAggregator.Graphics;
using SettingsAggregator.Implementation;
using SettingsAggregator.Implementation.View;
using UnityEngine;

public class WidgetGameSettings : MonoBehaviour
{
    [SerializeField] private WidgetQualityLevel widgetGraphicWidgetQuality;
    [SerializeField] private WidgetScreenResolutions widgetScreenResolution;
    [SerializeField] private WidgetScreenModeToggle widgetScreenMode;

    public void Setup(GameSettings gameSettings)
    {
        var graphicSettings = gameSettings.GetSettingsElement<GraphicsSettings>();
        
        widgetGraphicWidgetQuality.Setup(graphicSettings.GetSettingsElement<GraphicsQualityLevel>());
        widgetScreenResolution.Setup(graphicSettings.GetSettingsElement<ResolutionSettings>());
        widgetScreenMode.Setup(graphicSettings.GetSettingsElement<ScreenMode>());
    }
}
