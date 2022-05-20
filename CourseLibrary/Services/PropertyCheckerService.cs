using System.Reflection;

namespace CourseLibrary.API.Services
{
    public class PropertyCheckerService : IPropertyCheckerService
    {
        public bool TypeHasProperties<T>(string fields)
        {
            if (string.IsNullOrWhiteSpace(fields))
            {
                return true;
            }

            var fieldsAfterSplit = fields.Split(',');

            foreach (var field in fieldsAfterSplit)
            {
                var propertyName = field.Trim();

                //use Reflection to see if the prop can be fount on T
                var propertyInfo = typeof(T)
                    .GetProperty(propertyName,
                    BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                //it can't be found, return false
                if (propertyInfo == null)
                {
                    return false;
                }

            }
            //all checks out, return true
            return true;
        }
    }
}
