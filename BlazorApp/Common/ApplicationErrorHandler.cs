using BlazorApp.Data;
using EATTS.Client;
using Midland.Core.Client;
using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;

namespace BlazorApp.Common;

public class ApplicationErrorHandler : ISubscriber
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IEattsApiRepository _eattsRepository;
    private readonly ClientSettings _clientSettings;

    public ApplicationErrorHandler(IEventChannelBus eventBus, IEmployeeRepository employeeRepository, IEattsApiRepository eattsRepository, ClientSettings clientSettings)
    {
        _employeeRepository = employeeRepository;
        _eattsRepository = eattsRepository;
        _clientSettings = clientSettings;
        eventBus.Subscribe(new ApplicationErrorEvent(), this);
    }

    public void ChannelNotification<T>(IChannelEvent<T> Evt)
    {
        if (Evt is ApplicationErrorEvent applicationErrorEvent)
        {
            Handle(applicationErrorEvent).GetAwaiter().GetResult();
        }
    }

    public async Task ChannelNotificationAsync<T>(IChannelEvent<T> Evt)
    {
        if (Evt is ApplicationErrorEvent applicationErrorEvent)
        {
            await Handle(applicationErrorEvent);
        }
    }

    public async Task Handle(ApplicationErrorEvent channelEvent)
    {
        if (channelEvent.Value is ErrorResponse errorResponse)
        {
            errorResponse.Code = ErrorCodes.ApplicationUnhandledException;
            var code = await _eattsRepository.PostLog(new EattsEntryModel(null, _clientSettings.ApplicationName, MakeEntryKey(), _employeeRepository.CurrentUser.Result.UserRef, "", errorResponse));
            errorResponse.Description = $"Application Unhandled Error and has been reported with Occurrence Id {code.OccurrenceRef}.";
        }

        return;
    }

    private string MakeEntryKey()
    {
        return $"Application unhandled error {_clientSettings.ApplicationName}";
    }

    public int NotificationOrder()
    {
        return 0;
    }
}