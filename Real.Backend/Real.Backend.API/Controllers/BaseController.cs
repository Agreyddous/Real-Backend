using FluentValidator;
using Microsoft.AspNetCore.Mvc;
using Real.Backend.Infra.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real.Backend.API.Controllers
{
    public class BaseController
    {
		private readonly IUow _uow;
		public BaseController(IUow uow) => _uow = uow;

		public async Task<IActionResult> Response(object result, IEnumerable<Notification> notifications)
		{
			IActionResult response = BadRequest(new { success = false, errors = notifications });

			if (!notifications.Any())
			{
				try
				{
					_uow.Commit();
					response = Ok(new { success = true, data = result });
				}
				catch (Exception)
				{
					response = BadRequest(new { success = false, errors = new[] { "Server Error" } });
				}
			}

			return response;
		}

		public async Task<IActionResult> Response(object result)
		{
			IActionResult response = BadRequest(new { success = false, errors = new[] { "Not Found" } });

			if (result != null)
			{
				try
				{
					_uow.Commit();
					response = Ok(new { success = true, data = result });
				}
				catch (Exception)
				{
					response = BadRequest(new { success = false, errors = new[] { "Server Error" } });
				}
			}

			return response;
		}
	}
}