namespace Midland.Core.Common.Database;

public class DbColumn
{
	public string DataType { get; set; }
	public bool IsNullable { get; set; }
	public short MaxLength { get; set; }
	public string Name { get; set; }
	public byte Precision { get; set; }
	public byte Scale { get; set; }
}

public class DbTable
{
	public List<DbColumn> Columns { get; set; } = new();
	public string Name { get; set; }
	public string Schema { get; set; }
}

public class EfColumn
{
	public string ClrType { get; set; }
	public string EfType { get; set; }
	public bool IsKey { get; set; }
	public bool IsNullable { get; set; }
	public string Name { get; set; }
}

public class SchemaValidationResult
{
	public SchemaValidationResult()
	{ }

	public List<string> DBOnlyColumns { get; set; } = new();
	public List<string> DBOnlyTables { get; set; } = new();
	public List<string> EFOnlyColumns { get; set; } = new();
	public List<string> EFOnlyTables { get; set; } = new();

	public bool IsValid =>
		EFOnlyTables.IsEmpty() &&
		EFOnlyColumns.IsEmpty();

	public List<string> NullabilityMismatches { get; set; } = new();
	public List<string> TypesIncompatible { get; set; } = new();
}

public class EfTable
{
	public List<EfColumn> Columns { get; set; } = new();
	public string EntityName { get; set; }
	public string Name { get; set; }
	public string Schema { get; set; }
}