public static class DbInitializer
{
    public static void Initialize(NewContainerDataContext context)
    {
        // Ensure the database is created
        context.Database.EnsureCreated();

        // Check if there are any existing records
        if (context.Companies.Any() || context.ServiceRequests.Any())
        {
            return; // Database has been seeded
        }

        // Seed initial data
        var company1 = new Company
        {
            CompanyName = "Company 1",
            ContactPersonName = "John Doe",
            ContactPersonEmail = "john.doe@example.com"
        };

        var company2 = new Company
        {
            CompanyName = "Company 2",
            ContactPersonName = "Jane Smith",
            ContactPersonEmail = "jane.smith@example.com"
        };

        context.Companies.AddRange(company1, company2);
        context.SaveChanges();

        var serviceRequest1 = new ServiceRequest
        {
            CompanyId = company1.CompanyId,
            ServicesNeeded = "Service A",
            Duration = 2,
            TimeLimit = DateTime.Now.AddDays(7)
        };

        var serviceRequest2 = new ServiceRequest
        {
            CompanyId = company2.CompanyId,
            ServicesNeeded = "Service B",
            Duration = 3,
            TimeLimit = DateTime.Now.AddDays(14)
        };

        context.ServiceRequests.AddRange(serviceRequest1, serviceRequest2);
        context.SaveChanges();
    }
}