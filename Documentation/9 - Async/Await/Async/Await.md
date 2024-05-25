## Async/Await
Async make the code faster since it allows server to do other tasks while waiting for a request to another server (which ussually takes some time) to be fulfil, before completing the task.

```
public async Task<Stock> GetStock{
    Console.WriteLine("Running");
    var stock = await getStockFromDB();
    Console.WriteLine("Running");
    return stock;
}
```

The word async does not actually doing anything, it's just there to tell us that the function is async.
