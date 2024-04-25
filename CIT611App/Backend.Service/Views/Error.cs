namespace Backend.Service.Common.Views
{
    public class Error
    {
        public Error(string code, string description)
        {
            Code = code;
            Description = description;
        }
        public string Code { get; set; }
        public string Description { get; set; }
        public static Error None => new Error(string.Empty, string.Empty);
    }
}
