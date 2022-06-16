using Microsoft.AspNetCore.Mvc;
using MyList.Application.Common.Dto;
using MyList.Domain.Common.Models.ContentModels;

namespace MyList.Web.Controllers
{
    public interface ICollectionController<T> where T : class
    {
        Task<IActionResult> GetAll();
        Task<IActionResult> GetAllTags();
        Task<IActionResult> Get(string id);
        Task<ActionResult> AddToList(AddCollectionDto collecitonDto);
        Task<ActionResult> Find(string name);
        Task<ActionResult> Create(T name);
    }
}
