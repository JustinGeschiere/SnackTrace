using System.Collections.Generic;

namespace SnackTrace.Web.Areas.Admin.Models.Menus
{
	public class IndexRenderModel
	{
		private IndexItemModel _template;

		public IndexItemModel Template
		{
			get 
			{ 
				if (_template == null)
				{
					_template = new IndexItemModel();
				}
				return _template; 
			}
			set { _template = value; }
		}

		public IEnumerable<IndexItemModel> Items { get; }

		public IndexRenderModel(IEnumerable<IndexItemModel> items)
		{
			Items = items;
		}
	}
}
