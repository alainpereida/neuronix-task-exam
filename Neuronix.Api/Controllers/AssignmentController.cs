using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Neuronix.Api.Dtos;
using Neuronix.Api.Validations;
using Neuronix.Core.IServices;
using Neuronix.Core.Models;

namespace Neuronix.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssignmentController : ControllerBase
{
    private readonly ILogger<AssignmentController> _logger;
    private readonly IAssignmentService _assignmentService;
    private readonly IMapper _mapper;

    public AssignmentController(ILogger<AssignmentController> logger, IAssignmentService assignmentService, IMapper mapper)
    {
        _logger = logger;
        _assignmentService = assignmentService;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Buscar las tareas del usuario
    /// </summary>
    [HttpGet("")]
    public async Task<ActionResult<IEnumerable<Assignment>>> GetAssignmentsForUser()
    {
        BaseErrorResponse result = new BaseErrorResponse();
        List<string> err = new List<string>();
        var idUser = AuthorizationValidator.GetIdUser(User.Claims.ToList());

        try
        {
            var assigments = await _assignmentService.GetAssignmentByUserId(idUser);
            
            return Ok(assigments);
        }
        catch (Exception ex)
        {
            err.Add("Error información de gigya -> " + ex.Message);
            result.errors = err;
            return BadRequest(result);
        }
    }
    
    /// <summary>
    /// Crear una nueva tarea para el usuario
    /// </summary>
    /// <param name="assignmentCreateDto"></param>
    /// <returns></returns>
    [HttpPost("")]
    public async Task<ActionResult<Assignment>> CreateeAssignmentStatus([FromBody] AssignmentCreateDto assignmentCreateDto)
    {
        BaseErrorResponse result = new BaseErrorResponse();
        List<string> err = new List<string>();
        var idUser = AuthorizationValidator.GetIdUser(User.Claims.ToList());

        try
        {
            var assignmentToBeCreated = _mapper.Map<AssignmentCreateDto, Assignment>(assignmentCreateDto);
            assignmentToBeCreated.UserId = idUser;
            
            var assignment = await _assignmentService.CreateAssignment(assignmentToBeCreated);
            
            return Ok(assignment);
        }
        catch (Exception ex)
        {
            err.Add("Error información de gigya -> " + ex.Message);
            result.errors = err;
            return BadRequest(result);
        }
    }
    
    /// <summary>
    /// Actualizar la tarea en completada o no completada.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="valueStatus"></param>
    /// <returns></returns>
    [HttpPatch("{id}/ChangeStatus")]
    public async Task<ActionResult<IEnumerable<Assignment>>> UpdateAssignmentStatus(int id, [FromQuery] bool isCompleted)
    {
        BaseErrorResponse result = new BaseErrorResponse();
        List<string> err = new List<string>();
        var idUser = AuthorizationValidator.GetIdUser(User.Claims.ToList());

        try
        {
            var assigmentsToBeUpdated = await _assignmentService.GetAssignmentById(id);
            
            if (assigmentsToBeUpdated == null)
            {
                //If doesn't exist assigmnet
                err.Add("La tarea que se desea editar no existe ");
                result.errors = err;
                return BadRequest(result);
            }
            
            await _assignmentService.UpdateAssignment(assigmentsToBeUpdated, isCompleted);
            
            return Ok(assigmentsToBeUpdated);
        }
        catch (Exception ex)
        {
            err.Add("Error información de gigya -> " + ex.Message);
            result.errors = err;
            return BadRequest(result);
        }
    }
    
    /// <summary>
    /// Eliminar una tarea.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> UpdateAssignmentStatus(int id)
    {
        BaseErrorResponse result = new BaseErrorResponse();
        List<string> err = new List<string>();
        var idUser = AuthorizationValidator.GetIdUser(User.Claims.ToList());

        try
        {
            var assigmentsToBeDeleted = await _assignmentService.GetAssignmentById(id);
            
            if (assigmentsToBeDeleted == null)
            {
                //If doesn't exist assigmnet
                err.Add("La tarea que se desea elimianr no existe ");
                result.errors = err;
                return BadRequest(result);
            }
            
            await _assignmentService.DeleteAssignment(assigmentsToBeDeleted);
            
            return NoContent();
        }
        catch (Exception ex)
        {
            err.Add("Error información de gigya -> " + ex.Message);
            result.errors = err;
            return BadRequest(result);
        }
    }
}