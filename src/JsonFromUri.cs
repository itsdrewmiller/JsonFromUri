using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using System.Web.Http.Controllers;

namespace JsonFromUri
{

    public class JsonUriModelBinder<T> : IModelBinder {
        
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext) {
        
            try {

                var queryParameters = actionContext.Request.RequestUri.GetComponents(UriComponents.Query, UriFormat.Unescaped).Split('&');
                var filterParam = (from param in queryParameters
                                   where param.StartsWith(bindingContext.ModelName + "=")
                                   select param.Substring(bindingContext.ModelName.Length + 1)).Single();

                bindingContext.Model = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(filterParam);

                return true;
                
            } catch {

                return false;

            }

        }
    }


    public class JsonFromUriAttribute : ModelBinderAttribute
    {

        public JsonFromUriAttribute(Type type)
            : base(typeof(JsonUriModelBinder<>).MakeGenericType(type))
        {
        }
    }

}
