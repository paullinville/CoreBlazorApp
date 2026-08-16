using System.Collections.Generic;

namespace SecurityModel.Common.Models;

public class UserActionsModel : UserSelectModel
{
    public List<string> Actions { get; set; }
}