## Delete 
1. General Steps:
```
var object = firstOrDefault(id);
_context.table.Remove(object); 
saveChanges();
```

2. Example:
```
[HttpDelete]
[Route("{id}")]
public IActionResult Delete([FromRoute] int id){
    var stockModel = _context.Stocks.FirstOrDefault(x => x.Id == id);
    
    if(stockModel == null){
        return NotFound();
    }

    _context.Stocks.Remove(stockModel);
    _context.SaveChanges();

    return NoContent(); //No content is an indicator of a successful delete

}
```