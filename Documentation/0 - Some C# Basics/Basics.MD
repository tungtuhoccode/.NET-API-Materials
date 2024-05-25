# Extension method in C#
- When you want to add methods to existing types
- Extension methods are special kind of static method
- They must exist in a static class

## FirstOrDefault() vs Find() 
Find in EF Core will look first at tracked entities so there is a chance (depending on your EF context management) that this will NOT call the database. It can be both good and bad.

