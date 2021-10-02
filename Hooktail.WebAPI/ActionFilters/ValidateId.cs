using Hooktail.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hooktail.WebAPI.ActionFilters
{
    public class ValidateId<T>: IActionFilter where T : class
    {
        IGenericService<T> genericService;

        public ValidateId(IGenericService<T> genericService)
        {
            this.genericService = genericService;
        }

        public void OnActionExecuted(ActionExecutedContext context){}

        public  void OnActionExecuting(ActionExecutingContext context)
        {
            var parameterDict = context.ActionArguments.Where(I => I.Key.Equals("id")).FirstOrDefault();
            var requestedId = (int)parameterDict.Value;
            var entity =   genericService.FindById(requestedId).Result;

            if (entity == null) context.Result = new NotFoundObjectResult($"There is no object with Id: {requestedId}");

        }
    }
}
