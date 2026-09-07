using BlazorApp.Common;
using BlazorApp.Models;
using EATTS.Client;
using EATTS.Common.Models;
using Midland.Core.SimpleMessageBus;
using RestEase;

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
        var found = await ProcessResponse(response);
        return found;
    }

    public async Task<ApplicationOptionsGetModel> ApplicationOptionAdd(ApplicationOptionsPostModel model)
    {
        var response = await RestClient.For<IEATTSApiClient>(_httpClient)
                                        .PostApplicationOptions(model);

        var found = await ProcessResponse(response);

        return found;
    }

    public async void ApplicationOptionDelete(ApplicationOptionsGetModel model)
    {
        var response = await RestClient.For<IEATTSApiClient>(_httpClient)
                                        .DeleteApplicationOptions(model.ApplicationOptionsRef);

        await CheckForErrors(response);
    }

    public async Task<ApplicationOptionsGetModel> ApplicationOptionUpdate(ApplicationOptionsGetModel model)
    {
        var response = await RestClient.For<IEATTSApiClient>(_httpClient)
                                        .PutApplicationOptions(model.ApplicationOptionsRef, model);

        var found = await ProcessResponse(response);

        return found;
    }

    public async Task<ContactModel> ContactAdd(ContactModel model)
    {
        var response = await RestClient.For<IEATTSApiClient>(_httpClient)
                                       .PostSupportContact(model);

        var updated = new ContactModel(await ProcessResponse(response));

        updated.FullName = _empRepo.GetActiveSelectionUsers().Result.FirstOrDefault(r => r.UserRef == updated.UserRef)?.FullName;
        return updated;
    }

    public async void ContactDelete(ContactModel model)
    {
        var response = await RestClient.For<IEATTSApiClient>(_httpClient)
                           .DeleteSupportContact(model.SupportDefaultContactRef);

        await CheckForErrors(response);
    }

    public async Task<ContactModel> ContactUpdate(ContactModel model)
    {
        var response = await RestClient.For<IEATTSApiClient>(_httpClient)
                                       .PutSupportContact(model);

        var updated = new ContactModel(await ProcessResponse(response));

        updated.FullName = _empRepo.GetActiveSelectionUsers().Result.FirstOrDefault(r => r.UserRef == updated.UserRef)?.FullName;
        return updated;
    }

    public async Task<List<EntrySummaryModel>> FindEntries(EntrySearchCriteria criteria)
    {
        IEATTSApiClient result = RestClient.For<IEATTSApiClient>(_httpClient);

        var response = await result.GetEntryViewSummaryPaged(criteria.ToQueryString());

        var x = await ProcessResponse(response);

        return x?.Results?.Values().ToList();
    }

    public async Task<List<EntryOccurrenceSummaryModel>> FindOccurrences(EntryOccurrenceSearchCriteria criteria)
    {
        IEATTSApiClient result = RestClient.For<IEATTSApiClient>(_httpClient);

        var response = await RestClient.For<IEATTSApiClient>(_httpClient).GetEntryOccurrenceViewPaged(criteria.ToQueryString());

        var x = await ProcessResponse(response);
        return x.Results.Values().ToList();
    }

    public async Task<List<ApplicationOptionsGetModel>> GetAllApplicationOptions()
    {
        var response = await RestClient.For<IEATTSApiClient>(_httpClient)
                                        .GetAllApplicationOptionsList();

        var found = (await ProcessResponse(response)).ToList();
        found.ForEach(r => { r.ApiName = r.ApiName.ToLower().Trim(); });
        return found;
    }

    public async Task<EntryDetailModel> GetEntryDetail(int entryRef)
    {
        IEATTSApiClient result = RestClient.For<IEATTSApiClient>(_httpClient);

        var response = await result.GetEntryViewDetail(entryRef);
        return await ProcessResponse(response);
    }

    public async Task<EntryOccurrenceDetailModel> GetOccurrenceDetail(int occurrenceRef)
    {
        var response = await RestClient.For<IEATTSApiClient>(_httpClient).GetEntryOccurrenceViewDetail(occurrenceRef);
        var found = await ProcessResponse(response);
        return found;
    }

    public async Task<List<ContactModel>> GetSupportDefaultContactEdit()
    {
        var response = await RestClient.For<IEATTSApiClient>(_httpClient)
                                        .GetAllSupportContactList();

        var found = new List<SupportDefaultContactEditModel>();

        found = await ProcessResponse(response);
        if (found != null)
        {
            var users = (await _empRepo.GetActiveSelectionUsers()).Values();
            return found.Select(r => new ContactModel(r) { FullName = users.FirstOrDefault(u => u.UserRef == r.UserRef)?.FullName }).ToList();
        }
        return new List<ContactModel>();
    }

    public async Task<EattsEntryResultModel> PostLog(EattsEntryModel eattsEntryModel)
    {
        var response = await RestClient.For<IEATTSApiClient>(_httpClient)
                                        .PostLog(eattsEntryModel);

        var found = await ProcessResponse(response);

        return found;
    }
}