using Microsoft.AspNetCore.Mvc;
using MyList.Application.Common.Dto;
using MyList.Domain.Common.Models.ContentModels;

namespace MyList.Web.Controllers
{
    public interface ICollectionController<T> where T : class
    {
        Task<IActionResult> GetAll();
        Task<IActionResult> GetAllTags();
        Task<IActionResult> Get(Guid id);
        Task<ActionResult> AddToList(T item);
        Task<ActionResult> AddToList(Guid id);
        Task<ActionResult> Find(string name);
        Task<ActionResult> Create(T name);
    }
}
