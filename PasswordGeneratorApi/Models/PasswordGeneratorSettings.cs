namespace PasswordGeneratorApi.Models
{
    public class PasswordGeneratorSettings
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string UserId { get; set; } = "";

        public int Length { get; set; } = 16;

        public bool UseUppercase { get; set; } = true;

        public bool UseLowercase { get; set; } = true;

        public bool UseDigits { get; set; } = true;

        public bool UseSpecialChars { get; set; } = true;

        public bool ExcludeSimilarChars { get; set; } = false;
    }
}
