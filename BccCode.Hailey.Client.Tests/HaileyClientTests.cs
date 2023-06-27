using Microsoft.Extensions.Configuration;

namespace BccCode.Hailey.Client.Tests
{
    public class HaileyClientTests
    {

        protected IHaileyClient _client;

        public HaileyClientTests()
        {
            var config = new ConfigurationBuilder().AddUserSecrets(typeof(HaileyClientTests).Assembly).Build();
            string apiKey = config.GetValue<string>("Api_Key")!;

            _client = new HaileyClient(new HaileyClientOptions
            {
                ApiKey = apiKey
            });
        }


        [Fact]
        public async Task Employee_GetById_ReturnsEmployeee()
        {
            // Assemble -- setup test rig
            var employeeIdList = new List<Guid>();
            var resultlist = default(List<EmployeeListItem>);
            var result = default(Employee);
            var employeewithtimeoff = default(List<EmployeeWithTimeOffs>);

            // Act -- do the thing you want to test
            try
            {
                resultlist = await _client.EmployeesAllAsync();

                result = await _client.EmployeesAsync(resultlist[new Random().Next(0,resultlist.Count)].EmployeeId);

                var timeoff = await _client.TimeOffAsync();

                employeewithtimeoff = timeoff.Employees;

                foreach (var employee in employeewithtimeoff)
                {
                    employeeIdList.Add(employee.EmployeeId);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"Api call failed with the following message: {ex.Message}");
            }

            // Assert -- check that it worked as expected
            Assert.NotNull(result);
            Assert.NotEmpty(employeewithtimeoff);

        }
    }
}