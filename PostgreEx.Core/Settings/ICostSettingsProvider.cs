namespace PostgreEx.Core.Settings;

public interface ICostSettingsProvider
{
    Task<ICostSettings> GetSettings();
}