using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
public class FlightController : Controller
{
    private readonly DatabaseHelper _db;
    public FlightController(IConfiguration configuration)
    {
        _db = new DatabaseHelper(configuration);
    }
    public async Task<IActionResult> Index()
    {
        var model = new SearchViewModel
        {
            SourceList = new SelectList(await _db.GetSourcesAsync()),
            DestinationList = new SelectList(await _db.GetDestinationsAsync())
        };

        return View(model);
    }
    [HttpPost]
    public async Task<IActionResult> SearchFlights(SearchViewModel model)
    {
        var results = await _db.SearchFlightsAsync(
            model.Source,
            model.Destination,
            model.NumberOfPersons
        );

        return View("Results", results);
    }
    [HttpPost]
    public async Task<IActionResult> SearchFlightsWithHotels(SearchViewModel model)
    {
        var results = await _db.SearchFlightsWithHotelsAsync(
            model.Source,
            model.Destination,
            model.NumberOfPersons
        );
        return View("Results", results);
    }
}