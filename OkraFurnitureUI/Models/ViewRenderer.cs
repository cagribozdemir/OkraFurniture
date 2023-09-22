using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace OkraFurnitureUI.Models
{
    public class ViewRenderer
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IViewEngine _viewEngine;
        private readonly ITempDataProvider _tempDataProvider;

        public ViewRenderer(IServiceScopeFactory serviceScopeFactory, IViewEngine viewEngine, ITempDataProvider tempDataProvider)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _viewEngine = viewEngine;
            _tempDataProvider = tempDataProvider;
        }

        public async Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var httpContext = new DefaultHttpContext();
                var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());

                var viewResult = _viewEngine.FindView(actionContext, viewName, false);

                if (viewResult.View == null)
                {
                    throw new ArgumentNullException($"{viewName} does not match any available view");
                }

                var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {
                    Model = model
                };

                using (var sw = new StringWriter())
                {
                    var viewContext = new ViewContext(actionContext, viewResult.View, viewDictionary, new TempDataDictionary(actionContext.HttpContext, _tempDataProvider), sw, new HtmlHelperOptions());
                    await viewResult.View.RenderAsync(viewContext);
                    return sw.GetStringBuilder().ToString();
                }
            }
        }
    }
}
