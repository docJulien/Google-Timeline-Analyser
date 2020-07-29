
using System.Collections.Generic;
using System.Linq;
using Kendo.Mvc;

namespace APS.Extensions
{
    public static class Extensions
    {
        public static List<FilterDescriptor> ToFilterDescriptor(this IList<IFilterDescriptor> filters)
        {
            var result = new List<FilterDescriptor>();
            if (filters.Any())
            {
                foreach (var filter in filters)
                {
                    var descriptor = filter as FilterDescriptor;
                    if (descriptor != null)
                    {
                        result.Add(descriptor);
                    }
                    else
                    {
                        var compositeFilterDescriptor = filter as CompositeFilterDescriptor;
                        if (compositeFilterDescriptor != null)
                        {
                            result.AddRange(compositeFilterDescriptor.FilterDescriptors.ToFilterDescriptor());
                        }
                    }
                }
            }
            return result;
        }
    }
}