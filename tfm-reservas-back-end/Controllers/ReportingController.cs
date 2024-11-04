using DevExpress.AspNetCore.Reporting.WebDocumentViewer;
using DevExpress.AspNetCore.Reporting.WebDocumentViewer.Native.Services;
using Microsoft.AspNetCore.Mvc;

namespace tfm_reservas_back_end.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
[Route("api/DXXRDV")]
public class DXWebDocumentViewerController : WebDocumentViewerController
{
    public DXWebDocumentViewerController(IWebDocumentViewerMvcControllerService controllerService) : base(controllerService)
    {
    }

    public override Task<IActionResult> Invoke()
    {
        return base.Invoke();
    }
}
