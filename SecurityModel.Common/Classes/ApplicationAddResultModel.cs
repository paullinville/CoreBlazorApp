using SecurityModel.Common.Models;
using System.Collections.Generic;

namespace SecurityModel.Common;

public class ApplicationAddResultModel
{
	public List<IAction> Actions { get; set; } = new List<IAction>();
	public ApplicationGetModel Application { get; set; }
	public IContext Context { get; set; }
	public IContextType ContextType { get; set; }
	public IEmployeeSimple InitialUser { get; set; }
	public IRole Role { get; set; }
	public List<IRoleActionHolder> RoleActionHolders { get; set; } = new List<IRoleActionHolder>();
}