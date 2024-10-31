using Microsoft.AspNetCore.Mvc;
using Core;
using ServerAPI.Repositories;

namespace HelloBlazor.Server.Controllers
{
    [ApiController]
    [Route("api/shopping")]
    public class ShoppingController : ControllerBase
    {
        private IShoppingRepository mRepo;

        public ShoppingController(IShoppingRepository repo){
            mRepo = repo;
        }

        [HttpGet]
        [Route("getall")]
        public IEnumerable<ShoppingItem> GetAll(){
            return mRepo.GetAll();
        }

        

        [HttpPost]
        [Route("add")]
        public void AddItem(ShoppingItem product){
            mRepo.AddItem(product);  
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public void DeleteItem(int id) {
            mRepo.DeleteById(id);
        }

        [HttpPut]
        [Route("update")]
        public void UpdateItem(ShoppingItem product){
            mRepo.UpdateItem(product);
        }


    }
}

