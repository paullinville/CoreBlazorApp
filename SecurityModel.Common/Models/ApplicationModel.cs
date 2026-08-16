using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SecurityModel.Common.Models;

public class ApplicationDeleteModel
{
	public virtual int ApplicationRef { get; set; }
}

public class ApplicationGetModel : ApplicationPostModel
{
	public ApplicationGetModel()
	{ }

	public ApplicationGetModel(IApplication values) : base(values)
	{
		ApplicationRef = values.ApplicationRef;
		Guid = values.Guid;
		IsLoaded = values.IsLoadedFlag == 1;
		CreatedDate = values.CreateDate;
	}

	public int ApplicationRef { get; set; }
	public EmployeeSimple CreatedBy { get; set; }
	public DateTime? CreatedDate { get; set; }
	public Guid Guid { get; set; }

	[JsonIgnore]
	public override int? InitialUserRef { get; set; }

	public bool IsLoaded { get; set; }

	public override bool Equals(object obj)
	{
		if (obj is IApplication agh)
		{
			return agh.ApplicationRef == ApplicationRef;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return $"Application{ApplicationRef}".GetHashCode();
	}
}

public class ApplicationPostModel
{
	public ApplicationPostModel()
	{ }

	public ApplicationPostModel(IApplication values)
	{
		if (values == null) return;
		ApiName = values.ApiName;
		Description = values.Description;
		Name = values.Name;
		Slug = values.Slug;
		VirtualDirectory = values.VirtualDirectory;
		IsActive = values.IsActiveFlag;
	}

	[StringLength(150)]
	public string ApiName { get; set; }

	[Required(AllowEmptyStrings = false)]
	[StringLength(400)]
	public string Description { get; set; }

	public virtual int? InitialUserRef { get; set; }
	public bool IsActive { get; set; }

	[Required(AllowEmptyStrings = false)]
	[StringLength(150)]
	public string Name { get; set; }

	[StringLength(90)]
	public string Slug { get; set; }

	[Required(AllowEmptyStrings = false)]
	[StringLength(250)]
	public string VirtualDirectory { get; set; }
}

public class ApplicationPutBodyModel : ApplicationPostModel
{
	public ApplicationPutBodyModel(IApplication values) : base(values)
	{
	}

	public ApplicationPutBodyModel()
	{ }

	[JsonIgnore]//This is only used on the initial adding of the application.
	public override int? InitialUserRef { get; set; }
}

public class ApplicationPutModel
{
	public ApplicationPutModel()
	{ }

	public ApplicationPutModel(IApplication values)
	{
		ApplicationRef = values.ApplicationRef;
		Body = new ApplicationPutBodyModel(values);
	}

	[Required, Range(1, int.MaxValue)]
	public virtual int ApplicationRef { get; set; }

	public virtual ApplicationPutBodyModel Body { get; set; }

	public override bool Equals(object obj)
	{
		if (obj is IApplication agh)
		{
			return agh.ApplicationRef == ApplicationRef;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return $"Application{ApplicationRef}".GetHashCode();
	}
}