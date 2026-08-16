using System;

namespace SecurityModel.Common.Interfaces;

public interface IServiceTokenOwner
{
	Guid ServiceTokenId { get; set; }
	DateTime Created { get; set; }
	int CreatedBy { get; set; }
	int ServiceTokenOwnerRef { get; set; }
	int UserRef { get; set; }

	public static void Map(IServiceTokenOwner fromData, IServiceTokenOwner toData)
	{
		if (fromData == null || toData == null) return;
		toData.ServiceTokenId = fromData.ServiceTokenId;
		toData.Created = fromData.Created;
		toData.CreatedBy = fromData.CreatedBy;
		toData.ServiceTokenOwnerRef = fromData.ServiceTokenOwnerRef;
		toData.UserRef = fromData.UserRef;
	}

	public void MapTo(IServiceTokenOwner toData)
	{
		Map(this, toData);
	}

	public void MapFrom(IServiceTokenOwner fromData)
	{
		Map(fromData, this);
	}
}