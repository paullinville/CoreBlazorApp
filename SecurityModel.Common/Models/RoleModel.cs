using SecurityModel.Common.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SecurityModel.Common.Models;

public class RoleDeleteModel
{
	public virtual int RoleRef { get; set; }
}

public class RoleGetModel : RolePostModel
{
	public RoleGetModel()
	{ }

	public RoleGetModel(IRole values) : base(values)
	{
		RoleRef = values.RoleRef;
	}

	public int RoleRef { get; set; }

	[Range(typeof(DateTime), "1/1/1775", "12/31/9999 11:59AM")]
	protected DateTime CreateDate { get; set; }

	protected int? CreateUserRef { get; set; }

	[Range(typeof(DateTime), "1/1/1775", "12/31/9999 11:59AM")]
	protected DateTime? UpdateDate { get; set; }

	protected int? UpdateUserRef { get; set; }

	public override RoleDto CreateDto()
	{
		var createdItem = new RoleDto();
		createdItem.ApplicationRef = ApplicationRef;

		createdItem.Description = Description;

		createdItem.Name = Name;
		createdItem.RoleRef = RoleRef;

		return createdItem;
	}

	public override bool Equals(object obj)
	{
		if (obj is IRole agh)
		{
			return agh.RoleRef == RoleRef;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return $"Role{RoleRef}".GetHashCode();
	}
}

public class RolePostModel : RolePutBodyModel
{
	public RolePostModel()
	{ }

	public RolePostModel(IRole values)
	{
		if (values == null) return;
		ApplicationRef = values.ApplicationRef;

		Description = values.Description;

		Name = values.Name;
	}

	public int ApplicationRef { get; set; }

	public override RoleDto CreateDto()
	{
		var createdItem = base.CreateDto();
		createdItem.ApplicationRef = ApplicationRef;
		return createdItem;
	}
}

public class RolePutBodyModel
{
	public RolePutBodyModel()
	{ }

	public RolePutBodyModel(IRole values)
	{
		if (values == null) return;

		Description = values.Description;

		Name = values.Name;
	}

	public List<int> ActionGroupRefs { get; set; }

	public List<int> ActionRefs { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(400)]
	public string Description { get; set; }

	[Required(AllowEmptyStrings = true)]
	[StringLength(150)]
	public string Name { get; set; }

	public virtual RoleDto CreateDto()
	{
		var createdItem = new RoleDto();

		createdItem.Description = Description;
		createdItem.Name = Name;

		return createdItem;
	}
}

public class RolePutModel
{
	public RolePutModel()
	{ }

	public RolePutModel(IRole values)
	{
		RoleRef = values.RoleRef;
		Body = new RolePutBodyModel(values);
	}

	public virtual RolePutBodyModel Body { get; set; }

	[Required, Range(1, int.MaxValue)]
	public virtual int RoleRef { get; set; }

	public override bool Equals(object obj)
	{
		if (obj is IRole agh)
		{
			return agh.RoleRef == RoleRef;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return $"Role{RoleRef}".GetHashCode();
	}
}