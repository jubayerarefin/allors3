namespace Autotest.Angular
{
    using Newtonsoft.Json.Linq;

    public class Provider
    {
        public Project Project { get; set; }

        public JToken Json { get; set; }

        public Reference TokenIdentifier { get; set; }

        public string TokenValue { get; set; }

        public Reference UseClass{ get; set; }

        public JToken UseExisting{ get; set; }

        public Reference UseFactory{ get; set; }

        public bool Multi { get; set; }

        public void BaseLoad()
        {
        }
    }
}