using System;
using Microsoft.AspNetCore.Components;

public class UserContextService
{
    private readonly ILogger<UserContextService> _logger;
    private string _userId;

    public UserContextService(ILogger<UserContextService> logger)
    {
        _logger = logger;
    }

    public string UserId
    {
        get => _userId;
        set
        {
            if (_userId == value) return;
            _logger.LogInformation($"UserId changing from {_userId} to {value}");
            _userId = value;
            NotifyStateChanged();
        }
    }

    public event Action OnChange;

    private void NotifyStateChanged()
    {
        _logger.LogInformation($"UserId changed to {_userId}. Notifying subscribers.");
        OnChange?.Invoke();
    }
}
