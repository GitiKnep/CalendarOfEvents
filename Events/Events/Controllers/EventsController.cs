using Events;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/GitiDateEvent")]
public class EventsController : ControllerBase
{
    private static List<Event> events = new List<Event> { new Event { Start = new DateOnly(2023, 9, 17) }, new Event { Start = new DateOnly(2023, 9, 15) }, new Event { Start = new DateOnly(2023, 9, 13) } };
   
    [HttpGet]
    public IEnumerable<Event> Get()
    {
        return events;
    }

    [HttpPost]
    public void Post(Event eve)
    {
        events.Add(eve);
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Event even)
    {
        var eve2 = events.Find(e => e.Id == id);
        eve2.Id = even.Id;
        eve2.Title = even.Title;
        eve2.Start = even.Start;
        eve2.End = even.End;
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        var eve3 = events.Find(e => e.Id == id);
        events.Remove(eve3);
    }
}
