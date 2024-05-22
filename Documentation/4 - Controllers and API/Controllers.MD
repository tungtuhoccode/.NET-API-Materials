# List vs Detail
List is a collection of data such as a list of stock
Detail about a stock 

# IActionResult
- This is an interface for Action Results
- Common implementation: 
    •	Ok(): Returns a 200 OK response with optional data.
    •	NotFound(): Returns a 404 Not Found response.
    •	BadRequest(): Returns a 400 Bad Request response.
    •	Created(): Returns a 201 Created response.
    •	NoContent(): Returns a 204 No Content response.
    •	File(): Returns a file to be downloaded by the client.
    •	Redirect(): Returns a redirect response to a specified URL.
    •	Forbid(): Returns a 403 Forbidden response.
    •	Unauthorized(): Returns a 401 Unauthorized response.

- Coding example: 
An Api endpoint that return all 
```
     [HttpGet("{id}")] 
    public IActionResult GetById([FromRoute] int id){
        var stock = _context.Stocks.Find(id);

        if(stock == null){
            return NotFound(); //This is one form of IActionResult
        }

        return Ok(stock); 
    }
```

Steps in the Example
For example, a request to http://yourdomain/api/stock/5 would match this route, with 5 being the value for id.
	
    1.	Route Definition:
	•	[HttpGet("{id}")] specifies that this action handles GET requests to api/stock/{id}, where {id} is a route parameter.

	2.	Parameter Binding:
	•	[FromRoute] int id explicitly tells the framework to take the value of id from the route data.

	3.	Processing the Request:
	•	The value of id from the route (e.g., 5 from api/stock/5) is used in the method.
	•	var stock = _context.Stocks.Find(id); searches for a stock item with the specified id in the database.
	•	If the stock item is found, it is returned with a 200 OK response.
	•	If the stock item is not found, a 404 Not Found response is returned.
 
# Alternative Binding Sources
	•	[FromQuery]: Binds a parameter from the query string.
	•	[FromBody]: Binds a parameter from the request body.
	•	[FromForm]: Binds a parameter from form data in a POST request.
	•	[FromHeader]: Binds a parameter from the request headers.
	•	[FromServices]: Binds a parameter from the request’s dependency injection container.

# To be able to use our newly created Controller, we also have to add it to program.cs
