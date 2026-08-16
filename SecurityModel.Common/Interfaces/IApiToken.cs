//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
namespace SecurityModel.Common.Interfaces;

public interface IApiToken
{

    bool Active { get; set; }
    string Body { get; set; }
    int ApiTokenRef { get; set; }
    int ApplicationRef { get; set; }

    public static void Map(IApiToken fromData, IApiToken toData)
    {
        if (fromData == null || toData == null) return;
        toData.Active = fromData.Active;
        toData.Body = fromData.Body;
        toData.ApiTokenRef = fromData.ApiTokenRef;
        toData.ApplicationRef = fromData.ApplicationRef;
    }

    public void MapTo(IApiToken toData)
    {
        Map(this, toData);
    }

    public void MapFrom(IApiToken fromData)
    {
        Map(fromData, this);
    }

    public void Update(IApiToken fromData)
    {
        var currentRef = this.ApiTokenRef;
        Map(fromData, this);
        this.ApiTokenRef = currentRef;
    }

}