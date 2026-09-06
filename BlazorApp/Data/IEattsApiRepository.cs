using EATTS.Common.Models;
using BlazorApp.Models;
using Midland.Core.Common;
using RestEase;

namespace BlazorApp.Data;

public interface IEattsApiRepository
{
    Task<EattsEntryResultModel> PostLog(EattsEntryModel eattsEntryModel);

    Task<PageResultsModel<EntryOccurrenceSummaryModel>> GetEntryOccurrenceDetail(EntryOccurrenceSearchCriteria criteria);
}
