//This class has been code generated.
//Do not change the contents of this file because it will be regenerated in the future if the schema
//changes or new code generation features are added.
using System;
namespace EATTS.Common.Interfaces;

public interface IParameter
{

    DateTime CreateDate { get; set; }
    int CreateUserRef { get; set; }
    string DataType { get; set; }
    string Description { get; set; }
    bool Encrypted { get; set; }
    bool IsDropDownList { get; set; }
    string Name { get; set; }
    int ParameterRef { get; set; }
    bool System { get; set; }
    DateTime UpdateDate { get; set; }
    int UpdateUserRef { get; set; }
    string Value { get; set; }

    public static void Map(IParameter fromData, IParameter toData)
    {
        if (fromData == null || toData == null) return;
        toData.CreateDate = fromData.CreateDate;
        toData.CreateUserRef = fromData.CreateUserRef;
        toData.DataType = fromData.DataType;
        toData.Description = fromData.Description;
        toData.Encrypted = fromData.Encrypted;
        toData.IsDropDownList = fromData.IsDropDownList;
        toData.Name = fromData.Name;
        toData.ParameterRef = fromData.ParameterRef;
        toData.System = fromData.System;
        toData.UpdateDate = fromData.UpdateDate;
        toData.UpdateUserRef = fromData.UpdateUserRef;
        toData.Value = fromData.Value;
    }

    public void MapTo(IParameter toData)
    {
        Map(this, toData);
    }

    public void MapFrom(IParameter fromData)
    {
        Map(fromData, this);
    }

    public void Update(IParameter fromData)
    {
        var currentRef = this.ParameterRef;
        Map(fromData, this);
        this.ParameterRef = currentRef;
    }

}