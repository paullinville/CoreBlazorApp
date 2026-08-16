namespace Midland.Core.Authorization;

public enum TokenSubjectType
{
	Unknown = 0,
	Service = 10,
	Api = 20,
	Gateway = 30,
	Intermediate = 40,
	User = 50,
}