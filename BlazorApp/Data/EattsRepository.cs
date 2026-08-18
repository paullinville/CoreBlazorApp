using BlazorApp.Classes;
using BlazorApp.Models;
using EATTS.Client;
using EATTS.Common.Models;
using Midland.Core.Client;
using Midland.Core.Common;
using Midland.Core.SimpleMessageBus;
using RestEase;

namespace BlazorApp.Data;

public class EattsRepository : ClientRepositoryBase, IEattsApiRepository
{
	private readonly IEmployeeRepository _empRepo;

	public EattsRepository(HttpClient httpClient, ISecurityModelToken securityModel, IEmployeeRepository empRepo, IEventChannelBus eventBus, ClientSettings clientSettings)
		: base(httpClient, securityModel, eventBus, clientSettings)
	{
		_empRepo = empRepo;
	}

	public async Task<ApplicationOptionsGetModel> ApplicationOptionAdd(ApplicationOptionsPostModel model)
	{
		await _securityModel.SetAuthorization(_httpClient);

		var response = await RestClient.For<IEATTSApiClient>(_httpClient)
										.PostApplicationOptions(model);

		var found = ProcessResponse(response);

		return found;
	}

	public async void ApplicationOptionDelete(ApplicationOptionsGetModel model)
	{
		await _securityModel.SetAuthorization(_httpClient);

		var response = await RestClient.For<IEATTSApiClient>(_httpClient)
										.DeleteApplicationOptions(model.ApplicationOptionsRef);

		CheckForErrors(response);
	}

	public async Task<ApplicationOptionsGetModel> ApplicationOptionUpdate(ApplicationOptionsGetModel model)
	{
		await _securityModel.SetAuthorization(_httpClient);

		var response = await RestClient.For<IEATTSApiClient>(_httpClient)
										.PutApplicationOptions(model.ApplicationOptionsRef, model);

		var found = ProcessResponse(response);

		return found;
	}

	public async Task<ContactModel> ContactAdd(ContactModel model)
	{
		await _securityModel.SetAuthorization(_httpClient);

		var response = await RestClient.For<IEATTSApiClient>(_httpClient)
									   .PostSupportContact(model);

		var updated = new ContactModel(ProcessResponse(response));

		updated.FullName = _empRepo.GetActiveSelectionUsers().Result.FirstOrDefault(r => r.UserRef == updated.UserRef)?.FullName;
		return updated;
	}

	public async void ContactDelete(ContactModel model)
	{
		await _securityModel.SetAuthorization(_httpClient);

		var response = await RestClient.For<IEATTSApiClient>(_httpClient)
						   .DeleteSupportContact(model.SupportDefaultContactRef);

		CheckForErrors(response);
	}

	public async Task<ContactModel> ContactUpdate(ContactModel model)
	{
		await _securityModel.SetAuthorization(_httpClient);

		var response = await RestClient.For<IEATTSApiClient>(_httpClient)
									   .PutSupportContact(model);

		var updated = new ContactModel(ProcessResponse(response));

		updated.FullName = _empRepo.GetActiveSelectionUsers().Result.FirstOrDefault(r => r.UserRef == updated.UserRef)?.FullName;
		return updated;
	}

	public async Task<List<EntrySummaryModel>> FindEntries(EntrySearchCriteria criteria)
	{
		try
		{
			await _securityModel.SetAuthorization(_httpClient);
			var token = await _securityModel.GetToken();
			_httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

			IEATTSApiClient result = RestClient.For<IEATTSApiClient>(_httpClient);

			var response = await result.GetEntryViewSummaryPaged(criteria.ToQueryString());

			var x = ProcessResponse(response);

			return x?.Results?.Values().ToList();
		}
		catch (Exception)
		{
			throw;
		}
;
	}

	public async Task<List<EntryOccurrenceSummaryModel>> FindOccurrences(EntryOccurrenceSearchCriteria criteria)
	{
		try
		{
			await _securityModel.SetAuthorization(_httpClient);

			IEATTSApiClient result = RestClient.For<IEATTSApiClient>(_httpClient);

			var response = await RestClient.For<IEATTSApiClient>(_httpClient).GetEntryOccurrenceViewPaged(criteria.ToQueryString());

			var x = ProcessResponse(response);
			return x.Results.Values().ToList();
		}
		catch (Exception)
		{
			throw;
		}
	}

	public async Task<List<ApplicationOptionsGetModel>> GetAllApplicationOptions()
	{
		await _securityModel.SetAuthorization(_httpClient);

		var response = await RestClient.For<IEATTSApiClient>(_httpClient)
										.GetAllApplicationOptionsList();

		var found = ProcessResponse(response).ToList();
		found.ForEach(r => { r.ApplicationSlug = r.ApplicationSlug.ToLower().Trim(); });
		return found;
	}

	public async Task<EntryDetailModel> GetEntryDetail(int entryRef)
	{
		await _securityModel.SetAuthorization(_httpClient);

		IEATTSApiClient result = RestClient.For<IEATTSApiClient>(_httpClient);

		var response = await result.GetEntryViewDetail(entryRef);
		return ProcessResponse(response); ;
	}

	public async Task<EntryOccurrenceDetailModel> GetOccurrenceDetail(int occurrenceRef)
	{
		await _securityModel.SetAuthorization(_httpClient);
		var response = await RestClient.For<IEATTSApiClient>(_httpClient).GetEntryOccurrenceViewDetail(occurrenceRef);
		var found = ProcessResponse(response);
		return found;
	}

	public async Task<List<ContactModel>> GetSupportDefaultContactEdit()
	{
		await _securityModel.SetAuthorization(_httpClient);

		var response = await RestClient.For<IEATTSApiClient>(_httpClient)
										.GetAllSupportContactList();

		var found = new List<SupportDefaultContactEditModel>();

		found = ProcessResponse(response);
		if (found != null)
		{
			var users = await _empRepo.GetActiveSelectionUsers();
			return found.Select(r => new ContactModel(r) { FullName = users.FirstOrDefault(u => u.UserRef == r.UserRef)?.FullName }).ToList();
		}
		return new List<ContactModel>();
	}

	public async Task<EattsEntryResultModel> PostLog(EattsEntryModel eattsEntryModel)
	{
		await _securityModel.SetAuthorization(_httpClient);

		var response = await RestClient.For<IEATTSApiClient>(_httpClient)
										.PostLog(eattsEntryModel);

		var found = ProcessResponse(response);

		return found;
	}
}