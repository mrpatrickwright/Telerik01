using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Telerik01.Context;
using Telerik01.ViewModels;

using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Telerik01
{
    public class ExerciseModel : PageModel
    {
        private GroupExClassPlansContext _context;
        public static IList<ExerciseViewModel> exercises;
        public ExerciseModel()
        {
            _context = new GroupExClassPlansContext();
        }
        public void OnGet()
        {
            var activities = _context.Activity.ToList();
            exercises = new List<ExerciseViewModel>();
           // List<ExerciseViewModel> data = new List<ExerciseViewModel>();
            foreach (var a in activities)
            {
                exercises.Add(new ExerciseViewModel() { AccountId = a.AccountId, ActivityName = a.ActivityName, Id = a.Id });
            }

        }


        public JsonResult OnPostRead([DataSourceRequest] DataSourceRequest request)
        {
            var data = exercises.ToDataSourceResult(request);

            
            return new JsonResult(exercises.ToDataSourceResult(request));
        }

        public JsonResult OnPostReadRecords()
        {
            var activities = _context.Activity.ToList();
            List<ExerciseViewModel> data = new List<ExerciseViewModel>();
            foreach (var a in activities)
            {
                data.Add( new ExerciseViewModel(){AccountId = a.AccountId, ActivityName = a.ActivityName, Id = a.Id});
            }

            return new JsonResult(data);
        }

        public JsonResult OnPostUpdateRecord([DataSourceRequest] DataSourceRequest request, ExerciseViewModel customer)
        {
            System.Diagnostics.Debug.WriteLine("Updating");

            return new JsonResult(customer);
        }
    }
}