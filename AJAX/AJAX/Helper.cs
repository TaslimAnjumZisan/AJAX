using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
namespace AJAX
{
    public class Helper
    {
//        public static string RenderRezorViewToString(Controller controller,string viewName,object model=null)
//        {
//            controller.ViewData.Model = model;
//            using (var writer = new StringWriter())
//            {
//                IViewEngine viewEngine = controller.HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;
//                ViewEngineResult viewEngineResult = viewEngine.FindView(controller, ControllerContext, viewName, false);
//                ViewContext viewContext = new ViewContext(
//                   controller.ControllerContext,
//                   ViewResult.View,
//                   controller.TempData,
//                   sw,
//                   new HtmlHelperOptions()
//                    );
//                ViewResult.View.Render(viewContext);
//                return sw.GetStringBuilder().ToString();
//g           }
//        }
    }
}
