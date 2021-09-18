namespace Framework.Core.Model
{
    public static class CommonErrors
    {
        public static Error NOT_FOUND = new Error(404, "NOT_FOUND");
        public static Error ALREADY_EXIST = new Error(400, "ALREADY_EXIST");
        public static Error Required(string field)
        {
            return new Error(403, $"REQUIRED-{field}");
        }
    }
    public class Error
    {
        public Error(int code, string error)
        {
            Code = code;
            Message = error;
        }

        public int Code { get; set; }
        public string Message { get; set; }
    }
}
