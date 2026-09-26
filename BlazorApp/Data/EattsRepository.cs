using BlazorApp.Common;
using BlazorApp.Models;
using EATTS.Client;
using EATTS.Common.Models;
using Midland.Core.SimpleMessageBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestEase;
using System.Security.Cryptography;

namespace BlazorApp.Data;

public class EattsRepository : BlazorClientRepositoryBase<IEATTSApiClient>, IEattsApiRepository
{
    private readonly IEmployeeRepository _empRepo;

    public EattsRepository(HttpClient httpClient, IEventChannelBus eventBus, ClientSettings clientSettings, IEmployeeRepository empRepo, JsonSerializerSettings jsonSerializerSettings)
        : base(httpClient, eventBus, clientSettings, jsonSerializerSettings)
    {
        _empRepo = empRepo;
    }

    public async Task<PageResultsModel<EntryOccurrenceSummaryModel>> GetEntryOccurrenceDetail(EntryOccurrenceSearchCriteria criteria)
    {
        var response = await Client.GetEntryOccurrenceViewPaged(criteria.ToQueryString());
        var found = await ProcessResponseAsync(response);
        return found;
    }

    public async Task<ApplicationOptionsGetModel> ApplicationOptionAdd(ApplicationOptionsPostModel model)
    {
        var response = await Client.PostApplicationOptions(model);

        var found = await ProcessResponseAsync(response);

        return found;
    }

    public async void ApplicationOptionDelete(ApplicationOptionsGetModel model)
    {
        var response = await Client.DeleteApplicationOptions(model.ApplicationOptionsRef);

        await CheckForErrorsAsync(response);
    }

    public async Task<ApplicationOptionsGetModel> ApplicationOptionUpdate(ApplicationOptionsGetModel model)
    {
        var response = await Client.PutApplicationOptions(model.ApplicationOptionsRef, model);

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

    public async Task<List<ApiLogDataModel>> FindApiLogData(ApiLogCriteria criteria)
    {
        var response = await Client.GetLogPaged(criteria.ToQueryString());
        var x = await ProcessResponseAsync(response);
        return x?.Results?.Values().ToList();
    }

    public async Task<List<EntrySummaryModel>> FindEntries(EntrySearchCriteria criteria)
    {
        var response = await Client.GetEntryViewSummaryPaged(criteria.ToQueryString());

        var x = await ProcessResponseAsync(response);

        return x?.Results?.Values().ToList();
    }

    public async Task<List<EntryOccurrenceSummaryModel>> FindOccurrences(EntryOccurrenceSearchCriteria criteria)
    {
        var response = await Client.GetEntryOccurrenceViewPaged(criteria.ToQueryString());

        var x = await ProcessResponseAsync(response);
        return x.Results.Values().ToList();
    }

    public async Task<List<ApplicationOptionsGetModel>> GetAllApplicationOptions()
    {
        var response = await Client.GetAllApplicationOptionsList();

        var found = (await ProcessResponseAsync(response)).ToList();
        found.ForEach(r => { r.ApiName = r.ApiName.ToLower().Trim(); });
        return found;
    }

    public async Task<EntryDetailModel> GetEntryDetail(int entryRef)
    {
        var response = await Client.GetEntryViewDetail(entryRef);
        return await ProcessResponseAsync(response);
    }

    public async Task<EntryOccurrenceDetailModel> GetOccurrenceDetail(int occurrenceRef)
    {
        var response = await Client.GetEntryOccurrenceViewDetail(occurrenceRef);
        var found = await ProcessResponseAsync(response);
        return found;
    }

    public async Task<List<ContactModel>> GetSupportDefaultContactEdit()
    {
        var response = await Client.GetAllSupportContactList();

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
        var response = await Client.GetAllSupportOptionOverrideList();

        return await ProcessResponseAsync(response);
    }

    public async Task<SupportOptionsOverrideGetModel> GetSupportOptionOverride(int supportOptionsOverrideRef)
    {
        var response = await Client.GetSupportOptionOverride(supportOptionsOverrideRef);

        return await ProcessResponseAsync(response);
    }

    public async Task<SupportOptionsOverrideGetModel> PostSupportOptionOverride(SupportOptionsOverridePostModel model)
    {
        var response = await Client.PostSupportOptionOverride(model);

        return await ProcessResponseAsync(response);
    }

    public async Task<SupportOptionsOverrideGetModel> PutSupportOptionOverride(int supportOptionsOverrideRef, SupportOptionsOverridePostModel model)
    {
        var response = await Client.PutSupportOptionOverride(supportOptionsOverrideRef, model);

        return await ProcessResponseAsync(response);
    }

    public async Task DeleteSupportOptionOverride(int supportOptionsOverrideRef)
    {
        var response = await Client.DeleteSupportOptionOverride(supportOptionsOverrideRef);

        await CheckForErrorsAsync(response);
    }

    public async Task<SupportDefaultContactEditModel> PostSupportContact(SupportDefaultContactAddModel model)
    {
        var response = await Client.PostSupportContact(model);

        return await ProcessResponseAsync(response);
    }

    public async Task<SupportDefaultContactEditModel> PutSupportContact(SupportDefaultContactEditModel model)
    {
        var response = await Client.PutSupportContact(model);

        return await ProcessResponseAsync(response);
    }

    public async Task DeleteSupportContact(int supportDefaultContactRef)
    {
        var response = await Client.DeleteSupportContact(supportDefaultContactRef);

        await CheckForErrorsAsync(response);
    }

    public async Task<SupportOptionsEditModel> GetSupportOptions()

    {
        var options = await Client.GetSupportOption();

        return await ProcessResponseAsync(options);
    }

    public async Task<SupportOptionsEditModel> UpdateSupportOptions(SupportOptionsEditModel model)

    {
        var options = await Client.PutSupportOption(model);

        return await ProcessResponseAsync(options);
    }

    public async Task<EattsEntryResultModel> PostLog(EattsEntryModel eattsEntryModel)
    {
        var response = await Client.PostLog(eattsEntryModel);

        var found = await ProcessResponseAsync(response);

        return found;
    }

    //public async Task<List<EntryOccurrenceSearchView>> SearchEntries(EntryOccurrenceSearchCriteria criteria)
    //{
    //    var response = await Client.Getoccurrence(criteria.ToQueryString());
    //    var found = await ProcessResponseAsync(response);
    //    return found.Results.Values().ToList();
    //}
}