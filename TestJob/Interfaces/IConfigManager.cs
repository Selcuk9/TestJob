namespace TestJob.Interfaces;

public interface IConfigManager
{
    public string GetValueByKey(string connectionName);

    public IConfigurationSection GetConfigurationSection(string key);
    public int GetMinimumRequestTime();
}