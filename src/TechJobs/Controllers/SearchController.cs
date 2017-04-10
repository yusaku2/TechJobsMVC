using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Dictionary<string, string>> JobResult = new List<Dictionary<string, string>>();
            ViewBag.columns = ListController.columnChoices;
        //do the searching and putting the results in JobResult, once it's in ViewBag.jobs, the process will occur in the index.
             if(searchType.Equals("all")) 
                    {
                        JobResult = JobData.FindByValue(searchTerm);
                       
                    }           
                    else
                    {
                        JobResult = JobData.FindByColumnAndValue(searchType, searchTerm);
                    }
            ViewBag.title = "Jobs with " + ViewBag.columns[searchType];
            ViewBag.jobs=JobResult;
            return View("Index");


        
        }
    }
}
