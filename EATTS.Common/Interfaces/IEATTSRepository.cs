using Midland.Core.Common;
using Midland.Core.Database;
using System;
using System.Collections.Generic;
using static EATTS.Common.Classes.Enumerations;

namespace EATTS.Common.Interfaces;

public delegate int NewEntityRef();

public partial interface IEATTSRepository : IRepository
{
	void DeleteApiLog(int apiLogRef);

	int DeleteApiLogs(DateTime dateOf);

	void DeleteEntryNotes(int entryRef);

	void DeleteEntryOccurrences(int entryRef);

	IEnumerable<IMidlandUser> GetAllUsers();

	IApplicationOptions GetApplicationOptions(string slug);

	Employee GetEmployee(int? userRef);

	IParameter GetParameter(ApplicationParameters parameter);

	IMidlandUser GetUser(int userRef);
}