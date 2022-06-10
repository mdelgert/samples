namespace SampleAPI.Shared.Helpers
{
    public static class RandomJsonHelper
    {
        private const string BasePath = @"..\..\..\..\Files\SampleJsonData\";
        private const int RecordCount = 10;
        
        public static void CreateCustomers()
        {
            dynamic output = new List<dynamic>();
            var randomizerFirstName = RandomizerFactory.GetRandomizer(new FieldOptionsFirstName());
            var randomizerLastName = RandomizerFactory.GetRandomizer(new FieldOptionsLastName());
            
            for (var i = 0; i < RecordCount; i++)
            {
                dynamic row = new ExpandoObject();
                var firstname = randomizerFirstName.Generate();
                var lastname = randomizerLastName.Generate();
                if (firstname != null) row.fname = firstname;
                if (lastname != null) row.lname = lastname;
                output.Add(row);
            }
            string json = JsonConvert.SerializeObject(output, Formatting.Indented);
            File.WriteAllTextAsync($"{BasePath}\\Customers.json", json);
        }
    }
}
