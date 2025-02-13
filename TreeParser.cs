using Newtonsoft.Json.Linq;

namespace BlazorApp_Treeview
{
    public static class TreeParser
    {
        public static List<TreeNode> ParseJsonToTree(JToken token)
        {
            var nodes = new List<TreeNode>();

            if (token is JObject obj)
            {
                foreach (var property in obj.Properties())
                {
                    var node = new TreeNode
                    {
                        Key = property.Name,
                        Children = ParseJsonToTree(property.Value)
                    };
                    nodes.Add(node);
                }
            }
            else if (token is JArray array)
            {
                foreach (var item in array)
                {
                    var node = new TreeNode
                    {
                        Key = item["t_name"]?.ToString(),
                        Id = item["t_id"]?.ToObject<int>()
                    };
                    nodes.Add(node);
                }
            }

            return nodes;
        }
    }


    public class TreeNode
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public int? Id { get; set; }
        public List<TreeNode> Children { get; set; } = new List<TreeNode>();
        public bool IsVisible { get; set; } = true;
    }
}
