namespace Midland.Core.Common;

public class EattsError
{
	public EattsError()
	{ }

	public int ErrorRef { get; set; }

	public ApplicationView ApplicationRef { get; set; }

	public string AdditionalDescription { get; set; }
	public ICode Category { get; set; }
	public DateTime CreateDate { get; set; }
	public string Description { get; set; }
	public string Number { get; set; }
	public int? ImportanceRef { get; set; }
	public int? InputUserRef { get; set; }
	public short IsActiveFlag { get; set; }
	public UserSelectModel PrimaryContactUser { get; set; }
	public UserSelectModel SecondaryContact { get; set; }
	public ICode Status { get; set; }
	public ICode Type { get; set; }
}