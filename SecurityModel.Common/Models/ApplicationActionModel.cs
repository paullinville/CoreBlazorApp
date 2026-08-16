using System.ComponentModel.DataAnnotations;
using System;
using SecurityModel.Common.Interfaces;
namespace SecurityModel.Common.Models;

    public class ApplicationActionModel : IApplicationAction 
    {
        public ApplicationActionModel () {}
    public ApplicationActionModel(IApplicationAction values)
    {
        values?.MapTo(this);
    }
    public SecurityModel.Common.Dto.ApplicationActionDto CreateDto()
    {
        var createdItem = new SecurityModel.Common.Dto.ApplicationActionDto();
        createdItem.ActionCreateDate = ActionCreateDate;
        createdItem.ActionDescription = ActionDescription;
        createdItem.ActionName = ActionName;
        createdItem.ActionRef = ActionRef;
        createdItem.ApplicationApiName = ApplicationApiName;
        createdItem.ApplicationDescription = ApplicationDescription;
        createdItem.ApplicationGuid = ApplicationGuid;
        createdItem.ApplicationIsActiveFlag = ApplicationIsActiveFlag;
        createdItem.ApplicationName = ApplicationName;
        createdItem.ApplicationRef = ApplicationRef;
        createdItem.ApplicationSlug = ApplicationSlug;
        createdItem.ApplicationVirtualDirectory = ApplicationVirtualDirectory;
        return createdItem;
    }

        public DateTime ActionCreateDate { get; set; }
        [Required]
        [StringLength(400)]
        public string ActionDescription { get; set; }
        [Required]
        [StringLength(150)]
        public string ActionName { get; set; }
        public int ActionRef { get; set; }
        [StringLength(150)]
        public string ApplicationApiName { get; set; }
        [Required]
        [StringLength(400)]
        public string ApplicationDescription { get; set; }
        public Guid ApplicationGuid { get; set; }
        public bool ApplicationIsActiveFlag { get; set; }
        [Required]
        [StringLength(150)]
        public string ApplicationName { get; set; }
        public int ApplicationRef { get; set; }
        [StringLength(90)]
        public string ApplicationSlug { get; set; }
        [StringLength(250)]
        public string ApplicationVirtualDirectory { get; set; }
}