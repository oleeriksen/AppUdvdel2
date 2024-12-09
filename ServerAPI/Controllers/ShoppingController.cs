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
        
        [HttpGet]
        [Route("getbyid/{id:int}")]
        public ShoppingList GetById(int id)
        {
            return mRepo.GetById(id);
        }

       [HttpPost]
        [Route("add")]
        public ShoppingList AddItemToList(ShoppingList sl){
            mRepo.Add(sl);
            return sl;
        }

        [HttpPut]
        [Route("update")]
        public void UpdateShoppingItems(ShoppingList sl){
            mRepo.UpdateShoppingItems(sl);
        }
        
        /*
        [HttpDelete]
        [Route("delete/{id:int}")]
        public void DeleteItem(int id) {
            mRepo.DeleteById(id);
        }
        */
        


    }
}

