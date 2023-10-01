using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;

namespace STDComponents.Basics.Dropdown
{
    public partial class STDDropdown<TValue, TModel> : ComponentBase
    {
        [Parameter]
        public TValue Value
        {
            get
            {
                return fieldValue;
            }
            set
            {
                if (fieldValue == null || fieldValue?.Equals(value) == false)
                {
                    fieldValue = value;
                    if (ValueChanged.HasDelegate)
                    {
                        ValueChanged.InvokeAsync(fieldValue);
                    }
                }
            }
        }

        [Parameter]
        public TModel Model { get; set; }

        [Parameter]
        public Expression<Func<TValue>> ValueExpression { get; set; }

        [Parameter]
        public Expression<Func<TModel, TValue>> ValuePropertyExpression { get; set; }

        [Parameter]
        public Expression<Func<TModel, string>> DisplayExpression { get; set; }

        [Parameter]
        public IEnumerable<TModel> Options { get; set; } = Enumerable.Empty<TModel>();

        [Parameter]
        public string DefaultOptionText { get; set; } = "---";

        [Parameter]
        public EventCallback<TValue> ValueChanged { get; set; }

        private TValue fieldValue;
    }
}
