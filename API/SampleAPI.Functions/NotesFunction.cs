namespace SampleAPI.Functions
{
    public class NotesFunction
    {
        private readonly INoteService _noteService;
        
        public NotesFunction(INoteService noteService)
        {
            _noteService = noteService;
        }

        [FunctionName("NotesFunction")]
        [OpenApiOperation(operationId: "Run", tags: new[] { "name" })]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        //[OpenApiParameter(name: "name", In = ParameterLocation.Query, Required = true, Type = typeof(string), Description = "The **Name** parameter")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
        public async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req, ILogger log)
        {
            log.LogInformation("NotesFunction processed a request.");

            //var notes = await _noteService.ReadAll();
            var notes = await _noteService.ReadPaged(1, 5);
            
            var responseMessage = JsonConvert.SerializeObject(notes, Formatting.Indented);
            
            return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(responseMessage, Encoding.UTF8, "application/json")
            });
        }
    }
}

