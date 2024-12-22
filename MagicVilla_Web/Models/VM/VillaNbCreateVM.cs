using MagicVilla_Web.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagicVilla_Web.Models.VM
{
    public class VillaNbCreateVM
    {
        public VillaNbCreateVM(VillaNbRequestDTO villaNb)
        {
            VillaNb = villaNb;
        }
        public VillaNbCreateVM()
        {
            VillaNb = new VillaNbRequestDTO();
        }

        public VillaNbRequestDTO VillaNb { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> villaList { get; set; }
    }
}
