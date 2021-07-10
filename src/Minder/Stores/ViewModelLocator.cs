using Minder.ViewModels.Base;
using System.Collections.Generic;

namespace Minder.Stores
{
    public class ViewModelLocator 
    {
        private readonly IDictionary<ViewType, TitleViewModel> _viewmodels;

        public ViewModelLocator(IDictionary<ViewType, TitleViewModel> viewModels)
        {
            _viewmodels = viewModels ?? throw new System.ArgumentNullException(nameof(viewModels));
        }

        public TitleViewModel this[ViewType viewType]
        {
            get
            {
                if (_viewmodels.ContainsKey(viewType))
                    return _viewmodels[viewType];

                return null;
            }
        }
    }
}
