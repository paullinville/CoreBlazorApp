using System.Threading.Tasks;

namespace EATTS.Common.Interfaces;

public interface IRazorViewToStringRenderer
{
	#region Public Interface

	Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);

	#endregion Public Interface
}