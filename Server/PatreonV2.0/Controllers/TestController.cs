using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace PatreonV2._0.Controllers
{
  public class User
  {
    public string Name;
    public int Age;
  }

  [Route("api/[controller]")]
  [ApiController]
  public class TestController : ControllerBase
  {

    private List<User> users = new List<User>
    {
      new User{Name = "Timur4ik", Age = 19 },
      new User{Name = "Mishaa", Age = 18}
    };
    private Dictionary<int, string> _test = new Dictionary<int, string>();
    private List<string> _test2 = new List<string>();
    // GET: api/Test
    [HttpGet]
    public IEnumerable<string> Get()
    {
      var values = _test.Values.ToList();
      values.AddRange(_test2);
      return values;
    }

    private List<User> GetUsers()
    {
      return users;
    }

    // GET: api/Test/5
    [HttpGet("{id}")]
    public string  Get(int id)
    {
      var users = GetUsers();
      return JsonConvert.SerializeObject(users);
    }

    // POST: api/Test
    [HttpPost]
    public void Post([FromBody] object value)
    {
      _test2.Add(value?.ToString());
    }

    // PUT: api/Test/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
      _test[id] = value;
    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      if (_test.ContainsKey(id))
        _test.Remove(id);
    }
  }
}