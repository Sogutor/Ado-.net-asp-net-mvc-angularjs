using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApplication15.Models;
using WebApplication15.Models.Entities;
using WebApplication15.Repositories;

namespace WebApplication15.Controllers
{

    public class CarsController : ApiController
    {
        private readonly IRepository<Car> _repository;
        public CarsController()
        {
            _repository = new Repository<Car>();
        }
        // GET api/cars
        public IEnumerable<Car> Get()
        {
            return _repository.GetAll();
        }

        // GET api/cars/{id}
        public Car Get(int id)
        {
            var result = _repository.Get(id);
            return result?.Id != 0 ? result : null;
        }

        // POST api/cars
        public bool Post([FromBody]Car car)
        {
            return _repository.Insert(car);
        }

        // PUT api/cars/{id}
        public bool Put(int id,[FromBody]Car car)
        {
            return _repository.Update(car);
        }

        // DELETE api/cars/{id}
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        [HttpGet]
        [Route("api/cars/attributes")]
        public IEnumerable<CarAttribute> Attributes()
        {
            return SortAttributes((new Repository<CarType>()).GetAll());
        }

        private static IEnumerable<CarAttribute> SortAttributes(IEnumerable<CarType> carTypes)
        {
            var result = new List<CarAttribute>();
            foreach (var carModel in carTypes)
            {
                var mark = result.FirstOrDefault(x => x.MarkId == carModel.MarkId);
                if (mark is null)
                {
                    mark = new CarAttribute
                    {
                        MarkName = carModel.MarkName,
                        MarkId = carModel.MarkId,
                        Models = new List<CarType> { carModel }
                    };
                    result.Add(mark);
                }
                else
                {
                    mark.Models.Add(carModel);
                }
            }
            return result;
        }
    }
}
