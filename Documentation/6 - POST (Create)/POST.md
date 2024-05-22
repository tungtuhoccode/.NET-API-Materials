## POST (CREATE) method
1. ```_context.Stocks.Add(payload);```
- This line of code does not save the data to the database, instead, it will only keep track of the changes

2. ```_context.SaveChanges();```
- This will save the changes into the actual database

## Example

```csharp

[HttpPost]

public IActionResult Create([FromBody] CreateStockRequestDto stockDto){ 
    var stockModel = stockDto.ToStockFromCreateDTO();
    _context.Stocks.Add(stockModel);
    _context.SaveChanges();
    return CreatedAtAction(nameof(GetById), new {id = stockModel.Id}, stockModel.ToStockDto());
}

```

## Breakdown of ```CreatedAtAction(nameof(GetById), new {id = stockModel.Id}, stockModel.ToStockDto());```
public virtual CreatedAtActionResult CreatedAtAction(string? actionName, object? routeValues, [ActionResultObjectValue] object? value);

1.	ActionName: The name of the action method to which the client can make a GET request to retrieve the newly created resource.

2.	RouteValues: An anonymous object containing the route parameters needed to generate the URL for the newly created resource.

3.	Value: The newly created resource to be included in the response body.

## Similar method to ```CreatedAtAction()```
In ASP.NET Core, there are several methods similar to `CreatedAtAction` that are used to return HTTP responses with specific status codes and additional information. Here are some of them:

### 1. `Created()`
- **Usage**: Returns a `201 Created` response with a Location header and the newly created resource.
- **Parameters**:
  - **uri**: The URI of the newly created resource.
  - **value**: The newly created resource to be included in the response body.

```csharp
return Created(new Uri($"/api/products/{product.Id}", UriKind.Relative), productReadDto);
```

### 2. `CreatedAtRoute()`
- **Usage**: Returns a `201 Created` response with a Location header pointing to a specific route.
- **Parameters**:
  - **routeName**: The name of the route.
  - **routeValues**: An anonymous object containing the route parameters.
  - **value**: The newly created resource to be included in the response body.

```csharp
return CreatedAtRoute("GetProductById", new { id = product.Id }, productReadDto);
```

### 3. `Ok()`
- **Usage**: Returns a `200 OK` response with an optional response body.
- **Parameters**:
  - **value** (optional): The response body to be included.

```csharp
return Ok(productReadDto);
```

### 4. `NoContent()`
- **Usage**: Returns a `204 No Content` response, typically used when an update or delete operation is successful but there is no content to return.
- **Parameters**: None.

```csharp
return NoContent();
```

### 5. `BadRequest()`
- **Usage**: Returns a `400 Bad Request` response, typically used when the request is invalid.
- **Parameters**:
  - **error** (optional): The error message or object to be included in the response body.

```csharp
return BadRequest("Invalid product data");
```

### 6. `NotFound()`
- **Usage**: Returns a `404 Not Found` response, typically used when a resource cannot be found.
- **Parameters**: None.

```csharp
return NotFound();
```

### 7. `Unauthorized()`
- **Usage**: Returns a `401 Unauthorized` response, typically used when authentication is required and has failed or has not yet been provided.
- **Parameters**: None.

```csharp
return Unauthorized();
```

### 8. `Forbid()`
- **Usage**: Returns a `403 Forbidden` response, typically used when the server understands the request but refuses to authorize it.
- **Parameters**: None.

```csharp
return Forbid();
```

### 9. `Conflict()`
- **Usage**: Returns a `409 Conflict` response, typically used when there is a conflict with the current state of the resource.
- **Parameters**:
  - **error** (optional): The error message or object to be included in the response body.

```csharp
return Conflict("A product with the same ID already exists");
```

### 10. `UnprocessableEntity()`
- **Usage**: Returns a `422 Unprocessable Entity` response, typically used when the server understands the content type of the request entity but was unable to process the contained instructions.
- **Parameters**:
  - **error** (optional): The error message or object to be included in the response body.

```csharp
return UnprocessableEntity("The product data is invalid");
```

These methods provide a range of ways to return standardized HTTP responses in your ASP.NET Core applications, helping to ensure that your API follows RESTful conventions and provides clear and consistent feedback to clients.