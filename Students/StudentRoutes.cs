using System;
using ApiCrud.Data;
using ApiCrud.Students.Services;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Students
{

	public static class StudentRoutes
	{
		public static void AddStudentsRoute(this WebApplication app)
		{
			app.MapGet("students", async (StudentServices service) => Results.Ok(await service.GetAllStudentsAsync()));

			app.MapGet("students/{name}", async (string name, StudentServices service) => Results.Ok(await service.GetStudentByNameAsync(name)));

			app.MapPost("students", async (AddStudentRequest request, StudentServices service) => Results.Ok(await service.AddStudentAsync(request)));

			app.MapPut("students", async (UpdateStudentRequest request, StudentServices service) =>
			{
				var res = await service.UpdateStudentAsync(request);

				return res != null ? Results.Ok(res) : Results.NotFound();

			});

			app.MapDelete("students/{id}", async (Guid id, StudentServices service) => Results.Ok(await service.DeleteStudentByIdAsync(id)));
		}
	}

}