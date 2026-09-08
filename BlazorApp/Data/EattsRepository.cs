using BlazorApp.Common;
using BlazorApp.Models;
using EATTS.Client;
using EATTS.Common.Models;
using Midland.Core.SimpleMessageBus;
using RestEase;
using System.Security.Cryptography;

namespace BlazorApp.Data;

public class EattsRepository : BlazorClientRepositoryBase, IEattsApiRepository
{
    private readonly IEmployeeRepository _empRepo;

    public EattsRepository(HttpClient httpClient, IEventChannelBus eventBus, ClientSettings clientSettings, IEmployeeRepository empRepo)
        : base(httpClient, eventBus, clientSettings)
    {
        _empRepo = empRepo;
    }

    public async Task<PageResultsModel<EntryOccurrenceSummaryModel>> GetEntryOccurrenceDetail(EntryOccurrenceSearchCriteria criteria)
    {
        var response = await RestClient.For<IEATTSApiClient>(_httpClient)
                                        .GetEntryOccurrenceViewPaged(criteria.ToQueryString());
        var found = await ProcessResponseAsync(response);
        return found;
    }

    public async Task<ApplicationOptionsGetModel> ApplicationOptionAdd(ApplicationOptionsPostModel model)
    {
        var response = await RestClient.For<IEATTSApiClient>(_httpClient)
                                        .PostApplicationOptions(model);

        var found = await ProcessResponseAsync(response);

        return found;
    }

    public async void ApplicationOptionDelete(ApplicationOptionsGetModel model)
    {
        var response = await RestClient.For<IEATTSApiClient>(_httpClient)
                                        .DeleteApplicationOptions(model.ApplicationOptionsRef);

        await CheckForErrorsAsync(response);
    }

    public async Task<ApplicationOptionsGetModel> ApplicationOptionUpdate(ApplicationOptionsGetModel model)
    {
        var response = await RestClient.For<IEATTSApiClient>(_httpClient)
                                        .PutApplicationOptions(model.ApplicationOptionsRef, model);

        var found = await ProcessResponseAsync(response);

        return found;
    }

    public async Task<ContactModel> ContactAdd(ContactModel model)
    {
        var updated = new ContactModel(await PostSupportContact(model));
        updated.FullName = _empRepo.GetActiveSelectionUsers().Result.FirstOrDefault(r => r.UserRef == updated.UserRef)?.FullName;
        return updated;
    }

    public async void ContactDelete(ContactModel model)
    {
        await DeleteSupportContact(model.SupportDefaultContactRef);
    }

    public async Task<ContactModel> ContactUpdate(ContactModel model)
    {
        var updated = new ContactModel(await PutSupportContact(model));
        updated.FullName = _empRepo.GetActiveSelectionUsers().Result.FirstOrDefault(r => r.UserRef == updated.UserRef)?.FullName;
        return updated;
    }

    public async Task<List<EntrySummaryModel>> FindEntries(EntrySearchCriteria criteria)
    {
        IEATTSApiClient result = RestClient.For<IEATTSApiClient>(_httpClient);

        var response = await result.GetEntryViewSummaryPaged(criteria.ToQueryString());

        var x = await ProcessResponseAsync(response);

        return x?.Results?.Values().ToList();
    }

    public async Task<List<EntryOccurrenceSummaryModel>> FindOccurrences(EntryOccurrenceSearchCriteria criteria)
    {
        IEATTSApiClient result = RestClient.For<IEATTSApiClient>(_httpClient);

        var response = await RestClient.For<IEATTSApiClient>(_httpClient).GetEntryOccurrenceViewPaged(criteria.ToQueryString());

        var x = await ProcessResponseAsync(response);
        return x.Results.Values().ToList();
    }

    public async Task<List<ApplicationOptionsGetModel>> GetAllApplicationOptions()
    {
        var response = await RestClient.For<IEATTSApiClient>(_httpClient)
                                        .GetAllApplicationOptionsList();

        var found = (await ProcessResponseAsync(response)).ToList();
        found.ForEach(r => { r.ApiName = r.ApiName.ToLower().Trim(); });
        return found;
    }

    public async Task<EntryDetailModel> GetEntryDetail(int entryRef)
    {
        IEATTSApiClient result = RestClient.For<IEATTSApiClient>(_httpClient);

        var response = await result.GetEntryViewDetail(entryRef);
        return await ProcessResponseAsync(response);
    }

    public async Task<EntryOccurrenceDetailModel> GetOccurrenceDetail(int occurrenceRef)
    {
        var response = await RestClient.For<IEATTSApiClient>(_httpClient).GetEntryOccurrenceViewDetail(occurrenceRef);
        var found = await ProcessResponseAsync(response);
        return found;
    }

    public async Task<List<ContactModel>> GetSupportDefaultContactEdit()
    {
        var response = await RestClient.For<IEATTSApiClient>(_httpClient)
                                        .GetAllSupportContactList();

        var found = new List<SupportDefaultContactEditModel>();

        found = await ProcessResponseAsync(response);
        if (found != null)
        {
            var users = (await _empRepo.GetActiveSelectionUsers()).Values();
            return found.Select(r => new ContactModel(r) { FullName = users.FirstOrDefault(u => u.UserRef == r.UserRef)?.FullName }).ToList();
        }
        return new List<ContactModel>();
    }

    public async Task<List<SupportOptionsOverrideGetModel>> GetAllSupportOptionOverrideList()
    {
        var response = await RestClient.For<IEATTSApiClient>(_httpClient)
                                        .GetAllSupportOptionOverrideList();

        return await ProcessResponseAsync(response);
    }

    public async Task<SupportOptionsOverrideGetModel> GetSupportOptionOverride(int supportOptionsOverrideRef)
    {
        var response = await RestClient.For<IEATTSApiClient>(_httpClient)
                                        .GetSupportOptionOverride(supportOptionsOverrideRef);

        return await ProcessResponseAsync(response);
    }

    public async Task<SupportOptionsOverrideGetModel> PostSupportOptionOverride(SupportOptionsOverridePostModel model)
    {
        var response = await RestClient.For<IEATTSApiClient>(_httpClient)
                                        .PostSupportOptionOverride(model);

        return await ProcessResponseAsync(response);
    }

    public async Task<SupportOptionsOverrideGetModel> PutSupportOptionOverride(int supportOptionsOverrideRef, SupportOptionsOverridePostModel model)
    {
        var response = await RestClient.For<IEATTSApiClient>(_httpClient)
                                        .PutSupportOptionOverride(supportOptionsOverrideRef, model);

        return await ProcessResponseAsync(response);
    }

    public async Task DeleteSupportOptionOverride(int supportOptionsOverrideRef)
    {
        var response = await RestClient.For<IEATTSApiClient>(_httpClient)
                                        .DeleteSupportOptionOverride(supportOptionsOverrideRef);

        await CheckForErrorsAsync(response);
    }

    public async Task<SupportDefaultContactEditModel> PostSupportContact(SupportDefaultContactAddModel model)
    {
        var response = await RestClient.For<IEATTSApiClient>(_httpClient)
                                        .PostSupportContact(model);

        return await ProcessResponseAsync(response);
    }

    public async Task<SupportDefaultContactEditModel> PutSupportContact(SupportDefaultContactEditModel model)
    {
        var response = await RestClient.For<IEATTSApiClient>(_httpClient)
                                        .PutSupportContact(model);

        return await ProcessResponseAsync(response);
    }

    public async Task DeleteSupportContact(int supportDefaultContactRef)
    {
        var response = await RestClient.For<IEATTSApiClient>(_httpClient)
                                        .DeleteSupportContact(supportDefaultContactRef);

        await CheckForErrorsAsync(response);
    }

    public async Task<SupportOptionsEditModel> GetSupportOptions()

    {
        var options = await RestClient.For<IEATTSApiClient>(_httpClient)
                                        .GetSupportOption();

        return await ProcessResponseAsync(options);
    }

    public async Task<SupportOptionsEditModel> UpdateSupportOptions(SupportOptionsEditModel model)

    {
        var options = await RestClient.For<IEATTSApiClient>(_httpClient)
                                        .PutSupportOption(model);

        return await ProcessResponseAsync(options);
    }

    public async Task<EattsEntryResultModel> PostLog(EattsEntryModel eattsEntryModel)
    {
        var response = await RestClient.For<IEATTSApiClient>(_httpClient)
                                        .PostLog(eattsEntryModel);

        var found = await ProcessResponseAsync(response);

        return found;
    }

    
}