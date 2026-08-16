using System;

namespace EATTS.Common.Interfaces;

public interface IError
{
	int? ApplicationRef { get; set; }
	string AdditionalDescription { get; set; }
	int? CategoryRef { get; set; }
	DateTime? CloseDate { get; set; }
	DateTime CreateDate { get; set; }
	string Description { get; set; }
	string Number { get; set; }
	int? ImportanceRef { get; set; }
	int? InputUserRef { get; set; }
	short IsActiveFlag { get; set; }
	short IsStrikeFlag { get; set; }
	string Page { get; set; }
	int? PrimaryContactUserRef { get; set; }
	int ErrorRef { get; set; }
	string ResolutionDescription { get; set; }
	int? SecondaryContactUserRef { get; set; }
	int? StatusRef { get; set; }
	int? TypeRef { get; set; }

	public static void Map(IError fromData, IError toData)
	{
		if (fromData == null || toData == null) return;
		toData.ApplicationRef = fromData.ApplicationRef;
		toData.AdditionalDescription = fromData.AdditionalDescription;
		toData.CategoryRef = fromData.CategoryRef;
		toData.CloseDate = fromData.CloseDate;
		toData.CreateDate = fromData.CreateDate;
		toData.Description = fromData.Description + "";
		toData.Number = fromData.Number;
		toData.ImportanceRef = fromData.ImportanceRef;
		toData.InputUserRef = fromData.InputUserRef;
		toData.IsActiveFlag = fromData.IsActiveFlag;
		toData.IsStrikeFlag = fromData.IsStrikeFlag;
		toData.Page = fromData.Page + "";
		toData.PrimaryContactUserRef = fromData.PrimaryContactUserRef;
		toData.ErrorRef = fromData.ErrorRef;
		toData.ResolutionDescription = fromData.ResolutionDescription + "";
		toData.SecondaryContactUserRef = fromData.SecondaryContactUserRef;
		toData.StatusRef = fromData.StatusRef;
		toData.TypeRef = fromData.TypeRef;
	}

	public void MapTo(IError toData)
	{
		Map(this, toData);
	}

	public void MapFrom(IError fromData)
	{
		Map(fromData, this);
	}
}