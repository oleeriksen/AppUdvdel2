using Microsoft.AspNetCore.Mvc;
using Core;
using ServerAPI.Repositories;

namespace ServerAPI.Controllers
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
        public List<ShoppingList> GetAll(){
            
            return mRepo.GetAll();
        }

        [HttpPost]
        [Route("add/{id:int}")]
        public ShoppingItem AddItemToList(int id,ShoppingItem product){
            mRepo.AddItemToList(id, product);
            return product;
        }

        /*
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
*/

    }
}

