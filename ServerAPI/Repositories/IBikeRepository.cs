using System;
using Core.Model;
namespace ServerAPI.Repositories
{
	public interface IBikeRepository
	{
		Bike[] GetAll();
		void Add(Bike bike);
		void Delete(int id);
	}
}

