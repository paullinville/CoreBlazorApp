using EATTS.Common.Models;
using BlazorApp.Models;
using Midland.Core.Common;
using RestEase;

namespace BlazorApp.Data;

public interface IEattsApiRepository
{
    Task<EattsEntryResultModel> PostLog(EattsEntryModel eattsEntryModel);

    Task<PageResultsModel<EntryOccurrenceSummaryModel>> GetEntryOccurrenceDetail(EntryOccurrenceSearchCriteria criteria);

    Task<ApplicationOptionsGetModel> ApplicationOptionAdd(ApplicationOptionsPostModel model);

    void ApplicationOptionDelete(ApplicationOptionsGetModel model);

    Task<ApplicationOptionsGetModel> ApplicationOptionUpdate(ApplicationOptionsGetModel model);

    Task<ContactModel> ContactAdd(ContactModel model);

    void ContactDelete(ContactModel model);

    Task<ContactModel> ContactUpdate(ContactModel model);

    Task<List<EntrySummaryModel>> FindEntries(EntrySearchCriteria criteria);

    Task<List<EntryOccurrenceSummaryModel>> FindOccurrences(EntryOccurrenceSearchCriteria criteria);

    Task<List<ApplicationOptionsGetModel>> GetAllApplicationOptions();

    Task<EntryDetailModel> GetEntryDetail(int entryRef);

    Task<EntryOccurrenceDetailModel> GetOccurrenceDetail(int occurrenceRef);

    Task<List<ContactModel>> GetSupportDefaultContactEdit();
}