using System;
using System.Collections.Generic;
using System.Text;

namespace VWE.My.Data.Models
{
	/// <summary>
	/// class that keeps the paging parameters within boundaries
	/// </summary>
	public class VehiclePagingParams
	{
		const int maxPageSize = 10;

		private int _pageSize = 1;
		private int _pageNumber = 1;

		public int PageSize
		{
			get
			{
				return _pageSize;
			}
			set
			{
				//pagesize cannot be smaller than 0
				//pageSize cannot be bigger than max page size.
				_pageSize = (value <= 0) ? 1 : value;
				_pageSize = (_pageSize > maxPageSize) ? maxPageSize : _pageSize;
			}
		}
		public int PageNumber
		{
			get
			{
				return _pageNumber;
			}
			set
			{
				//pageNumber cannot be lower than 0. If 0 than the page number will be 1.
				//So, no errors will occur.
				_pageNumber = (value <= 0) ? 1 : value;
			}
		}
	}
}
