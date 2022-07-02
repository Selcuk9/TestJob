using TestJob.Interfaces;

namespace TestJob.Services;

public class ConfigManager : IConfigManager
{
    private readonly IConfiguration _configuration;

    public ConfigManager(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetValueByKey(string connectionName)
    {
        return _configuration[connectionName];
    }

    public IConfigurationSection GetConfigurationSection(string key)
    {
        return _configuration.GetSection(key);
    }

    public int GetMinimumRequestTime()
    {
        var minRequestTime = _configuration["Configuration:MinimumRequestTime"];
        return Convert.ToInt32(minRequestTime);
    } 
}